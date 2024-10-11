namespace DropFile_I3d
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            buttonGetFile = new Button();
            buttonCancel = new Button();
            textBoxName = new TextBox();
            label1 = new Label();
            textBoxCustomerID = new TextBox();
            label2 = new Label();
            labelProgress = new Label();
            labelMessage = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            openFileDialog = new OpenFileDialog();
            buttonInstallDriver = new Button();
            buttonIScan3d = new Button();
            buttonInstallZip7 = new Button();
            buttonInstallOffice = new Button();
            buttonNotePadPlus = new Button();
            SuspendLayout();
            // 
            // buttonGetFile
            // 
            buttonGetFile.Enabled = false;
            buttonGetFile.Location = new Point(10, 107);
            buttonGetFile.Name = "buttonGetFile";
            buttonGetFile.Size = new Size(116, 23);
            buttonGetFile.TabIndex = 0;
            buttonGetFile.Text = "Get and Move File";
            buttonGetFile.UseVisualStyleBackColor = true;
            buttonGetFile.Click += buttonGetFile_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(158, 107);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(10, 71);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(277, 23);
            textBoxName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 3;
            label1.Text = "ICamBody Serial Number";
            // 
            // textBoxCustomerID
            // 
            textBoxCustomerID.Location = new Point(10, 24);
            textBoxCustomerID.Name = "textBoxCustomerID";
            textBoxCustomerID.Size = new Size(277, 23);
            textBoxCustomerID.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 5);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 5;
            label2.Text = "ICam Serial Number";
            // 
            // labelProgress
            // 
            labelProgress.AutoSize = true;
            labelProgress.Location = new Point(2, 214);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(0, 15);
            labelProgress.TabIndex = 8;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(12, 189);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(0, 15);
            labelMessage.TabIndex = 11;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // buttonInstallDriver
            // 
            buttonInstallDriver.Location = new Point(304, 20);
            buttonInstallDriver.Name = "buttonInstallDriver";
            buttonInstallDriver.Size = new Size(137, 23);
            buttonInstallDriver.TabIndex = 14;
            buttonInstallDriver.Text = "Install Drivers";
            buttonInstallDriver.UseVisualStyleBackColor = true;
            buttonInstallDriver.Click += buttonInstallDriver_Click;
            // 
            // buttonIScan3d
            // 
            buttonIScan3d.Location = new Point(304, 136);
            buttonIScan3d.Name = "buttonIScan3d";
            buttonIScan3d.Size = new Size(137, 44);
            buttonIScan3d.TabIndex = 15;
            buttonIScan3d.Text = "Install IScan3D Dental";
            buttonIScan3d.UseVisualStyleBackColor = true;
            buttonIScan3d.Click += buttonIScan3d_Click;
            // 
            // buttonInstallZip7
            // 
            buttonInstallZip7.Location = new Point(304, 49);
            buttonInstallZip7.Name = "buttonInstallZip7";
            buttonInstallZip7.Size = new Size(137, 23);
            buttonInstallZip7.TabIndex = 16;
            buttonInstallZip7.Text = "Install 7Zip";
            buttonInstallZip7.UseVisualStyleBackColor = true;
            buttonInstallZip7.Click += buttonInstallZip7_Click;
            // 
            // buttonInstallOffice
            // 
            buttonInstallOffice.Location = new Point(304, 78);
            buttonInstallOffice.Name = "buttonInstallOffice";
            buttonInstallOffice.Size = new Size(137, 23);
            buttonInstallOffice.TabIndex = 17;
            buttonInstallOffice.Text = "Install LibreOffice";
            buttonInstallOffice.UseVisualStyleBackColor = true;
            buttonInstallOffice.Click += buttonInstallOffice_Click;
            // 
            // buttonNotePadPlus
            // 
            buttonNotePadPlus.Location = new Point(304, 107);
            buttonNotePadPlus.Name = "buttonNotePadPlus";
            buttonNotePadPlus.Size = new Size(137, 23);
            buttonNotePadPlus.TabIndex = 18;
            buttonNotePadPlus.Text = "Install NotePad ++";
            buttonNotePadPlus.UseVisualStyleBackColor = true;
            buttonNotePadPlus.Click += buttonNotePadPlus_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 200);
            Controls.Add(buttonNotePadPlus);
            Controls.Add(buttonInstallOffice);
            Controls.Add(buttonInstallZip7);
            Controls.Add(buttonIScan3d);
            Controls.Add(buttonInstallDriver);
            Controls.Add(labelMessage);
            Controls.Add(labelProgress);
            Controls.Add(label2);
            Controls.Add(textBoxCustomerID);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(buttonCancel);
            Controls.Add(buttonGetFile);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ICam Setup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGetFile;
        private Button buttonCancel;
        private TextBox textBoxName;
        private Label label1;
        private TextBox textBoxCustomerID;
        private Label label2;
        private Label labelProgress;
        private Label labelMessage;
        private FolderBrowserDialog folderBrowserDialog;
        private OpenFileDialog openFileDialog;
        private Button buttonInstallDriver;
        private Button buttonIScan3d;
        private Button buttonInstallZip7;
        private Button buttonInstallOffice;
        private Button buttonNotePadPlus;
    }
}