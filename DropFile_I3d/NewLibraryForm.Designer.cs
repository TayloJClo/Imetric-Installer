namespace DropFile_I3d
{
    partial class NewLibraryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button dropArea;
        private System.Windows.Forms.Button buttonNext;

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
            buttonNext = new System.Windows.Forms.Button();
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
            dropArea.Text = "Drag-and-drop the sensor data here";
            dropArea.UseVisualStyleBackColor = false;
            // 
            // buttonNext
            // 
            buttonNext.Location = new System.Drawing.Point(120, 120);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new System.Drawing.Size(120, 40);
            buttonNext.TabIndex = 1;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // NewLibraryForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(352, 185);
            Controls.Add(buttonNext);
            Controls.Add(dropArea);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewLibraryForm";
            Text = "Create Library";
            ResumeLayout(false);
        }
    }
}
