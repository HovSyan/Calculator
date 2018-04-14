using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string input;
        public string Input { get { return this.input; } set { this.input = value; } }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = Messeges.HELP_MESSAGE;
            MessageBox.Show(message);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String messasge = Messeges.ABOUT_MESSAGE;
            MessageBox.Show(messasge);
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            input = inputBox.Text;
            outputBox.Text = Methods.Calculate(input).ToString();
        }

        private void inputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                doneButton_Click(sender, e);
            }
        }
    }
}
