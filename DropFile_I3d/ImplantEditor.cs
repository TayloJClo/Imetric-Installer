using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ImplantPositionEditor
{
    public partial class ImplantEditor : Form
    {
        private string loadedFilePath = "";
        private Dictionary<string, (string Library, string Type, string Subtype)> templateData = new Dictionary<string, (string, string, string)>();
        private List<string> loadedFilePaths = new List<string>(); // Store multiple files
        

        public ImplantEditor()
        {
            InitializeComponent();
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog

            {
                Filter = "Implant Position Files (*.implantPosition)|*.implantPosition|All Files (*.*)|*.*",
                Multiselect = true // Allow multiple file selection
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadedFilePaths = openFileDialog.FileNames.ToList(); // Store selected file paths

                lstFiles.Items.Clear(); // Clear previous list
                lstFiles.Items.AddRange(loadedFilePaths.Select(Path.GetFileName).ToArray()); // Show filenames

                if (loadedFilePaths.Count > 0)
                {
                    lstFiles.SelectedIndex = 0; // Select first file by default
                }
            }
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select your ICamBody Library CSV file";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"C:\\I3D_Systems\\";
                

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedFilePath = openFileDialog.FileName;
                    LoadCSV(loadedFilePath);
                }
                else
                {
                    MessageBox.Show("No local CSV file selected. The form will now close.");
                    this.Close();
                    return;
                }
            }

            
        }

        private void LoadCSV(string filePath)
        {
            label4.Text = "CSV Loaded: " + Path.GetFileName(filePath);
            if (!File.Exists(filePath))
            {
                MessageBox.Show("CSV file not found! Please upload a valid CSV file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            templateData.Clear();
            cmbTemplates.Items.Clear();

            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line;
                    bool firstLine = true;
                    int rowIndex = 1;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (firstLine)
                        {
                            firstLine = false; // Skip the header row
                            continue;
                        }

                        // CSV is tab-separated (\t)
                        string[] parts = line.Split('\t');

                        if (parts.Length >= 10) // Ensure required columns exist (B, F, I, J)
                        {
                            string templateName = parts[1].Trim(); // Column B
                            string library = parts[5].Trim();      // Column F
                            string type = parts[8].Trim();         // Column I
                            string subtype = parts[9].Trim();      // Column J (optional)

                            // Check if the template name is "ICamRef" and skip it
                            if (!string.IsNullOrWhiteSpace(templateName) && !string.Equals(templateName, "ICamRef", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!templateData.ContainsKey(templateName))
                                {
                                    templateData[templateName] = (library, type, subtype);
                                    cmbTemplates.Items.Add(templateName);
                                    Console.WriteLine($"Loaded: {templateName} → Library: {library}, Type: {type}, Subtype: {subtype}");
                                }
                            }

                        }
                    }
                }
                // Sort dropdown alphabetically
                var sortedItems = cmbTemplates.Items.Cast<string>().OrderBy(item => item).ToList();
                cmbTemplates.Items.Clear();
                cmbTemplates.Items.AddRange(sortedItems.ToArray());

                if (cmbTemplates.Items.Count > 0)
                {
                    cmbTemplates.SelectedIndex = 0;
                    MessageBox.Show("CSV loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("No templates found in CSV!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTemplates.SelectedItem != null && loadedFilePaths.Count > 0)
            {
                string selectedTemplate = cmbTemplates.SelectedItem.ToString();

                if (templateData.ContainsKey(selectedTemplate))
                {
                    string newLibrary = templateData[selectedTemplate].Library;
                    string newType = templateData[selectedTemplate].Type;
                    string newSubtype = templateData[selectedTemplate].Subtype;

                    Console.WriteLine($"Applying Template: {selectedTemplate} → Library: {newLibrary}, Type: {newType}, Subtype: {newSubtype}");

                    // Apply the template to all loaded implant position files
                    for (int i = 0; i < loadedFilePaths.Count; i++)
                    {
                        ApplyTemplate(newLibrary, newType, newSubtype, loadedFilePaths[i]);
                    }

                    // Update the displayed content (show the first file's updated content)
                    txtFileContent.Text = File.ReadAllText(loadedFilePaths[0]);
                }
            }
        }



        private void ApplyTemplate(string newLibrary, string newType, string newSubtype, string filePath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath); // Load from file

                XmlNode libraryNode = xmlDoc.SelectSingleNode("//Library");
                XmlNode typeNode = xmlDoc.SelectSingleNode("//Type");
                XmlNode subtypeNode = xmlDoc.SelectSingleNode("//Subtype");

                if (libraryNode == null || typeNode == null)
                {
                    MessageBox.Show($"Error: Library or Type node not found in {Path.GetFileName(filePath)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                libraryNode.InnerText = newLibrary;
                typeNode.InnerText = newType;

                // Handle Subtype (create it if missing, remove if empty)
                if (!string.IsNullOrWhiteSpace(newSubtype))
                {
                    if (subtypeNode == null)
                    {
                        subtypeNode = xmlDoc.CreateElement("Subtype");
                        typeNode.ParentNode.InsertAfter(subtypeNode, typeNode); // Insert after <Type>
                    }
                    subtypeNode.InnerText = newSubtype;
                }
                else
                {
                    // Remove <Subtype> if it exists but should be empty
                    subtypeNode?.ParentNode.RemoveChild(subtypeNode);
                }

                // Save updated XML back to file
                xmlDoc.Save(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error modifying XML for {Path.GetFileName(filePath)}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void btnSave_Click(object sender, EventArgs e)
        {
            if (loadedFilePaths.Count == 0)
            {
                MessageBox.Show("No files loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                foreach (string filePath in loadedFilePaths)
                {
                    File.WriteAllText(filePath, File.ReadAllText(filePath)); // Save all files
                }

                MessageBox.Show("All files saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving files: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex >= 0)
            {
                string selectedFilePath = loadedFilePaths[lstFiles.SelectedIndex];
                txtFileContent.Text = File.ReadAllText(selectedFilePath); // Load content into text box
            }
        }

        private void txtFileContent_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("txtFileContent Updated!");
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (loadedFilePaths.Count == 0)
            {
                MessageBox.Show("No files loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save modified files";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;

                    try
                    {
                        foreach (string originalFilePath in loadedFilePaths)
                        {
                            string fileName = Path.GetFileName(originalFilePath); // Get the original file name
                            string newFilePath = Path.Combine(selectedFolder, fileName); // New location

                            File.WriteAllText(newFilePath, File.ReadAllText(originalFilePath)); // Save the modified content
                        }

                        MessageBox.Show("All files saved successfully in the new location!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving files: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.All(f => f.EndsWith(".implantPosition") || f.EndsWith(".csv") || f.EndsWith(".lnk")))
                {
                    e.Effect = DragDropEffects.Copy; // Allow drop
                }
                else
                {
                    e.Effect = DragDropEffects.None; // Deny drop if not supported
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (file.EndsWith(".implantPosition"))
                {
                    LoadImplantPositionFile(file); // Properly load implant files
                }
                else if (file.EndsWith(".csv"))
                {
                    LoadCSV(file); // Load CSV templates
                }
            }

            if (loadedFilePaths.Count > 0)
            {
                lstFiles.SelectedIndex = 0; // Automatically select the first file
            }
        }

        private void LoadImplantPositionFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!loadedFilePaths.Contains(filePath)) // Avoid duplicate entries
            {
                loadedFilePaths.Add(filePath);
                lstFiles.Items.Add(Path.GetFileName(filePath)); // Add filename to the list
            }

            // Display content of the first file
            if (loadedFilePaths.Count == 1)
            {
                txtFileContent.Text = File.ReadAllText(filePath);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            bool isImplantFileLoaded = loadedFilePaths.Count > 0;
            bool isCSVLoaded = templateData.Count > 0;

            if (isImplantFileLoaded && isCSVLoaded)
            {
                label3.Text = "Status: All required files are loaded.";
            }
            else if (!isImplantFileLoaded && !isCSVLoaded)
            {
                label3.Text = "Status: No files loaded. Please load an Implant Position file and a CSV file.";
            }
            else if (!isImplantFileLoaded)
            {
                label3.Text = "Status: Implant Position file is missing.";
            }
            else if (!isCSVLoaded)
            {
                label3.Text = "Status: CSV file is missing.";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label4.Text) || label4.Text.StartsWith("CSV:"))
            {
                label4.Text = "No CSV file loaded.";
            }
            else
            {
                MessageBox.Show($"Currently loaded CSV: {label4.Text.Replace("CSV Loaded: ", "")}",
                                "CSV Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
