using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICam4DSetup
{
    public partial class CsvSelectionForm : Form
    {
        private CheckedListBox checkedListBoxItems;





        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CsvSelectionForm));
            checkedListBoxItems = new CheckedListBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            checkedListBox1 = new CheckedListBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // checkedListBoxItems
            // 
            checkedListBoxItems.CheckOnClick = true;
            checkedListBoxItems.FormattingEnabled = true;
            checkedListBoxItems.Location = new Point(36, 95);
            checkedListBoxItems.Name = "checkedListBoxItems";
            checkedListBoxItems.Size = new Size(539, 480);
            checkedListBoxItems.TabIndex = 0;
            checkedListBoxItems.SelectedIndexChanged += checkedListBoxItems_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(412, 588);
            button1.Name = "button1";
            button1.Size = new Size(163, 58);
            button1.TabIndex = 1;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonApply_Click;
            // 
            // button2
            // 
            button2.Location = new Point(615, 588);
            button2.Name = "button2";
            button2.Size = new Size(163, 58);
            button2.TabIndex = 2;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCancel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(903, 628);
            button3.Name = "button3";
            button3.Size = new Size(135, 40);
            button3.TabIndex = 6;
            button3.Text = "Click Here";
            button3.Click += buttonHelp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(849, 588);
            label1.Name = "label1";
            label1.Size = new Size(238, 25);
            label1.TabIndex = 4;
            label1.Text = "Don't see the one you want?";
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(615, 95);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(539, 480);
            checkedListBox1.TabIndex = 5;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(213, 41);
            label2.Name = "label2";
            label2.Size = new Size(174, 30);
            label2.TabIndex = 7;
            label2.Text = "Screw Channels";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(824, 41);
            label3.Name = "label3";
            label3.Size = new Size(149, 30);
            label3.TabIndex = 8;
            label3.Text = "Healing Caps";
            // 
            // CsvSelectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1184, 694);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(checkedListBox1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkedListBoxItems);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CsvSelectionForm";
            Text = "Library Selection";
            ResumeLayout(false);
            PerformLayout();
        }

        private void checkedListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private CheckedListBox checkedListBox1;
        private Label label2;
        private Label label3;
    }
}
