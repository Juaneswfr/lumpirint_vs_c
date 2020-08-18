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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Vista
{
    public partial class GestionarVentas : Form
    {
        public static Empleado Empleado;

        public Produccioon ComProduc { get; set; }

        public PedidoCliente Ab { get; set; }
        public PedidoCliente Cd { get; set; }

        public PedidoCliente ComSeleccionad { get; set; }
        public PedidoCliente ComActua{ get; set; }

        public Cliente ConSeleccionad { get; set; }
        public Cliente ConActua { get; set; }

        public PedidoCliente Totaal { get; set; }
        public PedidoCliente Totaa { get; set; }

        public Empleado H { get; set; }
        public Empleado G { get; set; }

        public PedidoCliente ComActual { get; set; }
        public PedidoCliente ComSeleccionado { get; set; }

        public PedidoCliente Est { get; set; }
        public PedidoCliente Esta { get; set; }

        public GestionarVentas(Empleado X)
        {
            Empleado = X;

            InitializeComponent();
            switch (X.Nombre_cargo)
            {
                case TipoCargo.Gerente:
                    RegistrarVenta.Visible = false;
                    ActualizarVenta.Visible = false;
                    EmpleNom.Text = Empleado.Nombre_em.ToString();
                    EmpleApe.Text = Empleado.Apellido_em.ToString();
                    break;

                case TipoCargo.Contador:
                    RegistrarVenta.Visible = false;
                    ActualizarVenta.Visible = false;
                    EmpleNom.Text = Empleado.Nombre_em.ToString();
                    EmpleApe.Text = Empleado.Apellido_em.ToString();
                    break;

                case TipoCargo.Diseñador:
                    EmpleNom.Text = Empleado.Nombre_em.ToString();
                    EmpleApe.Text = Empleado.Apellido_em.ToString();
                    break;

                case TipoCargo.Administrador:
                    EmpleNom.Text = Empleado.Nombre_em.ToString();
                    EmpleApe.Text = Empleado.Apellido_em.ToString();
                    break;
            }
        }

        PedidoCliente PPedidoCliente = new PedidoCliente();

        private void Atras_Click(object sender, EventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                MenuPrincipal form = new MenuPrincipal(MenuPrincipal.Empleado);
                form.Show(this);
                this.Hide();
            }
            else
            {
                PanelRegistrarVentas.Enabled = false;
                panelELiVen.Location = new Point(396, 133);
                panelELiVen.Visible = true;


                Atras.Enabled = false;
                ActualizarVenta.Enabled = false;
                RegistrarVenta.Enabled = false;
                GenerarReporte.Enabled = false;
                Produccion.Enabled = false;
                ConsultarVentas.Enabled = false;

            }
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

        private void GestionarVentas_Load(object sender, EventArgs e)
        {
            Cliente PCliente = new Cliente();
            PCliente.IndentiSelectCli(CajaIndenti);

            
        }

        public float[] GetTamañoColumnas(DataGridView DG)
        {
            float[] Valor = new float[DG.ColumnCount];
            for (int i = 0; i < DG.ColumnCount; i++)
            {
                Valor[i] = (float)DG.Columns[i].Width;
            }
            return Valor;
        }
        public void ExportarPDf(Document DC)
        {
            DataTerceraTaVen.Columns.RemoveAt(0);
            DataTerceraTaVen.Columns.RemoveAt(0);
            int i, j;
            PdfPTable PdTabla = new PdfPTable(DataTerceraTaVen.Columns.Count);
            PdTabla.DefaultCell.Padding = 3;
            float[] HW = GetTamañoColumnas(DataTerceraTaVen);
            PdTabla.SetWidths(HW);
            PdTabla.WidthPercentage = 100;
            PdTabla.DefaultCell.BorderWidth = 2;
            PdTabla.HorizontalAlignment = Element.ALIGN_CENTER;
            BaseColor b = new BaseColor(230, 141, 55);
            PdTabla.DefaultCell.BorderColor = b;
            for (i = 0; i < DataTerceraTaVen.ColumnCount; i++)
            {
                PdTabla.AddCell(DataTerceraTaVen.Columns[i].HeaderText);

            }
            PdTabla.HeaderRows = 1;
            PdTabla.DefaultCell.BorderWidth = 1;
            BaseColor a = new BaseColor(162, 205, 100);
            PdTabla.DefaultCell.BorderColor = a;
            for (i = 0; i < DataTerceraTaVen.Rows.Count; i++)
            {
                for (j = 0; j < DataTerceraTaVen.Columns.Count; j++)
                {
                    if (DataTerceraTaVen[j, i].Value != null)
                    {

                        PdTabla.AddCell(new Phrase(DataTerceraTaVen[j, i].Value.ToString()));

                    }

                }
                PdTabla.CompleteRow();

            }
            DC.Add(PdTabla);

        }
        private void En_PDF()
        {
            try
            {
                Document doc = new Document(PageSize.A4, 10, 10, 50, 25);
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                string x = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                GuardarArchivo.InitialDirectory = x;
                GuardarArchivo.FileName = "Venta No_" + LaCodVen.Text + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + DateTime.Now.ToString("hhmm") + ".pdf";
                GuardarArchivo.DefaultExt = ".pdf";
                GuardarArchivo.Filter = "pdf files (*.pdf)|*.pdf| All Files (*.*)|*.*";
                GuardarArchivo.FilterIndex = 2;
                GuardarArchivo.RestoreDirectory = true;

                string Nombre = "";
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    Nombre = GuardarArchivo.FileName;
                    Documento Guardado = new Documento();
                    Guardado.ShowDialog(); ;
                }
                if (Nombre.Trim() != "")
                {
                    BaseColor Naranja = new BaseColor(230, 141, 55);
                    BaseColor Verde = new BaseColor(162, 205, 100);
                    FileStream Arv = new FileStream(Nombre,
                        FileMode.OpenOrCreate,
                        FileAccess.ReadWrite,
                        FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, Arv);
                    doc.Open();
                    byte[] bytesImagen = new System.Drawing.ImageConverter().ConvertTo(Resources.Logotipo, typeof(byte[])) as byte[];
                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(bytesImagen);
                    imagen.Alignment = Element.ALIGN_CENTER;
                    imagen.ScaleAbsolute(620f, 80f);
                    Chunk Ch = new Chunk("Venta No." + LaCodVen.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, Naranja));
                    Chunk Linea = new Chunk("*********************************************************", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD));
                    Paragraph P1 = new Paragraph(Ch);
                    Chunk Re = new Chunk("Reporte realizado por: " + Empleado.Nombre_em + " " + Empleado.Apellido_em + "       Cargo que desempeña:" + Empleado.Nombre_cargo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P2 = new Paragraph(Re);
                    Chunk Fecha = new Chunk("Fecha y hora:" + DateTime.Now.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P3 = new Paragraph(Fecha);

                    Chunk Venta = new Chunk("Estado: " + ComboEstVen.Text + "       Cliente: " + laNommcli.Text + " " + laApeeCli.Text + "       Documento: " + NumeroDocCli.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Naranja));
                    Paragraph P4 = new Paragraph(Venta);
                    Chunk Venta2 = new Chunk("Fecha de realización: " + LafeRVen.Text + "       Fecha de entrega: " + LaFE.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P5 = new Paragraph(Venta2);
                    Chunk Venta3 = new Chunk("SubTotal: " + CajaSubTotaal.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P6 = new Paragraph(Venta3);
                    Chunk Venta4 = new Chunk("Iva: " + CajaIva.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Naranja));
                    Paragraph P7 = new Paragraph(Venta4);
                    Chunk Venta5 = new Chunk("Valor Total: " + CajaaValorTPC.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P8 = new Paragraph(Venta5);
                    Chunk Venta6 = new Chunk("Abono: " + CajaAbono.Text + "       Saldo: "+CajaSaldo.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Naranja));
                    Paragraph P9 = new Paragraph(Venta6);
                    P1.Alignment = Element.ALIGN_CENTER; P2.Alignment = Element.ALIGN_CENTER; P3.Alignment = Element.ALIGN_CENTER; P4.Alignment = Element.ALIGN_CENTER; P5.Alignment = Element.ALIGN_CENTER; P6.Alignment = Element.ALIGN_RIGHT; P7.Alignment = Element.ALIGN_RIGHT; P8.Alignment = Element.ALIGN_RIGHT; P9.Alignment = Element.ALIGN_CENTER;
                    doc.Add(imagen);
                    doc.Add(new Paragraph(Linea));
                    doc.Add(P1);
                    doc.Add(P2);
                    doc.Add(P3);
                    doc.Add(new Paragraph(Linea));
                    doc.Add(P4);
                    doc.Add(P5);
                    doc.Add(new Paragraph(Linea));
                    doc.Add(new Paragraph("                       "));
                    ExportarPDf(doc);
                    doc.Add(new Paragraph("                       "));
                    doc.Add(P9);
                    doc.Add(P6);
                    doc.Add(P7);
                    doc.Add(P8);
                    doc.AddCreationDate();
                    doc.Close();
                    Process.Start(Nombre);
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("El documento no se puede abrir porque ya esta en uso, Cierre el documento que tenga el mismo nombre.", ex.Message);
            }
        }

        private void GenerarReporte_Click(object sender, EventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                if (DatagriedVen.Rows.Count == 0)
                {
                    MessageBox.Show("Realice una consulta para poder generar un reporte");
                }
                else
                {
                    En_PDF();
                }
            }
            else
            {
                PanelRegistrarVentas.Enabled = false;
                panelELiVen.Visible = true;
                panelELiVen.Location = new Point(396, 133);

                Atras.Enabled = false;
                ActualizarVenta.Enabled = false;
                RegistrarVenta.Enabled = false;
                GenerarReporte.Enabled = false;
                Produccion.Enabled = false;
                ConsultarVentas.Enabled = false;

            }
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

        private void RegistrarVenta_Click(object sender, EventArgs e)
        {

            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                PanelRegistrarVentas.Visible = false;
                Int64 io = Convert.ToInt64(LIdPediCli.Text);
                Cd = PedidoCliente.AutoincrementarCli(io);

                if (Cd != null)
                {
                    Ab = Cd;
                    LIdPediCli.Text = Convert.ToString(Cd.Id_Pcli);
                    panelCli.Visible = true;
                    ComboIdProducc.Visible = true;
                    Lacodp.Visible = true;
                    LaProdc.Visible = true;
                    LaPr.Visible = true;
                    CajaPrcom.Visible = true;
                    LaDes.Visible = true;
                    CajatpDes.Visible = true;
                    LaCant.Visible = true;
                    richObserva.Enabled = true;
                    CajaFechaEnVen.Visible = true;
                    CajaCantVendida.Visible = true;
                    LaVp.Visible = true;
                    CajaValorP.Visible = true;
                    LaVtc.Visible = true;
                    CajaValorT.Visible = true;

                }

                else
                {

                }
            }
            else
            {
                PanelRegistrarVentas.Enabled = false;
                panelELiVen.Visible = true;
                panelELiVen.Location = new Point(396, 133);

                Atras.Enabled = false;
                ActualizarVenta.Enabled = false;
                RegistrarVenta.Enabled = false;
                GenerarReporte.Enabled = false;
                Produccion.Enabled = false;
                ConsultarVentas.Enabled = false;
            }

        }

        private void Limpiar()
        {

        }

        private void ActualizarVenta_Click(object sender, EventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                if (DatagriedVen.SelectedRows.Count == 1)
                {
                    Int64 Ho = Convert.ToInt64(DatagriedVen.CurrentRow.Cells[0].Value);
                    ComSeleccionado = PedidoCliente.ObtenerPedidoCliente(Ho);

                    if (ComSeleccionado != null & ComSeleccionado.Estado_Pcli == "No pago")
                    {

                        PanelRegistrarVentas.Visible = true;
                        Registrar.Visible = false;
                        Actualizar.Visible = true;
                        LaFE.Location = new Point(51, 476);
                        LaFE.Visible = true;
                        CajaFechaEnVen.Visible = false;
                        Actualizar.Location = new Point(100, 533);
                        ComboEstVen.Text = Convert.ToString(ComSeleccionado.Estado_Pcli);
                        ComboEstVen.Enabled = false;
                        LafeRVen.Text = ComSeleccionado.Fecha_Realizacion_Pcli;
                        LaFE.Text = Convert.ToString(ComSeleccionado.Fecha_Entrega_Pcli);
                        LaCodVen.Text = Convert.ToString(ComSeleccionado.Id_Pcli);
                        CajaSubTotaal.Text = Convert.ToString(ComSeleccionado.Subtotal_Pcli);
                        richObserva.Text = ComSeleccionado.Observaciones;
                        CajaaValorTPC.Text = Convert.ToString(ComSeleccionado.Valor_Total_Pcli);
                        EmpleNom.Text = ComSeleccionado.Nombre_em;
                        EmpleApe.Text = ComSeleccionado.Apellido_em;
                        CajaIva.Text = Convert.ToString(ComSeleccionado.Iva_Pcli);
                        NumeroDocCli.Text = Convert.ToString(ComSeleccionado.No_Documento_Cl);
                        laNommcli.Text = ComSeleccionado.Nombre_Cl;
                        laApeeCli.Text = ComSeleccionado.Apellido_Cl;
                        CajaSaldo.Text = Convert.ToString(ComSeleccionado.Saldo_Pcli);
                        ComboEstVen.Text = ComSeleccionado.Estado_Pcli;
                        CajaAbono.Text = "0";
                        CajaAbono.Enabled = true;
                        ComboIdProducc.Visible = false;
                        Lacodp.Visible = false;
                        LaProdc.Visible = false;
                        LaPr.Visible = false;
                        CajaPrcom.Visible = false;
                        LaDes.Visible = false;
                        CajatpDes.Visible = false;
                        LaCant.Visible = false;
                        CajaCantVendida.Visible = false;
                        LaVp.Visible = false;
                        CajaValorP.Visible = false;
                        LaVtc.Visible = false;
                        CajaValorT.Visible = false;
                        DataTerceraTaVen.DataSource = PedidoCliente_Inv.ConsultarPedidoCliente_Inv(LaCodVen.Text);
                        Nombresterceratab();
                    }
                    else
                    {
                        MessageBox.Show("Ya se realizaron cambios de esta venta.");
                    }

                }


                else
                {
                    SeleccioneUnaFila form = new SeleccioneUnaFila();
                    form.ShowDialog();
                }
            }
            else
            {
                PanelRegistrarVentas.Enabled = false;
                panelELiVen.Visible = true;
                panelELiVen.Location = new Point(396, 133);

                Atras.Enabled = false;
                ActualizarVenta.Enabled = false;
                RegistrarVenta.Enabled = false;
                GenerarReporte.Enabled = false;
                Produccion.Enabled = false;
                ConsultarVentas.Enabled = false;
            }
            
        }
        void NombresPrimeratab()
        {
            DatagriedVen.Columns["Iva_Pcli"].Visible = false;
            DatagriedVen.Columns["Subtotal_Pcli"].Visible = false;
            DatagriedVen.Columns["Valor_Total_Pcli"].Visible = false;
            DatagriedVen.Columns["Nombre_em"].HeaderText = "Nombre empleado";
            DatagriedVen.Columns["Apellido_em"].HeaderText = "Apellido empleado";
            DatagriedVen.Columns["Nombre_Cl"].HeaderText = "Nombre cliente";
            DatagriedVen.Columns["Apellido_Cl"].HeaderText = "Apellido cliente";
            DatagriedVen.Columns["Id_Pcli"].HeaderText = "Código";
            DatagriedVen.Columns["Observaciones"].HeaderText = "Observaciones";
            DatagriedVen.Columns["Fecha_Realizacion_Pcli"].HeaderText = "Fecha de realizacion";
            DatagriedVen.Columns["No_Documento_em"].Visible = false;
            DatagriedVen.Columns["No_Documento_Cl"].HeaderText = "Documento Cliente";
            DatagriedVen.Columns["Estado_Pcli"].HeaderText = "Estado";
            DatagriedVen.Columns["Fecha_Entrega_Pcli"].HeaderText = "Fecha de entrega";
            DatagriedVen.Columns["Abono_Pcli"].HeaderText = "Abono";
            DatagriedVen.Columns["Saldo_Pcli"].HeaderText = "Saldo";
        }

        void Nombresterceratab()
        {
            DataTerceraTaVen.Columns["Id_PeInv"].Visible = false;
            DataTerceraTaVen.Columns["Id_Pcli"].Visible = false;
            DataTerceraTaVen.Columns["Id_Produccion"].HeaderText = "Código producto";
            DataTerceraTaVen.Columns["Cantidad_PeInv"].HeaderText = "Cantidad";
            DataTerceraTaVen.Columns["Valor_Total_PeInv"].HeaderText = "Valor producto";
            DataTerceraTaVen.Columns["Nombre_Producto"].HeaderText = "Producto";
            DataTerceraTaVen.Columns["Descripcion"].HeaderText = "Descripción";
        }
        private void ConsultarVentas_Click(object sender, EventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                PedidoCliente.EliminarPCli(0);
                if (FEchas.Enabled == false)
                {
                    DatagriedVen.DataSource = PedidoCliente.ConsultarPedidoCli(Consultar.Text);
                    NombresPrimeratab();

                }
                else if (Consultar.Enabled == false)
                {
                    string FechaC;
                    FechaC = FEchas.Value.ToString("yyyy-MM-dd");
                    DatagriedVen.DataSource = PedidoCliente.ConsultarPedidoCli(FechaC);
                    NombresPrimeratab();
                }
                else
                {
                    DatagriedVen.DataSource = PedidoCliente.ConsultarPedidoCli(Consultar.Text);
                    NombresPrimeratab();

                }
                Consultar.Enabled = true;
                FEchas.Enabled = true;
            }
        }

        private void ConsultarVentas_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarVentas));
        }

        private void ConsultarVentas_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarVentasP));
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

        private void CerrarPanelREmpleados_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.CerrarP));
        }

        private void CerrarPanelREmpleados_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Cerrar));
        }

        private void CajaValorP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CerrarPanelREmpleados_Click(object sender, EventArgs e)
        {
            PanelRegistrarVentas.Visible = false;

            CajaValorP.Clear();
        }

        private void CajaDiseño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaTipoPieza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaTamaño_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaTamaño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            PedidoCliente PPedido_Cliente = new PedidoCliente();

            if (CajaaValorTPC.Text == "" | CajaSubTotaal.Text == "" | CajaIva.Text == "")
            {
                MessageBox.Show("Registre algun producto");
            }
            else
            {
                PPedido_Cliente.Id_Pcli = Convert.ToInt64(LaCodVen.Text);
                PPedido_Cliente.Fecha_Realizacion_Pcli = Convert.ToString(LafeRVen.Text);
                PPedido_Cliente.Fecha_Entrega_Pcli = CajaFechaEnVen.Value.ToString();
                PPedido_Cliente.Observaciones = richObserva.Text;
                PPedido_Cliente.Iva_Pcli = Convert.ToInt64(CajaIva.Text);
                PPedido_Cliente.Subtotal_Pcli= Convert.ToInt64(CajaSubTotaal.Text);
                PPedido_Cliente.Valor_Total_Pcli = Convert.ToInt64(CajaaValorTPC.Text);
                PPedido_Cliente.No_Documento_em = Empleado.No_Documento_em;
                PPedido_Cliente.Nombre_em = EmpleNom.Text;
                PPedido_Cliente.Apellido_em = EmpleApe.Text;
                PPedido_Cliente.No_Documento_Cl = Convert.ToInt64(NumeroDocCli.Text);
                PPedido_Cliente.Nombre_Cl = laNommcli.Text;
                PPedido_Cliente.Apellido_Cl = laApeeCli.Text;
                PPedido_Cliente.Abono_Pcli = Convert.ToInt64(CajaAbono.Text);
                PPedido_Cliente.Saldo_Pcli = Convert.ToInt64(CajaSaldo.Text);
                PPedido_Cliente.Estado_Pcli = ComboEstVen.Text;
                LaFE.Text = CajaFechaEnVen.Value.ToString();
                
                int ResultadoReeeg = PedidoCliente.ActualizarPedidoCliente(PPedido_Cliente);
                if (ResultadoReeeg > 0)
                {
                    RegistroCompletado Completo = new RegistroCompletado();
                    Completo.ShowDialog();
                    En_PDF();
                    PanelRegistrarVentas.Visible = false;
                    ComboIdProducc.Items.Clear();
                    Borrar();
                }
                else
                {
                    Registro_Incompleto Incompleto = new Registro_Incompleto();
                    Incompleto.ShowDialog();
                }


            }



        }

        void Borrar()
        {
            CajaPrcom.Text = "";
            CajatpDes.Text = "";
            CajaCantVendida.Text = "";
            richObserva.Text = "";
            ComboIdProducc.Text = "";
            CajaValorP.Text = "";
        }
        private void Actualizar_Click(object sender, EventArgs e)
        {
            PedidoCliente PPedido_Cliente = new PedidoCliente();

                PPedido_Cliente.Id_Pcli = Convert.ToInt64(LaCodVen.Text);
                PPedido_Cliente.Fecha_Realizacion_Pcli = Convert.ToString(LafeRVen.Text);
                PPedido_Cliente.Fecha_Entrega_Pcli = Convert.ToString(LaFE.Text);
                PPedido_Cliente.Observaciones = richObserva.Text;
                PPedido_Cliente.Iva_Pcli = Convert.ToInt64(CajaIva.Text);
                PPedido_Cliente.Subtotal_Pcli= Convert.ToInt64(CajaSubTotaal.Text);
                PPedido_Cliente.Valor_Total_Pcli = Convert.ToInt64(CajaaValorTPC.Text);
                PPedido_Cliente.No_Documento_em = Empleado.No_Documento_em;
                PPedido_Cliente.Nombre_em = EmpleNom.Text;
                PPedido_Cliente.Apellido_em = EmpleApe.Text;
                PPedido_Cliente.No_Documento_Cl = Convert.ToInt64(NumeroDocCli.Text);
                PPedido_Cliente.Nombre_Cl = laNommcli.Text;
                PPedido_Cliente.Apellido_Cl = laApeeCli.Text;
                PPedido_Cliente.Abono_Pcli = Convert.ToInt64(CajaAbono.Text);
                PPedido_Cliente.Saldo_Pcli = Convert.ToInt64(CajaSaldo.Text);
                PPedido_Cliente.Estado_Pcli = ComboEstVen.Text;

                int ResultadoReeeg = PedidoCliente.ActualizarPedidoCliente(PPedido_Cliente);
                if (ResultadoReeeg > 0)
                {
                    ModificacionCompleta Completo = new ModificacionCompleta();
                    Completo.ShowDialog();
                    En_PDF();
                    PanelRegistrarVentas.Visible = false;
                    ComboIdProducc.Items.Clear();
                }
                else
                {
                    ModificacionIncompleta Incompleta = new ModificacionIncompleta();
                    Incompleta.ShowDialog();
                }
        }

        private void panelEmpre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AgreProdu_Click(object sender, EventArgs e)
        {
            PanelRegisCli.Visible = true;
            panelCli.Visible = false;
        }

        private void LafeR_Click(object sender, EventArgs e)
        {

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            PedidoCliente PPedido_Cliente = new PedidoCliente();

            Int64 io = Convert.ToInt64(LaCodVen.Text);
            ComSeleccionad = PedidoCliente.AutoincrementarCli(io);

            if (CajaIndenti.Text == "-Seleccione Cliente-")
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
            }
            else
            {
                if (ComSeleccionad != null)
                {
                    ComActua = ComSeleccionad;
                    LaCodVen.Text = Convert.ToString(ComSeleccionad.Id_Pcli);

                    PPedido_Cliente.Id_Pcli = Convert.ToInt64(LIdPediCli.Text);
                    PPedido_Cliente.No_Documento_em = Empleado.No_Documento_em;
                    PPedido_Cliente.No_Documento_Cl = Convert.ToInt64(CajaIndenti.Text);
                    Produccioon PProduccion = new Produccioon();
                    PProduccion.ObtenerIdX(ComboIdProducc);

                    int ResultadoReg = PedidoCliente.RegistrarPedidoCliente(PPedido_Cliente);
                    if (ResultadoReg > 0)
                    {
                        PanelRegistrarVentas.Visible = true;
                        panelCli.Visible = false;
                        Actualizar.Visible = false;
                        Registrar.Location = new Point(100, 533);
                        NumeroDocCli.Text = CajaIndenti.Text;
                        PPedido_Cliente.Nombre_em = laNommcli.Text;
                        PPedido_Cliente.Apellido_Cl = laApeeCli.Text;
                        ComboEstVen.Text = "No pago";
                        CajaIva.Text = "";
                        CajaaValorTPC.Text = "";
                        CajaSubTotaal.Text = "";
                        ComboEstVen.Enabled = false;
                        LaFE.Visible = false;
                        CajaAbono.Enabled = true;
                        laNommcli.Text = CLienNom.Text;
                        laApeeCli.Text = Convert.ToString(CLienApe.Text);
                        LafeRVen.Text = DateTime.Now.ToString();
                        CajaFechaEnVen.MinDate = DateTime.Now;

                    }
                    else
                    {
                        Registro_Incompleto Incompleto = new Registro_Incompleto();
                        Incompleto.ShowDialog();
                    }
                }

                else
                {

                }

            }
        }

        void LimpiarCliente()
        {
            CajaIdentCli.Clear();
            CajaNomCli.Clear();
            CajaApeCli.Clear();
            CajaCelularCli.Clear();
            CajaDirecCli.Clear();
            CajaCorreoCli.Clear();
            ComboTipoDocu.Text = "     -Seleccione Tipo-";
        }

        private void RegistroClien_Click(object sender, EventArgs e)
        {
            Cliente PCliente = new Cliente();

            if (CajaIdentCli.Text == "" | CajaNomCli.Text == "" | CajaApeCli.Text == ""
                  | CajaCelularCli.Text == "" | CajaDirecCli.Text == "" | CajaCorreoCli.Text == "" |
                  ComboTipoDocu.Text == "     -Seleccione Tipo-")
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
            }

            else
            {

                PCliente.No_Documento_Cl = Convert.ToInt64(CajaIdentCli.Text);
                PCliente.Correo_Cl = CajaCorreoCli.Text;
                PCliente.Nombre_Cl = CajaNomCli.Text;
                PCliente.Apellido_Cl = CajaApeCli.Text;
                PCliente.Celular_Cl = Convert.ToInt64(CajaCelularCli.Text);
                PCliente.Direccion_Cl = CajaDirecCli.Text;
                PCliente.Tipo_Identificacion_Cl = ComboTipoDocu.Text;


                int ResultadoRegs = Cliente.RegistrarCliente(PCliente);

                if (ResultadoRegs > 0)
                {
                    RegistroCompletado Completo = new RegistroCompletado();
                    Completo.ShowDialog();
                    PanelRegisCli.Visible = false;
                    panelCli.Visible = true;
                    CajaIndenti.Items.Clear();
                    
                    PCliente.IndentiSelectCli(CajaIndenti);

                    LimpiarCliente();
                }
                else
                {
                    Registro_Incompleto Incompleto = new Registro_Incompleto();
                    Incompleto.ShowDialog();
                }


            }
        }

        private void ButtonCerrar_Click(object sender, EventArgs e)
        {
            PanelRegisCli.Visible = false;
        }

        private void CajaIndenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 oi = Convert.ToInt64(CajaIndenti.Text);
            ConSeleccionad = Cliente.ObtenerCli(oi);


            if (ConSeleccionad != null)
            {
                ConActua = ConSeleccionad;
                CLienNom.Text = ConSeleccionad.Nombre_Cl;
                CLienApe.Text = ConSeleccionad.Apellido_Cl;
            }

            else
            {
                SeleccioneUnaFila form = new SeleccioneUnaFila();
                form.ShowDialog();
            }
        }

       

        private void CajaCantVendida_TextChanged(object sender, EventArgs e)
        {
            decimal a, b, c;

            if (ComboIdProducc.Text == "-Seleccione ID-")
            {
                MessageBox.Show("Seleccione un codigo");
            }
            else
            {
                if (CajaCantVendida.Text != "")
                {
                    a = Convert.ToDecimal(CajaValorP.Text);
                    b = Convert.ToInt64(CajaCantVendida.Text);
                    c = a * b;
                    CajaValorT.Text = c.ToString();
                }
                else if (CajaCantVendida.Text == "")
                {
                    a = Convert.ToDecimal(CajaValorP.Text);
                    b = 0;
                    c = a * b;
                    CajaValorT.Text = c.ToString();
                }
                else
                {
                    a = Convert.ToDecimal(CajaValorP.Text);
                    b = 0;
                    c = a * b;
                    CajaValorT.Text = c.ToString();
                }
            }
        }

        private void LafeE_Click(object sender, EventArgs e)
        {

        }

        private void ComboEstVen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboEstVen.Text=="No Pago")
            {
                CajaAbono.Enabled = true;
                CajaSaldo.Enabled = false;
            }
            else if (ComboEstVen.Text == "Pago")
            {
                CajaAbono.Text = "0";
                CajaSaldo.Text = "0";
                CajaAbono.Enabled = false;
                CajaSaldo.Enabled = false;
            }
        }

        private void Agregaar_Click(object sender, EventArgs e)
        {
            PedidoCliente_Inv PPedidoCliente_Inv = new PedidoCliente_Inv();

            if (CajaCantVendida.Text == "" | ComboIdProducc.Text == "-Seleccione ID-" | ComboIdProducc.Text == "")
            {
                SeguridadCompleteCam formx = new SeguridadCompleteCam();
                formx.ShowDialog();
            }
            else
            {
                
                PPedidoCliente_Inv.Id_Pcli = Convert.ToInt64(LaCodVen.Text);
                PPedidoCliente_Inv.Id_Produccion = Convert.ToInt64(ComboIdProducc.Text);
                PPedidoCliente_Inv.Cantidad_PeInv = Convert.ToInt64(CajaCantVendida.Text);
                PPedidoCliente_Inv.Valor_Total_PeInv = Convert.ToInt64(CajaValorT.Text);

                int ResultadoReg = PedidoCliente_Inv.RegistrarPeInv(PPedidoCliente_Inv);
                if (ResultadoReg > 0)
                {
                    DataTerceraTaVen.DataSource = PedidoCliente_Inv.ConsultarPedidoCliente_Inv(LaCodVen.Text);
                    Nombresterceratab();
                    CajaCantVendida.Text = "";

                    if (DataTerceraTaVen.Rows.Count > 0)
                    {
                        Totaa = PedidoCliente.CalcularSubTotal(Convert.ToInt64(LaCodVen.Text));
                        CajaSubTotaal.Text = Convert.ToString(Totaa.Subtotal_Pcli);
                    }
                    else
                    {
                        CajaSubTotaal.Text = "";
                        CajaIva.Text = "";
                        CajaaValorTPC.Text = "";
                        CajaSaldo.Text = "";
                    }

                }
            }
        }

        private void CajaSubTotaal_TextChanged(object sender, EventArgs e)
        {
            Int64 a;

            if (CajaSubTotaal.Text != "")
            {
                a = Convert.ToInt64(CajaSubTotaal.Text);

                CajaaValorTPC.Text = a.ToString();
            }
            else
            {
                CajaaValorTPC.Text = "0";
            }
        }

        private void BorrarProducto_Click(object sender, EventArgs e)
        {
            PedidoCliente_Inv Plol = new PedidoCliente_Inv();

            if (DataTerceraTaVen.SelectedRows.Count == 1)
            {

                int result = Convert.ToInt16(DataTerceraTaVen.CurrentRow.Cells[0].Value);
                int resu = PedidoCliente_Inv.EliminarProduc(Convert.ToInt64(result));
                if (resu > 0)
                {
                    DataTerceraTaVen.DataSource = PedidoCliente_Inv.ConsultarPedidoCliente_Inv(LaCodVen.Text);
                    if (DataTerceraTaVen.Rows.Count > 0)
                    {
                        Totaa = PedidoCliente.CalcularSubTotal(Convert.ToInt64(LaCodVen.Text));
                        CajaSubTotaal.Text = Convert.ToString(Totaa.Subtotal_Pcli);
                    }
                    else
                    {
                        CajaSubTotaal.Text = "";
                        CajaIva.Text = "";
                        CajaaValorTPC.Text = "";
                        CajaSaldo.Text = "";
                    }
                }
            }
            else
            {
                SeleccioneUnaFila form = new SeleccioneUnaFila();
                form.ShowDialog();
            }

        }

        private void CajaCantVendida_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaAbono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaSaldo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaCelularCli_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaCelularCli_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaIdentCli_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ComboTipoDocu_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaIndenti_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ComboEstVen_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaIdIn_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaNomCli_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaNomCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaApeCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaAbono_TextChanged(object sender, EventArgs e)
        {
            Int64 a, b, c;
            if (Registrar.Visible == true)
            {
                if (CajaAbono.Text != "")
                {
                    a = Convert.ToInt64(CajaAbono.Text);
                    b = Convert.ToInt64(CajaaValorTPC.Text);
                    c = b - a;

                    if (c > 0)
                    {
                        CajaSaldo.Text = c.ToString();
                        ComboEstVen.Text = "No pago";
                    }
                    else if (c <= 0)
                    {
                        CajaSaldo.Text = "0";
                        ComboEstVen.Text = "Pago";
                    }

                }
                else if (CajaAbono.Text == "")
                {
                    a = 0;
                    b = Convert.ToInt64(CajaaValorTPC.Text);
                    c = b - a;
                    CajaSaldo.Text = c.ToString();

                }
            }
            else if (Actualizar.Visible == true)
            {
                Int64 Ho = Convert.ToInt64(LaCodVen.Text);
                ComSeleccionado = PedidoCliente.ObtenerPedidoCliente(Ho);
                if (ComSeleccionado != null)
                {
                    long SaldoD;
                    SaldoD = Convert.ToInt64(ComSeleccionado.Saldo_Pcli);
                    if (CajaAbono.Text != "")
                    {
                        a = Convert.ToInt64(CajaAbono.Text);
                        b = SaldoD;
                        c = b - a;

                        if (c > 0)
                        {
                            CajaSaldo.Text = c.ToString();
                            ComboEstVen.Text = "No pago";
                        }
                        else if (c <= 0)
                        {
                            CajaSaldo.Text = "0";
                            ComboEstVen.Text = "Pago";
                        }

                    }

                    else if (CajaAbono.Text == "")
                    {
                        a = 0;
                        b = Convert.ToInt64(SaldoD);
                        c = b - a;
                        CajaSaldo.Text = c.ToString();

                    }
                }

            }
        }

        private void Produccion_Click(object sender, EventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                Produccion form = new Produccion(Empleado);
                form.Show();
                this.Hide();
            }
            else
            {
                PanelRegistrarVentas.Enabled = false;
                panelELiVen.Visible = true;
                panelELiVen.Location = new Point(396, 133);

                Atras.Enabled = false;
                ActualizarVenta.Enabled = false;
                RegistrarVenta.Enabled = false;
                GenerarReporte.Enabled = false;
                Produccion.Enabled = false;
                ConsultarVentas.Enabled = false;

            }
        }

        private void ActualizarVenta_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActualizarVentaP));
        }

        private void ActualizarVenta_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActualizarVenta));
        }

        private void ComboIdProducc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 P = Convert.ToInt64(ComboIdProducc.Text);

            ComProduc = Produccioon.ObtenerPro(P);


            if (ComProduc != null)
            {
                CajaPrcom.Text = ComProduc.Nombre_Producto;
                CajatpDes.Text = ComProduc.Descripcion;
                CajaValorP.Text = Convert.ToString(ComProduc.Valor_Producto);
            }
        }

        private void Aceptar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.AceptP));
        }

        private void Aceptar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Acept));
        }

        private void AgreProdu_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void AgreProdu_MouseLeave(object sender, EventArgs e)
        {
        }

        private void Agregaar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources._PP));
        }

        private void Agregaar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources._));
        }

        private void RegistroClien_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarP));
        }

        private void RegistroClien_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar));
        }

        private void ButtonCerrar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.CerrarP));
        }

        private void ButtonCerrar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Cerrar));
        }

        private void Cerrar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.CerrarP));
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Cerrar));
        }

        private void RegistrarVenta_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarVentaP));
        }

        private void RegistrarVenta_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarVenta));
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void LIdPediCli_Click(object sender, EventArgs e)
        {

        }

        private void LaVtc_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LaTp_Click(object sender, EventArgs e)
        {

        }

        private void CajaTpcom_TextChanged(object sender, EventArgs e)
        {

        }

        private void LaDes_Click(object sender, EventArgs e)
        {

        }

        private void CajatpDes_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanelRegistrarVentas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LaCant_Click(object sender, EventArgs e)
        {

        }

        private void LaVp_Click(object sender, EventArgs e)
        {

        }

        private void CajaValorP_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaEst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataTerceraTaVen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LaFE_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void CajaApeCli_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaCorreoCli_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void CajaIdentCli_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void ComboTipoDocu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void CajaSubTotaal_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click_1(object sender, EventArgs e)
        {

        }

        private void LaEsta_Click(object sender, EventArgs e)
        {

        }

        private void NumeroDocCli_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void CajaValorT_TextChanged(object sender, EventArgs e)
        {

        }

        private void laApeeCli_Click(object sender, EventArgs e)
        {

        }

        private void laNommcli_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void EmpleApe_Click(object sender, EventArgs e)
        {

        }

        private void EmpleNom_Click(object sender, EventArgs e)
        {

        }

        private void LaCodVen_Click(object sender, EventArgs e)
        {

        }

        private void CajaaValorTPC_Click(object sender, EventArgs e)
        {

        }

        private void CajaIva_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void richObserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void CajaSaldo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void CajaFechaEnVen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void CajaSubTotaal_TextChanged_1(object sender, EventArgs e)
        {
            Int64 Subtotal;
            double Iva;
            double Total;

            if (CajaSubTotaal.Text != "")
            {

                Subtotal = Convert.ToInt64(CajaSubTotaal.Text);
                Iva = Subtotal * 0.19;
                double Iva1 = (Iva % 1);
                if (Iva < 0.3)
                {
                    CajaIva.Text = Convert.ToString(Math.Round(Iva));
                }
                else if (Iva > 0.3)
                {
                    CajaIva.Text = Convert.ToString(Math.Ceiling(Iva));

                }
                Total = Iva + Subtotal;

                double Total1 = (Total % 1);
                if (Total1 < 0.3)
                {

                    CajaaValorTPC.Text = Convert.ToString(Math.Round(Total / 50) * 50);
                    CajaSaldo.Text = Convert.ToString(Math.Round(Total / 50) * 50);
                }
                else if (Total1 > 0.3)
                {
                    CajaSaldo.Text = Convert.ToString(Math.Ceiling(Total / 50) * 50);
                    CajaaValorTPC.Text = Convert.ToString(Math.Ceiling(Total / 50) * 50);

                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void DatagriedVen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DatagriedVen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                Int64 Ho = Convert.ToInt64(DatagriedVen.CurrentRow.Cells[0].Value);
                ComSeleccionado = PedidoCliente.ObtenerPedidoCliente(Ho);

                if (ComSeleccionado != null & ComSeleccionado.Estado_Pcli == "No pago")
                {

                    PanelRegistrarVentas.Visible = true;
                    Registrar.Visible = false;
                    Actualizar.Visible = false;
                    LaFE.Location = new Point(51, 476);
                    LaFE.Visible = true;
                    CajaFechaEnVen.Visible = false;
                    CajaAbono.Enabled = false;
                    richObserva.Enabled = false;
                    ComboEstVen.Text = Convert.ToString(ComSeleccionado.Estado_Pcli);
                    ComboEstVen.Enabled = false;
                    LafeRVen.Text = ComSeleccionado.Fecha_Realizacion_Pcli;
                    LaFE.Text = Convert.ToString(ComSeleccionado.Fecha_Entrega_Pcli);
                    LaCodVen.Text = Convert.ToString(ComSeleccionado.Id_Pcli);
                    CajaSubTotaal.Text = Convert.ToString(ComSeleccionado.Subtotal_Pcli);
                    richObserva.Text = ComSeleccionado.Observaciones;
                    CajaaValorTPC.Text = Convert.ToString(ComSeleccionado.Valor_Total_Pcli);
                    EmpleNom.Text = ComSeleccionado.Nombre_em;
                    EmpleApe.Text = ComSeleccionado.Apellido_em;
                    CajaIva.Text = Convert.ToString(ComSeleccionado.Iva_Pcli);
                    NumeroDocCli.Text = Convert.ToString(ComSeleccionado.No_Documento_Cl);
                    laNommcli.Text = ComSeleccionado.Nombre_Cl;
                    laApeeCli.Text = ComSeleccionado.Apellido_Cl;
                    CajaSaldo.Text = Convert.ToString(ComSeleccionado.Saldo_Pcli);
                    ComboEstVen.Text = ComSeleccionado.Estado_Pcli;
                    CajaAbono.Text = "0";
                    ComboIdProducc.Visible = false;
                    Lacodp.Visible = false;
                    LaProdc.Visible = false;
                    LaPr.Visible = false;
                    CajaPrcom.Visible = false;
                    LaDes.Visible = false;
                    CajatpDes.Visible = false;
                    LaCant.Visible = false;
                    CajaCantVendida.Visible = false;
                    LaVp.Visible = false;
                    CajaValorP.Visible = false;
                    LaVtc.Visible = false;
                    CajaValorT.Visible = false;
                    DataTerceraTaVen.DataSource = PedidoCliente_Inv.ConsultarPedidoCliente_Inv(LaCodVen.Text);
                    Nombresterceratab();

                }
            }
        }

        private void DatagriedVen_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            FEchas.Enabled = false;
        }

        private void FEchas_Enter(object sender, EventArgs e)
        {
            Consultar.Clear();
            Consultar.Enabled = false;
        }

        private void CajaaValorTPC_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"I:\PROYECTO\Lumiprint\Modulo Utilidades\VENTAS.pdf");
        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Si_Click(object sender, EventArgs e)
        {
            PedidoCliente PPedidoCliente = new PedidoCliente();

            Int64 result = Convert.ToInt64(LaCodVen.Text);
            Int64 resulttt = Convert.ToInt64(LaCodVen.Text);
            Int64 resu = PedidoCliente.EliminarPCli(Convert.ToInt64(result));
            Int64 re = PedidoCliente.EliminarVentaa(Convert.ToInt64(resulttt));


            if (resu > 0 | re > 0)
            {

                ComboIdProducc.Items.Clear();
                Borrar();
                PanelRegistrarVentas.Visible = false;
                panelELiVen.Visible = false;
                PanelRegistrarVentas.Enabled = true;
                Atras.Enabled = true;
                ActualizarVenta.Enabled = true;
                RegistrarVenta.Enabled = true;
                GenerarReporte.Enabled = true;
                Produccion.Enabled = true;
                ConsultarVentas.Enabled = true;

                //MenuPrincipal form = new MenuPrincipal(MenuPrincipal.Empleado);
                //form.Show(this);
            }
            else
            {
                MessageBox.Show("No Ha cancelado la compra");

            }
        }

        private void No_Click(object sender, EventArgs e)
        {
            panelELiVen.Visible = false;
            PanelRegistrarVentas.Visible = true;
            Atras.Enabled = true;
            ActualizarVenta.Enabled = true;
            RegistrarVenta.Enabled = true;
            GenerarReporte.Enabled = true;
            Produccion.Enabled = true;
            ConsultarVentas.Enabled = true;
            PanelRegistrarVentas.Enabled = true;
        }

        private void CerrarCompra_Click(object sender, EventArgs e)
        {
            PanelRegistrarVentas.Enabled = false;
            panelELiVen.Visible = true;
            panelELiVen.Location = new Point(396, 133);

            Atras.Enabled = false;
            ActualizarVenta.Enabled = false;
            RegistrarVenta.Enabled = false;
            GenerarReporte.Enabled = false;
            Produccion.Enabled = false;
            ConsultarVentas.Enabled = false;
        }



    }
}
    
