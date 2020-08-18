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
using System.Threading;

namespace Vista
{

    public partial class GestionarCompras : Form
    {

        public static Empleado Empleado;
        public static Proveedor Proveedor;
        public static Pedido_Compra Pedido_Compra;
        public Pedido_Compra ComActual { get; set; }
        public Pedido_Compra ComSeleccionado { get; set; }
        public Pedido_Compra A { get; set; }
        public Pedido_Compra B { get; set; }
        public Inventario InvActua { get; set; }
        public Inventario InvSeleccionad { get; set; }
        public Pedido_Compra ComActua { get; set; }
        public Pedido_Compra ComSeleccionad { get; set; }
        public Pedido_Compra ComActua1 { get; set; }
        public Pedido_Compra ComSeleccionad1 { get; set; }
        public Pedido_Compra Total { get; set; }
        public Pedido_Compra Tota { get; set; }
        public Inventario InvA { get; set; }
        public Inventario InvS { get; set; }
        public Proveedor IDPR { get; set; }
        public Proveedor IDPRS { get; set; }
        public static string F;
        public static string N;



        public GestionarCompras(Empleado X)
        {
            Empleado = X;

            InitializeComponent();
            switch (X.Nombre_cargo)
            {
                case TipoCargo.Contador:
                    RegistrarCompra.Visible = false;
                    ActualizarCompra.Visible = false;

                    break;
            }
        }

        Pedido_Compra fr = new Pedido_Compra();




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

