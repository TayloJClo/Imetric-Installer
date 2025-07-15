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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddIcamBodiesForm));
            dropArea = new Button();
            buttonApply = new Button();
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
            dropArea.Text = "Drag-and-drop ICamBodies here";
            dropArea.UseVisualStyleBackColor = false;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(108, 120);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(120, 40);
            buttonApply.TabIndex = 1;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // AddIcamBodiesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 185);
            Controls.Add(buttonApply);
            Controls.Add(dropArea);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddIcamBodiesForm";
            Text = "Add ICamBodies";
            ResumeLayout(false);
        }
    }
}
