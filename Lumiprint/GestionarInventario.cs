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
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;
namespace Vista
{
    public partial class GestionarInventario : Form
    {
        public static Proveedor Proveedor;
        public static Empleado Empleado;
        public static Inventario Inventario;
        public Inventario InvId { get; set; }
        public Inventario InvIdAc { get; set; }
        public Inventario InvGI { get; set; }
        public Inventario InvGA { get; set; }
        public Inventario InvActual { get; set; }
        public Inventario InvSeleccionado { get; set; }
        public Proveedor ProvAct { get; set; }
        public Proveedor ProvSele{ get; set; }

        public SqlConnection CNX = new SqlConnection("Data Source=.; Initial Catalog=LumiPrint; Integrated Security=True");

        public GestionarInventario(Empleado X)
        {
            Empleado = X;

            InitializeComponent();
            switch (X.Nombre_cargo)
            {
                case TipoCargo.Administrador:
                    RegistrarInventario.Visible = false;
                    break;
                case TipoCargo.Contador:
                    RegistrarInventario.Visible=false;
                    ActualizarInventario.Visible = false;
                    break;
                case TipoCargo.Diseñador:
                    RegistrarInventario.Visible = false;
                    break;
                    }
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


        private void ActualizarInventario_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_inventarioP));
        }

        private void ActualizarInventario_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Actualizar_inventario));
        }

        private void RegistrarInventario_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_inventarioP));
        }

        private void RegistrarInventario_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Registrar_inventario));
        }

        private void RegistrarInventario_Click(object sender, EventArgs e)
        {

        }

        private void GestionarInventario_Load(object sender, EventArgs e)
        {
            Proveedor PProveedor = new Proveedor();
            DataTable Tabla = new DataTable();
            PProveedor.EmpresaSelect(Tabla);
            CajaEm.DataSource = Tabla;
            CajaEm.ValueMember = "Empresa";
            CajaEm.DisplayMember = "Empresa";

            
            AutoCompleteStringCollection Colección = new AutoCompleteStringCollection();
            foreach (DataRow row in Tabla.Rows)
            {
                Colección.Add(Convert.ToString(row["Empresa"]));
            }
            CajaEm.AutoCompleteCustomSource = Colección;
            CajaEm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CajaEm.AutoCompleteSource = AutoCompleteSource.CustomSource;

            chart1.Visible = false;
            try
            {
                CNX.Open();
                
                SqlCommand CmdeI = new SqlCommand(string.Format("select * from Inventario"), CNX);
                SqlDataReader LeeerI = CmdeI.ExecuteReader();
                while (LeeerI.Read())
                {
                    chart1.Series["Pieza"].Points.AddXY(LeeerI["Tipo_de_pieza"], LeeerI["Cantidad_Existente"].ToString());
                }
                
               CNX.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void GestionarInventario_Load_1(object sender, EventArgs e)
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
            PdfPTable PdTabla = new PdfPTable(DatagriedInv.Columns.Count);
            PdTabla.DefaultCell.Padding = 3;
            float[] HW = GetTamañoColumnas(DatagriedInv);
            PdTabla.SetWidths(HW);
            PdTabla.WidthPercentage = 100;
            PdTabla.DefaultCell.BorderWidth = 2;
            PdTabla.HorizontalAlignment = Element.ALIGN_CENTER;
            BaseColor b = new BaseColor(230, 141, 55);
            PdTabla.DefaultCell.BorderColor = b;
            for (i = 0; i < DatagriedInv.ColumnCount; i++)
            {
                PdTabla.AddCell(DatagriedInv.Columns[i].HeaderText);

            }
            PdTabla.HeaderRows = 1;
            PdTabla.DefaultCell.BorderWidth = 1;
            BaseColor a = new BaseColor(162, 205, 100);
            PdTabla.DefaultCell.BorderColor = a;
            for (i = 0; i < DatagriedInv.Rows.Count; i++)
            {
                for (j = 0; j < DatagriedInv.Columns.Count; j++)
                {
                    if (DatagriedInv[j, i].Value != null)
                    {

                        PdTabla.AddCell(new Phrase(DatagriedInv[j, i].Value.ToString()));

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
                GuardarArchivo.FileName = "Pieza No_" + DatagriedInv.CurrentRow.Cells[0].Value + "_" + DateTime.Now.ToString("yyyymmdd") + "_" + DateTime.Now.ToString("hhmm") + ".pdf";
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
                    Chunk Ch = new Chunk("Inventario", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, iTextSharp.text.Font.BOLD, Naranja));
                    Chunk Linea = new Chunk("**********************************************************************************************************************************", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, iTextSharp.text.Font.BOLD));
                    Paragraph P1 = new Paragraph(Ch);
                    Chunk Re = new Chunk("Reporte realizado por: " + Empleado.Nombre_em + " " + Empleado.Apellido_em + "       Cargo que desempeña: " + Empleado.Nombre_cargo, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P2 = new Paragraph(Re);
                    Chunk Fecha = new Chunk("Fecha y hora:" + DateTime.Now.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, Verde));
                    Paragraph P3 = new Paragraph(Fecha);
                    Chunk Grafica = new Chunk("Grafica cantidad existente" , FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD, Naranja));
                    Paragraph P4 = new Paragraph(Grafica);
                    P1.Alignment = Element.ALIGN_CENTER; P2.Alignment = Element.ALIGN_CENTER; P3.Alignment = Element.ALIGN_CENTER; P4.Alignment = Element.ALIGN_CENTER;
                    doc.Add(imagen);
                    doc.Add(new Paragraph(Linea));
                    doc.Add(P1);
                    doc.Add(P2);
                    doc.Add(P3);
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph(Linea));
                    doc.Add(new Paragraph("                       "));
                    var Chartimage = new MemoryStream();
                    chart1.SaveImage(Chartimage, ChartImageFormat.Png);
                    iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(Chartimage.GetBuffer());
                    chartImage.Alignment = Element.ALIGN_CENTER;
                    ExportarPDf(doc);
                    doc.AddCreationDate();
                    doc.Add(new Paragraph("                       "));
                    doc.Add(P4);
                    doc.Add(chartImage);
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
            if (DatagriedInv.Rows.Count == 0)
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

        private void ConsultarInventario_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarMateriaPrimaP));
        }

        private void ConsultarInventario_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.BuscarMateriaPrima));
        }

        private void ActualizarInventario_Click(object sender, EventArgs e)
        {
            if (DatagriedInv.SelectedRows.Count == 1)
                {
            Int64 Id_pz = Convert.ToInt64(DatagriedInv.CurrentRow.Cells[0].Value);
            InvSeleccionado = Inventario.ObtenerMateriaPrima(Id_pz);
            InvActual = InvSeleccionado;
            PanelRegistroMateriaprima.Visible = true;
            TareaXlabel.Text = "Actualizar Inventario";
            Registrar.Visible = false;
            Limpiar();
            Actualizar.Location = new Point(133, 405);
            Actualizar.Visible = true;
                

            if (InvSeleccionado != null)
            {

                InvActual = InvSeleccionado;
                CajaTp.Text = InvSeleccionado.Tipo_de_pieza;
                CajaCE.Text = Convert.ToString(InvSeleccionado.Cantidad_Existente);
                CajaTam.Text = InvSeleccionado.Tamaño;
                CajaVpro.Text = Convert.ToString(InvSeleccionado.Valor_Proveedor);
                CajaEm.Text = InvSeleccionado.Empresa;
                CajaDes.Text = InvSeleccionado.Descripcion;
            }
                }
             else
             {
                 SeleccioneUnaFila form = new SeleccioneUnaFila();
                 form.ShowDialog();
             }
        }

        private void TareaXlabel_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarInventario_Click_1(object sender, EventArgs e)
        {
            PanelRegistroMateriaprima.Visible = true;
            TareaXlabel.Text = "Registrar Materia prima";
            Registrar.Visible = true;
            Limpiar();
            LaE.ForeColor = Color.Red;
            Actualizar.Visible = false;
            Registrar.Location = new Point(133, 405);
        }