        private void ActualizarCompra_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_compraP));
        }

        private void ActualizarCompra_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_compra));
        }

        private void RegistrarCompra_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_compraP));
        }

        private void RegistrarCompra_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_compra));
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
            DataTerceraTa.Columns.RemoveAt(0);
            DataTerceraTa.Columns.RemoveAt(0);
            DataTerceraTa.Columns.RemoveAt(7);
            DataTerceraTa.Columns.RemoveAt(7);
            int i, j;
            PdfPTable PdTabla = new PdfPTable(DataTerceraTa.Columns.Count);
            PdTabla.DefaultCell.Padding = 3;

            float[] HW = GetTamañoColumnas(DataTerceraTa);
            PdTabla.SetWidths(HW);
            PdTabla.WidthPercentage = 100;
            PdTabla.DefaultCell.BorderWidth = 2;
            PdTabla.HorizontalAlignment = Element.ALIGN_CENTER;
            BaseColor b = new BaseColor(230, 141, 55);
            PdTabla.DefaultCell.BorderColor = b;
            for (i = 0; i < DataTerceraTa.ColumnCount; i++)
            {
                PdTabla.AddCell(DataTerceraTa.Columns[i].HeaderText);

            }
            PdTabla.HeaderRows = 1;
            PdTabla.DefaultCell.BorderWidth = 1;
            BaseColor a = new BaseColor(162, 205, 100);
            PdTabla.DefaultCell.BorderColor = a;
            for (i = 0; i < DataTerceraTa.Rows.Count; i++)
            {
                for (j = 0; j < DataTerceraTa.Columns.Count; j++)
                {
                    if (DataTerceraTa[j, i].Value != null)
                    {

                        PdTabla.AddCell(new Phrase(DataTerceraTa[j, i].Value.ToString()));

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
                GuardarArchivo.FileName = "Compra No_" + LaCod.Text + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + DateTime.Now.ToString("hhmm") + ".pdf";
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
                    Chunk Ch = new Chunk("Compra No."+LaCod.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, Naranja));
                    Chunk Linea = new Chunk("*********************************************************", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD));
                    Paragraph P1 = new Paragraph(Ch);
                    Chunk Re = new Chunk("Reporte realizado por: " + Empleado.Nombre_em + " " + Empleado.Apellido_em + "       Cargo que desempeña: " + Empleado.Nombre_cargo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P2 = new Paragraph(Re);
                    Chunk Fecha = new Chunk("Fecha y hora:" + DateTime.Now.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P3 = new Paragraph(Fecha);
                    Chunk Venta = new Chunk("Estado: " + CajaEst.Text + "       Código empresa: " + LabIdProv.Text + "       Empresa: " + LabEmpresa.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Naranja));
                    Paragraph P4 = new Paragraph(Venta);
                    Chunk Venta2 = new Chunk("Fecha de realización: " + LafeR.Text + "       Fecha de entrega: " + LaFE.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P5 = new Paragraph(Venta2);
                    Chunk Venta3 = new Chunk("SubTotal: " + CajaSubTotaal.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P6 = new Paragraph(Venta3);
                    Chunk Venta4 = new Chunk("Iva: " + CajaIva.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Naranja));
                    Paragraph P7 = new Paragraph(Venta4);
                    Chunk Venta5 = new Chunk("Valor Total: " + CajaaValorTPC.Text, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P8 = new Paragraph(Venta5);
                    P1.Alignment = Element.ALIGN_CENTER; P2.Alignment = Element.ALIGN_CENTER; P3.Alignment = Element.ALIGN_CENTER; P4.Alignment = Element.ALIGN_CENTER; P5.Alignment = Element.ALIGN_CENTER; P6.Alignment = Element.ALIGN_RIGHT; P7.Alignment = Element.ALIGN_RIGHT; P8.Alignment = Element.ALIGN_RIGHT;
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
                    doc.Add(P6);
                    doc.Add(P7);
                    doc.Add(P8);
                    doc.AddCreationDate();
                    doc.Close();
                    Process.Start(Nombre);
                }

            }
            catch (IOException)
            {
                NoAbrir NoAbrira = new NoAbrir();
                NoAbrira.ShowDialog();
            }

        }
        private void RegistrarCompra_Click(object sender, EventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false )
            {
                Pedido_Compra.EliminarPC(0);
           
                PanelRegistroCompras.Visible = false;
                Int64 io = Convert.ToInt64(LIdPedi.Text);
                ComSeleccionad1 = Pedido_Compra.Autoincrementar(io);
                ComActua1 = ComSeleccionad1;
                LIdPedi.Text = Convert.ToString(ComSeleccionad1.Id_Pc);
                CajaEmpresa.Text = "-Seleccione Empresa-";
                panelEmpre.Visible = true;
                Registrar.Visible = true;
                LaCop.Visible = true;
                LIdProv.Visible = false;
                LaTp.Visible = true;
                LaVp2.Visible = true;
                Lavtc2.Visible = true;
                Lacop2.Visible = true;
                LaDes.Visible = true;
                LaCant.Visible = true;
                CajaTam.Visible = true;
                LaTa.Visible = true;
                LaVp.Visible = true;
                LaVtc.Visible = true;
                CajaIdIn.Visible = true;
                CajaTpcom.Visible = true;
                CajatpDes.Visible = true;
                CajaValorP.Visible = true;
                CajaValorT.Visible = true;
                CajaFechaEn.Visible = true;
                CajaCantComprada.Visible = true;
                AgreProdu.Visible = true;
                BorrarProducto.Visible = true;
                AgreProdu.Visible = true;
                BorrarProducto.Visible = true;
                CajaCantComprada.Enabled = true;
                CajaIdIn.Enabled = true;
                CajaFechaEn.Enabled = true;
                Actualizar.Visible = false;
            }
            else
            {
                MessageBox.Show("Complete la venta.");
            }
        }

        private void Limpiaar()
        {
            CajaIdIn.Text = "";
            CajaTpcom.Clear();
            CajatpDes.Clear();
            CajaCantComprada.Text = "0";
            CajaValorP.Clear();
            CajaValorT.Clear();

        }

        private void LimpiarRegis()
        {
            CajaIdIn.Text = "-Seleccione ID-";
            CajaTpcom.Clear();
            CajatpDes.Clear();
            CajaCantComprada.Text = "0";
            CajaValorP.Clear();
            CajaValorT.Clear();
            CajaFechaEn.Text = "";
            CajaSubTotaal.Text = "Subtotal";
            CajaaValorTPC.Text = "Valor total";
        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void GestionarCompras_Load(object sender, EventArgs e)
        {
            
            Proveedor PProveedor = new Proveedor();
            DataTable Tabla = new DataTable();
            PProveedor.EmpresaSelect(Tabla);
            CajaEmpresa.DataSource = Tabla;
            CajaEmpresa.ValueMember = "Empresa";
            CajaEmpresa.DisplayMember = "Empresa";

            
            AutoCompleteStringCollection Colección = new AutoCompleteStringCollection();
            foreach (DataRow row in Tabla.Rows)
            {
                Colección.Add(Convert.ToString(row["Empresa"]));
            }
            CajaEmpresa.AutoCompleteCustomSource = Colección;
            CajaEmpresa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CajaEmpresa.AutoCompleteSource = AutoCompleteSource.CustomSource;
          

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

        private void GenerarReporte_Click(object sender, EventArgs e)
        {

        }

        private void ConsultarCompras_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarCompraP));
        }

        private void ConsultarCompras_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarCompra));
        }
        void FilasPrimerTable()
        {
            DatagriedCom.Columns["Id_Pc"].HeaderText = "Código";
            DatagriedCom.Columns["Fecha_Realizacion_Pc"].HeaderText = "Fecha de realización";
            DatagriedCom.Columns["Fecha_Entrega_Pc"].HeaderText = "Fecha de entrega";
            DatagriedCom.Columns["Id_Prov"].HeaderText = "Código empresa";
            DatagriedCom.Columns["Empresa"].HeaderText = "Empresa";
            DatagriedCom.Columns["Estado_Pc"].HeaderText = "Estado";
            DatagriedCom.Columns["Iva_Pc"].Visible = false;
            DatagriedCom.Columns["Valor_Total_Pc"].Visible = false;
            DatagriedCom.Columns["Subtotal_Pc"].Visible = false;
        }
        void FilasTercerTable()
        {
            DataTerceraTa.Columns["IdPCIV"].Visible = false;
            DataTerceraTa.Columns["Id_Pc"].Visible = false;
            DataTerceraTa.Columns["Id_pz"].HeaderText = "Código Producto";
            DataTerceraTa.Columns["CantidadPedido"].HeaderText = "Cantidad";
            DataTerceraTa.Columns["ValorTotalProv"].HeaderText = "Valor";
            DataTerceraTa.Columns["Tipo_de_pieza"].HeaderText = "Tipo de pieza";
            DataTerceraTa.Columns["Tamaño"].HeaderText = "Tamaño";
            DataTerceraTa.Columns["Descripcion"].HeaderText = "Descripción";
            DataTerceraTa.Columns["Valor_Proveedor"].HeaderText = "Valor Proveedor";
            DataTerceraTa.Columns["Id_Prov"].Visible = false;
            DataTerceraTa.Columns["Empresa"].Visible = false;
        }
        private void ConsultarCompras_Click(object sender, EventArgs e)
        {

            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                Pedido_Compra.EliminarPC(0);


                if (FEchas.Enabled == false)
                {
                    DatagriedCom.DataSource = Pedido_Compra.ConsultarPedido_Compra(Consultar.Text);
                    FilasPrimerTable();

                }
                else if (Consultar.Enabled == false)
                {
                    string FechaC;
                    FechaC = FEchas.Value.ToString("yyyy-MM-dd");
                    DatagriedCom.DataSource = Pedido_Compra.ConsultarPedido_Compra(FechaC);
                    FilasPrimerTable();
                }
                else
                {
                    DatagriedCom.DataSource = Pedido_Compra.ConsultarPedido_Compra("");
                    FilasPrimerTable();
                }
                Pedido_Compra p = new Pedido_Compra();
                Int64 io = Convert.ToInt64(LIdPedi.Text);
                Consultar.Enabled = true;
                FEchas.Enabled = true;
            }
        }



        private void CajaDocu_TextChanged(object sender, EventArgs e)
        {

        }

        private void ActualizarCompra_Click(object sender, EventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                Pedido_Compra.EliminarPC(0);
                if (DatagriedCom.SelectedRows.Count == 1)
                {
                    Int64 Ho = Convert.ToInt64(DatagriedCom.CurrentRow.Cells[1].Value);
                    ComSeleccionado = Pedido_Compra.ObtenerPedidoCompra(Ho);

                    if (ComSeleccionado != null & ComSeleccionado.Estado_Pc == "Activo")
                    {
                        PanelRegistroCompras.Visible = true;
                        Registrar.Visible = false;
                        Actualizar.Visible = true;
                        LafeR.Text = ComSeleccionado.Fecha_Realizacion_Pc;
                        LaFE.Visible = true;
                        LaFE.Text = Convert.ToString(ComSeleccionado.Fecha_Entrega_Pc);
                        LaFE.Location = new Point(208, 458);
                        LafeR.Text = Convert.ToString(ComSeleccionado.Fecha_Realizacion_Pc);
                        CajaaValorTPC.Text = Convert.ToString(ComSeleccionado.Valor_Total_Pc);
                        CajaSubTotaal.Text = Convert.ToString(ComSeleccionado.Subtotal_Pc);
                        LaCod.Text = Convert.ToString(ComSeleccionado.Id_Pc);
                        LabIdProv.Text = Convert.ToString(ComSeleccionado.Id_Prov);
                        LabEmpresa.Text = ComSeleccionado.Empresa;
                        CajaEst.Text = ComSeleccionado.Estado_Pc;
                        CajaEst.Enabled = true;
                        Actualizar.Location = new Point(40, 502);
                        LaCop.Visible = false;
                        LaTp.Visible = false;
                        LaVp2.Visible = false;
                        Lavtc2.Visible = false;
                        Lacop2.Visible = false;
                        LaDes.Visible = false;
                        LaCant.Visible = false;
                        CajaTam.Visible = false;
                        LaTa.Visible = false;
                        LaVp.Visible = false;
                        LaVtc.Visible = false;
                        CajaIdIn.Visible = false;
                        CajaTpcom.Visible = false;
                        CajatpDes.Visible = false;
                        CajaValorP.Visible = false;
                        CajaValorT.Visible = false;
                        CajaFechaEn.Visible = false;
                        CajaCantComprada.Visible = false;
                        AgreProdu.Visible = false;
                        BorrarProducto.Visible = false;


                        string i = LabEmpresa.Text;
                        InvS = Inventario.ObtenerIdXEm(i);
                        if (InvS != null)
                        {
                            InvA = InvS;
                            CajaIdIn.Text = InvS.Id_pz.ToString();


                            Int64 oi = Convert.ToInt64(LabIdProv.Text);
                            InvSeleccionad = Inventario.ObtenerMateriaPrimaX(oi);

                            Inventario PInventario = new Inventario();
                            PInventario.IdPzSelect(CajaIdIn, Convert.ToString(LabEmpresa.Text));
                            CajaIdIn.Text = "-Seleccione ID-";


                            DataTerceraTa.DataSource = PedidoComInvPro.ConsultarComInvPro(LaCod.Text);
                            FilasTercerTable();


                        }

                    }
                    else
                    {
                        MessageBox.Show("Ya se realizaron cambios de esta compra.");
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
                MessageBox.Show("Termine la compra.");
            }
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

        private void Registrar_Click(object sender, EventArgs e)
        {
                Pedido_Compra PPedido_Compra = new Pedido_Compra();
            if (CajaaValorTPC.Text == "" | CajaSubTotaal.Text == "" | CajaIva.Text == "")
            {
                MessageBox.Show("Registre algun producto");
            }
            else
            {
                PPedido_Compra.Fecha_Realizacion_Pc = Convert.ToString(LafeR.Text);
                PPedido_Compra.Fecha_Entrega_Pc = CajaFechaEn.Value.ToShortDateString();
                PPedido_Compra.Valor_Total_Pc = Convert.ToInt64(CajaaValorTPC.Text);
                PPedido_Compra.Subtotal_Pc = Convert.ToInt64(CajaSubTotaal.Text);
                PPedido_Compra.Iva_Pc = Convert.ToInt64(CajaIva.Text);
                PPedido_Compra.Empresa = LabEmpresa.Text;
                PPedido_Compra.Estado_Pc = Convert.ToString(CajaEst.Text);
                PPedido_Compra.Id_Prov = Convert.ToInt64(LIdProv.Text);
                PPedido_Compra.Id_Pc = Convert.ToInt64(LaCod.Text);
                PPedido_Compra.Estado_Pc = Convert.ToString(CajaEst.Text);
                CajaFechaEn.MinDate = new DateTime(1985, 6, 20);
                LaFE.Text = CajaFechaEn.Value.ToShortDateString();

                int ResultadoReeeg = Pedido_Compra.ActualizarPedidoCompra(PPedido_Compra);
                if (ResultadoReeeg > 0)
                {
                    RegistroCompletado Completo = new RegistroCompletado();
                    Completo.ShowDialog();
                    En_PDF();
                    PanelRegistroCompras.Visible = false;
                    CajaIdIn.Items.Clear();

                }
                else
                {
                    Registro_Incompleto Incompleto = new Registro_Incompleto();
                    Incompleto.ShowDialog();
                }
            }
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


        private void CajaCantComprada_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaValorT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CerrarPanelRCompras_Click(object sender, EventArgs e)
        {
            PanelRegistroCompras.Visible = false;
            CajaCantComprada.Clear();
            CajaValorT.Clear();
            CajaValorP.Clear();

        }

        private void CajaTp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            Pedido_Compra PPedido_Compra = new Pedido_Compra();
            PPedido_Compra.Fecha_Realizacion_Pc = Convert.ToString(LafeR.Text);
            PPedido_Compra.Fecha_Entrega_Pc = Convert.ToString(LaFE.Text);
            PPedido_Compra.Valor_Total_Pc = Convert.ToInt64(CajaaValorTPC.Text);
            PPedido_Compra.Subtotal_Pc = Convert.ToInt64(CajaSubTotaal.Text);
            PPedido_Compra.Iva_Pc = Convert.ToInt64(CajaIva.Text);
            PPedido_Compra.Empresa = LabEmpresa.Text;
            PPedido_Compra.Estado_Pc = Convert.ToString(CajaEst.Text);
            PPedido_Compra.Id_Prov = Convert.ToInt64(LabIdProv.Text);
            PPedido_Compra.Id_Pc = Convert.ToInt64(LaCod.Text);
            PPedido_Compra.Estado_Pc = Convert.ToString(CajaEst.Text);

            int ResultadoInv = Pedido_Compra.ActualizarPedidoCompraDos(PPedido_Compra);
            if (ResultadoInv > 0)
            {
                ModificacionCompleta Completo = new ModificacionCompleta();
                Completo.ShowDialog();
                En_PDF();
                PanelRegistroCompras.Visible = false;
                CajaIdIn.Items.Clear();
            }
            else
            {
                ModificacionIncompleta Incompleta = new ModificacionIncompleta();
                Incompleta.ShowDialog();
            }

        }

        private void PanelRegistroCompras_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CajaValorP_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CajaEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void DatagriedCom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CajaEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

            string i = CajaEmpresa.Text;
            InvS = Inventario.ObtenerIdXEm(i);
            

            IDPRS = Proveedor.ObtenerIDProv(i);

            if (InvS != null)
            {

                InvA = InvS;
                CajaIdIn.Text = InvS.Id_pz.ToString();

                if (IDPRS != null)
                {

                    IDPR = IDPRS;
                    LIdProv.Visible = true;
                    LIdProv.Text = IDPRS.Id_Prov.ToString();
                }
            }
        }

        private void PanelRegistroCompras_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void CajaFechaR_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaIdIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 oi = Convert.ToInt64(CajaIdIn.Text);
            InvSeleccionad = Inventario.ObtenerMateriaPrimaX(oi);


            if (InvSeleccionad != null)
            {
                InvActua = InvSeleccionad;
                CajaTpcom.Text = InvSeleccionad.Tipo_de_pieza;
                CajatpDes.Text = InvSeleccionad.Descripcion;
                CajaTam.Text = InvSeleccionad.Tamaño;
                CajaValorP.Text = Convert.ToString(InvSeleccionad.Valor_Proveedor);
            }

            else
            {
                SeleccioneUnaFila form = new SeleccioneUnaFila();
                form.ShowDialog();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaCantComprada_Leave(object sender, EventArgs e)
        {

        }


        private void AgreProdu_Click(object sender, EventArgs e)
        {
            PedidoComInvPro PPedido_PCIV = new PedidoComInvPro();

            if (CajaCantComprada.Text == "" | CajaIdIn.Text == "-Seleccione ID-" | CajaIdIn.Text == "")
            {
                SeguridadCompleteCam formx = new SeguridadCompleteCam();
                formx.ShowDialog();
            }
            else
            {

                PPedido_PCIV.Id_Pc = Convert.ToInt64(LaCod.Text);
                PPedido_PCIV.CantidadPedido = Convert.ToInt64(CajaCantComprada.Text);
                PPedido_PCIV.ValorTotalProv = Convert.ToDecimal(CajaValorT.Text);
                PPedido_PCIV.Id_pz = Convert.ToInt64(CajaIdIn.Text);
                PPedido_PCIV.Empresa = LabEmpresa.Text;
                PPedido_PCIV.Id_Prov = Convert.ToInt64(LabIdProv.Text);
                PPedido_PCIV.Tipo_de_pieza = Convert.ToString(CajaTpcom.Text);
                PPedido_PCIV.Tamaño = Convert.ToString(CajaTam.Text);
                PPedido_PCIV.Valor_Proveedor = Convert.ToDecimal(CajaValorP.Text);
                PPedido_PCIV.Descripcion = Convert.ToString(CajatpDes.Text);
                PPedido_PCIV.Empresa = LabEmpresa.Text;

                int ResultadoReg = PedidoComInvPro.RegistrarPCIV(PPedido_PCIV);
                if (ResultadoReg > 0)
                {
                    DataTerceraTa.DataSource = PedidoComInvPro.ConsultarComInvPro(LaCod.Text);
                    CajaCantComprada.Text = "";

                    if (DataTerceraTa.Rows.Count > 0)
                    {
                        Tota = Pedido_Compra.TotalSubTotal(Convert.ToInt64(LaCod.Text));
                        CajaSubTotaal.Text = Convert.ToString(Tota.Subtotal_Pc);
                    }
                    else
                    {
                        CajaSubTotaal.Text = "";
                        CajaIva.Text = "";
                        CajaaValorTPC.Text = "";
                    }

                }
                else
                {
                    Registro_Incompleto Incompleto = new Registro_Incompleto();
                    Incompleto.ShowDialog();
                }
            }


        }



        private void GenerarReporte_Click_1(object sender, EventArgs e)
        {
            
          if (Registrar.Visible == false & Actualizar.Visible == false )
            {
            if (PanelRegistroCompras.Visible == false)
            {
                Consulta Consultar = new Consulta();
                Consultar.ShowDialog(); ;
            }
            else
            {
                En_PDF();
                DataTerceraTa.DataSource = PedidoComInvPro.ConsultarComInvPro(LaCod.Text);
                FilasTercerTable();
            }
               }
            else
                   {
                       MessageBox.Show("Complete la compra.");
                   }

            }
        
        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (LIdProv.Visible != true)
            {
                CajaEmpresa.Text = "-Seleccione Empresa";
            }
        }


        private void Aceptar_Click(object sender, EventArgs e)
        {
            Pedido_Compra PPedido_Compra = new Pedido_Compra();

            Int64 oo = Convert.ToInt64(LaCod.Text);
            ComSeleccionad1 = Pedido_Compra.Autoincrementaaar(oo);

            if (CajaEmpresa.Text == "-Seleccione Empresa-" | LIdProv.Visible == false)
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
            }
            else
            {

                string i = CajaEmpresa.Text;
                InvS = Inventario.ObtenerIdXEm(i);


                if (InvS != null)
                {
                    InvA = InvS;
                    CajaIdIn.Text = InvS.Id_pz.ToString();

                    if (ComSeleccionad1 != null)
                    {
                        ComActua1 = ComSeleccionad1;
                        LaCod.Text = Convert.ToString(ComSeleccionad1.Id_Pc);
                        LabIdProv.Text = Convert.ToString(ComSeleccionad1.Id_Prov);
                        PPedido_Compra.Empresa = CajaEmpresa.Text;
                        PPedido_Compra.Id_Pc = Convert.ToInt64(LIdPedi.Text);
                        PPedido_Compra.Id_Prov = Convert.ToInt64(LIdProv.Text);

                        int ResultadoReg = Pedido_Compra.RegistrarPedidoCompra(PPedido_Compra);
                        if (ResultadoReg > 0)
                        {

                            LabIdProv.Text = Convert.ToString(PPedido_Compra.Id_Prov);
                            CajaFechaEn.MinDate = DateTime.Now;
                            panelEmpre.Visible = false;
                            LaFE.Visible = false;
                            PanelRegistroCompras.Visible = true;
                            Registrar.Visible = true;
                            Inventario PInventario = new Inventario();
                            PInventario.IdPzSelect(CajaIdIn, Convert.ToString(CajaEmpresa.Text));
                            CajaIdIn.Text = "-Seleccione ID-";
                            CajaEst.Text = "Activo";
                            CajaIva.Text = "";
                            CajaaValorTPC.Text = "";
                            CajaSubTotaal.Text = "";
                            CajaEst.Enabled = false;
                            DataTerceraTa.DataSource = PedidoComInvPro.ConsultarComInvPro(LaCod.Text);
                            FilasTercerTable();
                            LabEmpresa.Text = Convert.ToString(CajaEmpresa.Text);
                            LafeR.Text = DateTime.Now.ToString();
                            CajaEmpresa.Text = "-Seleccione Empresa-";


                        }
                        else
                        {
                            Registro_Incompleto Incompleto = new Registro_Incompleto();
                            Incompleto.ShowDialog();
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

                }
            }

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void CajaIva_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            panelEmpre.Visible = false;
        }

        private void DataTerceraTa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CajaValorT_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaCantComprada_TextChanged(object sender, EventArgs e)
        {
            decimal a, b, c;

            if (CajaIdIn.Text == "-Seleccione ID-")
            {
                MessageBox.Show("Seleccione un codigo");
            }
            else
            {
                if (CajaCantComprada.Text != "")
                {
                    a = Convert.ToDecimal(CajaValorP.Text);
                    b = Convert.ToInt64(CajaCantComprada.Text);
                    c = a * b;
                    CajaValorT.Text = c.ToString();
                }

                else if (CajaCantComprada.Text == "")
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

        private void CajaValorTPC_Leave(object sender, EventArgs e)
        {

        }

        private void CajaValorTPC_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaCantComprada_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void CajaSubTotal_Leave(object sender, EventArgs e)
        {

        }

        private void CajaSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CajaIva_Leave(object sender, EventArgs e)
        {


        }

        private void LafeR_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void CajaValorP_TextChanged(object sender, EventArgs e)
        {

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
            PedidoComInvPro Pxd = new PedidoComInvPro();

            if (DataTerceraTa.SelectedRows.Count == 1)
            {

                int result = Convert.ToInt16(DataTerceraTa.CurrentRow.Cells[0].Value);
                int resu = PedidoComInvPro.EliminarProducto(Convert.ToInt64(result));

                if (resu > 0)
                {
                    DataTerceraTa.DataSource = PedidoComInvPro.ConsultarComInvPro(LaCod.Text);
                    if (DataTerceraTa.Rows.Count > 0)
                    {
                        Tota = Pedido_Compra.TotalSubTotal(Convert.ToInt64(LaCod.Text));
                        CajaSubTotaal.Text = Convert.ToString(Tota.Subtotal_Pc);
                    }
                    else
                    {
                        CajaSubTotaal.Text = "";
                        CajaIva.Text = "";
                        CajaaValorTPC.Text = "";
                    }
                }
            }
            else
            {
                SeleccioneUnaFila form = new SeleccioneUnaFila();
                form.ShowDialog();
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

        private void BorrarProducto_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.EliP));
        }

        private void BorrarProducto_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Eli));
        }

        private void AgreProdu_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources._PP));
        }

        private void AgreProdu_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources._));
        }

        private void Atras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Registrar.CausesValidation == true)
            {

            }
        }

        private void CajaaValorTPC_TextChanged(object sender, EventArgs e)
        {
            CajaaValorTPC.Text.Replace(",", ".");
        }

        private void CajaIva_TextChanged_1(object sender, EventArgs e)
        {
            CajaIva.Text.Replace(",", ".");
        }

        private void LIdPedi_Click(object sender, EventArgs e)
        {

        }

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
                SCompleteLaCompra form = new SCompleteLaCompra();
                form.ShowDialog();

            }

        }

        private void CajaFechaEn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CajaaValorTPC_Click(object sender, EventArgs e)
        {

        }

        private void CajaSubTotaal_Click(object sender, EventArgs e)
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
                    if (Iva1 < 0.3)
                    {
                        CajaIva.Text = Convert.ToString(Math.Round(Iva));
                    }
                    else if (Iva1 > 0.3)
                    {
                        CajaIva.Text= Convert.ToString(Math.Ceiling(Iva));

                    }
                    Total = Iva + Subtotal;

                    double Total1 = (Total % 1);
                    if (Total1 < 0.3)
                    {

                        CajaaValorTPC.Text = Convert.ToString(Math.Round(Total / 50) * 50);
                    }
                    else if (Total1 > 0.3)
                    {

                        CajaaValorTPC.Text = Convert.ToString(Math.Ceiling(Total / 50) * 50);

                    }
                }
        }

        private void CajaEst_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DatagriedCom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Registrar.Visible == false & Actualizar.Visible == false)
            {
                Int64 Ho = Convert.ToInt64(DatagriedCom.CurrentRow.Cells[1].Value);
                ComSeleccionado = Pedido_Compra.ObtenerPedidoCompra(Ho);

                if (ComSeleccionado != null)
                {
                    PanelRegistroCompras.Visible = true;
                    Registrar.Visible = false;
                    Actualizar.Visible = false;
                    LafeR.Text = ComSeleccionado.Fecha_Realizacion_Pc;
                    LaFE.Visible = true;
                    LaFE.Text = Convert.ToString(ComSeleccionado.Fecha_Entrega_Pc);
                    LaFE.Location = new Point(208, 458);
                    LafeR.Text = Convert.ToString(ComSeleccionado.Fecha_Realizacion_Pc);
                    CajaaValorTPC.Text = Convert.ToString(ComSeleccionado.Valor_Total_Pc);
                    CajaIva.Text = Convert.ToString(ComSeleccionado.Iva_Pc);
                    CajaSubTotaal.Text = Convert.ToString(ComSeleccionado.Subtotal_Pc);
                    LaCod.Text = Convert.ToString(ComSeleccionado.Id_Pc);
                    LabIdProv.Text = Convert.ToString(ComSeleccionado.Id_Prov);
                    LabEmpresa.Text = ComSeleccionado.Empresa;
                    CajaEst.Text = ComSeleccionado.Estado_Pc;
                    CajaEst.Enabled = false;
                    Actualizar.Location = new Point(40, 502);
                    LaCop.Visible = false;
                    LaTp.Visible = false;
                    LaVp2.Visible = false;
                    Lavtc2.Visible = false;
                    Lacop2.Visible = false;
                    LaDes.Visible = false;
                    LaCant.Visible = false;
                    CajaTam.Visible = false;
                    LaTa.Visible = false;
                    LaVp.Visible = false;
                    LaVtc.Visible = false;
                    CajaIdIn.Visible = false;
                    CajaTpcom.Visible = false;
                    CajatpDes.Visible = false;
                    CajaValorP.Visible = false;
                    CajaValorT.Visible = false;
                    CajaFechaEn.Visible = false;
                    CajaCantComprada.Visible = false;
                    AgreProdu.Visible = false;
                    BorrarProducto.Visible = false;
                    CajaIdIn.Items.Clear();
                        DataTerceraTa.DataSource = PedidoComInvPro.ConsultarComInvPro(LaCod.Text);
                        FilasTercerTable();


                    

                }
            }

        }

        private void Fechas_Con_ValueChanged(object sender, EventArgs e)
        {


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Consultar.Clear();
        }

        private void Consultar_TextChanged(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void LF1_Click(object sender, EventArgs e)
        {

        }

        private void LaEsta_Click(object sender, EventArgs e)
        {

        }

        private void CerrarCompra_Click(object sender, EventArgs e)
        {
            SCompleteLaCompra formC = new SCompleteLaCompra();
            formC.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"I:\PROYECTO\Lumiprint\Modulo Utilidades\COMPRAS.pdf");
        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }
    }
}
