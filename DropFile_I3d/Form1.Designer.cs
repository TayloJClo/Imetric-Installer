﻿
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
            menuStrip1 = new MenuStrip();
            installationMenuItem = new ToolStripMenuItem();
            installIScanMenuItem = new ToolStripMenuItem();
            otherSoftwareMenuItem = new ToolStripMenuItem();
            moreToolsMenuItem = new ToolStripMenuItem();
            implantPositionEditorMenuItem = new ToolStripMenuItem();
            createNewLibraryMenuItem = new ToolStripMenuItem();
            hotSwapHelperMenuItem = new ToolStripMenuItem();
            troubleshootingMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            buttonRemove = new Button();
            button1 = new Button();
            comboBoxCsvDir = new ComboBox();
            toolTip1 = new ToolTip(components);
            label2 = new Label();
            labelVersion = new Label();
            groupBox2 = new GroupBox();
            label1 = new Label();
            label4 = new Label();
            button2 = new Button();
            label3 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { installationMenuItem, moreToolsMenuItem });
            menuStrip1.Location = new Point(0, 116);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(624, 33);
            menuStrip1.TabIndex = 30;
            menuStrip1.Text = "menuStrip1";
            // 
            // installationMenuItem
            // 
            installationMenuItem.DropDownItems.AddRange(new ToolStripItem[] { installIScanMenuItem, otherSoftwareMenuItem });
            installationMenuItem.Name = "installationMenuItem";
            installationMenuItem.Size = new Size(114, 29);
            installationMenuItem.Text = "Installation";
            // 
            // installIScanMenuItem
            // 
            installIScanMenuItem.Name = "installIScanMenuItem";
            installIScanMenuItem.Size = new Size(234, 34);
            installIScanMenuItem.Text = "Install IScan";
            installIScanMenuItem.Click += installIScanMenuItem_Click;
            // 
            // otherSoftwareMenuItem
            // 
            otherSoftwareMenuItem.Name = "otherSoftwareMenuItem";
            otherSoftwareMenuItem.Size = new Size(234, 34);
            otherSoftwareMenuItem.Text = "Other Software";
            otherSoftwareMenuItem.Click += otherSoftwareMenuItem_Click;
            // 
            // moreToolsMenuItem
            // 
            moreToolsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { implantPositionEditorMenuItem, createNewLibraryMenuItem, hotSwapHelperMenuItem, troubleshootingMenuItem });
            moreToolsMenuItem.Name = "moreToolsMenuItem";
            moreToolsMenuItem.Size = new Size(116, 29);
            moreToolsMenuItem.Text = "More Tools";
            // 
            // implantPositionEditorMenuItem
            // 
            implantPositionEditorMenuItem.Name = "implantPositionEditorMenuItem";
            implantPositionEditorMenuItem.Size = new Size(295, 34);
            implantPositionEditorMenuItem.Text = "Implant Position Editor";
            implantPositionEditorMenuItem.Click += implantPositionEditorMenuItem_Click;
            // 
            // createNewLibraryMenuItem
            // 
            createNewLibraryMenuItem.Name = "createNewLibraryMenuItem";
            createNewLibraryMenuItem.Size = new Size(295, 34);
            createNewLibraryMenuItem.Text = "Create New Library";
            createNewLibraryMenuItem.Click += createNewLibraryMenuItem_Click;
            // 
            // hotSwapHelperMenuItem
            // 
            hotSwapHelperMenuItem.Name = "hotSwapHelperMenuItem";
            hotSwapHelperMenuItem.Size = new Size(295, 34);
            hotSwapHelperMenuItem.Text = "HotSwap Helper";
            hotSwapHelperMenuItem.Click += hotSwapHelperMenuItem_Click;
            // 
            // troubleshootingMenuItem
            // 
            troubleshootingMenuItem.Name = "troubleshootingMenuItem";
            troubleshootingMenuItem.Size = new Size(295, 34);
            troubleshootingMenuItem.Text = "Troubleshooting";
            troubleshootingMenuItem.Click += troubleshootingMenuItem_Click;
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
            buttonRemove.Location = new Point(25, 148);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(238, 59);
            buttonRemove.TabIndex = 0;
            buttonRemove.Text = "Remove";
            toolTip1.SetToolTip(buttonRemove, "Click here to remove options from your\r\ndropdown menus");
            buttonRemove.Click += buttonRemove_Click;
            // 
            // button1
            // 
            button1.Location = new Point(25, 83);
            button1.Name = "button1";
            button1.Size = new Size(238, 59);
            button1.TabIndex = 0;
            button1.Text = "Add";
            toolTip1.SetToolTip(button1, "Click here to add screw channels or \r\nhealing caps to your current library\r\n");
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonAddComponents_Click;
            // 
            // comboBoxCsvDir
            // 
            comboBoxCsvDir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCsvDir.ForeColor = SystemColors.ControlText;
            comboBoxCsvDir.FormattingEnabled = true;
            comboBoxCsvDir.Location = new Point(207, 196);
            comboBoxCsvDir.Name = "comboBoxCsvDir";
            comboBoxCsvDir.Size = new Size(201, 33);
            comboBoxCsvDir.TabIndex = 28;
            toolTip1.SetToolTip(comboBoxCsvDir, "Please select the ICam you would like to edit");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(224, 248);
            label2.Name = "label2";
            label2.Size = new Size(162, 32);
            label2.TabIndex = 26;
            label2.Text = "Library Tools";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            labelVersion.Location = new Point(547, 516);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(65, 21);
            labelVersion.TabIndex = 27;
            labelVersion.Text = "V8.1.5.1";
            labelVersion.Click += labelVersion_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(buttonRemove);
            groupBox2.Controls.Add(button1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(37, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(553, 221);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(34, 42);
            label1.Name = "label1";
            label1.Size = new Size(229, 21);
            label1.TabIndex = 29;
            label1.Text = "Screw Channels/Healing Caps:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(347, 42);
            label4.Name = "label4";
            label4.Size = new Size(136, 21);
            label4.TabIndex = 28;
            label4.Text = "Add ICamBodies:";
            // 
            // button2
            // 
            button2.AllowDrop = true;
            button2.BackColor = SystemColors.Window;
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ControlDark;
            button2.Location = new Point(295, 83);
            button2.Name = "button2";
            button2.Size = new Size(238, 124);
            button2.TabIndex = 25;
            button2.Text = "Drag-and-drop ICamBody folder here";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.DragDrop += button2_DragDrop;
            button2.DragEnter += button2_DragEnter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(159, 162);
            label3.Name = "label3";
            label3.Size = new Size(294, 21);
            label3.TabIndex = 28;
            label3.Text = "Please select your ICam Serial Number:";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(624, 546);
            Controls.Add(menuStrip1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox2);
            Controls.Add(comboBoxCsvDir);
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
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label labelProgress;
        private FolderBrowserDialog folderBrowserDialog;
        private OpenFileDialog openFileDialog;
        private PictureBox pictureBox1;
        private Button button1;
        private EventHandler button1_Click_1;
        private EventHandler button2_Click_2;
        private Button buttonRemove;
        private ToolTip toolTip1;
        private Label label2;
        private GroupBox groupBox2;
        private Label labelVersion;
        private Button button2;
        private ComboBox comboBoxCsvDir;
        private Label label3;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem installationMenuItem;
        private ToolStripMenuItem installIScanMenuItem;
        private ToolStripMenuItem otherSoftwareMenuItem;
        private ToolStripMenuItem moreToolsMenuItem;
        private ToolStripMenuItem createNewLibraryMenuItem;
        private ToolStripMenuItem hotSwapHelperMenuItem;
        private ToolStripMenuItem troubleshootingMenuItem;
        private ToolStripMenuItem implantPositionEditorMenuItem;
        private Label label1;
    }
}