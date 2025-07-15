using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public partial class NewLibraryForm : Form
    {
        private string sensorFolder = string.Empty;
        private readonly string baseDir = @"C:\\I3D_Systems";

        public NewLibraryForm()
        {
            InitializeComponent();
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
            if (files.Length > 0 && Directory.Exists(files[0]))
            {
                sensorFolder = files[0];
                dropArea.Text = Path.GetFileName(sensorFolder);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sensorFolder) || !Directory.Exists(sensorFolder))
            {
                MessageBox.Show("Please drag-and-drop the sensor data folder.");
                return;
            }

            try
            {
                string folderName = Path.GetFileName(sensorFolder.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
                string targetSensor = Path.Combine(baseDir, folderName);
                CopyDirectory(sensorFolder, targetSensor);

                string sourceLibrary = Path.Combine(baseDir, "I221301 ICamBody Library");
                string targetLibrary = Path.Combine(baseDir, folderName + " ICamBody Library");
                CopyDirectory(sourceLibrary, targetLibrary);

                MessageBox.Show("Library created at " + targetLibrary + ".");

                using var addForm = new AddIcamBodiesForm(targetLibrary);
                addForm.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating library: " + ex.Message);
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
