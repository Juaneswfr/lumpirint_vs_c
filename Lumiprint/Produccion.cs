using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Vista.Properties;
using System.Windows.Forms;
using Logica;

namespace Vista
{
    public partial class Produccion : Form
    {
        public static Empleado Empleado;


        public Produccioon ComActual { get; set; }
        public Produccioon ComSeleccionado { get; set; }
        public Inventario InvActua { get; set; }
        public Inventario InvSeleccionad { get; set; }
        public Inventario InvId { get; set; }
        public Inventario InvIdAc { get; set; }
        public Inventario In { get; set; }
        public Inventario InP{ get; set; }
        public Maquinaria MaquiSelect { get; set; }


        public Produccion(Empleado X)
        {
            Empleado = X;

            InitializeComponent();
        }

        private void Produccion_Load(object sender, EventArgs e)
        {
            Inventario PInventario = new Inventario();
            PInventario.IdPzSelect(CajaCodigo);

            Maquinaria PMaquinaria = new Maquinaria();
            PMaquinaria.IdMaquina(CajaMaqui);
        }

        private void RegistrarProduccion_Click(object sender, EventArgs e)
        {
            Produccioon PProduccion = new Produccioon();
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {

                Int64 io = Convert.ToInt64(ProducID.Text);
                ComSeleccionado = Produccioon.Autoincrementar(io);


                    if (ComSeleccionado != null)
                    {
                        ComActual = ComSeleccionado;
                        ProducID.Text = Convert.ToString(ComSeleccionado.Id_Produccion);

                            panelMaqui.Visible = true;
                            Registrar.Visible = true;

                        

                    }

                }
            }

        

        


        private void label15_Click(object sender, EventArgs e)
        {
        
        }

    void Limpiar()
    {
        CajaNomProduc.Clear();
        CajaValorProduc.Clear();
        CajaTam.Clear();
        RichDescrip.Clear();
        CajaCantNece.Clear();
    }

        private void Registrar_Click(object sender, EventArgs e)
        {
            Produccioon PProduccion = new Produccioon();

            if (CajaNomProduc.Text == "" | CajaValorProduc.Text == ""  
                | CajaTam.Text == "" | RichDescrip.Text == "")
            {
                SeguridadCompleteCam formx = new SeguridadCompleteCam();
                formx.ShowDialog();
            }
            else
            {
            
            if (dataProducInv.Rows.Count > 0)
            {
                PProduccion.Id_Ma = Convert.ToInt64(label2.Text);
                PProduccion.Tipo_Ma = Convert.ToString(LaMaqui.Text);
                PProduccion.Nombre_Producto = Convert.ToString(CajaNomProduc.Text);
                PProduccion.Tamaño = Convert.ToString(CajaTam.Text);
                PProduccion.Valor_Producto = Convert.ToInt64(CajaValorProduc.Text);
                PProduccion.Descripcion = Convert.ToString(RichDescrip.Text);
                PProduccion.Empresa = Convert.ToString(CajaEmpresa.Text);
                PProduccion.Id_Produccion = Convert.ToInt64(LaIdProducc.Text);


                int ResultadoReeeg = Produccioon.ActualizarProduccion(PProduccion);
                if (ResultadoReeeg > 0)
                {

                    RegistroCompletado Completo = new RegistroCompletado();
                    Completo.ShowDialog();

                    Limpiar();
                    PanelProduccion.Visible = false;

                }
                else
                {
                    Registro_Incompleto Incompleto = new Registro_Incompleto();
                    Incompleto.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("Agregue UNA materia prima");
            }
           
            }
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            GestionarVentas form = new GestionarVentas(Empleado);
            form.Show();
            this.Hide();
        }

        private void CajaCodigo_SelectedIndexChanged (object sender, EventArgs e)
        {
            Int64 Nom = Convert.ToInt64(CajaCodigo.Text);
            In = Inventario.ConsulNomProd(Nom);
            if (In != null)
            {
                InP = In;
                LaNomProd.Text = Convert.ToString(In.Tipo_de_pieza);

                Int64 oi = Convert.ToInt64(CajaCodigo.Text);
                InvSeleccionad = Inventario.ConsulEXISTEN(oi);


                if (InvSeleccionad != null)
                {
                    InvActua = InvSeleccionad;
                    CantInvEx.Text = Convert.ToString(InvSeleccionad.Cantidad_Existente);

                    Int32 a = Convert.ToInt32(CantInvEx.Text);
 
                    if (a < 5)
                    {
                        MessageBox.Show("Quedan pocas unidades de este producto: "+a+".");
                    }
                }
            }
        }

        void OrdenFilasTT()
        {
            dataProducInv.Columns["Id_pz"].DisplayIndex = 1;
            dataProducInv.Columns["Tipo_de_pieza"].DisplayIndex = 2;
            dataProducInv.Columns["Cantidad_Necesitada"].DisplayIndex = 3;
            dataProducInv.Columns["Id_Produccion"].DisplayIndex = 4;
        }

        void NombreColumnsTT()
        {
            dataProducInv.Columns["Id_pz"].HeaderText = "Producto";
            dataProducInv.Columns["Tipo_de_pieza"].HeaderText = "NombreProducto";
            dataProducInv.Columns["Cantidad_Necesitada"].HeaderText = "Cantidad";
            dataProducInv.Columns["Id_Produccion"].HeaderText = "Produccion";
        }
        void FilasPrimerTable()
        {
            DatagriedProducc.Columns["Id_Produccion"].HeaderText = "Código";
            DatagriedProducc.Columns["Id_Ma"].HeaderText = "Código maquinaria";
            DatagriedProducc.Columns["Tipo_Ma"].HeaderText = "Tipo de maquinaria";
            DatagriedProducc.Columns["Nombre_Producto"].HeaderText = "Nombre producto";
            DatagriedProducc.Columns["Valor_Producto"].HeaderText = "Valor";
            DatagriedProducc.Columns["Descripcion"].HeaderText = "Descripción";

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Produc_Invent PProducInvent = new Produc_Invent();

            if (CajaCantNece.Text == "" | CajaCodigo.Text == "-Seleccione ID-" | CajaCodigo.Text == "")
            {
                SeguridadCompleteCam formx = new SeguridadCompleteCam();
                formx.ShowDialog();
            }
            else
            {
                Int32 a = Convert.ToInt32(CantInvEx.Text);
                Int32 b = Convert.ToInt32(CajaCantNece.Text);

                if (b > a)
                {
                    MessageBox.Show("Solo tienes unidades :" + a + " de este producto");
                }
                else
                {

                    PProducInvent.Cantidad_Necesitada = Convert.ToInt64(CajaCantNece.Text);
                    PProducInvent.Id_Produccion = Convert.ToInt64(LaIdProducc.Text);
                    PProducInvent.Id_pz = Convert.ToInt64(CajaCodigo.Text);
                    PProducInvent.Tipo_de_pieza = LaNomProd.Text;

                    int ResultadoReeeg = Produc_Invent.RegistrarProduccTT(PProducInvent);
                    if (ResultadoReeeg > 0)
                    {
                        dataProducInv.DataSource = Produc_Invent.ConsultarProduccTT(LaIdProducc.Text);
                        OrdenFilasTT();
                        NombreColumnsTT();

                        dataProducInv.Columns[0].Visible = false;

                        CajaCantNece.Text = "";
                        CajaCodigo.Text = "-Seleccione ID-";
                    }
                    else
                    {
                        Registro_Incompleto Incompleto = new Registro_Incompleto();
                        Incompleto.ShowDialog();
                    }
                }
            }
        }

        private void CajaCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
            if (e.KeyChar != (char)Keys.Return)
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaValorProduc_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
        }

