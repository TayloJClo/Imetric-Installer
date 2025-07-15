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
            labelInstruction = new System.Windows.Forms.Label();
            dropBox1 = new System.Windows.Forms.Button();
            dropBox2 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelInstruction
            // 
            labelInstruction.AutoSize = true;
            labelInstruction.Location = new System.Drawing.Point(30, 20);
            labelInstruction.Name = "labelInstruction";
            labelInstruction.Size = new System.Drawing.Size(298, 25);
            labelInstruction.TabIndex = 0;
            labelInstruction.Text = "Please drag-and-drop the calibration plate data here";
            // 
            // dropBox1
            // 
            dropBox1.AllowDrop = true;
            dropBox1.BackColor = System.Drawing.Color.AliceBlue;
            dropBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            dropBox1.Location = new System.Drawing.Point(34, 60);
            dropBox1.Name = "dropBox1";
            dropBox1.Size = new System.Drawing.Size(140, 80);
            dropBox1.TabIndex = 1;
            dropBox1.Text = "File 1";
            dropBox1.UseVisualStyleBackColor = false;
            // 
            // dropBox2
            // 
            dropBox2.AllowDrop = true;
            dropBox2.BackColor = System.Drawing.Color.AliceBlue;
            dropBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            dropBox2.Location = new System.Drawing.Point(188, 60);
            dropBox2.Name = "dropBox2";
            dropBox2.Size = new System.Drawing.Size(140, 80);
            dropBox2.TabIndex = 2;
            dropBox2.Text = "File 2";
            dropBox2.UseVisualStyleBackColor = false;
            // 
            // CalibrationPlateForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(362, 162);
            Controls.Add(dropBox2);
            Controls.Add(dropBox1);
            Controls.Add(labelInstruction);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CalibrationPlateForm";
            Text = "Calibration Data";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
