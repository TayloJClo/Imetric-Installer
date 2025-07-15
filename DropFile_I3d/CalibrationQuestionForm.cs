using System;
using System.IO;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public partial class CalibrationQuestionForm : Form
    {
        private readonly string oldLibraryPath;
        private readonly string newIcamFolder;

        public CalibrationQuestionForm(string oldLibraryPath, string newIcamFolder)
        {
            InitializeComponent();
            this.oldLibraryPath = oldLibraryPath;
            this.newIcamFolder = newIcamFolder;
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            try
            {
                string first7 = Path.GetFileName(oldLibraryPath).Substring(0, 7);
                string sourceRef = Path.Combine(@"C:\\I3D_Systems", first7, "0References");
                string destRef = Path.Combine(newIcamFolder, "0References");
                if (Directory.Exists(sourceRef))
                {
                    if (Directory.Exists(destRef))
                        Directory.Delete(destRef, true);
                    CopyDirectory(sourceRef, destRef);
                }
                MessageBox.Show("Reference data copied.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying references: " + ex.Message);
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            string destRef = Path.Combine(newIcamFolder, "0References");
            using var calibForm = new CalibrationPlateForm(destRef);
            calibForm.ShowDialog();
            Close();
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
