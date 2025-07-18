using AutoUpdaterDotNET;
using ICam4DSetup;
using ImplantPositionEditor;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace DropFile_I3d
{
    public partial class Form1 : Form
    {
        private const string V = "runas";
        private string iCamSerialNo = "";
        private IniFile iniFile;

        private class FolderItem
        {
            public string DisplayName { get; init; } = "";
            public string Path { get; init; } = "";
            public override string ToString() => DisplayName;
        }

        public string SelectedCsvDirectory => (comboBoxCsvDir.SelectedItem as FolderItem)?.Path ?? string.Empty;


        public Form1()
        {
            InitializeComponent();
            comboBoxCsvDir.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCsvDir.SelectedIndexChanged += ComboBoxCsvDir_SelectedIndexChanged;
            iniFile = new IniFile(Path.Combine(Application.StartupPath, "config.ini"));
            labelVersion.Text = "V" + Assembly.GetExecutingAssembly()
                                     .GetName().Version?.ToString();
            PopulateCsvDirectories();
        }

        private void buttonCancel_Click(object sender, EventArgs e) => Application.Exit();

        private void LoadConfigButton_Click(object sender, EventArgs e)
        {
            string iCamSerialNo = iniFile.Read("Settings", "ICamSerialNo");
        }



        static void AddLineToCsv(string filePath, string newData)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(newData);
            }
        }

        private void buttonInstallDriver_Click(object sender, EventArgs e)
        {
            InstallHelpers.InstallBat("C:\\I3D_Software\\Drivers\\Camera Flir\\Flir_1.23.0.27_Driver\\install.bat");
            InstallHelpers.InstallInf("C:\\I3D_Software\\Drivers\\Projector Imetric4D 9\\cyusb3.inf");
        }

        private async void buttonIScan3d_Click(object sender, EventArgs e)
        {
            var popup = new OptionPopupForm();

            if (popup.ShowDialog() == DialogResult.OK)
            {
                string selected = popup.SelectedOption;

                string remoteCsvUrl = selected switch
                {
                    "Default" => "https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/main/Default.csv",
                    "Nobel" => "https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/main/Nobel.csv",
                    "Straumann" => "https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/main/Straumann.csv",
                    _ => ""
                };

                string destinationDir = "C:\\I3D_Systems\\I221301 ICamBody Library";
                string destinationCsvPath = Path.Combine(destinationDir, "ICamBody Library.csv");

                try
                {
                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    if (!string.IsNullOrWhiteSpace(remoteCsvUrl))
                    {
                        using HttpClient client = new HttpClient();
                        byte[] data = await client.GetByteArrayAsync(remoteCsvUrl);
                        await File.WriteAllBytesAsync(destinationCsvPath, data);
                        MessageBox.Show($"Downloaded {selected} CSV to: {destinationCsvPath}");
                    }
                    else
                    {
                        MessageBox.Show("No download URL available.");
                        return;
                    }

                    install("C:\\I3D_Software\\Imetric4D Software\\IScan3D Dental\\IScan3D_Dental_v9.1.113_2025-04-01_64bit.msi");

                    string exePath = "C:\\Program Files (x86)\\ICamSetup\\Manuals\\CreateShortcut.exe"; // Adjust path as needed
                    if (File.Exists(exePath))
                    {
                        System.Diagnostics.Process.Start(exePath);
                    }
                    else
                    {
                        MessageBox.Show("Could not find: " + exePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying CSV or running install: " + ex.Message);
                }
            }
        }

        private void installMsi(string msiPath)
        {
            InstallHelpers.InstallMsi(msiPath);
        }

        private void buttonInstallOffice_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "https://www.libreoffice.org/download/"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void buttonInstallZip7_Click(object sender, EventArgs e)
        {
            install("C:\\I3D_Software\\General\\7zip\\7z1900-x64.exe");
        }

        private void buttonNotePadPlus_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "https://notepad-plus-plus.org/downloads/"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void installIScanMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Will this computer be using an ICam?", "Install IScan", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                buttonInstallDriver_Click(sender, e);
            }
            buttonIScan3d_Click(sender, e);
        }

        private void otherSoftwareMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new OtherSoftwareForm();
            form.ShowDialog();
        }





        private void buttonAddComponents_Click(object sender, EventArgs e)
        {
            string csvPath = Path.Combine(SelectedCsvDirectory, "ICamBody Library.csv");
            if (!File.Exists(csvPath))
            {
                MessageBox.Show($"CSV file not found: {csvPath}");
                return;
            }

            using var form = new CsvSelectionForm(
                "https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/refs/heads/main/ICamBody%20Library%20Master%20(test).csv",
                csvPath);
            form.ShowDialog();
        }

        private void installbat(string batFilePath)
        {
            InstallHelpers.InstallBat(batFilePath);
        }

        private void installInf(string batFilePath)
        {
            InstallHelpers.InstallInf(batFilePath);
        }

        private void install(string batFilePath)
        {
            InstallHelpers.Install(batFilePath);
        }

        private void buttonEditor_Click(object sender, EventArgs e)
        {
            // If the popup should be shown
            if (!Properties.Settings.Default.HideImplantHowTo)
            {
                var howToForm = new ImplantHowTo();
                var result = howToForm.ShowDialog();

                // If the user clicked OK, check for "Don't show again"
                if (result == DialogResult.OK)
                {
                    if (howToForm.DontShowAgain)
                    {
                        Properties.Settings.Default.HideImplantHowTo = true;
                        Properties.Settings.Default.Save();
                    }

                    // Open the editor only if they confirmed
                    ImplantEditor editorForm = new ImplantEditor();
                    editorForm.ShowDialog();
                }
                // If they clicked Cancel or closed the popup, do nothing
            }
            else
            {
                // If "Don't show again" was previously checked, just open the editor
                ImplantEditor editorForm = new ImplantEditor();
                editorForm.ShowDialog();
            }
        }


        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string csvPath = Path.Combine(SelectedCsvDirectory, "ICamBody Library.csv");
            if (!File.Exists(csvPath))
            {
                MessageBox.Show($"CSV file not found: {csvPath}");
                return;
            }

            using var removeForm = new CsvRemoveForm(csvPath);
            removeForm.ShowDialog();
        }

        private void textBoxCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!UpdateHelper.IsAutoUpdateDisabled())
            {
                AutoUpdater.Start("https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/main/Version.xml");
            }
            PopulateCsvDirectories();
            groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ProcessIcamBodyFolder(dialog.SelectedPath);
            }
        }

        private void button2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Directory.Exists(files[0]))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && Directory.Exists(files[0]))
            {
                ProcessIcamBodyFolder(files[0]);
            }
        }

        private void ProcessIcamBodyFolder(string sourceFolder)
        {
            try
            {
                string baseDir = SelectedCsvDirectory;
                if (string.IsNullOrWhiteSpace(baseDir) || !Directory.Exists(baseDir))
                {
                    MessageBox.Show("No ICamBody Library selected.");
                    return;
                }

                string csvPath = Path.Combine(baseDir, "ICamBody Library.csv");
                if (!File.Exists(csvPath))
                {
                    MessageBox.Show($"CSV file not found: {csvPath}");
                    return;
                }

                string folderName = Path.GetFileName(sourceFolder.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

                // Copy folder into MU-RP
                string muRpFolder = Path.Combine(baseDir, "MU-RP", folderName);
                CopyDirectory(sourceFolder, muRpFolder);

                // Determine target directories from column F
                var csvLines = File.ReadAllLines(csvPath).ToList();
                var directories = new HashSet<string>();
                foreach (var line in csvLines.Skip(1))
                {
                    var parts = line.Split('\t');
                    if (parts.Length > 5 && !string.IsNullOrWhiteSpace(parts[5]))
                        directories.Add(parts[5].Trim());
                }

                foreach (var dir in directories)
                {
                    if (dir.Equals("ICamRef", StringComparison.OrdinalIgnoreCase) ||
                        dir.Equals("MU-RP", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string target = Path.Combine(baseDir, dir, folderName);
                    CopyDirectory(sourceFolder, target);
                }

                var header = csvLines.First();
                var dataLines = csvLines.Skip(1).ToList();
                var existing = new HashSet<string>(dataLines);
                var newLines = new List<string>();

                foreach (var line in dataLines)
                {
                    var parts = line.Split('\t');
                    if (parts.Length <= 6 || parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase))
                        continue;

                    var copy = (string[])parts.Clone();
                    copy[4] = folderName;
                    copy[6] = folderName + ".ad";
                    var newLine = string.Join('\t', copy);
                    if (!existing.Contains(newLine))
                    {
                        newLines.Add(newLine);
                        existing.Add(newLine);
                    }
                }

                dataLines.AddRange(newLines);

                var healingLines = dataLines.Where(l => l.Split('\t')[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase));
                var screwLines = dataLines.Except(healingLines);
                screwLines = screwLines.OrderBy(l => l.Split('\t')[4]).ThenBy(l => l.Split('\t')[1]);
                dataLines = screwLines.Concat(healingLines).ToList();

                File.WriteAllLines(csvPath, new[] { header }.Concat(dataLines), Encoding.UTF8);

                MessageBox.Show("ICamBodies added to library.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding ICamBodies: " + ex.Message);
            }
        }

        private void CopyDirectory(string sourceDir, string targetDir)
        {
            foreach (string dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                string targetSubDir = dir.Replace(sourceDir, targetDir);
                Directory.CreateDirectory(targetSubDir);
            }

            foreach (string fileName in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                string targetFilePath = fileName.Replace(sourceDir, targetDir);
                Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath)!);
                File.Copy(fileName, targetFilePath, true);
            }
        }

        private void PopulateCsvDirectories()
        {
            comboBoxCsvDir.Items.Clear();
            string baseDir = @"C:\\I3D_Systems";
            if (!Directory.Exists(baseDir))
                return;

            var dirs = Directory.GetDirectories(baseDir, "*", SearchOption.TopDirectoryOnly)
                .Where(d => d.Contains("ICamBody Library", StringComparison.OrdinalIgnoreCase)
                         || d.Contains("ICamBodyLibrary", StringComparison.OrdinalIgnoreCase))
                .ToArray();
            foreach (var dir in dirs)
            {
                string folderName = Path.GetFileName(dir);
                string displayName = folderName.Split(' ')[0];
                comboBoxCsvDir.Items.Add(new FolderItem { DisplayName = displayName, Path = dir });
            }

            if (comboBoxCsvDir.Items.Count > 0)
            {
                string lastPath = Properties.Settings.Default.LastCsvDir;
                int index = -1;
                if (!string.IsNullOrWhiteSpace(lastPath))
                {
                    index = comboBoxCsvDir.Items.Cast<FolderItem>().ToList()
                        .FindIndex(fi => fi.Path.Equals(lastPath, StringComparison.OrdinalIgnoreCase));
                }
                comboBoxCsvDir.SelectedIndex = index >= 0 ? index : 0;
            }
        }

        private void ComboBoxCsvDir_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (comboBoxCsvDir.SelectedItem is FolderItem item)
            {
                Properties.Settings.Default.LastCsvDir = item.Path;
                Properties.Settings.Default.Save();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void installToolsMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void createNewLibraryMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new NewLibraryForm();
            form.ShowDialog();
        }

        private void implantPositionEditorMenuItem_Click(object sender, EventArgs e)
        {
            buttonEditor_Click(sender, e);
        }

        private void hotSwapHelperMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new HotSwapHelperForm();
            form.ShowDialog();
        }

        private void troubleshootingMenuItem_Click(object sender, EventArgs e)
        {
            ShowComingSoon();
        }

        private static void ShowComingSoon()
        {
            using var form = new ComingSoonForm();
            form.ShowDialog();
        }
    }
}
