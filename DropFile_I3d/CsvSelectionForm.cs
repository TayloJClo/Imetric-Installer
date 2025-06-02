using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICam4DSetup
{
    public partial class CsvSelectionForm : Form
    {
        private string localCsvPath = @"C:\I3D_Systems\I221301 ICamBody Library\ICamBody Library.csv";
        private string filterType;
        private Dictionary<string, string> itemToLineMap = new(); // Add this field

       
        private Button buttonApply;
        private Button buttonCancel;

        public CsvSelectionForm(string dropboxUrl, string type)
        {
            InitializeComponent();
            filterType = type.ToLower();
            LoadCsvFromDropbox(dropboxUrl);
        }

        private async void LoadCsvFromDropbox(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string csvData = await client.GetStringAsync(url);
                    var lines = csvData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in lines.Skip(1)) // Skip header
                    {
                        var parts = line.Split('\t');
                        if (parts.Length < 2) continue;

                        string columnB = parts[1].Trim();

                        if (!string.IsNullOrWhiteSpace(columnB)
                            && !columnB.Equals("ICamRef", StringComparison.OrdinalIgnoreCase))
                        {
                            checkedListBoxItems.Items.Add(columnB);
                            itemToLineMap[columnB] = line; // <-- ADD THIS HERE
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load CSV: " + ex.Message);
            }
        }



        private void CsvSelectionForm_Load(object sender, EventArgs e)
        {

        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            var selectedItems = checkedListBoxItems.CheckedItems.Cast<string>().ToList();

            if (!selectedItems.Any())
            {
                MessageBox.Show("No items selected.");
                return;
            }

            try
            {
                var lines = File.Exists(localCsvPath)
                    ? File.ReadAllLines(localCsvPath).ToList()
                    : new List<string>();

                int insertIndex = lines.FindIndex(line =>
                {
                    var parts = line.Split('\t');
                    return parts.Length > 1 && parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase);
                });

                if (insertIndex == -1) insertIndex = lines.Count; // If not found, append to end

                // Build list of new lines to insert
                List<string> newLines = new();

                foreach (var item in selectedItems)
                {
                    if (itemToLineMap.TryGetValue(item, out string fullLine))
                    {
                        newLines.Add(""); // add blank
                    }
                }

                // Insert blank lines first
                lines.InsertRange(insertIndex, newLines);

                // Then populate them
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    if (itemToLineMap.TryGetValue(selectedItems[i], out string fullLine))
                    {
                        lines[insertIndex + i] = fullLine;
                    }
                }

                File.WriteAllLines(localCsvPath, lines, Encoding.UTF8);
                MessageBox.Show("Selected items inserted before 'ICamRef'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write to CSV: " + ex.Message);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

