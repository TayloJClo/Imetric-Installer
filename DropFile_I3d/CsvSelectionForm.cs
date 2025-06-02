using System.Data;
using System.Text;

namespace ICam4DSetup
{
    public partial class CsvSelectionForm : Form
    {
        private string localCsvPath;
        private string filterType;
        private Dictionary<string, string> itemToLineMap = new(); // Add this field


        private Button buttonApply;
        private Button buttonCancel;

        public CsvSelectionForm(string GitUrl, string type)
        {
            InitializeComponent();
            filterType = type.ToLower();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select your ICamBody Library CSV file";
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = @"C:\I3D_Systems\"; // <- Set default folder here

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    localCsvPath = openFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("No local CSV file selected. The form will now close.");
                    this.Close();
                    return;
                }
            }
            LoadCsvFromGithub(GitUrl);
        }

        private async void LoadCsvFromGithub(string url)
        {
            int maxRetries = 3;
            int delayMilliseconds = 2000;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
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
                                itemToLineMap[columnB] = line;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load CSV: " + ex.Message);
                }
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
                var fColumnValues = new HashSet<string>(); // Add this declaration

                foreach (var line in dataLines)
                {
                    var parts = line.Split('\t');
                    if (parts.Length > 6)
                    {
                        string b = parts[1].Trim();
                        string columnE = parts[4].Trim();
                        string columnF = parts[5].Trim(); // Extract column F

                        if (!string.IsNullOrWhiteSpace(b) && !b.Equals("ICamRef", StringComparison.OrdinalIgnoreCase))
                        {
                            if (!string.IsNullOrWhiteSpace(columnE))
                            {
                                uniqueEValues.Add(columnE);
                            }
                            if (!string.IsNullOrWhiteSpace(columnF))
                            {
                                fColumnValues.Add(columnF); // Collect unique F values
                            }
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

                // Create folders named by column F values and copy from MU-RP
                var baseDir = Path.GetDirectoryName(localCsvPath);
                var muRpFolder = Path.Combine(baseDir, "MU-RP");
                foreach (var folderName in fColumnValues)
                {
                    var newFolderPath = Path.Combine(baseDir, folderName);
                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                        if (Directory.Exists(muRpFolder))
                        {
                            CopyDirectory(muRpFolder, newFolderPath);
                        }
                    }
                }

                MessageBox.Show("Selected items added to library.");
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
                File.Copy(fileName, targetFilePath, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

