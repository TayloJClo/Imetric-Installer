using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICam4DSetup
{
    public partial class CsvRemoveForm : Form
    {
        private string localCsvPath = string.Empty; // Initialize with a default value
        private Dictionary<string, List<string>> itemToLinesMap = new();
        private HashSet<string> screwKeys = new();
        private HashSet<string> healingKeys = new();

        public CsvRemoveForm()
        {
            InitializeComponent();

            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select your ICamBody Library CSV file",
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                InitialDirectory = @"C:\I3D_Systems\"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                localCsvPath = openFileDialog.FileName;
                LoadCsv();
            }
            else
            {
                MessageBox.Show("No file selected. Closing.");
                this.Close();
            }
        }

        private void LoadCsv()
        {
            var lines = File.ReadAllLines(localCsvPath).ToList();
            itemToLinesMap.Clear();
            screwKeys.Clear();
            healingKeys.Clear();
            checkedListBoxScrews.Items.Clear();
            checkedListBoxHealing.Items.Clear();

            foreach (var line in lines.Skip(1)) // skip header row
            {
                var parts = line.Split('\t');
                if (parts.Length < 5) continue;

                string columnB = parts[1].Trim();
                string columnE = parts[4].Trim();

                // Determine key and display text based on whether this is a healing cap
                bool isHealing = columnB.Equals("ICamRef", StringComparison.OrdinalIgnoreCase);
                string display = isHealing ? columnE : columnB;

                if (!itemToLinesMap.TryGetValue(display, out var list))
                {
                    list = new List<string>();
                    itemToLinesMap[display] = list;
                }
                list.Add(line);
                if (isHealing)
                    healingKeys.Add(display);
                else
                    screwKeys.Add(display);
            }

            foreach (var key in screwKeys.OrderBy(k => k, StringComparer.OrdinalIgnoreCase))
            {
                checkedListBoxScrews.Items.Add(key);
            }

            foreach (var key in healingKeys.OrderBy(k => k, StringComparer.OrdinalIgnoreCase))
            {
                checkedListBoxHealing.Items.Add(key);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var selectedItems = checkedListBoxScrews.CheckedItems.Cast<string>()
                .Concat(checkedListBoxHealing.CheckedItems.Cast<string>()).ToList();
            if (!selectedItems.Any())
            {
                MessageBox.Show("No items selected.");
                return;
            }

            var allLines = File.ReadAllLines(localCsvPath).ToList();
            var header = allLines[0];
            var dataLines = allLines.Skip(1).ToList();

            foreach (var selected in selectedItems)
            {
                if (itemToLinesMap.TryGetValue(selected, out var linesToRemove))
                {
                    foreach (var lineToRemove in linesToRemove)
                    {
                        dataLines.RemoveAll(l => l.Equals(lineToRemove));
                    }
                }
            }

            File.WriteAllLines(localCsvPath, new[] { header }.Concat(dataLines), Encoding.UTF8);
            MessageBox.Show("Items removed.");
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
