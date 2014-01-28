using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphicalHelloWorld
{
    public partial class GraphicalHellowWorld : Form
    {
        public GraphicalHellowWorld()
        {
            InitializeComponent();
            // Hide the label to prevent obscuring graphical Hello World
            this.label1.Visible = false;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object
            e.Graphics.DrawString("Graphical Hello World",
                new System.Drawing.Font("Arial", 16.0F, FontStyle.Italic),
                new SolidBrush(ForeColor), 10.0F, 10.0F);
        }

        private void GraphicalHellowWorld_Load(object sender, EventArgs e)
        {

        }
    }
}
