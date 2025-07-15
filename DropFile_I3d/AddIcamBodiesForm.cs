using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public partial class AddIcamBodiesForm : Form
    {
        private readonly string libraryDir;
        private readonly List<string> folders = new();

        public AddIcamBodiesForm(string libraryDir)
        {
            InitializeComponent();
            this.libraryDir = libraryDir;
            dropArea.AllowDrop = true;
            dropArea.DragEnter += DropArea_DragEnter;
            dropArea.DragDrop += DropArea_DragDrop;
        }

        private void DropArea_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DropArea_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var f in files)
            {
                if (Directory.Exists(f))
                    folders.Add(f);
            }
            dropArea.Text = $"{folders.Count} folder(s) selected";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (folders.Count == 0)
            {
                MessageBox.Show("Please drop ICamBody folders.");
                return;
            }
            try
            {
                foreach (var folder in folders)
                    ProcessFolder(folder);
                MessageBox.Show("ICamBodies added.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding ICamBodies: " + ex.Message);
            }
        }

        private void ProcessFolder(string sourceFolder)
        {
            string csvPath = Path.Combine(libraryDir, "ICamBody Library.csv");
            if (!File.Exists(csvPath))
                throw new FileNotFoundException(csvPath);

            string folderName = Path.GetFileName(sourceFolder.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

            string csvText = File.ReadAllText(csvPath);
            if (csvText.Contains("MURPXXXXXX"))
            {
                csvText = csvText.Replace("MURPXXXXXX", folderName);
                File.WriteAllText(csvPath, csvText);
            }

            var csvLines = File.ReadAllLines(csvPath).ToList();

            string muRpFolder = Path.Combine(libraryDir, "MU-RP", folderName);
            CopyDirectory(sourceFolder, muRpFolder);

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
                string target = Path.Combine(libraryDir, dir, folderName);
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
        }

        private static void CopyDirectory(string sourceDir, string targetDir)
        {
            foreach (string dir in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
            {
                string targetSubDir = dir.Replace(sourceDir, targetDir);
                Directory.CreateDirectory(targetSubDir);
            }
            foreach (string file in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
            {
                string targetFile = file.Replace(sourceDir, targetDir);
                Directory.CreateDirectory(Path.GetDirectoryName(targetFile)!);
                File.Copy(file, targetFile, true);
            }
        }
    }
}
