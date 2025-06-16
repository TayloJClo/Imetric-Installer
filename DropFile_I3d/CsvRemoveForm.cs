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
        private Dictionary<string, string> itemToLineMap = new();

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
            itemToLineMap.Clear();
            checkedListBox1.Items.Clear();

            foreach (var line in lines.Skip(1)) // skip header
            {
                var parts = line.Split('\t');
                if (parts.Length < 2) continue;

                string label = parts[1].Trim(); // column B
                string key = parts[4].Trim();   // column E

                string display = $"{label} — {key}";
                if (!itemToLineMap.ContainsKey(display))
                {
                    itemToLineMap[display] = line;
                    checkedListBox1.Items.Add(display);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var selectedItems = checkedListBox1.CheckedItems.Cast<string>().ToList();
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
                if (itemToLineMap.TryGetValue(selected, out var lineToRemove))
                {
                    dataLines.RemoveAll(l => l.Equals(lineToRemove));
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
