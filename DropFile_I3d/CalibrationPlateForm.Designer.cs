namespace DropFile_I3d
{
    partial class CalibrationPlateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelInstruction;
        private System.Windows.Forms.Button dropBox1;
        private System.Windows.Forms.Button dropBox2;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationPlateForm));
            labelInstruction = new Label();
            dropBox1 = new Button();
            dropBox2 = new Button();
            SuspendLayout();
            // 
            // labelInstruction
            // 
            labelInstruction.AutoSize = true;
            labelInstruction.Location = new Point(30, 20);
            labelInstruction.Name = "labelInstruction";
            labelInstruction.Size = new Size(426, 25);
            labelInstruction.TabIndex = 0;
            labelInstruction.Text = "Please drag-and-drop the calibration plate data here";
            // 
            // dropBox1
            // 
            dropBox1.AllowDrop = true;
            dropBox1.BackColor = Color.AliceBlue;
            dropBox1.FlatStyle = FlatStyle.Flat;
            dropBox1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            dropBox1.ForeColor = SystemColors.ControlDark;
            dropBox1.Location = new Point(30, 69);
            dropBox1.Name = "dropBox1";
            dropBox1.Size = new Size(191, 80);
            dropBox1.TabIndex = 1;
            dropBox1.Text = "CP_100.obr";
            dropBox1.UseVisualStyleBackColor = false;
            // 
            // dropBox2
            // 
            dropBox2.AllowDrop = true;
            dropBox2.BackColor = Color.AliceBlue;
            dropBox2.FlatStyle = FlatStyle.Flat;
            dropBox2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            dropBox2.ForeColor = SystemColors.ControlDark;
            dropBox2.Location = new Point(275, 69);
            dropBox2.Name = "dropBox2";
            dropBox2.Size = new Size(181, 80);
            dropBox2.TabIndex = 2;
            dropBox2.Text = "RD_CP100.obr";
            dropBox2.UseVisualStyleBackColor = false;
            // 
            // CalibrationPlateForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 180);
            Controls.Add(dropBox2);
            Controls.Add(dropBox1);
            Controls.Add(labelInstruction);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CalibrationPlateForm";
            Text = "Calibration Data";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
