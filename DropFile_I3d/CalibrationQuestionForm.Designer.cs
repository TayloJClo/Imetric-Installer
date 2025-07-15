namespace DropFile_I3d
{
    partial class CalibrationQuestionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;

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
            labelQuestion = new System.Windows.Forms.Label();
            buttonYes = new System.Windows.Forms.Button();
            buttonNo = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new System.Drawing.Point(34, 27);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new System.Drawing.Size(283, 25);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = "Are you keeping the same calibration plate?";
            // 
            // buttonYes
            // 
            buttonYes.Location = new System.Drawing.Point(38, 70);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new System.Drawing.Size(94, 34);
            buttonYes.TabIndex = 1;
            buttonYes.Text = "Yes";
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.Location = new System.Drawing.Point(223, 70);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new System.Drawing.Size(94, 34);
            buttonNo.TabIndex = 2;
            buttonNo.Text = "No";
            buttonNo.UseVisualStyleBackColor = true;
            buttonNo.Click += buttonNo_Click;
            // 
            // CalibrationQuestionForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(358, 128);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(labelQuestion);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CalibrationQuestionForm";
            Text = "Calibration";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
