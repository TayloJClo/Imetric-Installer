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
            labelOld = new System.Windows.Forms.Label();
            comboBoxOldIcam = new System.Windows.Forms.ComboBox();
            dropArea = new System.Windows.Forms.Button();
            buttonApply = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelOld
            // 
            labelOld.AutoSize = true;
            labelOld.Location = new System.Drawing.Point(30, 25);
            labelOld.Name = "labelOld";
            labelOld.Size = new System.Drawing.Size(171, 25);
            labelOld.TabIndex = 0;
            labelOld.Text = "Please select Old ICam";
            // 
            // comboBoxOldIcam
            // 
            comboBoxOldIcam.FormattingEnabled = true;
            comboBoxOldIcam.Location = new System.Drawing.Point(34, 55);
            comboBoxOldIcam.Name = "comboBoxOldIcam";
            comboBoxOldIcam.Size = new System.Drawing.Size(300, 33);
            comboBoxOldIcam.TabIndex = 1;
            // 
            // dropArea
            // 
            dropArea.AllowDrop = true;
            dropArea.BackColor = System.Drawing.Color.AliceBlue;
            dropArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            dropArea.Location = new System.Drawing.Point(34, 110);
            dropArea.Name = "dropArea";
            dropArea.Size = new System.Drawing.Size(300, 80);
            dropArea.TabIndex = 2;
            dropArea.Text = "Drag-and-drop new ICam data here";
            dropArea.UseVisualStyleBackColor = false;
            // 
            // buttonApply
            // 
            buttonApply.Location = new System.Drawing.Point(120, 210);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new System.Drawing.Size(120, 40);
            buttonApply.TabIndex = 3;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // HotSwapHelperForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(368, 274);
            Controls.Add(buttonApply);
            Controls.Add(dropArea);
            Controls.Add(comboBoxOldIcam);
            Controls.Add(labelOld);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HotSwapHelperForm";
            Text = "HotSwap Helper";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
