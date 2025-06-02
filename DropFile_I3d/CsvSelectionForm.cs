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
                var existingLines = File.ReadAllLines(localCsvPath).ToList();
                var header = existingLines.First();
                var dataLines = existingLines.Skip(1).ToList();

                // Collect unique values in E (index 4) for screws (B != ICamRef)
                var uniqueEValues = new HashSet<string>();
                foreach (var line in dataLines)
                {
                    var parts = line.Split('\t');
                    if (parts.Length > 6)
                    {
                        string b = parts[1].Trim();
                        // Rename the variable 'e' to avoid conflict with the enclosing scope
                        string columnE = parts[4].Trim();

                        if (!string.IsNullOrWhiteSpace(b) && !b.Equals("ICamRef", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(columnE))
                        {
                            uniqueEValues.Add(columnE);
                        }
                    }
                }

                // Prepare new lines
                var newLines = new List<string>();
                foreach (var item in selectedItems)
                {
                    if (!itemToLineMap.TryGetValue(item, out var originalLine)) continue;

                    foreach (var uniqueE in uniqueEValues)
                    {
                        var parts = originalLine.Split('\t');
                        if (parts.Length < 7) continue;

                        parts[4] = uniqueE; // Column E
                        parts[6] = uniqueE + ".ad"; // Column G

                        newLines.Add(string.Join('\t', parts));
                    }
                }

                // Find index of first "ICamRef"
                int insertIndex = dataLines.FindIndex(line =>
                {
                    var parts = line.Split('\t');
                    return parts.Length > 1 && parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase);
                });

                if (insertIndex == -1)
                {
                    dataLines.AddRange(newLines);
                }
                else
                {
                    dataLines.InsertRange(insertIndex, newLines);
                }

                File.WriteAllLines(localCsvPath, new[] { header }.Concat(dataLines), Encoding.UTF8);

                MessageBox.Show("Selected items inserted with updated E/G values.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating CSV: " + ex.Message);
            }
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

