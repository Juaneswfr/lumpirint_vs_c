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

    public partial class GestionarMaquinariaa : Form
    {
        public Maquinaria MaActual { get; set; }
        public Maquinaria MaSeleccionado { get; set; }
        public static Maquinaria Maquinaria; 
        public static Empleado Empleado;
        public GestionarMaquinariaa(Empleado X)
        {
            Empleado = X;

            InitializeComponent();
            switch (X.Nombre_cargo)
            {
                case TipoCargo.Administrador:
                    RegistrarMaquinaria.Visible = false;
                    break;
                case TipoCargo.Diseñador:
                    RegistrarMaquinaria.Visible = false;
                    break;
                
            }
        }

        private void GestionarMaquinaria_Load(object sender, EventArgs e)
        {

        }

        private void Atras_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal(MenuPrincipal.Empleado);
            form.Show(this);
            this.Hide();
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

        private void ActualizarMaquinaria_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_maquinariaP));
        }

        private void ActualizarMaquinaria_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_maquinaria));
        }

        private void RegistrarMaquinaria_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_maquinariaP));
        }

        private void RegistrarMaquinaria_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_maquinaria));

        }

        private void RegistrarMaquinaria_Click(object sender, EventArgs e)
        {
            PanelRegistroMaquinaria.Visible = true;
            TareaXlabel.Text = "Registrar Maquinaria";
            Registrar.Visible = true;
            Actualizar.Visible = false;
            Limpiar();
            LaE.ForeColor = Color.Red;
            LaG.ForeColor = Color.Red;
            Registrar.Location = new Point(122, 363);
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
            PdfPTable PdTabla = new PdfPTable(dataGridMa.Columns.Count);
            PdTabla.DefaultCell.Padding = 3;
            float[] HW = GetTamañoColumnas(dataGridMa);
            PdTabla.SetWidths(HW);
            PdTabla.WidthPercentage = 100;
            PdTabla.DefaultCell.BorderWidth = 2;
            PdTabla.HorizontalAlignment = Element.ALIGN_CENTER;
            BaseColor b = new BaseColor(230, 141, 55);
            PdTabla.DefaultCell.BorderColor = b;
            for (i = 0; i < dataGridMa.ColumnCount; i++)
            {
                PdTabla.AddCell(dataGridMa.Columns[i].HeaderText);

            }
            PdTabla.HeaderRows = 1;
            PdTabla.DefaultCell.BorderWidth = 1;
            BaseColor a = new BaseColor(162, 205, 100);
            PdTabla.DefaultCell.BorderColor = a;
            for (i = 0; i < dataGridMa.Rows.Count; i++)
            {
                for (j = 0; j < dataGridMa.Columns.Count; j++)
                {
                    if (dataGridMa[j, i].Value != null)
                    {

                        PdTabla.AddCell(new Phrase(dataGridMa[j, i].Value.ToString()));

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
                GuardarArchivo.FileName = "Maquinaria No_" + dataGridMa.CurrentRow.Cells[0].Value + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + DateTime.Now.ToString("hhmm") + ".pdf";
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
                    imagen.ScaleAbsolute(720f, 125f);
                    Chunk Ch = new Chunk("Maquinaria", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, iTextSharp.text.Font.BOLD, Naranja));
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
            if (dataGridMa.Rows.Count == 0)
            {
                Consulta Consultar = new Consulta();
                Consultar.ShowDialog(); ;
            }
            else
            {
                En_PDF();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarMaquinaria_Click(object sender, EventArgs e)
        {
                if (dataGridMa.SelectedRows.Count == 1)
                {
                    Int64 Id_Ma = Convert.ToInt64(dataGridMa.CurrentRow.Cells[0].Value);
                    MaSeleccionado = Maquinaria.ObtenerMaquinaria(Id_Ma);
                  
                    MaActual = MaSeleccionado;
                    PanelRegistroMaquinaria.Visible = true;
                    TareaXlabel.Text = "Actualizar Maquinaria";
                    Registrar.Visible = false;
                    Actualizar.Visible = true;
                    Actualizar.Location = new Point(122, 363);
                    Limpiar();

                    if (MaSeleccionado != null)
                    {
                        MaActual = MaSeleccionado;
                        CajaTipo.Text = MaSeleccionado.Tipo_Ma;
                        ComboEstado.Text = MaSeleccionado.Estado_Ma;
                        ComboGarantia.Text = MaSeleccionado.Garantia;
                        CajaNReparacion.Text = Convert.ToString(MaSeleccionado.NumeroReparacion);
                        RichMantenimiento.Text = MaSeleccionado.Mantenimiento;
                        

                    }
                }
                else
                {
                    SeleccioneUnaFila Io = new SeleccioneUnaFila();
                    Io.ShowDialog();
                }
            
        }

        private void ConsultarMaquinaria_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarMaquinariaP));
        }

        private void ConsultarMaquinaria_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarMaquinaria));
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
            dataGridMa.Columns["Tipo_Ma"].HeaderText = "Tipo de maquinaria";
            dataGridMa.Columns["Garantia"].HeaderText = "Garantía";
            dataGridMa.Columns["NumeroReparacion"].HeaderText = "Número de reparación";
            dataGridMa.Columns["Mantenimiento"].HeaderText = "Mantenimiento";
            dataGridMa.Columns["Estado_Ma"].HeaderText = "Estado";
            dataGridMa.Columns["Id_ma"].HeaderText = "Código";
        }
        private void ConsultarMaquinaria_Click(object sender, EventArgs e)
        {
            dataGridMa.DataSource = Maquinaria.ConsultarMaquinaria(Consultar.Text);

            Nombres();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            Maquinaria PMaquinaria = new Maquinaria();

            if (CajaTipo.Text == "" | ComboEstado.Text == "-Seleccione Estado-" |
                ComboGarantia.Text == "-Tiempo Garantia-" | CajaNReparacion.Text == "" | 
                RichMantenimiento.Text == "" )
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
            }
            else
            {
            PMaquinaria.Tipo_Ma = CajaTipo.Text;
            PMaquinaria.Estado_Ma = ComboEstado.Text;
            PMaquinaria.Garantia = ComboGarantia.Text;
            PMaquinaria.NumeroReparacion = Convert.ToInt64(CajaNReparacion.Text);
            PMaquinaria.Mantenimiento = RichMantenimiento.Text;
            PanelRegistroMaquinaria.Visible = false;


            int ResultadoReg = Maquinaria.RegistrarMaquinaria(PMaquinaria);
            if (ResultadoReg > 0)
            {

                RegistroCompletado Completo = new RegistroCompletado();
                Completo.ShowDialog();
                dataGridMa.DataSource = Maquinaria.ConsultarMaquinaria(Convert.ToString(Convert.ToString("")));
                Nombres();
                PanelRegistroMaquinaria.Visible = false;
                Limpiar();
                En_PDF();
            }
            else
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
            }
          }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            Maquinaria PMaquinaria = new Maquinaria();

            PMaquinaria.Tipo_Ma = CajaTipo.Text;
            PMaquinaria.Estado_Ma = ComboEstado.Text;
            PMaquinaria.Garantia = ComboGarantia.Text;
            PMaquinaria.NumeroReparacion = Convert.ToInt64(CajaNReparacion.Text);
            PMaquinaria.Mantenimiento = RichMantenimiento.Text;
           
            PMaquinaria.Id_Ma = MaActual.Id_Ma;

            int ResultadoMa = Maquinaria.ActualizarMaquinaria(PMaquinaria);
            if (ResultadoMa > 0)
            {
                ModificacionCompleta Completo = new ModificacionCompleta();
                Completo.ShowDialog();
                dataGridMa.DataSource = Maquinaria.ConsultarMaquinaria(Convert.ToString(PMaquinaria.NumeroReparacion));
                Nombres();
                Limpiar();
                PanelRegistroMaquinaria.Visible = false;
                En_PDF();
            }
            else
            {
                ModificacionIncompleta Incompleto = new ModificacionIncompleta();
                Incompleto.ShowDialog();
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

        private void PanelRegistroMaquinaria_Paint(object sender, PaintEventArgs e)
        {
            if (LaE.ForeColor == Color.Red)
            {
                AD2.Visible = true;
                ADV();
                if (LaG.ForeColor == Color.Red)
                {
                    AD3.Visible = true;
                    ADV();
                }
            }
            else if (LaG.ForeColor == Color.Red)
            {
                AD3.Visible = true;
                ADV();
                if (LaE.ForeColor == Color.Red)
                {
                    AD2.Visible = true;
                    ADV();
                }
            }
            else if (AD1.Visible == true |  AD4.Visible == true
                | AD5.Visible == true)
            {
                ADV();

            }
            else
            {
                ADVN();

            }
        }

        private void CerrarPanelRMaquinaria_Click(object sender, EventArgs e)
        {
            PanelRegistroMaquinaria.Visible = false;
            Limpiar();
            
        }

        private void CajaTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaMantenimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void ComboEstado_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void ComboEstado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ComboGarantia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaNReparacion_KeyPress(object sender, KeyPressEventArgs e)
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
        void Limpiar()
        {
            CajaTipo.Clear();
            CajaNReparacion.Clear();
            RichMantenimiento.Clear();
            ComboEstado.Text = "-Seleccione Estado";
            ComboGarantia.Text = "-Seleccione Tiempo";

        }

        private void Atras_MouseHover(object sender, EventArgs e)
        {
            LV1.Visible = true;
        }

        private void ConsultarMaquinaria_MouseHover(object sender, EventArgs e)
        {
            LCO1.Visible = true;
            LCO2.Visible = true;
        }

        private void ActualizarMaquinaria_MouseHover(object sender, EventArgs e)
        {
            LA1.Visible = true;
            LA2.Visible = true;
        }

        private void GenerarReporte_MouseHover(object sender, EventArgs e)
        {
            LG1.Visible = true;
            LG2.Visible = true;
        }

        private void RegistrarMaquinaria_MouseHover(object sender, EventArgs e)
        {
            LR1.Visible = true;
        }

        private void GestionarMaquinariaa_MouseMove(object sender, MouseEventArgs e)
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

        private void CajaTipo_TextChanged(object sender, EventArgs e)
        {
            if (CajaTipo.Text == "")
            {
                LaT.ForeColor = Color.Red;
                AD1.Visible = true;

            }
            else
            {
                LaT.ForeColor = Color.YellowGreen;
                AD1.Visible = false;
            }
        }

        private void CajaNReparacion_TextChanged(object sender, EventArgs e)
        {
            if (CajaNReparacion.Text == "")
            {
                LaN.ForeColor = Color.Red;
                AD4.Visible = true;

            }
            else
            {
                LaN.ForeColor = Color.YellowGreen;
                AD4.Visible = false;
            }
        }

        private void RichMantenimiento_TextChanged(object sender, EventArgs e)
        {
            if (RichMantenimiento.Text == "")
            {
                LaM.ForeColor = Color.Red;
                AD5.Visible = true;

            }
            else
            {
                LaM.ForeColor = Color.YellowGreen;
                AD5.Visible = false;
            }
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboEstado.Text != "-Seleccione Estado-")
            {
                LaE.ForeColor = Color.YellowGreen;
                AD2.Visible = false;
            }
            else
            {
                LaE.ForeColor = Color.Red;
                AD2.Visible = true;
            }
        }

        private void ComboGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboGarantia.Text != "-Seleccione Tiempo-")
            {
                LaG.ForeColor = Color.YellowGreen;
                AD3.Visible = false;
            }
            else
            {
                LaG.ForeColor = Color.Red;
                AD3.Visible = true;
            }
        }

        private void AD1_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(72, 296);
            LInfo.Text = "Ingrese tipo de maquinaria.";
            LInfo.Visible = true;
        }

        private void AD2_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(105, 296);
            LInfo.Text = "Seleccione estado.";
            LInfo.Visible = true;
        }

        private void AD3_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(100, 296);
            LInfo.Text = "Seleccione garantía.";
            LInfo.Visible = true;
        }

        private void AD4_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(54, 296 );
            LInfo.Text = "Ingrese número de reparación.";
            LInfo.Visible = true;
        }

        private void AD5_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(15, 296);
            LInfo.Text = "Ingrese descripción del mantenimiento.";
            LInfo.Visible = true;
        }

        private void AD1_Click(object sender, EventArgs e)
        {

        }

        private void AD2_Click(object sender, EventArgs e)
        {

        }

        private void AD3_Click(object sender, EventArgs e)
        {

        }

        private void AD4_Click(object sender, EventArgs e)
        {

        }

        private void AD5_Click(object sender, EventArgs e)
        {

        }

        private void PanelRegistroMaquinaria_MouseEnter(object sender, EventArgs e)
        {

        }

        private void PanelRegistroMaquinaria_MouseMove(object sender, MouseEventArgs e)
        {
            LInfo.Visible = false;
            LCE.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"I:\PROYECTO\Lumiprint\Modulo Utilidades\MAQUINARIA.pdf");
        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



    }
}

