using System.Data;
using System.Text;
using System.Net.Http;

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

                        var labelLinePairs = new List<(string Label, string Line)>();

                        foreach (var line in lines.Skip(1))
                        {
                            var parts = line.Split('\t');
                            if (parts.Length < 2) continue;

                            string label = filterType == "healing" ? parts[4].Trim() : parts[1].Trim();

                            if (!string.IsNullOrWhiteSpace(label))
                            {
                                bool isHealing = parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase);
                                if ((filterType == "healing" && isHealing) || (filterType == "screw" && !isHealing))
                                {
                                    labelLinePairs.Add((label, line));
                                }
                            }
                        }

                        foreach (var (label, line) in labelLinePairs.OrderBy(x => x.Label, StringComparer.OrdinalIgnoreCase))
                        {
                            checkedListBoxItems.Items.Add(label);
                            itemToLineMap[label] = line;
                        }

                    }
                    break;
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

        private async void buttonApply_Click(object sender, EventArgs e)
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
                var gColumnValues = new HashSet<string>();

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
                        var parts = originalLine.Split('\t');
                        if (parts.Length > 6)
                        {
                            gColumnValues.Add(parts[6].Trim());
                        }
                        if (!currentSet.Contains(originalLine))
                        {
                            newLines.Add(originalLine);
                            currentSet.Add(originalLine);
                        }
                    }
                }

                dataLines.AddRange(newLines);
                int insertIndex = dataLines.FindIndex(line =>
                {
                    var parts = line.Split('\t');
                    return parts.Length > 1 && parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase);
                });

                if (insertIndex == -1)
                {
                    dataLines.AddRange(newLines); // Fallback: append to end
                }
                else
                {
                    dataLines.InsertRange(insertIndex, newLines); // Insert before first ICamRef
                }

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

                if (filterType == "healing")
                {
                    await DownloadICamRefFilesAsync(gColumnValues);
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

        private async Task DownloadICamRefFilesAsync(IEnumerable<string> columnGValues)
        {
            string baseFolder = Path.GetDirectoryName(localCsvPath);
            string targetFolder = Path.Combine(baseFolder, "ICamRef");
            Directory.CreateDirectory(targetFolder);

            using (HttpClient client = new HttpClient())
            {
                foreach (string fileName in columnGValues)
                {
                    if (string.IsNullOrWhiteSpace(fileName)) continue;

                    string githubBaseUrl = "https://github.com/TayloJClo/Imetric-Installer/tree/TayloJClo-IcamRefs/"; // Update this
                    string fileUrl = githubBaseUrl + fileName;
                    string targetPath = Path.Combine(targetFolder, fileName);

                    try
                    {
                        byte[] fileBytes = await client.GetByteArrayAsync(fileUrl);
                        await File.WriteAllBytesAsync(targetPath, fileBytes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to download {fileName}: {ex.Message}");
                    }
                }
            }
        }
    }
}
