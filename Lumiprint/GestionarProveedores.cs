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
    public partial class GestionarProveedores : Form
    {
        public Proveedor ProvActual { get; set; }
        public Proveedor ProvSeleccionado { get; set; }
        public static Proveedor Proveedor;
        public static Empleado Empleado;
        public GestionarProveedores(Empleado X)
        {
           Empleado = X;

            InitializeComponent();
            switch (X.Nombre_cargo)
            {
                case TipoCargo.Contador:
                    RegistrarProveedor.Visible = false;
                    ActualizarProveedor.Visible = false;
                    break;
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

        private void Atras_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal(MenuPrincipal.Empleado);
            form.Show(this);
            this.Hide();
        }

        private void ActualizarProveedor_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_proveedorP));
        }

        private void ActualizarProveedor_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_proveedor));
        }

        private void RegistrarProveedor_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_proveedorP));
        }

        private void RegistrarProveedor_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_proveedor));
        }

        private void RegistrarProveedor_Click(object sender, EventArgs e)
        {
            PanelRegistroProveedores.Visible = true;
            TareaXlabel.Text = "Registrar Proveedor";
            Registrar.Visible = true;
            Limpiar();
            Actualizar.Visible = false;
            Registrar.Location = new Point(113, 326);
            LaEst.ForeColor = Color.Red;

        }

        private void Limpiar()
        {
            CajaEmp.Clear();
            CajaNit.Clear();
            CajaTel.Clear();
            CajaCor.Clear();
            comboEstProv.Text = "-Seleccione Estado-";
        }

        private void GestionarProveedores_Load(object sender, EventArgs e)
        {

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

            int i, j;
            PdfPTable PdTabla = new PdfPTable(DatagriedProv.Columns.Count);
            PdTabla.DefaultCell.Padding = 3;
            float[] HW = GetTamañoColumnas(DatagriedProv);
            PdTabla.SetWidths(HW);
            PdTabla.WidthPercentage = 100;
            PdTabla.DefaultCell.BorderWidth = 2;
            PdTabla.HorizontalAlignment = Element.ALIGN_CENTER;
            BaseColor b = new BaseColor(230, 141, 55);
            PdTabla.DefaultCell.BorderColor = b;
            for (i = 0; i < DatagriedProv.ColumnCount; i++)
            {
                PdTabla.AddCell(DatagriedProv.Columns[i].HeaderText);

            }
            PdTabla.HeaderRows = 1;
            PdTabla.DefaultCell.BorderWidth = 1;
            BaseColor a = new BaseColor(162, 205, 100);
            PdTabla.DefaultCell.BorderColor = a;
            for (i = 0; i < DatagriedProv.Rows.Count; i++)
            {
                for (j = 0; j < DatagriedProv.Columns.Count; j++)
                {
                    if (DatagriedProv[j, i].Value != null)
                    {

                        PdTabla.AddCell(new Phrase(DatagriedProv[j, i].Value.ToString()));

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
                Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 50, 25);
                SaveFileDialog GuardarArchivo = new SaveFileDialog();
                string x = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                GuardarArchivo.InitialDirectory = x;
                GuardarArchivo.DefaultExt = "pdf";
                GuardarArchivo.FileName = "Proveedor No_" + DatagriedProv.CurrentRow.Cells[0].Value + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + DateTime.Now.ToString("hhmm") + ".pdf";
                GuardarArchivo.Filter = "pdf files (*.pdf)|*.pdf| All Files (*.*)|*.*";
                GuardarArchivo.FilterIndex = 2;
                GuardarArchivo.RestoreDirectory = true;

                string Nombre = "";
                if (GuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    Nombre = GuardarArchivo.FileName;
                    Documento Guardado = new Documento();
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
                    imagen.ScaleAbsolute(720f, 125f);
                    Chunk Ch = new Chunk("Proveedor", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, iTextSharp.text.Font.BOLD, Naranja));
                    Chunk Linea = new Chunk("**********************************************************************************************************************************", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, iTextSharp.text.Font.BOLD));
                    Paragraph P1 = new Paragraph(Ch);
                    Chunk Re = new Chunk("Reporte realizado por: " + Empleado.Nombre_em + " " + Empleado.Apellido_em + "       Cargo que desempeña: " + Empleado.Nombre_cargo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P2 = new Paragraph(Re);
                    Chunk Fecha = new Chunk("Fecha y hora:" + DateTime.Now.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P3 = new Paragraph(Fecha);
                    P1.Alignment = Element.ALIGN_CENTER; P2.Alignment = Element.ALIGN_CENTER; P3.Alignment = Element.ALIGN_CENTER;
                    doc.Add(imagen);
                    doc.Add(new Paragraph(Linea));
                    doc.Add(P1);
                    doc.Add(P2);
                    doc.Add(P3);
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph(Linea));
                    doc.Add(new Paragraph("                       "));
                    ExportarPDf(doc);
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
        private void GenerarReporte_Click(object sender, EventArgs e)
        {
            if (DatagriedProv.Rows.Count == 0)
            {
                Consulta Consultar = new Consulta();
                Consultar.ShowDialog(); ;
            }
            else
            {
                En_PDF();
            }
        }

        private void GenerarReporte_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.GenerarReporte));
        }

        private void GenerarReporte_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.GenerarReporteP));
        }

        private void ActualizarProveedor_Click(object sender, EventArgs e)
        {
                if (DatagriedProv.SelectedRows.Count == 1)
                {
                    Int64 Id_Prov = Convert.ToInt64(DatagriedProv.CurrentRow.Cells[0].Value);
                    ProvSeleccionado = Proveedor.ObtenerProveedor(Id_Prov);
                    ProvActual = ProvSeleccionado;
                    PanelRegistroProveedores.Visible = true;
                    TareaXlabel.Text = "Actualizar Proveedor";
                    Registrar.Visible = false;
                    Actualizar.Visible = true;
                    Actualizar.Location = new Point(113, 326);
                    CajaEmp.Clear();
                    CajaNit.Clear();
                    CajaTel.Clear();
                    CajaCor.Clear();
                    CajaNit.Enabled = false;
                    CajaEmp.Enabled = false;
                    if (ProvSeleccionado != null)
                    {
                        ProvActual = ProvSeleccionado;
                        CajaEmp.Text = ProvSeleccionado.Empresa;
                        CajaNit.Text = Convert.ToString(ProvSeleccionado.Nit_Prov);
                        CajaTel.Text = Convert.ToString(ProvSeleccionado.Telefono_Prov);
                        CajaCor.Text = ProvSeleccionado.Correo_Prov;
                        comboEstProv.Text = Convert.ToString(ProvSeleccionado.Estado_Prov);
                    }
                }
                else
                {
                    SeleccioneUnaFila form = new SeleccioneUnaFila();
                    form.ShowDialog();
                }
            
        }

        private void ConsultarProveedor_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarProveedoresP));
        }

        private void ConsultarProveedor_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarProveedores));
        }

        private void Registrar_Click(object sender, EventArgs e)
        {   
            Proveedor PProveedor = new Proveedor();

            if (CajaNit.Text == "" | CajaEmp.Text == "" |
                CajaCor.Text == "" | CajaTel.Text == "" | ComprobarFormatoEmail(CajaCor.Text) == false)
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
            }
            else
            {
            PProveedor.Nit_Prov= Convert.ToInt64(CajaNit.Text);
            PProveedor.Empresa = CajaEmp.Text;
            PProveedor.Correo_Prov = CajaCor.Text;
            PProveedor.Telefono_Prov = Convert.ToInt64(CajaTel.Text);
            PProveedor.Estado_Prov = comboEstProv.Text;
            PanelRegistroProveedores.Visible = false;
            Limpiar();

            int ResultadoReg = Proveedor.RegistrarProveedor(PProveedor);
            if (ResultadoReg > 0)
            {
                RegistroCompletado Completo = new RegistroCompletado();
                Completo.ShowDialog();
                PanelRegistroProveedores.Visible = false;
                DatagriedProv.DataSource = Proveedor.ConsultarProveedor(Convert.ToString(PProveedor.Nit_Prov));
                Nombres();
                Limpiar();
                En_PDF();
        
              
               
            }
            else
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
                PanelRegistroProveedores.Visible = false;
                Limpiar();
            }
        }
       }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (CajaCor.Text == "" | CajaEmp.Text == "" | CajaNit.Text == ""
             | CajaTel.Text == "" | ComprobarFormatoEmail(CajaCor.Text) == false)
            {
                ModificacionIncompleta Incompleto = new ModificacionIncompleta();
                Incompleto.ShowDialog();
            }
            else
            {

                Proveedor PProveedor = new Proveedor();
                PProveedor.Nit_Prov = Convert.ToInt64(CajaNit.Text);
                PProveedor.Empresa = CajaEmp.Text;
                PProveedor.Correo_Prov = CajaCor.Text;
                PProveedor.Telefono_Prov = Convert.ToInt64(CajaTel.Text);
                PProveedor.Id_Prov = ProvActual.Id_Prov;
                PProveedor.Estado_Prov = comboEstProv.Text;


                int ResultadoProv = Proveedor.ActualizarProveedor(PProveedor);
                if (ResultadoProv > 0)
                {
                    ModificacionCompleta Completo = new ModificacionCompleta();
                    Completo.ShowDialog();
                    DatagriedProv.DataSource = Proveedor.ConsultarProveedor(Convert.ToString(PProveedor.Nit_Prov));
                    Nombres();
                    PanelRegistroProveedores.Visible = false;
                    En_PDF();
                }
                else
                {
                    ModificacionIncompleta Incompleta = new ModificacionIncompleta();
                    Incompleta.ShowDialog();
                }
            }
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

        void Nombres()
        {
            DatagriedProv.Columns["Empresa"].HeaderText = "Empresa";
            DatagriedProv.Columns["Telefono_Prov"].HeaderText = "Teléfono";
            DatagriedProv.Columns["Nit_Prov"].HeaderText = "NIT";
            DatagriedProv.Columns["Correo_Prov"].HeaderText = "Correo";
            DatagriedProv.Columns["Id_Prov"].HeaderText = "Código";
            DatagriedProv.Columns["Estado_Prov"].HeaderText = "Estado";
        }
        private void ConsultarProveedor_Click(object sender, EventArgs e)
        {
            DatagriedProv.DataSource = Proveedor.ConsultarProveedor(Consultar.Text);
            Nombres();
        }

        private void PanelRegistroProveedores_Paint(object sender, PaintEventArgs e)
        {
            if (AD1.Visible == true | AD2.Visible == true | AD3.Visible == true | AD4.Visible == true | AD5.Visible == true)
            {
                ADV();

            }
            else
            {
                ADVN();

            }
           
        }
        void ADVN()
        {
            Lau.Visible = false;
            ADG.Visible = false;
        }

        void ADV()
        {
            Lau.Visible = true;
            ADG.Visible = true;
        }
        private void CerrarPanelREmpleados_Click(object sender, EventArgs e)
        {
            PanelRegistroProveedores.Visible = false;
            CajaEmp.Clear();
            CajaNit.Clear();
            CajaTel.Clear();
            CajaCor.Clear();
        }

        private void CajaNit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaTel_TextChanged(object sender, EventArgs e)
        {
            if (CajaTel.Text == "")
            {
                LaTe.ForeColor = Color.Red;
                AD3.Visible = true;

            }
            else
            {
                LaTe.ForeColor = Color.YellowGreen;
                AD3.Visible = false;
            }
        }

        private void CajaTel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void DatagriedProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Consultar_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void CerrarPanelREmpleados_MouseHover(object sender, EventArgs e)
        {
            LCE.Visible = true;
            LInfo.Visible = false;
        }

        private void ConsultarProveedor_MouseHover(object sender, EventArgs e)
        {
            LCO1.Visible = true;
            LCO2.Visible = true;
        }

        private void Atras_MouseHover(object sender, EventArgs e)
        {
            LV1.Visible = true;
        }

        private void ActualizarProveedor_MouseEnter(object sender, EventArgs e)
        {
            LA1.Visible = true;
            LA2.Visible = true;
        }

        private void RegistrarProveedor_MouseHover(object sender, EventArgs e)
        {
            LR1.Visible = true;
        }

        private void GestionarProveedores_MouseEnter(object sender, EventArgs e)
        {

        }

        private void GestionarProveedores_MouseMove(object sender, MouseEventArgs e)
        {
            LR1.Visible = false;
            LG1.Visible = false;
            LG2.Visible = false;
            LA1.Visible = false;
            LA2.Visible = false;
            LCO1.Visible = false;
            LCO2.Visible = false;
            LV1.Visible = false;
            LInfo.Visible = false;
            LCE.Visible = false;
        }

        private void GenerarReporte_MouseHover(object sender, EventArgs e)
        {
            LG1.Visible = true;
            LG2.Visible = true;
        }

        private void CajaEmp_TextChanged(object sender, EventArgs e)
        {
            if (CajaEmp.Text == "")
            {
                LaEm.ForeColor = Color.Red;
                AD1.Visible = true;

            }
            else
            {
                LaEm.ForeColor = Color.YellowGreen;
                AD1.Visible = false;
            }
        }

        private void CajaNit_TextChanged(object sender, EventArgs e)
        {
            if (CajaNit.Text == "")
            {
                LaNi.ForeColor = Color.Red;
                AD2.Visible = true;

            }
            else
            {
                LaNi.ForeColor = Color.YellowGreen;
                AD2.Visible = false;
            }
        }

        private void CajaCor_TextChanged(object sender, EventArgs e)
        {
            if (CajaCor.Text == "" | ComprobarFormatoEmail(CajaCor.Text) == false)
            {
                LaCo.ForeColor = Color.Red;
                AD4.Visible = true;

            }
            else
            {
                LaCo.ForeColor = Color.YellowGreen;
                AD4.Visible = false;
            }
        }

        private void PanelRegistroProveedores_MouseMove(object sender, MouseEventArgs e)
        {
            LInfo.Visible = false;
            LCE.Visible = false;
        }

        private void PanelRegistroProveedores_MouseHover(object sender, EventArgs e)
        {

        }

        private void AD1_MouseHover(object sender, EventArgs e)
        {

            LInfo.Location = new Point(52, 259);
            LInfo.Text = "Ingrese una empresa.";
            LInfo.Visible = true;
            
        }

        private void AD2_MouseHover(object sender, EventArgs e)
        {

            LInfo.Location = new Point(52, 259);
            LInfo.Text = "Ingrese número Nit.";
            LInfo.Visible = true;
           
        }

        private void AD3_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(52, 259);
            LInfo.Text = "Ingrese un número de teléfono.";
            LInfo.Visible = true;
        }

        private void AD4_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(52, 259);
            LInfo.Text = "Ingrese correo válido.";
            LInfo.Visible = true;

        }
        public static bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void AD1_Click(object sender, EventArgs e)
        {

        }

        private void AD4_Click(object sender, EventArgs e)
        {

        }

        private void AD2_Click(object sender, EventArgs e)
        {

        }

        private void AD3_Click(object sender, EventArgs e)
        {

        }

        private void AD1_MouseMove(object sender, MouseEventArgs e)
        {
 
        }

        private void AD2_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void AD4_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ActualizarProveedor_MouseHover(object sender, EventArgs e)
        {

        }

        private void comboEstProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEstProv.Text == "-Seleccione Estado-")
            {
                LaEst.ForeColor = Color.Red;
                AD5.Visible = true;

            }
            else
            {
                LaEst.ForeColor = Color.YellowGreen;
                AD5.Visible = false;
            }
        }

        private void AD5_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(52, 259);
            LInfo.Text = "Seleccione un estado.";
            LInfo.Visible = true;

        }

        private void LF1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"I:\PROYECTO\Lumiprint\Modulo Utilidades\PROVEEDOR.pdf");
        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



    }
}
