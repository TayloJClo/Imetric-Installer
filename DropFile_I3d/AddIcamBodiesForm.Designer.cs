namespace DropFile_I3d
{
    partial class AddIcamBodiesForm
    {
        private System.ComponentModel.IContainer components = null;
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
            dropArea = new System.Windows.Forms.Button();
            buttonApply = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // dropArea
            // 
            dropArea.AllowDrop = true;
            dropArea.BackColor = System.Drawing.SystemColors.Window;
            dropArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            dropArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            dropArea.ForeColor = System.Drawing.SystemColors.GrayText;
            dropArea.Location = new System.Drawing.Point(24, 23);
            dropArea.Name = "dropArea";
            dropArea.Size = new System.Drawing.Size(300, 80);
            dropArea.TabIndex = 0;
            dropArea.Text = "Drag-and-drop ICamBodies here";
            dropArea.UseVisualStyleBackColor = false;
            // 
            // buttonApply
            // 
            buttonApply.Location = new System.Drawing.Point(108, 120);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new System.Drawing.Size(120, 40);
            buttonApply.TabIndex = 1;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // AddIcamBodiesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(352, 185);
            Controls.Add(buttonApply);
            Controls.Add(dropArea);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddIcamBodiesForm";
            Text = "Add ICamBodies";
            ResumeLayout(false);
        }
    }
}
