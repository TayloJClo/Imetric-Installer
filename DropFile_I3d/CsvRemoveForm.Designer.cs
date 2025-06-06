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
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonCancel;

        private void InitializeComponent()
        {
            checkedListBox1 = new CheckedListBox();
            buttonRemove = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(20, 25);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(450, 340);
            checkedListBox1.TabIndex = 0;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(20, 396);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(192, 44);
            buttonRemove.TabIndex = 1;
            buttonRemove.Text = "Remove Selected";
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(277, 396);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(193, 44);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // CsvRemoveForm
            // 
            ClientSize = new Size(500, 474);
            Controls.Add(checkedListBox1);
            Controls.Add(buttonRemove);
            Controls.Add(buttonCancel);
            Name = "CsvRemoveForm";
            Text = "Remove From CSV";
            ResumeLayout(false);
        }

        #endregion
    }
}