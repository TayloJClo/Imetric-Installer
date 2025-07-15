namespace DropFile_I3d
{
    partial class HotSwapHelperForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelOld;
        private System.Windows.Forms.ComboBox comboBoxOldIcam;
        private System.Windows.Forms.Button dropArea;
        private System.Windows.Forms.Button buttonApply;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotSwapHelperForm));
            labelOld = new Label();
            comboBoxOldIcam = new ComboBox();
            dropArea = new Button();
            buttonApply = new Button();
            SuspendLayout();
            // 
            // labelOld
            // 
            labelOld.AutoSize = true;
            labelOld.Location = new Point(87, 27);
            labelOld.Name = "labelOld";
            labelOld.Size = new Size(187, 25);
            labelOld.TabIndex = 0;
            labelOld.Text = "Please select old ICam";
            // 
            // comboBoxOldIcam
            // 
            comboBoxOldIcam.FormattingEnabled = true;
            comboBoxOldIcam.Location = new Point(34, 55);
            comboBoxOldIcam.Name = "comboBoxOldIcam";
            comboBoxOldIcam.Size = new Size(300, 33);
            comboBoxOldIcam.TabIndex = 1;
            // 
            // dropArea
            // 
            dropArea.AllowDrop = true;
            dropArea.BackColor = SystemColors.Window;
            dropArea.FlatStyle = FlatStyle.Flat;
            dropArea.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            dropArea.ForeColor = SystemColors.GrayText;
            dropArea.Location = new Point(34, 110);
            dropArea.Name = "dropArea";
            dropArea.Size = new Size(300, 80);
            dropArea.TabIndex = 2;
            dropArea.Text = "Drag-and-drop new ICam data here";
            dropArea.UseVisualStyleBackColor = false;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(120, 210);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(120, 40);
            buttonApply.TabIndex = 3;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // HotSwapHelperForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 274);
            Controls.Add(buttonApply);
            Controls.Add(dropArea);
            Controls.Add(comboBoxOldIcam);
            Controls.Add(labelOld);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HotSwapHelperForm";
            Text = "HotSwap Helper";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
