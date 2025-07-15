using System;
using System.IO;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public partial class CalibrationPlateForm : Form
    {
        public CalibrationPlateForm()
        {
            InitializeComponent();
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
                dropBox1.Text = Path.GetFileName(files[0]);
        }

        private void DropBox2_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
                dropBox2.Text = Path.GetFileName(files[0]);
        }
    }
}
