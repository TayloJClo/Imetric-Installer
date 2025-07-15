namespace DropFile_I3d
{
    partial class ComingSoonForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label labelMessage;
        private Button buttonOk;

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
            labelMessage = new Label();
            buttonOk = new Button();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new System.Drawing.Point(30, 23);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new System.Drawing.Size(164, 25);
            labelMessage.TabIndex = 0;
            labelMessage.Text = "Feature coming soon";
            // 
            // buttonOk
            // 
            buttonOk.Location = new System.Drawing.Point(74, 63);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(75, 34);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += (sender, e) => Close();
            // 
            // ComingSoonForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(230, 120);
            Controls.Add(buttonOk);
            Controls.Add(labelMessage);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ComingSoonForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Coming Soon";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
