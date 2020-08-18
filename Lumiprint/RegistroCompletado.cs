﻿using System;
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
    public partial class RegistroCompletado : Form
    {
        public RegistroCompletado()
        {
            InitializeComponent();
        }

        private void Entendido_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistroCompletado_Load(object sender, EventArgs e)
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

    }

}
