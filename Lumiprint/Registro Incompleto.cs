using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Vista.Properties;
using Logica;
using System.Windows.Forms;

namespace Vista
{
    public partial class Registro_Incompleto : Form
    {
        public Registro_Incompleto()
        {
            InitializeComponent();
        }

        private void Registro_Incompleto_Load(object sender, EventArgs e)
        {

        }
        private void Entendido_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}
