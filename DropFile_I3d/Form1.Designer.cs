
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelProgress = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            openFileDialog = new OpenFileDialog();
            buttonInstallDriver = new Button();
            buttonIScan3d = new Button();
            buttonInstallZip7 = new Button();
            buttonInstallOffice = new Button();
            buttonNotePadPlus = new Button();
            pictureBox1 = new PictureBox();
            buttonRemove = new Button();
            button3 = new Button();
            button1 = new Button();
            comboBoxCsvDir = new ComboBox();
            toolTip1 = new ToolTip(components);
            label1 = new Label();
            label2 = new Label();
            labelVersion = new Label();
            groupBox2 = new GroupBox();
            button2 = new Button();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
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
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // buttonInstallDriver
            // 
            buttonInstallDriver.BackColor = SystemColors.ButtonHighlight;
            buttonInstallDriver.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            buttonInstallDriver.Location = new Point(285, 35);
            buttonInstallDriver.Margin = new Padding(4, 5, 4, 5);
            buttonInstallDriver.Name = "buttonInstallDriver";
            buttonInstallDriver.Size = new Size(238, 38);
            buttonInstallDriver.TabIndex = 14;
            buttonInstallDriver.Text = "Install Drivers";
            toolTip1.SetToolTip(buttonInstallDriver, "Only install drivers if you have an ICam\r\n");
            buttonInstallDriver.UseVisualStyleBackColor = false;
            buttonInstallDriver.Click += buttonInstallDriver_Click;
            // 
            // buttonIScan3d
            // 
            buttonIScan3d.BackColor = Color.White;
            buttonIScan3d.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonIScan3d.Location = new Point(285, 83);
            buttonIScan3d.Margin = new Padding(4, 5, 4, 5);
            buttonIScan3d.Name = "buttonIScan3d";
            buttonIScan3d.Size = new Size(238, 86);
            buttonIScan3d.TabIndex = 15;
            buttonIScan3d.Text = "Install IScan3D Dental";
            buttonIScan3d.UseVisualStyleBackColor = false;
            buttonIScan3d.Click += buttonIScan3d_Click;
            // 
            // buttonInstallZip7
            // 
            buttonInstallZip7.Location = new Point(18, 35);
            buttonInstallZip7.Margin = new Padding(4, 5, 4, 5);
            buttonInstallZip7.Name = "buttonInstallZip7";
            buttonInstallZip7.Size = new Size(238, 38);
            buttonInstallZip7.TabIndex = 16;
            buttonInstallZip7.Text = "Install 7Zip";
            buttonInstallZip7.UseVisualStyleBackColor = true;
            buttonInstallZip7.Click += buttonInstallZip7_Click;
            // 
            // buttonInstallOffice
            // 
            buttonInstallOffice.Location = new Point(18, 83);
            buttonInstallOffice.Margin = new Padding(4, 5, 4, 5);
            buttonInstallOffice.Name = "buttonInstallOffice";
            buttonInstallOffice.Size = new Size(238, 38);
            buttonInstallOffice.TabIndex = 17;
            buttonInstallOffice.Text = "Install LibreOffice";
            buttonInstallOffice.UseVisualStyleBackColor = true;
            buttonInstallOffice.Click += buttonInstallOffice_Click;
            // 
            // buttonNotePadPlus
            // 
            buttonNotePadPlus.Location = new Point(18, 131);
            buttonNotePadPlus.Margin = new Padding(4, 5, 4, 5);
            buttonNotePadPlus.Name = "buttonNotePadPlus";
            buttonNotePadPlus.Size = new Size(238, 38);
            buttonNotePadPlus.TabIndex = 18;
            buttonNotePadPlus.Text = "Install NotePad ++";
            buttonNotePadPlus.UseVisualStyleBackColor = true;
            buttonNotePadPlus.Click += buttonNotePadPlus_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = ICam4DSetup.Properties.Resources.imetric_0629req;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(624, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(18, 162);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(238, 59);
            buttonRemove.TabIndex = 0;
            buttonRemove.Text = "Remove Screws/Healing Caps";
            toolTip1.SetToolTip(buttonRemove, "Click here to remove options from your\r\ndropdown menus");
            buttonRemove.Click += buttonRemove_Click;
            // 
            // button3
            // 
            button3.Location = new Point(285, 162);
            button3.Name = "button3";
            button3.Size = new Size(238, 59);
            button3.TabIndex = 24;
            button3.Text = "Implant Position Editor";
            toolTip1.SetToolTip(button3, "Use this tool to edit the library for exocad if you\r\nchose the wrong one in the scanning process\r\n");
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonEditor_Click;
            // 
            // button1
            // 
            button1.Location = new Point(18, 86);
            button1.Name = "button1";
            button1.Size = new Size(238, 59);
            button1.TabIndex = 0;
            button1.Text = "Add Screws/Healing Caps";
            toolTip1.SetToolTip(button1, "Click here to add screw channels or \r\nhealing caps to your current library\r\n");
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonAddComponents_Click;
            // 
            // comboBoxCsvDir
            // 
            comboBoxCsvDir.FormattingEnabled = true;
            comboBoxCsvDir.Location = new Point(18, 30);
            comboBoxCsvDir.Name = "comboBoxCsvDir";
            comboBoxCsvDir.Size = new Size(306, 33);
            comboBoxCsvDir.TabIndex = 28;
            // 
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(195, 119);
            label1.Name = "label1";
            label1.Size = new Size(210, 32);
            label1.TabIndex = 25;
            label1.Text = "Installation Tools";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(237, 382);
            label2.Name = "label2";
            label2.Size = new Size(146, 30);
            label2.TabIndex = 26;
            label2.Text = "Library Tools";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            labelVersion.Location = new Point(547, 670);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(65, 21);
            labelVersion.TabIndex = 27;
            labelVersion.Text = "V8.1.3.5";
            labelVersion.Click += labelVersion_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(comboBoxCsvDir);
            groupBox2.Controls.Add(buttonRemove);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(37, 415);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(553, 252);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(285, 86);
            button2.Name = "button2";
            button2.Size = new Size(238, 59);
            button2.TabIndex = 25;
            button2.Text = "Add ICamBodies";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonInstallDriver);
            groupBox3.Controls.Add(buttonInstallZip7);
            groupBox3.Controls.Add(buttonInstallOffice);
            groupBox3.Controls.Add(buttonIScan3d);
            groupBox3.Controls.Add(buttonNotePadPlus);
            groupBox3.Location = new Point(37, 154);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(553, 200);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(624, 700);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(pictureBox1);
            Controls.Add(labelProgress);
            Controls.Add(labelVersion);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Form1";
            ShowInTaskbar = false;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label labelProgress;
        private FolderBrowserDialog folderBrowserDialog;
        private OpenFileDialog openFileDialog;
        private Button buttonInstallDriver;
        private Button buttonIScan3d;
        private Button buttonInstallZip7;
        private Button buttonInstallOffice;
        private Button buttonNotePadPlus;
        private PictureBox pictureBox1;
        private Button button1;
        private EventHandler button1_Click_1;
        private EventHandler button2_Click_2;
        private Button button3;
        private Button buttonRemove;
        private ToolTip toolTip1;
        private Label label1;
        private Label label2;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label labelVersion;
        private Button button2;
        private ComboBox comboBoxCsvDir;
    }
}