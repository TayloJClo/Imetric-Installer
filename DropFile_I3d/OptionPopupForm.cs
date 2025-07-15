using System;
using System.Windows.Forms;

namespace DropFile_I3d
{
    public partial class OptionPopupForm : Form
    {
        public string SelectedOption { get; private set; } = string.Empty;

        public OptionPopupForm()
        {
            InitializeComponent();
            comboBoxOptions.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SelectedOption = comboBoxOptions.SelectedItem?.ToString() ?? string.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}


