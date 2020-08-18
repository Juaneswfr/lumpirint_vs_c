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
    public partial class GestionarEmpleados : Form
    {
        public Empleado EmpleadoActual { get; set; }
        public Empleado EmpleadoSeleccionado { get; set; }
        public static Empleado Empleado;
        public static Empleado ConsultarEmplead;
        public GestionarEmpleados(Empleado X)
        {
            Empleado = X;

            InitializeComponent();
            switch (X.Nombre_cargo)
            {
                case TipoCargo.Contador:
                    RegistrarEmpleado.Visible = false;
                    ActualizarEmpleado.Visible = false;
                    break;
                case TipoCargo.Diseñador:
                    RegistrarEmpleado.Visible = false;
                    ActualizarEmpleado.Visible = false;
                    break;
            }
        }
        Empleado em = new Empleado();



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


        private void ActualizarEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActulizarEmpleadoP));
        }

        private void ActualizarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActulizarEmpleado));
        }

        private void RegistrarEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarEmpleadoP));
        }

        private void RegistrarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarEmpleado));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarEmpleado_Click(object sender, EventArgs e)
        {

            if (Datagriedemple.SelectedRows.Count == 1)
            {
                
                Int64 Id_em = Convert.ToInt64(Datagriedemple.CurrentRow.Cells[0].Value);
                EmpleadoSeleccionado = Empleado.ObtenerEmpleado(Id_em);
                EmpleadoActual = EmpleadoSeleccionado;
                if (EmpleadoSeleccionado != null)
                {
                    LaEs.ForeColor = Color.YellowGreen;
                    LaCa.ForeColor = Color.YellowGreen;
                    AD7.Visible = false;
                    AD8.Visible = false;
                    Modificar.Visible = true;
                    TareaXlabel.Text = "Actualizar Empleado";
                    Registrar.Visible = false;
                    Modificar.Location = new Point(119, 432);

                    EmpleadoActual = EmpleadoSeleccionado;
                    CajaNom.Text = EmpleadoSeleccionado.Nombre_em;
                    CajaDocu.Text = Convert.ToString(EmpleadoSeleccionado.No_Documento_em);
                    CajaApe.Text = EmpleadoSeleccionado.Apellido_em;
                    CajaCel.Text = Convert.ToString(EmpleadoSeleccionado.Celular_em);
                    CajaTel.Text = Convert.ToString(EmpleadoSeleccionado.Telefono_em);
                    CajaDirecc.Text = EmpleadoSeleccionado.Direccion_em;
                    CajaCorreo.Text = EmpleadoSeleccionado.Correo_em;
                    ComboEstado.Text = EmpleadoSeleccionado.Estado_em;
                    ComboCargo.Text = Convert.ToString(EmpleadoSeleccionado.Nombre_cargo);
                    PanelRegistroEmpleados.Visible = true;
                }
            }
            else
            {
                SeleccioneUnaFila Fila = new SeleccioneUnaFila();
                Fila.ShowDialog();
            }


        }
        private void RegistrarEmpleado_Click(object sender, EventArgs e)
        {
            
            TareaXlabel.Text = "Registrar Empleado";
            Registrar.Visible = true;
            Limpiar();
            LaEs.ForeColor = Color.Red;
            LaCa.ForeColor = Color.Red;
            Modificar.Visible = false;
            Registrar.Location = new Point(119, 432);
            PanelRegistroEmpleados.Visible = true;
        }


        private void GestionarEmpleados_Load(object sender, EventArgs e)
        {
        }

        private void GenerarReporte_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (CajaDocu.Text == "" | CajaNom.Text == "" | CajaApe.Text == ""
                | CajaCel.Text == "" | CajaDirecc.Text == "" | CajaCorreo.Text == "" |
                ComboEstado.Text == "-Seleccione Estado-" | ComboCargo.Text == "-Seleccione Cargo-"
                | CajaTel.Text == "")
            {
                ModificacionIncompleta Incompleto = new ModificacionIncompleta();
                Incompleto.ShowDialog();
            }
            else
            {

                Empleado PEmpleado = new Empleado();
                PEmpleado.No_Documento_em = Convert.ToInt64(CajaDocu.Text);
                PEmpleado.Nombre_em = CajaNom.Text;
                PEmpleado.Apellido_em = CajaApe.Text;
                PEmpleado.Celular_em = Convert.ToInt64(CajaCel.Text);
                PEmpleado.Telefono_em = Convert.ToInt64(CajaTel.Text);
                PEmpleado.Direccion_em = CajaDirecc.Text;
                PEmpleado.Correo_em = CajaCorreo.Text;
                PEmpleado.Estado_em = ComboEstado.Text;
                PEmpleado.Nombre_cargo = (TipoCargo)Enum.Parse(typeof(TipoCargo), ComboCargo.Text);
                PEmpleado.Id_em = EmpleadoActual.Id_em;


                int ResultadoEm = Empleado.ActualizarEmpleado(PEmpleado);
                if (ResultadoEm > 0)
                {
                    Datagriedemple.DataSource = Empleado.ConsultarEmpleado(Convert.ToString(PEmpleado.No_Documento_em));
                    Nombres();
                    ModificacionCompleta Completo = new ModificacionCompleta();
                    Completo.ShowDialog();
                    Limpiar();
                    PanelRegistroEmpleados.Visible = false;
                    En_PDF();
                }
                else
                {
                    ModificacionIncompleta Incompleto = new ModificacionIncompleta();
                    Incompleto.ShowDialog();

                }
            }
        }
        void ADV()
        {
            Lau.Visible = true;
            ADG.Visible = true;
        }
        private void PanelRegistroEmpleados_Paint(object sender, PaintEventArgs e)
        {
            if (LaEs.ForeColor == Color.Red)
            {
                AD7.Visible = true;
                ADV();
                if (LaCa.ForeColor == Color.Red)
                {
                    AD8.Visible = true;
                    ADV();
                }
            }
            else if (LaCa.ForeColor == Color.Red)
            {
                AD8.Visible = true;
                ADV();
                if (LaEs.ForeColor == Color.Red)
                {
                    AD7.Visible = true;
                    ADV();
                }
            }
            else if (AD1.Visible == true | AD2.Visible == true | AD3.Visible == true | AD4.Visible == true
                | AD5.Visible == true | AD6.Visible == true)
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
        private void CerrarPanelREmpleados_Click(object sender, EventArgs e)
        {
            
            Limpiar();
            Lau.Visible = false;
            ADG.Visible = false;
            LCE.Visible = false;
            PanelRegistroEmpleados.Visible = false;
            LInfo.Visible = false;
            

        }

        private void CajaDocu_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaCel_KeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                    return;
                }
                else
                {
                    e.Handled = true;
                }
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
            else if (Char.IsSeparator (e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void CajaNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void CajaApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }
        void Nombres()
        {
            Datagriedemple.Columns["Id_em"].HeaderText = "Código";
            Datagriedemple.Columns["No_Documento_em"].HeaderText = "Número de documento";
            Datagriedemple.Columns["Nombre_em"].HeaderText = "Nombre";
            Datagriedemple.Columns["Apellido_em"].HeaderText = "Apellido";
            Datagriedemple.Columns["Celular_em"].HeaderText = "Celular";
            Datagriedemple.Columns["Telefono_em"].HeaderText = "Teléfono";
            Datagriedemple.Columns["Direccion_em"].HeaderText = "Dirección";
            Datagriedemple.Columns["Correo_em"].HeaderText = "Correo";
            Datagriedemple.Columns["Estado_em"].HeaderText = "Estado";
            Datagriedemple.Columns["Nombre_cargo"].HeaderText = "Cargo"; 
        }

        private void ConsultarEmpleado_Click(object sender, EventArgs e)
        {
            Datagriedemple.DataSource = Empleado.ConsultarEmpleado(TextConsultar.Text);
            Nombres();

        }

        private void TextConsultar_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgregarEmpleadoo_Click(object sender, EventArgs e)
        {
            
            Empleado PEmpleado = new Empleado();

            if (CajaDocu.Text == "" | CajaNom.Text == "" | CajaApe.Text == ""
                  | CajaCel.Text == "" | CajaDirecc.Text == "" | CajaCorreo.Text == "" |
                  ComboEstado.Text == "-Seleccione Estado-" | ComboCargo.Text == "-Seleccione Cargo-"
                  | ComprobarFormatoEmail(CajaCorreo.Text) == false)
            {
                Registro_Incompleto Incompleto = new Registro_Incompleto();
                Incompleto.ShowDialog();
            }

            else
            {

                PEmpleado.No_Documento_em = Convert.ToInt64(CajaDocu.Text);
                string op = em.Existencia_Empleado(CajaDocu.Text);
                if (op == "No existe")
                {
                    PEmpleado.Correo_em = CajaCorreo.Text;
                        PEmpleado.Nombre_em = CajaNom.Text;
                        PEmpleado.Apellido_em = CajaApe.Text;
                        PEmpleado.Celular_em = Convert.ToInt64(CajaCel.Text);
                        PEmpleado.Direccion_em = CajaDirecc.Text;

                        PEmpleado.Estado_em = ComboEstado.Text;
                        PEmpleado.Nombre_cargo = (TipoCargo)Enum.Parse(typeof(TipoCargo), ComboCargo.Text);
                    
                    if (CajaTel.Text != "")
                    {
                        PEmpleado.Telefono_em = Convert.ToInt64(CajaTel.Text);
                    }
                    else
                    {
                        PEmpleado.Telefono_em = 0;
                    }
                    int ResultadoReg = Empleado.RegistrarEmpleado(PEmpleado);

                    if (ResultadoReg > 0)
                    {
                        Datagriedemple.DataSource = Empleado.ConsultarEmpleado(Convert.ToString(PEmpleado.No_Documento_em));
                        Nombres();
                        RegistroCompletado Completo = new RegistroCompletado();
                        Completo.ShowDialog();
                        Limpiar();
                        PanelRegistroEmpleados.Visible = false;
                        En_PDF();
                    }
                    else
                    {

                        Registro_Incompleto Incompleto = new Registro_Incompleto();
                        Incompleto.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Este Numero de documento ya esta registrado");
                }



            }
        }



        private void BTNBuscar_Click(object sender, EventArgs e)
        {

        }

        private void Datagriedemple_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void Limpiar()
        {
            CajaDocu.Clear();
            CajaNom.Clear();
            CajaApe.Clear();
            CajaCel.Clear();
            CajaTel.Clear();
            CajaDirecc.Clear();
            CajaCorreo.Clear();
            ComboCargo.Text = "-Seleccione Cargo-";
            ComboEstado.Text = "-Seleccione Estado-";

        }

        private void GenerarUnReporte_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.GenerarReporteP));
        }

        private void GenerarUnReporte_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.GenerarReporte));
        }

        private void ConsultarEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarEmpleadoxP));
        }

        private void ConsultarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarEmpleadox));
        }

        private void BtnGuardar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.ActualizaarP));
        }

        private void BtnGuardar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizaar));
        }

        private void AgregarEmpleadoo_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.RegistrarP));
        }

        private void AgregarEmpleadoo_MouseLeave(object sender, EventArgs e)
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

        private void GenerarUnReporte_Click(object sender, EventArgs e)
        {

        }

        private void CajaDocu_TextChanged(object sender, EventArgs e)
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

        private void CajaApe_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboEstado_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void ComboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboCargo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Datagriedemple_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CajaDocu_TextChanged_1(object sender, EventArgs e)
        {
            if (CajaDocu.Text == "")
            {
                DocLabel.ForeColor = Color.Red;
                AD1.Visible = true;

            }
            else
            {
                DocLabel.ForeColor = Color.YellowGreen;
                AD1.Visible=false;
            }
        }
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CajaNom_TextChanged(object sender, EventArgs e)
        {
            if (CajaNom.Text == "")
            {
               LaNomb.ForeColor = Color.Red;
               AD2.Visible = true;
            }
            else
            {
                LaNomb.ForeColor = Color.YellowGreen;
                AD2.Visible = false;
            }
        }

        private void CajaApe_TextChanged_1(object sender, EventArgs e)
        {
            if (CajaApe.Text == "")
            {
                LaAp.ForeColor = Color.Red;
                AD3.Visible = true;
            }
            else
            {
                LaAp.ForeColor = Color.YellowGreen;
                AD3.Visible = false;
            }
        }

        private void CajaCel_TextChanged(object sender, EventArgs e)
        {
            if (CajaCel.Text == "")
            {
                LaCe.ForeColor = Color.Red;
                AD4.Visible = true;
            }
            else
            {
                LaCe.ForeColor = Color.YellowGreen;
                AD4.Visible = false;
            }
        }

        private void CajaDirecc_TextChanged(object sender, EventArgs e)
        {
            if (CajaDirecc.Text == "")
            {
                LaDi.ForeColor = Color.Red;
                AD5.Visible = true;

            }
            else
            {
                LaDi.ForeColor = Color.YellowGreen;
                AD5.Visible = false;
         
            }
        }

        private void ComboEstado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (ComboEstado.Text != "-Seleccione Estado-")
            {
                LaEs.ForeColor = Color.YellowGreen;
                AD7.Visible = false;
            }
            else
            {
                LaEs.ForeColor = Color.Red;
                AD7.Visible = true; 
            }

        }

        private void ComboCargo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (ComboCargo.Text != "-Seleccione Cargo-")
            {
                LaCa.ForeColor = Color.YellowGreen;
                AD8.Visible = false;
            }
            else
            {
                LaCa.ForeColor = Color.Red;
                AD8.Visible = true;
            }

        }

        private void AD1_Click(object sender, EventArgs e)
        {

        }

        private void CajaCorreo_TextChanged(object sender, EventArgs e)
        {
            if (CajaCorreo.Text == "" | ComprobarFormatoEmail(CajaCorreo.Text) == false)
            {
                LaCo.ForeColor = Color.Red;
                AD6.Visible = true;

            }
            else
            {
                LaCo.ForeColor = Color.YellowGreen;
                AD6.Visible = false;

            }
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
            PdfPTable PdTabla = new PdfPTable(Datagriedemple.Columns.Count);
            PdTabla.DefaultCell.Padding = 3;
            
            float[] HW = GetTamañoColumnas(Datagriedemple);
            PdTabla.SetWidths(HW);
            PdTabla.WidthPercentage = 100;
            PdTabla.DefaultCell.BorderWidth = 2;
            PdTabla.HorizontalAlignment = Element.ALIGN_CENTER;
            BaseColor b = new BaseColor(230, 141, 55);
            PdTabla.DefaultCell.BorderColor = b;
            for (i = 0; i < Datagriedemple.ColumnCount; i++)
            {
                PdTabla.AddCell(Datagriedemple.Columns[i].HeaderText);
                
            }
            PdTabla.HeaderRows = 1;
            PdTabla.DefaultCell.BorderWidth = 1;
            BaseColor a = new BaseColor(162, 205, 100);
            PdTabla.DefaultCell.BorderColor = a;
            for (i = 0; i < Datagriedemple.Rows.Count; i++)
            {
                for (j = 0; j < Datagriedemple.Columns.Count; j++)
               {
                   if (Datagriedemple[j, i].Value != null)
                   {

                       PdTabla.AddCell(new Phrase(Datagriedemple[j, i].Value.ToString()));

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
                GuardarArchivo.FileName = "Empleado No_" + Datagriedemple.CurrentRow.Cells[0].Value + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + DateTime.Now.ToString("hhmm") + ".pdf";
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
                    imagen.ScaleAbsolute(720f,125f);
                    Chunk Ch = new Chunk("Empleado/s", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, iTextSharp.text.Font.BOLD,Naranja));
                    Chunk Linea = new Chunk("**********************************************************************************************************************************", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, iTextSharp.text.Font.BOLD));
                    Paragraph P1 = new Paragraph(Ch);
                    Chunk Re = new Chunk("Reporte realizado por: " + Empleado.Nombre_em + " " + Empleado.Apellido_em + "       Cargo que desempeña: " + Empleado.Nombre_cargo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD,Verde));
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
        private void GenerarUnReporte_Click_1(object sender, EventArgs e)
        {
            if (Datagriedemple.Rows.Count == 0)
            {
                Consulta Consultar = new Consulta();
                Consultar.ShowDialog(); ;
            }
            else
            {
                En_PDF();
                Datagriedemple.DataSource = Empleado.ConsultarEmpleado(TextConsultar.Text);
                Nombres();
            }
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
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarEmpleado_MouseHover(object sender, EventArgs e)
        {
            LR1.Visible = true;
        }

        private void GenerarUnReporte_MouseHover(object sender, EventArgs e)
        {
            LG1.Visible = true;
            LG2.Visible = true;
        }
        private void ActualizarEmpleado_MouseEnter(object sender, EventArgs e)
        {
            LA1.Visible = true;
            LA2.Visible = true;
        }

        private void GestionarEmpleados_MouseMove(object sender, MouseEventArgs e)
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

        private void PanelRegistroEmpleados_MouseHover(object sender, EventArgs e)
        {
    
        }

        private void ConsultarEmpleado_MouseHover(object sender, EventArgs e)
        {
            LCO1.Visible = true;
            LCO2.Visible = true;
        }

        private void AD1_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(42, 373);
            LInfo.Text = "Ingrese un numero de documento.";
            LInfo.Visible = true;
        }

        private void AD2_MouseHover(object sender, EventArgs e)
        {
            LInfo.Location = new Point(42, 373);
            LInfo.Text = "Ingrese primer o segundo nombre.";
            LInfo.Visible = true;
        }

        private void AD3_MouseHover(object sender, EventArgs e)
        {

            LInfo.Location = new Point(42, 373);
            LInfo.Text = "Ingrese primer o segundo apellido.";
            LInfo.Visible = true;

        }

        private void AD4_MouseHover(object sender, EventArgs e)
        {
            
            LInfo.Text = "Ingrese un numero de celular.";
            LInfo.Location = new Point(60, 373);
            LInfo.Visible = true;
        }

        private void AD5_MouseHover(object sender, EventArgs e)
        {
           
            LInfo.Text = "Ingrese una dirección.";
            LInfo.Location = new Point(90, 373);
            LInfo.Visible = true;
        }

        private void AD6_MouseHover(object sender, EventArgs e)
        {
           
            LInfo.Text = "Ingrese un correo valido.";
            LInfo.Location = new Point(80, 373);
            LInfo.Visible = true;
        }

        private void AD7_MouseHover(object sender, EventArgs e)
        {
            LInfo.Text = "Seleccione un estado.";
            LInfo.Location = new Point(100, 373);
            LInfo.Visible = true;
        }

        private void AD8_MouseHover(object sender, EventArgs e)
        {
            
            LInfo.Text = "Seleccione un cargo.";
            LInfo.Location = new Point(100, 373);
            LInfo.Visible = true;
        }

        private void CerrarPanelREmpleados_MouseHover(object sender, EventArgs e)
        {
            LCE.Visible = true;
            LInfo.Visible = false;
        }

        private void Atras_MouseHover(object sender, EventArgs e)
        {
                LV1.Visible = true;

        }

        private void Info(object sender, EventArgs e)
        {
            LInfo.Visible = false;
            LCE.Visible = false;
        }

        private void GestionarEmpleados_MouseHover(object sender, EventArgs e)
        {

        }

        private void PanelRegistroEmpleados_MouseMove(object sender, MouseEventArgs e)
        {
            LInfo.Visible = false;
            LCE.Visible = false;

        }

        private void AD7_Click(object sender, EventArgs e)
        {

        }

        private void CajaCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"I:\PROYECTO\Lumiprint\Modulo Utilidades\EMPLEADOS.pdf");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
    }
}

