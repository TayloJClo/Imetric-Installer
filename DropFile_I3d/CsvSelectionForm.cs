using System.Data;
using System.Text;

namespace ICam4DSetup
{
    public partial class CsvSelectionForm : Form
    {
        private string localCsvPath;
        private string filterType;
        private Dictionary<string, string> itemToLineMap = new();

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
                openFileDialog.InitialDirectory = @"C:\\I3D_Systems\\";

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

                        foreach (var line in lines.Skip(1))
                        {
                            var parts = line.Split('\t');
                            if (parts.Length < 2) continue;

                            string label = filterType == "healing" ? parts[4].Trim() : parts[1].Trim();

                            if (!string.IsNullOrWhiteSpace(label))
                            {
                                if ((filterType == "healing" && parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase)) ||
                                    (filterType == "screw" && !parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase)))
                                {
                                    checkedListBoxItems.Items.Add(label);
                                    itemToLineMap[label] = line;
                                }
                            }
                        }
                    }
                    break; // Success, exit loop
                }
                catch (Exception ex)
                {
                    if (attempt == maxRetries)
                        MessageBox.Show("Failed to load CSV: " + ex.Message);
                    else
                        await Task.Delay(delayMilliseconds);
                }
            }
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
                var currentSet = new HashSet<string>(dataLines);

                var uniqueEValues = new HashSet<string>();
                var fColumnValues = new HashSet<string>();

                if (filterType == "screw")
                {
                    foreach (var line in dataLines)
                    {
                        var parts = line.Split('\t');
                        if (parts.Length > 6)
                        {
                            string b = parts[1].Trim();
                            string columnE = parts[4].Trim();
                            string columnF = parts[5].Trim();

                            if (!string.IsNullOrWhiteSpace(b) && !b.Equals("ICamRef", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!string.IsNullOrWhiteSpace(columnE)) uniqueEValues.Add(columnE);
                                if (!string.IsNullOrWhiteSpace(columnF)) fColumnValues.Add(columnF);
                            }
                        }
                    }
                }

                var newLines = new List<string>();
                foreach (var item in selectedItems)
                {
                    if (!itemToLineMap.TryGetValue(item, out var originalLine)) continue;

                    if (filterType == "screw")
                    {
                        foreach (var uniqueE in uniqueEValues)
                        {
                            var parts = originalLine.Split('\t');
                            if (parts.Length < 7) continue;

                            parts[4] = uniqueE;
                            parts[6] = uniqueE + ".ad";

                            var line = string.Join('\t', parts);
                            if (!currentSet.Contains(line))
                            {
                                newLines.Add(line);
                                currentSet.Add(line);
                            }
                        }
                    }
                    else if (filterType == "healing")
                    {
                        if (!currentSet.Contains(originalLine))
                        {
                            newLines.Add(originalLine);
                            currentSet.Add(originalLine);
                        }
                    }
                }

                dataLines.AddRange(newLines);
                File.WriteAllLines(localCsvPath, new[] { header }.Concat(dataLines), Encoding.UTF8);

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

        private void button1_Click(object sender, EventArgs e) { }

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
    }
}
