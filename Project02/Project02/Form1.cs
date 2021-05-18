using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            //Require there to be an entry in the name text box for the user to continue
            if (nameTextBox.Text != "")
            {
                this.Hide();
                Form2 f2 = new Form2(nameTextBox.Text);
                f2.ShowDialog();
                Close();
            }
            else
            {
                //If there was no name entered into the textbox, display this warning
                warningLabel.Visible = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Close the form ifthe cancel button is pressed
            Close();
        }
    }
}
