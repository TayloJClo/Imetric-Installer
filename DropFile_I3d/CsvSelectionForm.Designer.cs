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
            this.checkedListBoxItems = new CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListBoxItems
            // 
            this.checkedListBoxItems.FormattingEnabled = true;
            this.checkedListBoxItems.Location = new Point(12, 12);
            this.checkedListBoxItems.Name = "checkedListBoxItems";
            this.checkedListBoxItems.Size = new Size(250, 424);
            this.checkedListBoxItems.TabIndex = 0;
            this.checkedListBoxItems.SelectedIndexChanged += new EventHandler(checkedListBoxItems_SelectedIndexChanged);
            // 
            // CsvSelectionForm
            // 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.checkedListBoxItems);
            this.Name = "CsvSelectionForm";
            this.Text = "Library Selection";
            this.ResumeLayout(false);
        }

     

        private void checkedListBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection changes if needed
        }
    }
}
