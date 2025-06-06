namespace ImplantPositionEditor
{
    partial class ImplantEditor
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImplantEditor));
            label1 = new Label();
            btnLoadFile = new Button();
            label2 = new Label();
            cmbTemplates = new ComboBox();
            txtFileContent = new TextBox();
            btnSave = new Button();
            btnLoadCSV = new Button();
            lstFiles = new ListBox();
            btnSaveAs = new Button();
            label3 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(186, 207);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 0;
            label1.Text = "Select Files:";
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(290, 194);
            btnLoadFile.Margin = new Padding(4, 6, 4, 6);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(124, 44);
            btnLoadFile.TabIndex = 1;
            btnLoadFile.Text = "Load File";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 258);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(182, 25);
            label2.TabIndex = 2;
            label2.Text = " Select Screw Channel";
            label2.Click += label2_Click;
            // 
            // cmbTemplates
            // 
            cmbTemplates.FormattingEnabled = true;
            cmbTemplates.Location = new Point(159, 289);
            cmbTemplates.Margin = new Padding(4, 6, 4, 6);
            cmbTemplates.Name = "cmbTemplates";
            cmbTemplates.Size = new Size(415, 33);
            cmbTemplates.TabIndex = 3;
            cmbTemplates.SelectedIndexChanged += cmbTemplates_SelectedIndexChanged;
            // 
            // txtFileContent
            // 
            txtFileContent.Location = new Point(80, 350);
            txtFileContent.Margin = new Padding(4, 6, 4, 6);
            txtFileContent.Multiline = true;
            txtFileContent.Name = "txtFileContent";
            txtFileContent.ScrollBars = ScrollBars.Vertical;
            txtFileContent.Size = new Size(550, 369);
            txtFileContent.TabIndex = 4;
            txtFileContent.TextChanged += txtFileContent_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(159, 743);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 61);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoadCSV
            // 
            btnLoadCSV.Location = new Point(290, 138);
            btnLoadCSV.Margin = new Padding(4, 6, 4, 6);
            btnLoadCSV.Name = "btnLoadCSV";
            btnLoadCSV.Size = new Size(124, 44);
            btnLoadCSV.TabIndex = 6;
            btnLoadCSV.Text = "Load CSV";
            toolTip1.SetToolTip(btnLoadCSV, "Find your CSV file in *you ICam serial*\r\nICamBody Library\r\n");
            btnLoadCSV.UseVisualStyleBackColor = true;
            btnLoadCSV.Click += btnLoadCSV_Click;
            // 
            // lstFiles
            // 
            lstFiles.BackColor = SystemColors.InactiveBorder;
            lstFiles.Dock = DockStyle.Right;
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 25;
            lstFiles.Location = new Point(715, 0);
            lstFiles.Margin = new Padding(4, 6, 4, 6);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(465, 834);
            lstFiles.TabIndex = 7;
            lstFiles.Click += lstFiles_SelectedIndexChanged;
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
            // 
            // btnSaveAs
            // 
            btnSaveAs.Location = new Point(430, 743);
            btnSaveAs.Margin = new Padding(4, 6, 4, 6);
            btnSaveAs.Name = "btnSaveAs";
            btnSaveAs.Size = new Size(144, 61);
            btnSaveAs.TabIndex = 8;
            btnSaveAs.Text = "Save As";
            btnSaveAs.UseVisualStyleBackColor = true;
            btnSaveAs.Click += btnSaveAs_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(422, 204);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(253, 25);
            label3.TabIndex = 9;
            label3.Text = "**Or Drag and Drop Files Here";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 18);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 10;
            label4.Click += label4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = ICam4DSetup.Properties.Resources.imetric_0629req;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(715, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(130, 148);
            label5.Name = "label5";
            label5.Size = new Size(157, 25);
            label5.TabIndex = 12;
            label5.Text = "Select Library CSV:";
            label5.Click += label5_Click;
            // 
            // ImplantEditor
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(224, 224, 224);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1180, 834);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnSaveAs);
            Controls.Add(lstFiles);
            Controls.Add(btnLoadCSV);
            Controls.Add(btnSave);
            Controls.Add(txtFileContent);
            Controls.Add(cmbTemplates);
            Controls.Add(label2);
            Controls.Add(btnLoadFile);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            Name = "ImplantEditor";
            Text = "Implant Position Editor";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTemplates;
        private System.Windows.Forms.TextBox txtFileContent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoadCSV;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private ToolTip toolTip1;
    }
}

