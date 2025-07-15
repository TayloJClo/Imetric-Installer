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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationQuestionForm));
            labelQuestion = new Label();
            buttonYes = new Button();
            buttonNo = new Button();
            SuspendLayout();
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new Point(34, 27);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(358, 25);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = "Are you keeping the same calibration plate?";
            // 
            // buttonYes
            // 
            buttonYes.Location = new Point(91, 72);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(94, 34);
            buttonYes.TabIndex = 1;
            buttonYes.Text = "Yes";
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.Location = new Point(227, 72);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(94, 34);
            buttonNo.TabIndex = 2;
            buttonNo.Text = "No";
            buttonNo.UseVisualStyleBackColor = true;
            buttonNo.Click += buttonNo_Click;
            // 
            // CalibrationQuestionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 123);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(labelQuestion);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CalibrationQuestionForm";
            Text = "Calibration";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
