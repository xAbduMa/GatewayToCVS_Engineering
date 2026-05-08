using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class ComboBoxDialogueForm : Form
    {
        public ComboBoxDialogueForm()
        {
            InitializeComponent();
        }
        public ComboBoxDialogueForm(string title, string prompt, List<string> items)
        {
            InitializeComponent();
            this.Text = title;
            PromptLabel.Text = prompt; // Add a Label for the message
            ItemsComboBox.Items.AddRange(items.ToArray()); // Add your selection options
        }
        private void ComboBoxDialogueForm_Load(object sender, EventArgs e)
        {

        }
        public string SelectedItem { get; private set; }



        private void OKButton_Click(object sender, EventArgs e)
        {
            // Store the selection before closing
            SelectedItem = ItemsComboBox.SelectedItem?.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
