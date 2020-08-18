using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;


namespace Vista
{
    public partial class SCompleteLaCompra : Form
    {

        public static Empleado Empleado;
        private SCompleteLaCompra Form1 = null;
        private GestionarCompras Form2 = null;

        public SCompleteLaCompra()
        {
            InitializeComponent();
        }

        private void Si_Click(object sender, EventArgs e)
        {
            Pedido_Compra.EliminarPC(0);
            Form1.Close();
            Form1 = null;
            if (Form2 == null)
            {
             return;
            }
                 
        }

        private void SCompleteLaCompra_Load(object sender, EventArgs e)
        {
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
