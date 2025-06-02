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
                        var parts = line.Split(',');
                        if (parts.Length < 2) continue;

                        string columnB = parts[1].Trim();

                        if (!string.IsNullOrWhiteSpace(columnB) &&
                            !columnB.Equals("ICamRef", StringComparison.OrdinalIgnoreCase))
                        {
                            checkedListBoxItems.Items.Add(columnB);
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
    }
}