private void Limpiar()
{
    CajaTp.Clear();
    CajaCE.Clear();
    CajaTam.Clear();
    CajaVpro.Clear();
    CajaDes.Clear();
    CajaEm.Text = "-Seleccione Empresa-";
}



private void Actualizar_Click(object sender, EventArgs e)
{
       Inventario PInventario = new Inventario();
       string i = CajaEm.Text;
       InvId = Inventario.ObtenerIDEmp(i);
       if (InvId != null)
       {
           InvIdAc = InvId;
           PInventario.Id_Prov = InvIdAc.Id_Prov;
       }
       PInventario.Tipo_de_pieza = CajaTp.Text;
       PInventario.Cantidad_Existente = Convert.ToInt64(CajaCE.Text);
       PInventario.Tamaño = CajaTam.Text;
       PInventario.Valor_Proveedor = Convert.ToDecimal(CajaVpro.Text);
       PInventario.Empresa = CajaEm.Text;
       PInventario.Descripcion = CajaDes.Text;
       PInventario.Id_pz = InvActual.Id_pz;


       int ResultadoInv = Inventario.ActualizarMateriaPrima(PInventario);
            if(ResultadoInv > 0)
                {
                   ModificacionCompleta Completo = new ModificacionCompleta();
                   Completo.ShowDialog();
                   DatagriedInv.DataSource = Inventario.ConsultarMateriaPrima((Convert.ToString("")));
                   Nombres();
                   Limpiar();
                   PanelRegistroMateriaprima.Visible = false;
                   En_PDF();
            }
            else
                 {
                     ModificacionIncompleta Incompleto = new ModificacionIncompleta();
                     Incompleto.ShowDialog();
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

private void CajaCantidadE_KeyPress(object sender, KeyPressEventArgs e)
{

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

private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void PanelRegistroMateriaprima_Paint(object sender, PaintEventArgs e)
{
    if (LaE.ForeColor == Color.Red)
    {
        AD6.Visible = true;
        ADV();
    }
 else if (AD1.Visible == true | AD3.Visible == true | AD4.Visible == true
                | AD5.Visible == true | AD7.Visible == true)
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

private void Registrar_Click(object sender, EventArgs e)
{
    Inventario PInventario = new Inventario();

    if (CajaTp.Text == "" | CajaCE.Text == ""
                | CajaTam.Text == "" | CajaVpro.Text == "" | CajaEm.Text == "-Seleccione Empresa-" |
                CajaDes.Text == "")
    {
        Registro_Incompleto Incompleto = new Registro_Incompleto();
        Incompleto.ShowDialog();
    }
    else
    {
        string i = CajaEm.Text;
        InvId = Inventario.ObtenerIDEmp(i);

        if (InvId != null)
        {
            InvIdAc = InvId;
            PInventario.Id_Prov = InvIdAc.Id_Prov;
        }

        PInventario.Id_Prov = PInventario.Id_Prov;
        PInventario.Tipo_de_pieza = CajaTp.Text;
        PInventario.Cantidad_Existente = Convert.ToInt64(CajaCE.Text);
        PInventario.Tamaño = CajaTam.Text;
        PInventario.Valor_Proveedor = Convert.ToDecimal(CajaVpro.Text);
        PInventario.Empresa = CajaEm.Text;

        PInventario.Descripcion = CajaDes.Text;

        PanelRegistroMateriaprima.Visible = false;
        int ResultadoReg = Inventario.RegistrarMateriaPrima(PInventario);
        if (ResultadoReg > 0)
        {
            RegistroCompletado Completo = new RegistroCompletado();
            Completo.ShowDialog();
            DatagriedInv.DataSource = Inventario.ConsultarMateriaPrima(Convert.ToString(""));
            Nombres();
            En_PDF();
            Limpiar();
        }
        else
        {
            Registro_Incompleto Incompleto = new Registro_Incompleto();
            Incompleto.ShowDialog();
        }
    }

}
private void CerrarPanelRInventario_Click(object sender, EventArgs e)
{
    PanelRegistroMateriaprima.Visible = false;
    CajaTp.Clear();
    CajaCE.Clear();
    CajaTam.Clear();
    Registrar.Location = new Point(110, 398);
}

private void CajaTipoPieza_KeyPress(object sender, KeyPressEventArgs e)
{

}

private void CajaTamaño_KeyPress(object sender, KeyPressEventArgs e)
{

}

private void label8_Click(object sender, EventArgs e)
{

}
   void Nombres()
    {
        DatagriedInv.Columns["Id_pz"].HeaderText = "Código";
        DatagriedInv.Columns["Tipo_de_pieza"].HeaderText = "Tipo de pieza";
        DatagriedInv.Columns["Descripcion"].HeaderText = "Descripción";
        DatagriedInv.Columns["Tamaño"].HeaderText = "Tamaño";
        DatagriedInv.Columns["Cantidad_Existente"].HeaderText = "Cantidad existente";
        DatagriedInv.Columns["Id_Prov"].HeaderText = "Código Proveedor";
        DatagriedInv.Columns["Empresa"].HeaderText = "Empresa";
        DatagriedInv.Columns["Valor_Proveedor"].HeaderText = "Valor Proveedor";

    }
private void ConsultarInventario_Click(object sender, EventArgs e)
{
    DatagriedInv.DataSource = Inventario.ConsultarMateriaPrima(Consultar.Text);
    Nombres();
}

private void CajaTp_TextChanged(object sender, EventArgs e)
{
    if (CajaTp.Text == "")
    {
        LaTp.ForeColor = Color.Red;
        AD1.Visible = true;

    }
    else
    {
        LaTp.ForeColor = Color.YellowGreen;
        AD1.Visible = false;
    }
}

private void CajaTp_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
    {
        e.Handled = true;
        return;
    }
}

private void Consultar_TextChanged(object sender, EventArgs e)
{

}

private void CajaEm_SelectedIndexChanged(object sender, EventArgs e)
{


    if (CajaEm.Text != "-Seleccione Empresa-")
    {
        LaE.ForeColor = Color.YellowGreen;
        AD6.Visible = false;
    }
    else
    {
        LaE.ForeColor = Color.Red;
        AD6.Visible = true;
    }

}

private void CajaEm_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
    {
        e.Handled = true;
        return;
    }
}

private void DatagriedInv_KeyDown(object sender, KeyEventArgs e)
{
    
}



private void DatagriedInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void CajaDes_KeyPress(object sender, KeyPressEventArgs e)
{
    
}

private void CajaVp_KeyPress(object sender, KeyPressEventArgs e)
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

private void CajaCE_KeyPress(object sender, KeyPressEventArgs e)
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

private void CajaTam_KeyPress(object sender, KeyPressEventArgs e)
{

}

private void CajaEm_Click(object sender, EventArgs e)
{

}

private void AgreProve_Click(object sender, EventArgs e)
{
    GestionarProveedores form = new GestionarProveedores(Empleado);
    form.Show();
    this.Hide();
}

private void Atras_MouseHover(object sender, EventArgs e)
{

    LV1.Visible = true;
}

private void ConsultarInventario_MouseHover(object sender, EventArgs e)
{
    LCO1.Visible = true;
    LCO2.Visible = true;
}

private void GestionarInventario_MouseMove(object sender, MouseEventArgs e)
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

private void ActualizarInventario_MouseHover(object sender, EventArgs e)
{
    LA1.Visible = true;
    LA2.Visible = true;
}

private void GenerarReporte_MouseHover(object sender, EventArgs e)
{
    LG1.Visible = true;
    LG2.Visible = true;
}

private void RegistrarInventario_MouseHover(object sender, EventArgs e)
{
    LR1.Visible = true;
}

private void CerrarPanelRInventario_MouseHover(object sender, EventArgs e)
{
    LCE.Visible = true;
    LInfo.Visible = false;
}

private void CajaCE_TextChanged(object sender, EventArgs e)
{
    if (CajaCE.Text == "")
    {
        LaCaE.ForeColor = Color.Red;
        AD3.Visible = true;

    }
    else
    {
        LaCaE.ForeColor = Color.YellowGreen;
        AD3.Visible = false;
    }
}

private void CajaTam_TextChanged(object sender, EventArgs e)
{
    if (CajaTam.Text == "")
    {
        LaT.ForeColor = Color.Red;
        AD4.Visible = true;

    }
    else
    {
        LaT.ForeColor = Color.YellowGreen;
        AD4.Visible = false;
    }
}

private void CajaVpro_TextChanged(object sender, EventArgs e)
{
        if (CajaVpro.Text == "")
    {
        LaVPro.ForeColor = Color.Red;
        AD5.Visible = true;

    }
    else
    {
        LaVPro.ForeColor = Color.YellowGreen;
        AD5.Visible = false;
    }
}

private void CajaDes_TextChanged(object sender, EventArgs e)
{
    if (CajaDes.Text == "")
    {
        LaD.ForeColor = Color.Red;
        AD7.Visible = true;

    }
    else
    {
        LaD.ForeColor = Color.YellowGreen;
        AD7.Visible = false;
    }
}

private void PanelRegistroMateriaprima_MouseMove(object sender, MouseEventArgs e)
{
    LInfo.Visible = false;
    LCE.Visible = false;
}

private void AD1_Click(object sender, EventArgs e)
{

}

private void AD1_MouseHover(object sender, EventArgs e)
{
    LInfo.Location = new Point(55, 343);
    LInfo.Text = "Ingrese nombre de tipo de pieza.";
    LInfo.Visible = true;
}

private void AD2_MouseHover(object sender, EventArgs e)
{
    LInfo.Location = new Point(67, 343);
    LInfo.Text = "Ingrese valor del producto.";
    LInfo.Visible = true;
}

private void AD3_MouseHover(object sender, EventArgs e)
{
    LInfo.Location = new Point(67, 343);
    LInfo.Text = "Ingrese cantidad del producto.";
    LInfo.Visible = true;
}

private void AD4_MouseHover(object sender, EventArgs e)
{
    LInfo.Location = new Point(67, 343);
    LInfo.Text = "Ingrese tamaño del producto.";
    LInfo.Visible = true;
}

private void AD5_MouseHover(object sender, EventArgs e)
{
    LInfo.Location = new Point(67, 343);
    LInfo.Text = "Ingrese valor del proveedor.";
    LInfo.Visible = true;
}

private void AD6_MouseHover(object sender, EventArgs e)
{
    LInfo.Location = new Point(67, 343);
    LInfo.Text = "Ingrese empresa del producto.";
    LInfo.Visible = true;
}

private void AD7_MouseHover(object sender, EventArgs e)
{
    LInfo.Location = new Point(55, 343);
    LInfo.Text = "Ingrese descripción del producto.";
    LInfo.Visible = true;
}

private void AD7_Click(object sender, EventArgs e)
{

}

private void AD6_Click(object sender, EventArgs e)
{

}

private void CajaEm_TextChanged(object sender, EventArgs e)
{
}

private void chart1_Click(object sender, EventArgs e)
{

}

private void button1_Click(object sender, EventArgs e)
{
    System.Diagnostics.Process.Start(@"I:\PROYECTO\Lumiprint\Modulo Utilidades\INVENTARIO.pdf");
}

private void Min_Click(object sender, EventArgs e)
{
    this.WindowState = FormWindowState.Minimized;
}






}

    }
