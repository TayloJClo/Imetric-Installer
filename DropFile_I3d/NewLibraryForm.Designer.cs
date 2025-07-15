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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLibraryForm));
            dropArea = new Button();
            buttonNext = new Button();
            SuspendLayout();
            // 
            // dropArea
            // 
            dropArea.AllowDrop = true;
            dropArea.BackColor = SystemColors.Window;
            dropArea.FlatStyle = FlatStyle.Flat;
            dropArea.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            dropArea.ForeColor = SystemColors.GrayText;
            dropArea.Location = new Point(24, 23);
            dropArea.Name = "dropArea";
            dropArea.Size = new Size(300, 80);
            dropArea.TabIndex = 0;
            dropArea.Text = "Drag-and-drop the sensor data here";
            dropArea.UseVisualStyleBackColor = false;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(120, 120);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(120, 40);
            buttonNext.TabIndex = 1;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // NewLibraryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 185);
            Controls.Add(buttonNext);
            Controls.Add(dropArea);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewLibraryForm";
            Text = "Create Library";
            ResumeLayout(false);
        }
    }
}
