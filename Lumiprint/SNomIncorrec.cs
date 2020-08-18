using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vista.Properties;

namespace Vista
{
    public partial class SNomIncorrec : Form
    {
        public SNomIncorrec()
        {
            InitializeComponent();
        }

        private void Entendido_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SNomIncorrec_Load(object sender, EventArgs e)
        {

        }

        private void Entendido_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.EntendidoP));
        }

        private void Entendido_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Entendido));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
