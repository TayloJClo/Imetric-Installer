namespace ICam4DSetup
{
    partial class CsvRemoveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.CheckedListBox checkedListBoxScrews;
        private System.Windows.Forms.CheckedListBox checkedListBoxHealing;
        private System.Windows.Forms.Label labelScrews;
        private System.Windows.Forms.Label labelHealing;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonCancel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvRemoveForm));
            checkedListBoxScrews = new CheckedListBox();
            checkedListBoxHealing = new CheckedListBox();
            labelScrews = new Label();
            labelHealing = new Label();
            buttonRemove = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // checkedListBoxScrews
            // 
            checkedListBoxScrews.CheckOnClick = true;
            checkedListBoxScrews.FormattingEnabled = true;
            checkedListBoxScrews.Location = new Point(36, 95);
            checkedListBoxScrews.Name = "checkedListBoxScrews";
            checkedListBoxScrews.Size = new Size(539, 480);
            checkedListBoxScrews.TabIndex = 0;
            // 
            // checkedListBoxHealing
            // 
            checkedListBoxHealing.CheckOnClick = true;
            checkedListBoxHealing.FormattingEnabled = true;
            checkedListBoxHealing.Location = new Point(615, 95);
            checkedListBoxHealing.Name = "checkedListBoxHealing";
            checkedListBoxHealing.Size = new Size(539, 480);
            checkedListBoxHealing.TabIndex = 1;
            // 
            // labelScrews
            // 
            labelScrews.AutoSize = true;
            labelScrews.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelScrews.Location = new Point(213, 41);
            labelScrews.Name = "labelScrews";
            labelScrews.Size = new Size(174, 30);
            labelScrews.TabIndex = 4;
            labelScrews.Text = "Screw Channels";
            // 
            // labelHealing
            // 
            labelHealing.AutoSize = true;
            labelHealing.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelHealing.Location = new Point(824, 41);
            labelHealing.Name = "labelHealing";
            labelHealing.Size = new Size(149, 30);
            labelHealing.TabIndex = 5;
            labelHealing.Text = "Healing Caps";
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(412, 588);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(163, 58);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Remove Selected";
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(615, 588);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(163, 58);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // CsvRemoveForm
            // 
            ClientSize = new Size(1184, 694);
            Controls.Add(labelHealing);
            Controls.Add(labelScrews);
            Controls.Add(checkedListBoxHealing);
            Controls.Add(checkedListBoxScrews);
            Controls.Add(buttonRemove);
            Controls.Add(buttonCancel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CsvRemoveForm";
            Text = "Remove From CSV";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}