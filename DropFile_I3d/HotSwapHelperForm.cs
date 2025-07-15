using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public partial class HotSwapHelperForm : Form
    {
        private class FolderItem
        {
            public string DisplayName { get; init; } = "";
            public string Path { get; init; } = "";
            public override string ToString() => DisplayName;
        }

        private string newIcamFolder = string.Empty;
        private readonly string baseDir = @"C:\\I3D_Systems";

        public HotSwapHelperForm()
        {
            InitializeComponent();
            comboBoxOldIcam.DropDownStyle = ComboBoxStyle.DropDownList;
            PopulateCsvDirectories();
            dropArea.AllowDrop = true;
            dropArea.DragEnter += DropArea_DragEnter;
            dropArea.DragDrop += DropArea_DragDrop;
        }

        private void PopulateCsvDirectories()
        {
            comboBoxOldIcam.Items.Clear();
            if (!Directory.Exists(baseDir))
                return;
            var dirs = Directory.GetDirectories(baseDir, "*ICamBody Library", SearchOption.TopDirectoryOnly);
            foreach (var dir in dirs)
            {
                string folderName = Path.GetFileName(dir);
                string displayName = folderName.Split(' ')[0];
                comboBoxOldIcam.Items.Add(new FolderItem { DisplayName = displayName, Path = dir });
            }
            if (comboBoxOldIcam.Items.Count > 0)
                comboBoxOldIcam.SelectedIndex = 0;
        }

        private void DropArea_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && Directory.Exists(files[0]))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void DropArea_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0 && Directory.Exists(files[0]))
            {
                newIcamFolder = files[0];
                dropArea.Text = Path.GetFileName(newIcamFolder);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newIcamFolder) || !Directory.Exists(newIcamFolder))
            {
                MessageBox.Show("Please drag-and-drop new ICam data folder.");
                return;
            }
            if (comboBoxOldIcam.SelectedItem is not FolderItem selected)
            {
                MessageBox.Show("Please select an old ICam library.");
                return;
            }

            try
            {
                string newFolderName = Path.GetFileName(newIcamFolder.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                string newFolderTarget = Path.Combine(baseDir, newFolderName);
                CopyDirectory(newIcamFolder, newFolderTarget);

                string newLibraryTarget = Path.Combine(baseDir, newFolderName + " ICamBody Library");
                CopyDirectory(selected.Path, newLibraryTarget);

                using var question = new CalibrationQuestionForm(selected.Path, newFolderTarget);
                question.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during HotSwap: " + ex.Message);
            }
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
