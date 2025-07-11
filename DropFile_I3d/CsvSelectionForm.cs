using System.Data;
using System.Diagnostics;
using System.Text;

namespace ICam4DSetup
{
    public partial class CsvSelectionForm : Form
    {
        private string localCsvPath;
        private Dictionary<string, string> screwMap = new();
        private Dictionary<string, string> healingMap = new();
        private HashSet<string> existingScrewKeys = new();
        private HashSet<string> existingHealingKeys = new();

        public CsvSelectionForm(string GitUrl, string localCsvPath)
        {
            InitializeComponent();

            checkedListBoxItems.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBoxItems.DrawItem += CheckedListBoxItems_DrawItem;
            checkedListBoxItems.ItemCheck += CheckedListBoxItems_ItemCheck;

            checkedListBox1.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBox1.DrawItem += CheckedListBox1_DrawItem;
            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;

            this.localCsvPath = localCsvPath;

            if (string.IsNullOrWhiteSpace(this.localCsvPath))
            {
                MessageBox.Show("No local CSV file selected. The form will now close.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            LoadCsvWithRetry(GitUrl);
        }

        private void CheckedListBoxItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            string item = checkedListBoxItems.Items[e.Index].ToString();
            bool isDisabled = existingScrewKeys.Contains(item.Trim().ToLowerInvariant());

            e.DrawBackground();
            Font font = isDisabled ? new Font(e.Font, FontStyle.Italic) : e.Font;
            Color color = isDisabled ? Color.Gray : SystemColors.ControlText;
            TextRenderer.DrawText(e.Graphics, item, font, e.Bounds, color, TextFormatFlags.Left);
            e.DrawFocusRectangle();
        }

        private void CheckedListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            string item = checkedListBox1.Items[e.Index].ToString();
            bool isDisabled = existingHealingKeys.Contains(item.Trim().ToLowerInvariant());

            e.DrawBackground();
            Font font = isDisabled ? new Font(e.Font, FontStyle.Italic) : e.Font;
            Color color = isDisabled ? Color.Gray : SystemColors.ControlText;
            TextRenderer.DrawText(e.Graphics, item, font, e.Bounds, color, TextFormatFlags.Left);
            e.DrawFocusRectangle();
        }

