using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormsIO
{
    public partial class Popup : Form
    {

        private string _userName = "";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public Popup()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _userName = nameTextBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
