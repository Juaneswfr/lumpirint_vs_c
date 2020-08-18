using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;
using Vista.Properties;

namespace Vista
{
    public partial class MenuPrincipal : Form
    {
        public static Empleado Empleado;

        public MenuPrincipal(Empleado X)
        {
            Empleado = X;

            InitializeComponent();
            switch (X.Nombre_cargo)
            {
                case TipoCargo.Gerente:
                    ConsultarMaquina.Visible = false;
                    CMaquinariaLabel.Visible = false;
                    ConsultarMateriaPrima.Visible = false;
                    CmateriaLabel.Visible = false;
                    ConsultarEmpleados.Visible = false;
                    CempleadoLabel.Visible = false;
                    ConsultarMaquina.Visible = false;
                    CMaquinariaLabel.Visible = false;
                    GestionarVentas.Visible = false;
                    GVentasLabel.Visible = false;
                    ConsultaProveedor.Visible = false;
                    CProveedorLabel.Visible = false;
                    ConsultarCompra.Visible = false;
                    CcomprasLabel.Visible = false;
                    CargoLabel.Text = Empleado.Nombre_cargo.ToString();
                    NomApLabel.Text = Empleado.Nombre_em.ToString();
                    ApeEmLabel.Text = Empleado.Apellido_em.ToString();
                    break;
                case TipoCargo.Administrador:
                    ConsultarMateriaPrima.Location = new Point(890, 232);
                    CmateriaLabel.Location = new Point(875, 187);
                    GestionarVentas.Location = new Point(900, 450);
                    GVentasLabel.Location = new Point(890, 410);
                    ConsultarMaquina.Location = new Point(422, 450);
                    CMaquinariaLabel.Location = new Point(427, 410);
                    Gempleadoslabel.Location = new Point(430, 187);
                    GestionEmpleados.Location = new Point(440, 232);
                    CargoLabel.Text = Empleado.Nombre_cargo.ToString();
                    NomApLabel.Text = Empleado.Nombre_em.ToString();
                    ApeEmLabel.Text = Empleado.Apellido_em.ToString();
                    ConsultarVenta.Visible = false;
                    CventasLabel.Visible = false;
                    ConsultarCompra.Visible = false;
                    CcomprasLabel.Visible = false;
                    ConsultarEmpleados.Visible = false;
                    CempleadoLabel.Visible = false;
                    ConsultaProveedor.Visible = false;
                    CProveedorLabel.Visible = false;
                    ConsultaProveedor.Visible = false;
                    CProveedorLabel.Visible = false;
                    GestionCompras.Visible = false;
                    Gcompraslabel.Visible = false;
                    Gproveedoreslabel.Visible = false;
                    GestionProveedores.Visible = false;
                    GestionMaquinaria.Visible = false;
                    Gmaquinarialabel.Visible = false;
                    Gestion_Inventario.Visible = false;
                    Gmaterialabel.Visible = false;

                    break;
                case TipoCargo.Diseñador:
                    CargoLabel.Text = Empleado.Nombre_cargo.ToString();
                    NomApLabel.Text = Empleado.Nombre_em.ToString();
                    ApeEmLabel.Text = Empleado.Apellido_em.ToString();
                    GestionCompras.Visible = false;
                    Gcompraslabel.Visible = false;
                    Gproveedoreslabel.Visible = false;
                    GestionProveedores.Visible = false;
                    GestionMaquinaria.Visible = false;
                    Gmaquinarialabel.Visible = false;
                    GestionEmpleados.Visible = false;
                    Gempleadoslabel.Visible = false;
                    Gestion_Inventario.Visible = false;
                    Gmaterialabel.Visible = false;
                    ConsultaProveedor.Visible = false;
                    CProveedorLabel.Visible = false;
                    ConsultarCompra.Visible = false;
                    CcomprasLabel.Visible = false;
                    ConsultarVenta.Visible = false;
                    CventasLabel.Visible = false;
                    break;
                case TipoCargo.Contador:
                    ConsultaProveedor.Location = new Point(278, 450);
                    CProveedorLabel.Location = new Point(294, 410);
                    ConsultarEmpleados.Location = new Point(622, 450);
                    CempleadoLabel.Location = new Point(642, 410);
                    ConsultarCompra.Location = new Point(760, 226);
                    CcomprasLabel.Location = new Point(790, 187);
                    CargoLabel.Text = Empleado.Nombre_cargo.ToString();
                    NomApLabel.Text = Empleado.Nombre_em.ToString();
                    ApeEmLabel.Text = Empleado.Apellido_em.ToString();
                    GestionCompras.Visible = false;
                    Gcompraslabel.Visible = false;
                    Gproveedoreslabel.Visible = false;
                    GestionProveedores.Visible = false;
                    GestionMaquinaria.Visible = false;
                    Gmaquinarialabel.Visible = false;
                    GestionEmpleados.Visible = false;
                    Gempleadoslabel.Visible = false;
                    Gestion_Inventario.Visible = false;
                    Gmaterialabel.Visible = false;
                    GestionarVentas.Visible = false;
                    GVentasLabel.Visible = false;
                    ConsultarMaquina.Visible = false;
                    CMaquinariaLabel.Visible = false;
                    break;

                    
        }

        }
        private void CerrarSesion_Click(object sender, EventArgs e)
        {

                SeguridadCerrarSesion Seguridad = new SeguridadCerrarSesion();
                Seguridad.Show();
                this.Hide();

        }

