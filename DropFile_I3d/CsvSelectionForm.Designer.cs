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
            checkedListBoxItems = new CheckedListBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // checkedListBoxItems
            // 
            checkedListBoxItems.FormattingEnabled = true;
            checkedListBoxItems.Location = new Point(12, 12);
            checkedListBoxItems.Name = "checkedListBoxItems";
            checkedListBoxItems.Size = new Size(601, 480);
            checkedListBoxItems.TabIndex = 0;
            checkedListBoxItems.SelectedIndexChanged += checkedListBoxItems_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(100, 525);
            button1.Name = "button1";
            button1.Size = new Size(163, 58);
            button1.TabIndex = 1;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonApply_Click;
            // 
            // button2
            // 
            button2.Location = new Point(365, 525);
            button2.Name = "button2";
            button2.Size = new Size(163, 58);
            button2.TabIndex = 2;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCancel_Click;
            // 
            // CsvSelectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 613);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkedListBoxItems);
            Name = "CsvSelectionForm";
            Text = "Library Selection";
            ResumeLayout(false);
        }



        private void checkedListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection changes if needed
        }
        private Button button1;
        private Button button2;
    }
}
