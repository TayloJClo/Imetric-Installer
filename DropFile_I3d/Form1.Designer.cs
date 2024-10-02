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
            button1 = new Button();
            button2 = new Button();
            buttonInstallDriver = new Button();
            buttonIScan3d = new Button();
            buttonInstallZip7 = new Button();
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
            label1.Size = new Size(103, 15);
            label1.TabIndex = 3;
            label1.Text = "ICamBody Serial #";
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
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "ICam Serial";
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
            // button1
            // 
            button1.Location = new Point(295, 22);
            button1.Name = "button1";
            button1.Size = new Size(36, 23);
            button1.TabIndex = 12;
            button1.Text = "..";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(294, 72);
            button2.Name = "button2";
            button2.Size = new Size(37, 23);
            button2.TabIndex = 13;
            button2.Text = "..";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonInstallDriver
            // 
            buttonInstallDriver.Location = new Point(353, 24);
            buttonInstallDriver.Name = "buttonInstallDriver";
            buttonInstallDriver.Size = new Size(137, 23);
            buttonInstallDriver.TabIndex = 14;
            buttonInstallDriver.Text = "Install Drivers";
            buttonInstallDriver.UseVisualStyleBackColor = true;
            buttonInstallDriver.Click += buttonInstallDriver_Click;
            // 
            // buttonIScan3d
            // 
            buttonIScan3d.Location = new Point(353, 56);
            buttonIScan3d.Name = "buttonIScan3d";
            buttonIScan3d.Size = new Size(137, 23);
            buttonIScan3d.TabIndex = 15;
            buttonIScan3d.Text = "Install IScan3D_Dental";
            buttonIScan3d.UseVisualStyleBackColor = true;
            buttonIScan3d.Click += buttonIScan3d_Click;
            // 
            // buttonInstallZip7
            // 
            buttonInstallZip7.Location = new Point(353, 88);
            buttonInstallZip7.Name = "buttonInstallZip7";
            buttonInstallZip7.Size = new Size(137, 23);
            buttonInstallZip7.TabIndex = 16;
            buttonInstallZip7.Text = "Install Zip7";
            buttonInstallZip7.UseVisualStyleBackColor = true;
            buttonInstallZip7.Click += buttonInstallZip7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 151);
            Controls.Add(buttonInstallZip7);
            Controls.Add(buttonIScan3d);
            Controls.Add(buttonInstallDriver);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(labelMessage);
            Controls.Add(labelProgress);
            Controls.Add(label2);
            Controls.Add(textBoxCustomerID);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(buttonCancel);
            Controls.Add(buttonGetFile);
            Name = "Form1";
            Text = "I3D Systems File Transfer";
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
        private Button button1;
        private Button button2;
        private Button buttonInstallDriver;
        private Button buttonIScan3d;
        private Button buttonInstallZip7;
    }
}