using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Vista.Properties;
using System.Windows.Forms;

namespace Vista
{
    public partial class SeguridadCerrarSesion : Form
    {
        public SeguridadCerrarSesion()
        {
            InitializeComponent();
        }

        private void Si_Click(object sender, EventArgs e)
        {
            Iniciodesesion Si = new Iniciodesesion();
            Si.Show();
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            MenuPrincipal No = new MenuPrincipal(MenuPrincipal.Empleado);
            No.Show();
            this.Close();
        }

        private void Si_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.SiP));
        }

        private void Si_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Si));
        }

        private void No_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.NoP));
        }

        private void No_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.No));
        }

        private void SeguridadCerrarSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
