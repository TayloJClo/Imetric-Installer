
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DropFile_I3d
{
    partial class OptionPopupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxOptions;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            comboBoxOptions = new System.Windows.Forms.ComboBox();
            buttonOk = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // comboBoxOptions
            // 
            comboBoxOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxOptions.FormattingEnabled = true;
            comboBoxOptions.Items.AddRange(new object[] { "Default", "Nobel", "Straumann" });
            comboBoxOptions.Location = new System.Drawing.Point(12, 12);
            comboBoxOptions.Name = "comboBoxOptions";
            comboBoxOptions.Size = new System.Drawing.Size(260, 33);
            comboBoxOptions.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.Location = new System.Drawing.Point(44, 60);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(75, 34);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(150, 60);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 34);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // OptionPopupForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(284, 111);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(comboBoxOptions);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OptionPopupForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Select Option";
            ResumeLayout(false);
        }
    }
}
