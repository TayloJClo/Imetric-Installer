using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public partial class CalibrationPlateForm : Form
    {
        private readonly string destRef;
        private string cpFilePath = string.Empty;
        private string rdFilePath = string.Empty;

        public CalibrationPlateForm() : this(string.Empty)
        {
        }

        public CalibrationPlateForm(string destRef)
        {
            InitializeComponent();
            this.destRef = destRef;
            dropBox1.AllowDrop = true;
            dropBox2.AllowDrop = true;
            dropBox1.DragEnter += Drop_DragEnter;
            dropBox2.DragEnter += Drop_DragEnter;
            dropBox1.DragDrop += DropBox1_DragDrop;
            dropBox2.DragDrop += DropBox2_DragDrop;
        }

        private void Drop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DropBox1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                cpFilePath = files[0];
                dropBox1.Text = Path.GetFileName(cpFilePath);
                TryUpdateCalibration();
            }
        }

        private void DropBox2_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                rdFilePath = files[0];
                dropBox2.Text = Path.GetFileName(rdFilePath);
                TryUpdateCalibration();
            }
        }

        private void TryUpdateCalibration()
        {
            if (File.Exists(cpFilePath) && File.Exists(rdFilePath) && Directory.Exists(destRef))
            {
                UpdateCalibrationFiles();
                MessageBox.Show("Calibration files updated.");
                Close();
            }
        }

        private void UpdateCalibrationFiles()
        {
            string archiveDir = Path.Combine(destRef, "_0Archive");
            Directory.CreateDirectory(archiveDir);

            foreach (var file in Directory.GetFiles(destRef, "CP100_*.obr"))
            {
                string target = Path.Combine(archiveDir, Path.GetFileName(file));
                if (File.Exists(target))
                    File.Delete(target);
                File.Move(file, target);
            }

            foreach (var file in Directory.GetFiles(destRef, "RD_CP100_*.obr").Where(f => !f.Contains("_IPD1")))
            {
                string target = Path.Combine(archiveDir, Path.GetFileName(file));
                if (File.Exists(target))
                    File.Delete(target);
                File.Move(file, target);
            }

            string cpDest = Path.Combine(destRef, Path.GetFileName(cpFilePath));
            File.Copy(cpFilePath, cpDest, true);

            string rdDest = Path.Combine(destRef, Path.GetFileName(rdFilePath));
            File.Copy(rdFilePath, rdDest, true);

            string rdBase = Path.GetFileNameWithoutExtension(rdDest);
            string newIpd1 = Path.Combine(destRef, rdBase + "_IPD1.obr");
            var oldIpd1 = Directory.GetFiles(destRef, "RD_CP100_*_IPD1.obr").FirstOrDefault();
            if (oldIpd1 != null)
            {
                if (File.Exists(newIpd1))
                    File.Delete(newIpd1);
                File.Move(oldIpd1, newIpd1);
            }

            string refFile = Path.Combine(destRef, "Reference_setup.txt");
            if (File.Exists(refFile))
            {
                string text = File.ReadAllText(refFile);
                text = Regex.Replace(text, @"CP100_\d+\.obr", Path.GetFileName(cpDest));
                text = Regex.Replace(text, @"RD_CP100_\d+\.obr", Path.GetFileName(rdDest));
                text = Regex.Replace(text, @"RD_CP100_\d+_IPD1\.obr", Path.GetFileName(newIpd1));
                File.WriteAllText(refFile, text);
            }
        }
    }
}
