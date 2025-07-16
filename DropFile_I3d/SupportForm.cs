using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public class SupportForm : Form
    {
        private Label labelHeader;
        private Button buttonTicket;
        private TextBox textBoxPhone;

        public SupportForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            labelHeader = new Label();
            buttonTicket = new Button();
            textBoxPhone = new TextBox();
            SuspendLayout();

            // labelHeader
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeader.Location = new Point(20, 20);
            labelHeader.Text = "Need Help?";

            // buttonTicket
            buttonTicket.Location = new Point(20, 60);
            buttonTicket.Size = new Size(240, 40);
            buttonTicket.Text = "Submit Support Ticket";
            buttonTicket.Click += ButtonTicket_Click;

            // textBoxPhone
            textBoxPhone.Location = new Point(20, 110);
            textBoxPhone.Size = new Size(240, 31);
            textBoxPhone.ReadOnly = true;
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Text = "Call us: 844-811-4449 ext 2";

            // Form
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 170);
            Controls.Add(labelHeader);
            Controls.Add(buttonTicket);
            Controls.Add(textBoxPhone);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Support";
            ResumeLayout(false);
            PerformLayout();
        }

        private void ButtonTicket_Click(object? sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("explorer.exe", "https://imetric4d.freshdesk.com/en/support/tickets/new") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open browser: " + ex.Message);
            }
        }
    }
}

