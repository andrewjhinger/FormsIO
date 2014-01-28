using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FormsIO
{
    public partial class FormsIO : Form
    {
        private const string TextFilters = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        private const string BinaryFilters = "All files (*.*)|*.*";

        public FormsIO()
        {
            InitializeComponent();
        }

        private void dialogButton_Click(object sender, EventArgs e)
        {
            Popup myPopup = new Popup();
            if (myPopup.ShowDialog() == DialogResult.OK)
            {
                hiLabel.Text = "Hi, " + myPopup.UserName;
            }
            else
            {
                hiLabel.Text = "So don't tell me your name.";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = binaryCheckBox.Checked ? BinaryFilters : TextFilters;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "";
            saveFileDialog.Title = "Save File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the file.
                if (saveFileDialog.FileName.Length > 0)
                {
                    if (!binaryCheckBox.Checked)
                    {
                        using (StreamWriter streamWriter = new StreamWriter(File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate)))
                        {
                            streamWriter.Write(contentTextBox.Text);
                        }
                    }
                    else
                    {
                        UnicodeEncoding encoding = new UnicodeEncoding();
                        using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate)))
                        {
                            binaryWriter.Write(encoding.GetBytes(contentTextBox.Text));
                        }
                    }
                    MessageBox.Show(Path.GetFileName(saveFileDialog.FileName) + " saved", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = binaryCheckBox.Checked ? BinaryFilters : TextFilters;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FileName = "";
            openFileDialog.Title = "Open File";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open the file.
                if (openFileDialog.FileName.Length > 0)
                {
                    if (!binaryCheckBox.Checked)
                    {

                        // Create a text stream reader connected to the file stream.
                        using (StreamReader streamReader = new StreamReader(File.Open(openFileDialog.FileName, FileMode.Open)))
                        {
                            // Read the data to the end of the stream.
                            contentTextBox.Text = streamReader.ReadToEnd();
                        }
                    }
                    else
                    {
                        // Create a binary stream reader connected to the file stream.
                        using (BinaryReader binaryReader = new BinaryReader(File.Open(openFileDialog.FileName, FileMode.Open)))
                        {
                            // Get the length of the file in bytes.
                            long fileLength = new FileInfo(openFileDialog.FileName).Length;
                            // Prepare an encoding object for translating the data read from the file.
                            UTF8Encoding encoding = new UTF8Encoding();
                            // Convert the byte data into a format we can read.
                            contentTextBox.Text = encoding.GetString(binaryReader.ReadBytes((int)fileLength));
                        }
                        MessageBox.Show(Path.GetFullPath(openFileDialog.FileName) + " loaded", this.Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


        }
    }
}