        private void CajaCantExis_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
        }

        private void CajaCantNece_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
        }

        private void RegistrarProduccion_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarProduccionP));
        }

        private void RegistrarProduccion_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarProduccion));
        }

        private void ActualizarCompra_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActualizarProduccionP));
        }

        private void ActualizarCompra_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActualizarProduccion));
        }

        private void GenerarReporte_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.GenerarReporteP));
        }

        private void GenerarReporte_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.GenerarReporte));
        }

        private void Registrar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarP));
        }

        private void Registrar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar));
        }

        private void Actualizar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActualizaarP));
        }

        private void Actualizar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizaar));
        }

        private void Agregar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources._PP));
        }

        private void Agregar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources._));
        }

        private void Atras_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.AtrasP));
        }

        private void Atras_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Atras));
        }

        private void ConsultarCompras_Click(object sender, EventArgs e)
        {
            DatagriedProducc.DataSource = Produccioon.ConsultarProduccion(Consultar.Text);
            FilasPrimerTable();
        }

        private void PanelProduccion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CajaMaqui_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 Mak = Convert.ToInt64(CajaMaqui.Text);
            MaquiSelect = Maquinaria.ObtenerTipoMaqui(Mak);

            if (MaquiSelect != null)
            {
                LaMaqui.Text = MaquiSelect.Tipo_Ma;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            Produccioon PProduccion = new Produccioon();
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {

                if(CajaMaqui.Text == "-Seleccione-" )
                {
                SeguridadCompleteCam formx = new SeguridadCompleteCam();
                formx.ShowDialog();
                }
                else
                {
                    
                    PProduccion.Id_Produccion = Convert.ToInt64(ProducID.Text);
                    PProduccion.Empresa = Convert.ToString(CajaEmpresa.Text);
                    PProduccion.Id_Ma = Convert.ToInt64(CajaMaqui.Text);
                    PProduccion.Tipo_Ma = Convert.ToString(LaMaqui.Text);

                    LaIdProducc.Text = ProducID.Text;
                    TipoMaquinaria.Text = LaMaqui.Text;
                    label2.Text = CajaMaqui.Text;

                    int ResultadoReg = Produccioon.RegistrarProducc(PProduccion);
                    if (ResultadoReg > 0)
                    {
                        PanelProduccion.Visible = true;
                        Registrar.Visible = true;
                        panelMaqui.Visible = false;
                        CajaMaqui.Text = "-Seleccione-";
                        CajaCodigo.Text = "-Seleccione ID-";

                    }
                }

                }

            }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            panelMaqui.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GenerarReporte_Click(object sender, EventArgs e)
        {

        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DatagriedProducc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataProducInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ActualizarCompra_Click(object sender, EventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {

        }
        }


       
        
        }

        

        
    

        

