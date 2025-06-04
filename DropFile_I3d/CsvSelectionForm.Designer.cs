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
            SuspendLayout();
            // 
            // checkedListBoxItems
            // 
            checkedListBoxItems.CheckOnClick = true;
            checkedListBoxItems.FormattingEnabled = true;
            checkedListBoxItems.Location = new Point(51, 12);
            checkedListBoxItems.Name = "checkedListBoxItems";
            checkedListBoxItems.Size = new Size(533, 480);
            checkedListBoxItems.TabIndex = 0;
            checkedListBoxItems.SelectedIndexChanged += checkedListBoxItems_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 512);
            button1.Name = "button1";
            button1.Size = new Size(163, 58);
            button1.TabIndex = 1;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonApply_Click;
            // 
            // button2
            // 
            button2.Location = new Point(181, 512);
            button2.Name = "button2";
            button2.Size = new Size(163, 58);
            button2.TabIndex = 2;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCancel_Click;
            // 
            // button3
            // 
            button3.Location = new Point(422, 540);
            button3.Name = "button3";
            button3.Size = new Size(137, 37);
            button3.TabIndex = 3;
            button3.Text = "Click here";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonHelp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(375, 512);
            label1.Name = "label1";
            label1.Size = new Size(238, 25);
            label1.TabIndex = 4;
            label1.Text = "Don't see the one you want?";
            // 
            // CsvSelectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(626, 619);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkedListBoxItems);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CsvSelectionForm";
            Text = "Library Selection";
            ResumeLayout(false);
            PerformLayout();
        }



        private void checkedListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection changes if needed
        }
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}