        private void CheckedListBoxItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string item = checkedListBoxItems.Items[e.Index].ToString().Trim().ToLowerInvariant();
            if (existingScrewKeys.Contains(item))
            {
                e.NewValue = e.CurrentValue;
            }
        }

        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string item = checkedListBox1.Items[e.Index].ToString().Trim().ToLowerInvariant();
            if (existingHealingKeys.Contains(item))
            {
                e.NewValue = e.CurrentValue;
            }
        }

        private async void LoadCsvWithRetry(string url)
        {
            int retryCount = 3;
            int delay = 2000;

            for (int attempt = 1; attempt <= retryCount; attempt++)
            {
                try
                {
                    await LoadCsvFromGithub(url);
                    return;
                }
                catch (Exception ex)
                {
                    if (attempt == retryCount)
                    {
                        MessageBox.Show("Failed to load CSV from GitHub after multiple attempts: " + ex.Message);
                        Close();
                    }
                    else
                    {
                        await Task.Delay(delay);
                    }
                }
            }
        }

        private async Task LoadCsvFromGithub(string url)
        {
            var existingLines = File.Exists(localCsvPath) ? File.ReadAllLines(localCsvPath).ToList() : new List<string>();

            foreach (var line in existingLines.Skip(1))
            {
                var parts = line.Split('\t');
                if (parts.Length < 5) continue;
                string b = parts[1].Trim().ToLowerInvariant();
                string e = parts[4].Trim().ToLowerInvariant();
                if (b.Equals("icamref"))
                    existingHealingKeys.Add(e);
                else
                    existingScrewKeys.Add(b);
            }

            using HttpClient client = new HttpClient();
            string csvData = await client.GetStringAsync(url);
            var allLines = csvData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var screwLines = new List<string>();
            var healingLines = new List<string>();

            foreach (var line in allLines.Skip(1))
            {
                var parts = line.Split('\t');
                if (parts.Length < 5) continue;

                string columnB = parts[1].Trim();
                if (columnB.Equals("ICamRef", StringComparison.OrdinalIgnoreCase))
                    healingLines.Add(line);
                else
                    screwLines.Add(line);
            }

            foreach (var line in healingLines.OrderBy(l => l.Split('\t')[4].Trim(), StringComparer.OrdinalIgnoreCase))
            {
                var parts = line.Split('\t');
                string columnE = parts[4].Trim();
                string keyE = columnE.ToLowerInvariant();

                if (!healingMap.ContainsKey(columnE))
                {
                    int index = checkedListBox1.Items.Add(columnE);
                    healingMap[columnE] = line;
                    if (existingHealingKeys.Contains(keyE))
                    {
                        BeginInvoke(() => checkedListBox1.SetItemCheckState(index, CheckState.Checked));
                    }
                }
            }

            foreach (var line in screwLines.OrderBy(l => l.Split('\t')[1].Trim(), StringComparer.OrdinalIgnoreCase))
            {
                var parts = line.Split('\t');
                string columnB = parts[1].Trim();
                string keyB = columnB.ToLowerInvariant();

                if (!screwMap.ContainsKey(columnB) && !checkedListBoxItems.Items.Contains(columnB))
                {
                    int index = checkedListBoxItems.Items.Add(columnB);
                    screwMap[columnB] = line;
                    if (existingScrewKeys.Contains(keyB))
                    {
                        BeginInvoke(() => checkedListBoxItems.SetItemCheckState(index, CheckState.Checked));
                    }
                }
            }

            checkedListBoxItems.Refresh();
            checkedListBox1.Refresh();
        }





        private async void buttonApply_Click(object sender, EventArgs e)
        {
            var selectedScrews = checkedListBoxItems.CheckedItems.Cast<string>().ToList();
            var selectedHealing = checkedListBox1.CheckedItems.Cast<string>().ToList();

            if (!selectedScrews.Any() && !selectedHealing.Any())
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
                var gColumnValues = new HashSet<string>();
                var newLines = new List<string>();

                foreach (var line in dataLines)
                {
                    var parts = line.Split('\t');
                    if (parts.Length > 6 && !parts[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!string.IsNullOrWhiteSpace(parts[4])) uniqueEValues.Add(parts[4].Trim());
                        if (!string.IsNullOrWhiteSpace(parts[5])) fColumnValues.Add(parts[5].Trim());
                    }
                }

                foreach (var item in selectedScrews)
                {
                    if (!screwMap.TryGetValue(item, out var line)) continue;
                    foreach (var uniqueE in uniqueEValues)
                    {
                        var parts = line.Split('\t');
                        parts[4] = uniqueE;
                        parts[6] = uniqueE + ".ad";

                        var modifiedLine = string.Join('\t', parts);
                        if (!currentSet.Contains(modifiedLine))
                        {
                            newLines.Add(modifiedLine);
                            currentSet.Add(modifiedLine);
                            if (!string.IsNullOrWhiteSpace(parts[5])) fColumnValues.Add(parts[5].Trim());
                        }
                    }
                }

                foreach (var item in selectedHealing)
                {
                    if (!healingMap.TryGetValue(item, out var line)) continue;
                    var parts = line.Split('\t');
                    if (parts.Length > 6) gColumnValues.Add(parts[6].Trim());
                    if (!currentSet.Contains(line))
                    {
                        newLines.Add(line);
                        currentSet.Add(line);
                    }
                }

                dataLines.AddRange(newLines);

                var healingLines = dataLines.Where(l => l.Split('\t')[1].Trim().Equals("ICamRef", StringComparison.OrdinalIgnoreCase));
                var screwLines = dataLines.Except(healingLines);

                screwLines = screwLines.OrderBy(l => l.Split('\t')[4]).ThenBy(l => l.Split('\t')[1]);
                dataLines = screwLines.Concat(healingLines).ToList();

                File.WriteAllLines(localCsvPath, new[] { header }.Concat(dataLines), Encoding.UTF8);

                var baseDir = Path.GetDirectoryName(localCsvPath);
                var muRpFolder = Path.Combine(baseDir, "MU-RP");

                // Ensure directories from column F exist
                foreach (var folder in fColumnValues)
                {
                    var newPath = Path.Combine(baseDir, folder);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                }

                // Ensure MU-RP contents are copied to folders referenced in column F
                EnsureMuRpFiles(baseDir, muRpFolder, fColumnValues);

                await DownloadICamRefFilesAsync(gColumnValues);

                MessageBox.Show("Selected items added to library.");
                DialogResult = DialogResult.OK;
                Close();
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

        private void EnsureMuRpFiles(string baseDir, string muRpFolder, IEnumerable<string> targetFolders)
        {
            if (!Directory.Exists(muRpFolder)) return;

            foreach (var folder in targetFolders)
            {
                if (string.IsNullOrWhiteSpace(folder)) continue;

                if (folder.Equals("ICamRef", StringComparison.OrdinalIgnoreCase) ||
                    folder.Equals("MU-RP", StringComparison.OrdinalIgnoreCase))
                    continue;

                var dir = Path.Combine(baseDir, folder);
                if (Directory.Exists(dir))
                {
                    CopyDirectory(muRpFolder, dir);
                }
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

                    string githubBaseUrl = "https://raw.githubusercontent.com/TayloJClo/Imetric-Installer/TayloJClo-IcamRefs/";
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

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://forms.monday.com/forms/a95a7d295dec90ec7478f8470b01232f?r=use1",
                UseShellExecute = true
            });
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private int index;

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
