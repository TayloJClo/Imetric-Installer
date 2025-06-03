
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
            buttonInstallDriver = new Button();
            buttonIScan3d = new Button();
            buttonInstallZip7 = new Button();
            buttonInstallOffice = new Button();
            buttonNotePadPlus = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonGetFile
            // 
            buttonGetFile.Enabled = false;
            buttonGetFile.Location = new Point(17, 315);
            buttonGetFile.Margin = new Padding(4, 5, 4, 5);
            buttonGetFile.Name = "buttonGetFile";
            buttonGetFile.Size = new Size(166, 38);
            buttonGetFile.TabIndex = 0;
            buttonGetFile.Text = "Get and Move File";
            buttonGetFile.UseVisualStyleBackColor = true;
            buttonGetFile.Click += buttonGetFile_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(230, 315);
            buttonCancel.Margin = new Padding(4, 5, 4, 5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(107, 38);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(40, 136);
            textBoxName.Margin = new Padding(4, 5, 4, 5);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(170, 31);
            textBoxName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 105);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(211, 25);
            label1.TabIndex = 3;
            label1.Text = "ICamBody Serial Number";
            // 
            // textBoxCustomerID
            // 
            textBoxCustomerID.Location = new Point(40, 62);
            textBoxCustomerID.Margin = new Padding(4, 5, 4, 5);
            textBoxCustomerID.Name = "textBoxCustomerID";
            textBoxCustomerID.Size = new Size(170, 31);
            textBoxCustomerID.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 32);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 5;
            label2.Text = "ICam Serial Number";
            // 
            // labelProgress
            // 
            labelProgress.AutoSize = true;
            labelProgress.Location = new Point(3, 357);
            labelProgress.Margin = new Padding(4, 0, 4, 0);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(0, 25);
            labelProgress.TabIndex = 8;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(17, 315);
            labelMessage.Margin = new Padding(4, 0, 4, 0);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(0, 25);
            labelMessage.TabIndex = 11;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // buttonInstallDriver
            // 
            buttonInstallDriver.BackColor = SystemColors.GradientActiveCaption;
            buttonInstallDriver.Location = new Point(375, 180);
            buttonInstallDriver.Margin = new Padding(4, 5, 4, 5);
            buttonInstallDriver.Name = "buttonInstallDriver";
            buttonInstallDriver.Size = new Size(196, 38);
            buttonInstallDriver.TabIndex = 14;
            buttonInstallDriver.Text = "Install Drivers";
            buttonInstallDriver.UseVisualStyleBackColor = false;
            buttonInstallDriver.Click += buttonInstallDriver_Click;
            // 
            // buttonIScan3d
            // 
            buttonIScan3d.BackColor = Color.White;
            buttonIScan3d.Location = new Point(375, 269);
            buttonIScan3d.Margin = new Padding(4, 5, 4, 5);
            buttonIScan3d.Name = "buttonIScan3d";
            buttonIScan3d.Size = new Size(196, 73);
            buttonIScan3d.TabIndex = 15;
            buttonIScan3d.Text = "Install IScan3D Dental";
            buttonIScan3d.UseVisualStyleBackColor = false;
            buttonIScan3d.Click += buttonIScan3d_Click;
            // 
            // buttonInstallZip7
            // 
            buttonInstallZip7.Location = new Point(375, 14);
            buttonInstallZip7.Margin = new Padding(4, 5, 4, 5);
            buttonInstallZip7.Name = "buttonInstallZip7";
            buttonInstallZip7.Size = new Size(196, 38);
            buttonInstallZip7.TabIndex = 16;
            buttonInstallZip7.Text = "Install 7Zip";
            buttonInstallZip7.UseVisualStyleBackColor = true;
            buttonInstallZip7.Click += buttonInstallZip7_Click;
            // 
            // buttonInstallOffice
            // 
            buttonInstallOffice.Location = new Point(375, 62);
            buttonInstallOffice.Margin = new Padding(4, 5, 4, 5);
            buttonInstallOffice.Name = "buttonInstallOffice";
            buttonInstallOffice.Size = new Size(196, 38);
            buttonInstallOffice.TabIndex = 17;
            buttonInstallOffice.Text = "Install LibreOffice";
            buttonInstallOffice.UseVisualStyleBackColor = true;
            buttonInstallOffice.Click += buttonInstallOffice_Click;
            // 
            // buttonNotePadPlus
            // 
            buttonNotePadPlus.Location = new Point(375, 110);
            buttonNotePadPlus.Margin = new Padding(4, 5, 4, 5);
            buttonNotePadPlus.Name = "buttonNotePadPlus";
            buttonNotePadPlus.Size = new Size(196, 38);
            buttonNotePadPlus.TabIndex = 18;
            buttonNotePadPlus.Text = "Install NotePad ++";
            buttonNotePadPlus.UseVisualStyleBackColor = true;
            buttonNotePadPlus.Click += buttonNotePadPlus_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ICam4DSetup.Properties.Resources.imetric_0629req;
            pictureBox1.Location = new Point(12, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(325, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(375, 223);
            label3.Name = "label3";
            label3.Size = new Size(185, 25);
            label3.TabIndex = 20;
            label3.Text = "*don't install for labs*";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxCustomerID);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxName);
            groupBox1.Location = new Point(20, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 177);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Feature coming soon";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Location = new Point(20, 378);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(306, 159);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Library Editor";
            // 
            // button2
            // 
            button2.Location = new Point(18, 101);
            button2.Name = "button2";
            button2.Size = new Size(264, 34);
            button2.TabIndex = 1;
            button2.Text = "Edit Healing Caps";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonHealing_Click;
            // 
            // button1
            // 
            button1.Location = new Point(18, 40);
            button1.Name = "button1";
            button1.Size = new Size(264, 34);
            button1.TabIndex = 0;
            button1.Text = "Edit Screw Channels";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonScrew_Click;
            // 
            // button3
            // 
            button3.Location = new Point(375, 418);
            button3.Name = "button3";
            button3.Size = new Size(196, 63);
            button3.TabIndex = 24;
            button3.Text = "Implant Position Editor";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonEditor_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 567);
            Controls.Add(button3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(buttonNotePadPlus);
            Controls.Add(buttonInstallOffice);
            Controls.Add(buttonInstallZip7);
            Controls.Add(buttonIScan3d);
            Controls.Add(buttonInstallDriver);
            Controls.Add(labelMessage);
            Controls.Add(labelProgress);
            Controls.Add(buttonCancel);
            Controls.Add(buttonGetFile);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Imetric Installation";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
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
        private PictureBox pictureBox1;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button2;
        private Button button1;
        private EventHandler button1_Click_1;
        private EventHandler button2_Click_2;
        private Button button3;
    }
}