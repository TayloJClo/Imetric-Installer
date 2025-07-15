using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public class OtherSoftwareForm : Form
    {
        private Button buttonZip;
        private Button buttonOffice;
        private Button buttonNotepad;

        public OtherSoftwareForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            buttonZip = new Button();
            buttonOffice = new Button();
            buttonNotepad = new Button();
            SuspendLayout();

            // buttonZip
            buttonZip.Location = new Point(20, 20);
            buttonZip.Size = new Size(238, 38);
            buttonZip.Text = "Install 7Zip";
            buttonZip.Click += ButtonZip_Click;

            // buttonOffice
            buttonOffice.Location = new Point(20, 68);
            buttonOffice.Size = new Size(238, 38);
            buttonOffice.Text = "Install LibreOffice";
            buttonOffice.Click += ButtonOffice_Click;

            // buttonNotepad
            buttonNotepad.Location = new Point(20, 116);
            buttonNotepad.Size = new Size(238, 38);
            buttonNotepad.Text = "Install NotePad ++";
            buttonNotepad.Click += ButtonNotepad_Click;

            // Form
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(278, 176);
            Controls.Add(buttonZip);
            Controls.Add(buttonOffice);
            Controls.Add(buttonNotepad);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Other Software";
            ResumeLayout(false);
        }

        private void ButtonZip_Click(object? sender, EventArgs e)
        {
            InstallHelpers.Install(@"C:\I3D_Software\General\7zip\7z1900-x64.exe");
        }

        private void ButtonOffice_Click(object? sender, EventArgs e)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = "install --id TheDocumentFoundation.LibreOffice -e --silent",
                    Verb = "runas",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(processInfo);
                process?.WaitForExit();
                MessageBox.Show("LibreOffice installation complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void ButtonNotepad_Click(object? sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "https://notepad-plus-plus.org/downloads/"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