        private void CerrarSesion_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Cerrar_sesiónP));
        }

        private void CerrarSesion_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Cerrar_sesión));
        }

        private void Min_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.MinP));
        }

        private void Min_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Min));
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void IdemLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void NombLabel_Click(object sender, EventArgs e)
        {

        }

        private void CargoLabel_Click(object sender, EventArgs e)
        {

        }

        private void GestionCompras_Click(object sender, EventArgs e)
        {
            GestionarCompras form = new GestionarCompras(Empleado);
            form.Show();
            this.Hide();
        }

        private void GestionProveedores_Click(object sender, EventArgs e)
        {
            GestionarProveedores form = new GestionarProveedores(Empleado);
            form.Show();
            this.Hide();
        }

        private void GestionMaquinaria_Click(object sender, EventArgs e)
        {
            GestionarMaquinariaa form = new GestionarMaquinariaa(Empleado);
            form.Show();
            this.Hide();
        }

        private void GestionEmpleados_Click(object sender, EventArgs e)
        {
  
            GestionarEmpleados form = new GestionarEmpleados(Empleado);
            form.Show();
            this.Hide();
        }

        private void Gestion_Inventario_Click(object sender, EventArgs e)
        {
            GestionarInventario form = new GestionarInventario(Empleado);
            form.Show();
            this.Hide();
        }

        private void IdCaja_TextChanged(object sender, EventArgs e)
        {
        }

        private void ApeEmLabel_Click(object sender, EventArgs e)
        {

        }

        private void CargoLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void GestionVentas_Click(object sender, EventArgs e)
        {
            GestionarVentas form = new GestionarVentas(Empleado);
            form.Show();
            this.Hide();
        }

        private void Gmaterialabel_Click(object sender, EventArgs e)
        {

        }


        private void ConsultarMateriaPrima_Click(object sender, EventArgs e)
        {
            GestionarInventario form = new GestionarInventario(Empleado);
            form.Show();
            this.Hide();
        }

        private void ConsultarEmpleados_Click(object sender, EventArgs e)
        {
            GestionarEmpleados form = new GestionarEmpleados(Empleado);
            form.Show();
            this.Hide();
        }

        private void ConsultarMaquina_Click(object sender, EventArgs e)
        {
            GestionarMaquinariaa form = new GestionarMaquinariaa(MenuPrincipal.Empleado);
            form.Show();
            this.Hide();
        }

        private void ConsultarVenta_Click(object sender, EventArgs e)
        {
            GestionarVentas form = new GestionarVentas(Empleado);
            form.Show();
            this.Hide();
        }

        private void ConsultaProveedor_Click(object sender, EventArgs e)
        {
            GestionarProveedores form = new GestionarProveedores(Empleado);
            form.Show();
            this.Hide();
        }

        private void ConsultarCompra_Click(object sender, EventArgs e)
        {
            GestionarCompras form = new GestionarCompras(Empleado);
            form.Show();
            this.Hide();
        }

        private void CerrarSesion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = false;
            }

        }

        private void MenuPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
