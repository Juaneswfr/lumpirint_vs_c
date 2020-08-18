namespace Vista
{
    partial class GestionarInventario
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionarInventario));
            this.Consultar = new System.Windows.Forms.TextBox();
            this.DatagriedInv = new System.Windows.Forms.DataGridView();
            this.LG2 = new System.Windows.Forms.Label();
            this.LG1 = new System.Windows.Forms.Label();
            this.LA2 = new System.Windows.Forms.Label();
            this.LA1 = new System.Windows.Forms.Label();
            this.LR1 = new System.Windows.Forms.Label();
            this.LCO2 = new System.Windows.Forms.Label();
            this.LCO1 = new System.Windows.Forms.Label();
            this.LV1 = new System.Windows.Forms.Label();
            this.LF1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LCE = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelRegistroMateriaprima = new System.Windows.Forms.Panel();
            this.LInfo = new System.Windows.Forms.Label();
            this.ADG = new System.Windows.Forms.PictureBox();
            this.Lau = new System.Windows.Forms.Label();
            this.AD7 = new System.Windows.Forms.PictureBox();
            this.AD4 = new System.Windows.Forms.PictureBox();
            this.AD6 = new System.Windows.Forms.PictureBox();
            this.AD5 = new System.Windows.Forms.PictureBox();
            this.AD3 = new System.Windows.Forms.PictureBox();
            this.AD1 = new System.Windows.Forms.PictureBox();
            this.AgreProve = new System.Windows.Forms.Button();
            this.CajaEm = new System.Windows.Forms.ComboBox();
            this.CajaDes = new System.Windows.Forms.RichTextBox();
            this.LaD = new System.Windows.Forms.Label();
            this.LaE = new System.Windows.Forms.Label();
            this.CajaVpro = new System.Windows.Forms.TextBox();
            this.LaVPro = new System.Windows.Forms.Label();
            this.Actualizar = new System.Windows.Forms.Button();
            this.Registrar = new System.Windows.Forms.Button();
            this.CerrarPanelRInventario = new System.Windows.Forms.Button();
            this.CajaTam = new System.Windows.Forms.TextBox();
            this.LaT = new System.Windows.Forms.Label();
            this.LaCaE = new System.Windows.Forms.Label();
            this.LaTp = new System.Windows.Forms.Label();
            this.CajaCE = new System.Windows.Forms.TextBox();
            this.CajaTp = new System.Windows.Forms.TextBox();
            this.TareaXlabel = new System.Windows.Forms.Label();
            this.GenerarReporte = new System.Windows.Forms.Button();
            this.ConsultarInventario = new System.Windows.Forms.Button();
            this.ActualizarInventario = new System.Windows.Forms.Button();
            this.RegistrarInventario = new System.Windows.Forms.Button();
            this.Atras = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Min = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DatagriedInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelRegistroMateriaprima.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD1)).BeginInit();
            this.SuspendLayout();
            // 
            // Consultar
            // 
            this.Consultar.BackColor = System.Drawing.Color.White;
            this.Consultar.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consultar.ForeColor = System.Drawing.Color.Black;
            this.Consultar.Location = new System.Drawing.Point(156, 102);
            this.Consultar.MaxLength = 60;
            this.Consultar.Name = "Consultar";
            this.Consultar.Size = new System.Drawing.Size(428, 30);
            this.Consultar.TabIndex = 46;
            this.Consultar.TabStop = false;
            this.Consultar.TextChanged += new System.EventHandler(this.Consultar_TextChanged);
            // 
            // DatagriedInv
            // 
            this.DatagriedInv.AllowUserToAddRows = false;
            this.DatagriedInv.AllowUserToDeleteRows = false;
            this.DatagriedInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DatagriedInv.BackgroundColor = System.Drawing.Color.Black;
            this.DatagriedInv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.YellowGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatagriedInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DatagriedInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatagriedInv.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.YellowGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DatagriedInv.DefaultCellStyle = dataGridViewCellStyle2;
            this.DatagriedInv.GridColor = System.Drawing.Color.Orange;
            this.DatagriedInv.Location = new System.Drawing.Point(153, 195);
            this.DatagriedInv.Name = "DatagriedInv";
            this.DatagriedInv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.YellowGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatagriedInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DatagriedInv.RowHeadersWidth = 40;
            this.DatagriedInv.Size = new System.Drawing.Size(752, 360);
            this.DatagriedInv.TabIndex = 45;
            this.DatagriedInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatagriedInv_KeyDown);
            this.DatagriedInv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatagriedInv_CellContentClick);
            // 
            // LG2
            // 
            this.LG2.AutoSize = true;
            this.LG2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LG2.ForeColor = System.Drawing.Color.DarkOrange;
            this.LG2.Location = new System.Drawing.Point(437, 713);
            this.LG2.Name = "LG2";
            this.LG2.Size = new System.Drawing.Size(205, 28);
            this.LG2.TabIndex = 50;
            this.LG2.Text = "información consultada.";
            this.LG2.Visible = false;
            // 
            // LG1
            // 
            this.LG1.AutoSize = true;
            this.LG1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LG1.ForeColor = System.Drawing.Color.DarkOrange;
            this.LG1.Location = new System.Drawing.Point(437, 685);
            this.LG1.Name = "LG1";
            this.LG1.Size = new System.Drawing.Size(194, 28);
            this.LG1.TabIndex = 49;
            this.LG1.Text = "Exporte un PDF con la";
            this.LG1.Visible = false;
            // 
            // LA2
            // 
            this.LA2.AutoSize = true;
            this.LA2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LA2.ForeColor = System.Drawing.Color.DarkOrange;
            this.LA2.Location = new System.Drawing.Point(170, 713);
            this.LA2.Name = "LA2";
            this.LA2.Size = new System.Drawing.Size(219, 28);
            this.LA2.TabIndex = 52;
            this.LA2.Text = "modificar su información.";
            this.LA2.Visible = false;
            // 
            // LA1
            // 
            this.LA1.AutoSize = true;
            this.LA1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LA1.ForeColor = System.Drawing.Color.DarkOrange;
            this.LA1.Location = new System.Drawing.Point(170, 685);
            this.LA1.Name = "LA1";
            this.LA1.Size = new System.Drawing.Size(216, 28);
            this.LA1.TabIndex = 51;
            this.LA1.Text = "Seleccione una pieza para";
            this.LA1.Visible = false;
            // 
            // LR1
            // 
            this.LR1.AutoSize = true;
            this.LR1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LR1.ForeColor = System.Drawing.Color.DarkOrange;
            this.LR1.Location = new System.Drawing.Point(721, 685);
            this.LR1.Name = "LR1";
            this.LR1.Size = new System.Drawing.Size(162, 28);
            this.LR1.TabIndex = 53;
            this.LR1.Text = "Registre una pieza.";
            this.LR1.Visible = false;
            // 
            // LCO2
            // 
            this.LCO2.AutoSize = true;
            this.LCO2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCO2.ForeColor = System.Drawing.Color.DarkOrange;
            this.LCO2.Location = new System.Drawing.Point(691, 119);
            this.LCO2.Name = "LCO2";
            this.LCO2.Size = new System.Drawing.Size(187, 28);
            this.LCO2.TabIndex = 55;
            this.LCO2.Text = "o con su debido filtro.";
            this.LCO2.Visible = false;
            // 
            // LCO1
            // 
            this.LCO1.AutoSize = true;
            this.LCO1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCO1.ForeColor = System.Drawing.Color.DarkOrange;
            this.LCO1.Location = new System.Drawing.Point(691, 91);
            this.LCO1.Name = "LCO1";
            this.LCO1.Size = new System.Drawing.Size(351, 28);
            this.LCO1.TabIndex = 54;
            this.LCO1.Text = "Presione para consultar todos los registros";
            this.LCO1.Visible = false;
            // 
            // LV1
            // 
            this.LV1.AutoSize = true;
            this.LV1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV1.ForeColor = System.Drawing.Color.DarkOrange;
            this.LV1.Location = new System.Drawing.Point(72, 17);
            this.LV1.Name = "LV1";
            this.LV1.Size = new System.Drawing.Size(214, 28);
            this.LV1.TabIndex = 0;
            this.LV1.Text = "Volver al menú principal.";
            this.LV1.Visible = false;
            // 
            // LF1
            // 
            this.LF1.AutoSize = true;
            this.LF1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LF1.ForeColor = System.Drawing.Color.YellowGreen;
            this.LF1.Location = new System.Drawing.Point(141, 60);
            this.LF1.Name = "LF1";
            this.LF1.Size = new System.Drawing.Size(328, 28);
            this.LF1.TabIndex = 56;
            this.LF1.Text = "Filtros: Código, Tipo de pieza, Empresa.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(609, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 28);
            this.label1.TabIndex = 58;
            this.label1.Text = "Buscar";
            // 
            // LCE
            // 
            this.LCE.AutoSize = true;
            this.LCE.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCE.ForeColor = System.Drawing.Color.DarkOrange;
            this.LCE.Location = new System.Drawing.Point(1266, 157);
            this.LCE.Name = "LCE";
            this.LCE.Size = new System.Drawing.Size(68, 28);
            this.LCE.TabIndex = 64;
            this.LCE.Text = "Cerrar.";
            this.LCE.Visible = false;
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisY.Interval = 2;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(336, 236);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Pieza";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(602, 300);
            this.chart1.TabIndex = 1000;
            this.chart1.Text = "chart1";
            title1.Name = "Objetos más comprados";
            this.chart1.Titles.Add(title1);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Vista.Properties.Resources.FondoSeguridad;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(146, 188);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(769, 374);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Vista.Properties.Resources.Borde_Text;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(144, 91);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(453, 53);
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Vista.Properties.Resources.Logotipo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1059, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 142);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // PanelRegistroMateriaprima
            // 
            this.PanelRegistroMateriaprima.BackColor = System.Drawing.Color.White;
            this.PanelRegistroMateriaprima.BackgroundImage = global::Vista.Properties.Resources.fondoxd;
            this.PanelRegistroMateriaprima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelRegistroMateriaprima.Controls.Add(this.LInfo);
            this.PanelRegistroMateriaprima.Controls.Add(this.ADG);
            this.PanelRegistroMateriaprima.Controls.Add(this.Lau);
            this.PanelRegistroMateriaprima.Controls.Add(this.AD7);
            this.PanelRegistroMateriaprima.Controls.Add(this.AD4);
            this.PanelRegistroMateriaprima.Controls.Add(this.AD6);
            this.PanelRegistroMateriaprima.Controls.Add(this.AD5);
            this.PanelRegistroMateriaprima.Controls.Add(this.AD3);
            this.PanelRegistroMateriaprima.Controls.Add(this.AD1);
            this.PanelRegistroMateriaprima.Controls.Add(this.AgreProve);
            this.PanelRegistroMateriaprima.Controls.Add(this.CajaEm);
            this.PanelRegistroMateriaprima.Controls.Add(this.CajaDes);
            this.PanelRegistroMateriaprima.Controls.Add(this.LaD);
            this.PanelRegistroMateriaprima.Controls.Add(this.LaE);
            this.PanelRegistroMateriaprima.Controls.Add(this.CajaVpro);
            this.PanelRegistroMateriaprima.Controls.Add(this.LaVPro);
            this.PanelRegistroMateriaprima.Controls.Add(this.Actualizar);
            this.PanelRegistroMateriaprima.Controls.Add(this.Registrar);
            this.PanelRegistroMateriaprima.Controls.Add(this.CerrarPanelRInventario);
            this.PanelRegistroMateriaprima.Controls.Add(this.CajaTam);
            this.PanelRegistroMateriaprima.Controls.Add(this.LaT);
            this.PanelRegistroMateriaprima.Controls.Add(this.LaCaE);
            this.PanelRegistroMateriaprima.Controls.Add(this.LaTp);
            this.PanelRegistroMateriaprima.Controls.Add(this.CajaCE);
            this.PanelRegistroMateriaprima.Controls.Add(this.CajaTp);
            this.PanelRegistroMateriaprima.Controls.Add(this.TareaXlabel);
            this.PanelRegistroMateriaprima.Location = new System.Drawing.Point(968, 188);
            this.PanelRegistroMateriaprima.Name = "PanelRegistroMateriaprima";
            this.PanelRegistroMateriaprima.Size = new System.Drawing.Size(366, 462);
            this.PanelRegistroMateriaprima.TabIndex = 24;
            this.PanelRegistroMateriaprima.Visible = false;
            this.PanelRegistroMateriaprima.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelRegistroMateriaprima_Paint);
            this.PanelRegistroMateriaprima.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelRegistroMateriaprima_MouseMove);
            // 
            // LInfo
            // 
            this.LInfo.AutoSize = true;
            this.LInfo.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfo.ForeColor = System.Drawing.Color.DarkOrange;
            this.LInfo.Location = new System.Drawing.Point(67, 343);
            this.LInfo.Name = "LInfo";
            this.LInfo.Size = new System.Drawing.Size(109, 28);
            this.LInfo.TabIndex = 63;
            this.LInfo.Text = "Información";
            this.LInfo.Visible = false;
            // 
            // ADG
            // 
            this.ADG.BackgroundImage = global::Vista.Properties.Resources.Adv;
            this.ADG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ADG.Location = new System.Drawing.Point(66, 375);
            this.ADG.Name = "ADG";
            this.ADG.Size = new System.Drawing.Size(23, 20);
            this.ADG.TabIndex = 62;
            this.ADG.TabStop = false;
            this.ADG.Visible = false;
            // 
            // Lau
            // 
            this.Lau.AutoSize = true;
            this.Lau.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lau.ForeColor = System.Drawing.Color.Red;
            this.Lau.Location = new System.Drawing.Point(86, 371);
            this.Lau.Name = "Lau";
            this.Lau.Size = new System.Drawing.Size(218, 28);
            this.Lau.TabIndex = 61;
            this.Lau.Text = "Este campo es obligatorio.";
            this.Lau.Visible = false;
            // 
            // AD7
            // 
            this.AD7.BackgroundImage = global::Vista.Properties.Resources.Adv;
            this.AD7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AD7.Location = new System.Drawing.Point(320, 259);
            this.AD7.Name = "AD7";
            this.AD7.Size = new System.Drawing.Size(23, 20);
            this.AD7.TabIndex = 60;
            this.AD7.TabStop = false;
            this.AD7.Visible = false;
            this.AD7.Click += new System.EventHandler(this.AD7_Click);
            this.AD7.MouseHover += new System.EventHandler(this.AD7_MouseHover);
            // 
            // AD4
            // 
            this.AD4.BackgroundImage = global::Vista.Properties.Resources.Adv;
            this.AD4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AD4.Location = new System.Drawing.Point(320, 146);
            this.AD4.Name = "AD4";
            this.AD4.Size = new System.Drawing.Size(23, 20);
            this.AD4.TabIndex = 59;
            this.AD4.TabStop = false;
            this.AD4.Visible = false;
            this.AD4.MouseHover += new System.EventHandler(this.AD4_MouseHover);
            // 
            // AD6
            // 
            this.AD6.BackgroundImage = global::Vista.Properties.Resources.Adv;
            this.AD6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AD6.Location = new System.Drawing.Point(320, 218);
            this.AD6.Name = "AD6";
            this.AD6.Size = new System.Drawing.Size(23, 20);
            this.AD6.TabIndex = 58;
            this.AD6.TabStop = false;
            this.AD6.Visible = false;
            this.AD6.Click += new System.EventHandler(this.AD6_Click);
            this.AD6.MouseHover += new System.EventHandler(this.AD6_MouseHover);
            // 
            // AD5
            // 
            this.AD5.BackgroundImage = global::Vista.Properties.Resources.Adv;
            this.AD5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AD5.Location = new System.Drawing.Point(320, 183);
            this.AD5.Name = "AD5";
            this.AD5.Size = new System.Drawing.Size(23, 20);
            this.AD5.TabIndex = 57;
            this.AD5.TabStop = false;
            this.AD5.Visible = false;
            this.AD5.MouseHover += new System.EventHandler(this.AD5_MouseHover);
            // 
            // AD3
            // 
            this.AD3.BackgroundImage = global::Vista.Properties.Resources.Adv;
            this.AD3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AD3.Location = new System.Drawing.Point(320, 111);
            this.AD3.Name = "AD3";
            this.AD3.Size = new System.Drawing.Size(23, 20);
            this.AD3.TabIndex = 55;
            this.AD3.TabStop = false;
            this.AD3.Visible = false;
            this.AD3.MouseHover += new System.EventHandler(this.AD3_MouseHover);
            // 
            // AD1
            // 
            this.AD1.BackgroundImage = global::Vista.Properties.Resources.Adv;
            this.AD1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AD1.Location = new System.Drawing.Point(320, 78);
            this.AD1.Name = "AD1";
            this.AD1.Size = new System.Drawing.Size(23, 20);
            this.AD1.TabIndex = 53;
            this.AD1.TabStop = false;
            this.AD1.Tag = "";
            this.AD1.Visible = false;
            this.AD1.Click += new System.EventHandler(this.AD1_Click);
            this.AD1.MouseHover += new System.EventHandler(this.AD1_MouseHover);
            // 
            // AgreProve
            // 
            this.AgreProve.BackgroundImage = global::Vista.Properties.Resources._;
            this.AgreProve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AgreProve.FlatAppearance.BorderSize = 0;
            this.AgreProve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.AgreProve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.AgreProve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgreProve.Location = new System.Drawing.Point(154, 213);
            this.AgreProve.Name = "AgreProve";
            this.AgreProve.Size = new System.Drawing.Size(31, 28);
            this.AgreProve.TabIndex = 52;
            this.AgreProve.UseVisualStyleBackColor = true;
            this.AgreProve.Click += new System.EventHandler(this.AgreProve_Click);
            // 
            // CajaEm
            // 
            this.CajaEm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CajaEm.FormattingEnabled = true;
            this.CajaEm.Location = new System.Drawing.Point(191, 218);
            this.CajaEm.Name = "CajaEm";
            this.CajaEm.Size = new System.Drawing.Size(128, 21);
            this.CajaEm.TabIndex = 50;
            this.CajaEm.Text = "-Seleccione Empresa-";
            this.CajaEm.SelectedIndexChanged += new System.EventHandler(this.CajaEm_SelectedIndexChanged);
            this.CajaEm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaEm_KeyPress);
            this.CajaEm.TextChanged += new System.EventHandler(this.CajaEm_TextChanged);
            this.CajaEm.Click += new System.EventHandler(this.CajaEm_Click);
            // 
            // CajaDes
            // 
            this.CajaDes.Location = new System.Drawing.Point(133, 259);
            this.CajaDes.MaxLength = 300;
            this.CajaDes.Name = "CajaDes";
            this.CajaDes.Size = new System.Drawing.Size(186, 75);
            this.CajaDes.TabIndex = 28;
            this.CajaDes.Text = "";
            this.CajaDes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaDes_KeyPress);
            this.CajaDes.TextChanged += new System.EventHandler(this.CajaDes_TextChanged);
            // 
            // LaD
            // 
            this.LaD.AutoSize = true;
            this.LaD.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaD.ForeColor = System.Drawing.Color.YellowGreen;
            this.LaD.Location = new System.Drawing.Point(23, 253);
            this.LaD.Name = "LaD";
            this.LaD.Size = new System.Drawing.Size(104, 28);
            this.LaD.TabIndex = 49;
            this.LaD.Text = "Descripción";
            this.LaD.Click += new System.EventHandler(this.label8_Click);
            // 
            // LaE
            // 
            this.LaE.AutoSize = true;
            this.LaE.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaE.ForeColor = System.Drawing.Color.YellowGreen;
            this.LaE.Location = new System.Drawing.Point(23, 212);
            this.LaE.Name = "LaE";
            this.LaE.Size = new System.Drawing.Size(81, 28);
            this.LaE.TabIndex = 47;
            this.LaE.Text = "Empresa";
            // 
            // CajaVpro
            // 
            this.CajaVpro.Location = new System.Drawing.Point(200, 183);
            this.CajaVpro.MaxLength = 10;
            this.CajaVpro.Name = "CajaVpro";
            this.CajaVpro.Size = new System.Drawing.Size(119, 20);
            this.CajaVpro.TabIndex = 26;
            this.CajaVpro.TextChanged += new System.EventHandler(this.CajaVpro_TextChanged);
            this.CajaVpro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaValorP_KeyPress);
            // 
            // LaVPro
            // 
            this.LaVPro.AutoSize = true;
            this.LaVPro.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaVPro.ForeColor = System.Drawing.Color.YellowGreen;
            this.LaVPro.Location = new System.Drawing.Point(23, 177);
            this.LaVPro.Name = "LaVPro";
            this.LaVPro.Size = new System.Drawing.Size(141, 28);
            this.LaVPro.TabIndex = 45;
            this.LaVPro.Text = "Valor Proveedor";
            // 
            // Actualizar
            // 
            this.Actualizar.BackColor = System.Drawing.Color.White;
            this.Actualizar.BackgroundImage = global::Vista.Properties.Resources.Actualizaar;
            this.Actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Actualizar.FlatAppearance.BorderSize = 0;
            this.Actualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Actualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Actualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Actualizar.Location = new System.Drawing.Point(200, 405);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(124, 42);
            this.Actualizar.TabIndex = 29;
            this.Actualizar.UseVisualStyleBackColor = false;
            this.Actualizar.MouseLeave += new System.EventHandler(this.Actualizar_MouseLeave);
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            this.Actualizar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Actualizar_MouseDown);
            // 
            // Registrar
            // 
            this.Registrar.BackgroundImage = global::Vista.Properties.Resources.Registrar;
            this.Registrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Registrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Registrar.FlatAppearance.BorderSize = 0;
            this.Registrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Registrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Registrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registrar.Location = new System.Drawing.Point(28, 405);
            this.Registrar.Name = "Registrar";
            this.Registrar.Size = new System.Drawing.Size(117, 42);
            this.Registrar.TabIndex = 43;
            this.Registrar.UseVisualStyleBackColor = true;
            this.Registrar.MouseLeave += new System.EventHandler(this.Registrar_MouseLeave);
            this.Registrar.Click += new System.EventHandler(this.Registrar_Click);
            this.Registrar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Registrar_MouseDown);
            // 
            // CerrarPanelRInventario
            // 
            this.CerrarPanelRInventario.BackgroundImage = global::Vista.Properties.Resources.Cerrar;
            this.CerrarPanelRInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CerrarPanelRInventario.FlatAppearance.BorderSize = 0;
            this.CerrarPanelRInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CerrarPanelRInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CerrarPanelRInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CerrarPanelRInventario.Location = new System.Drawing.Point(315, 17);
            this.CerrarPanelRInventario.Name = "CerrarPanelRInventario";
            this.CerrarPanelRInventario.Size = new System.Drawing.Size(33, 32);
            this.CerrarPanelRInventario.TabIndex = 30;
            this.CerrarPanelRInventario.UseVisualStyleBackColor = true;
            this.CerrarPanelRInventario.MouseLeave += new System.EventHandler(this.CerrarPanelREmpleados_MouseLeave);
            this.CerrarPanelRInventario.Click += new System.EventHandler(this.CerrarPanelRInventario_Click);
            this.CerrarPanelRInventario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CerrarPanelREmpleados_MouseDown);
            this.CerrarPanelRInventario.MouseHover += new System.EventHandler(this.CerrarPanelRInventario_MouseHover);
            // 
            // CajaTam
            // 
            this.CajaTam.Location = new System.Drawing.Point(200, 146);
            this.CajaTam.MaxLength = 15;
            this.CajaTam.Name = "CajaTam";
            this.CajaTam.Size = new System.Drawing.Size(119, 20);
            this.CajaTam.TabIndex = 25;
            this.CajaTam.TextChanged += new System.EventHandler(this.CajaTam_TextChanged);
            this.CajaTam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaTam_KeyPress);
            // 
            // LaT
            // 
            this.LaT.AutoSize = true;
            this.LaT.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaT.ForeColor = System.Drawing.Color.YellowGreen;
            this.LaT.Location = new System.Drawing.Point(23, 140);
            this.LaT.Name = "LaT";
            this.LaT.Size = new System.Drawing.Size(77, 28);
            this.LaT.TabIndex = 28;
            this.LaT.Text = "Tamaño";
            // 
            // LaCaE
            // 
            this.LaCaE.AutoSize = true;
            this.LaCaE.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaCaE.ForeColor = System.Drawing.Color.YellowGreen;
            this.LaCaE.Location = new System.Drawing.Point(23, 105);
            this.LaCaE.Name = "LaCaE";
            this.LaCaE.Size = new System.Drawing.Size(162, 28);
            this.LaCaE.TabIndex = 27;
            this.LaCaE.Text = "Cantidad existente";
            // 
            // LaTp
            // 
            this.LaTp.AutoSize = true;
            this.LaTp.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaTp.ForeColor = System.Drawing.Color.YellowGreen;
            this.LaTp.Location = new System.Drawing.Point(23, 72);
            this.LaTp.Name = "LaTp";
            this.LaTp.Size = new System.Drawing.Size(118, 28);
            this.LaTp.TabIndex = 25;
            this.LaTp.Text = "Tipo de pieza";
            // 
            // CajaCE
            // 
            this.CajaCE.Location = new System.Drawing.Point(200, 111);
            this.CajaCE.MaxLength = 5;
            this.CajaCE.Name = "CajaCE";
            this.CajaCE.Size = new System.Drawing.Size(119, 20);
            this.CajaCE.TabIndex = 24;
            this.CajaCE.TextChanged += new System.EventHandler(this.CajaCE_TextChanged);
            this.CajaCE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaCE_KeyPress);
            // 
            // CajaTp
            // 
            this.CajaTp.Location = new System.Drawing.Point(200, 78);
            this.CajaTp.MaxLength = 30;
            this.CajaTp.Name = "CajaTp";
            this.CajaTp.Size = new System.Drawing.Size(119, 20);
            this.CajaTp.TabIndex = 22;
            this.CajaTp.TextChanged += new System.EventHandler(this.CajaTp_TextChanged);
            this.CajaTp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaTp_KeyPress);
            // 
            // TareaXlabel
            // 
            this.TareaXlabel.AutoSize = true;
            this.TareaXlabel.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TareaXlabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.TareaXlabel.Location = new System.Drawing.Point(30, 20);
            this.TareaXlabel.Name = "TareaXlabel";
            this.TareaXlabel.Size = new System.Drawing.Size(92, 37);
            this.TareaXlabel.TabIndex = 21;
            this.TareaXlabel.Text = "TareaX";
            this.TareaXlabel.Click += new System.EventHandler(this.TareaXlabel_Click);
            // 
            // GenerarReporte
            // 
            this.GenerarReporte.BackgroundImage = global::Vista.Properties.Resources.GenerarReporte;
            this.GenerarReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GenerarReporte.FlatAppearance.BorderSize = 0;
            this.GenerarReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GenerarReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerarReporte.Location = new System.Drawing.Point(419, 619);
            this.GenerarReporte.Name = "GenerarReporte";
            this.GenerarReporte.Size = new System.Drawing.Size(233, 52);
            this.GenerarReporte.TabIndex = 23;
            this.GenerarReporte.TabStop = false;
            this.GenerarReporte.UseVisualStyleBackColor = true;
            this.GenerarReporte.MouseLeave += new System.EventHandler(this.GenerarReporte_MouseLeave);
            this.GenerarReporte.Click += new System.EventHandler(this.GenerarReporte_Click);
            this.GenerarReporte.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GenerarReporte_MouseDown);
            this.GenerarReporte.MouseHover += new System.EventHandler(this.GenerarReporte_MouseHover);
            // 
            // ConsultarInventario
            // 
            this.ConsultarInventario.BackgroundImage = global::Vista.Properties.Resources.BuscarMateriaPrima;
            this.ConsultarInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultarInventario.FlatAppearance.BorderSize = 0;
            this.ConsultarInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConsultarInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConsultarInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultarInventario.Location = new System.Drawing.Point(603, 81);
            this.ConsultarInventario.Name = "ConsultarInventario";
            this.ConsultarInventario.Size = new System.Drawing.Size(82, 73);
            this.ConsultarInventario.TabIndex = 11;
            this.ConsultarInventario.TabStop = false;
            this.ConsultarInventario.UseVisualStyleBackColor = true;
            this.ConsultarInventario.MouseLeave += new System.EventHandler(this.ConsultarInventario_MouseLeave);
            this.ConsultarInventario.Click += new System.EventHandler(this.ConsultarInventario_Click);
            this.ConsultarInventario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConsultarInventario_MouseDown);
            this.ConsultarInventario.MouseHover += new System.EventHandler(this.ConsultarInventario_MouseHover);
            // 
            // ActualizarInventario
            // 
            this.ActualizarInventario.BackgroundImage = global::Vista.Properties.Resources.Actualizar_inventario;
            this.ActualizarInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ActualizarInventario.FlatAppearance.BorderSize = 0;
            this.ActualizarInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ActualizarInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ActualizarInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActualizarInventario.Location = new System.Drawing.Point(156, 619);
            this.ActualizarInventario.Name = "ActualizarInventario";
            this.ActualizarInventario.Size = new System.Drawing.Size(233, 52);
            this.ActualizarInventario.TabIndex = 10;
            this.ActualizarInventario.TabStop = false;
            this.ActualizarInventario.UseVisualStyleBackColor = true;
            this.ActualizarInventario.Click += new System.EventHandler(this.ActualizarInventario_Click);
            this.ActualizarInventario.MouseHover += new System.EventHandler(this.ActualizarInventario_MouseHover);
            // 
            // RegistrarInventario
            // 
            this.RegistrarInventario.BackgroundImage = global::Vista.Properties.Resources.Registrar_inventario;
            this.RegistrarInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RegistrarInventario.FlatAppearance.BorderSize = 0;
            this.RegistrarInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RegistrarInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RegistrarInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegistrarInventario.Location = new System.Drawing.Point(683, 619);
            this.RegistrarInventario.Name = "RegistrarInventario";
            this.RegistrarInventario.Size = new System.Drawing.Size(233, 52);
            this.RegistrarInventario.TabIndex = 998;
            this.RegistrarInventario.TabStop = false;
            this.RegistrarInventario.UseVisualStyleBackColor = true;
            this.RegistrarInventario.Click += new System.EventHandler(this.RegistrarInventario_Click_1);
            this.RegistrarInventario.MouseHover += new System.EventHandler(this.RegistrarInventario_MouseHover);
            // 
            // Atras
            // 
            this.Atras.BackColor = System.Drawing.Color.Transparent;
            this.Atras.BackgroundImage = global::Vista.Properties.Resources.Atras;
            this.Atras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Atras.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Atras.FlatAppearance.BorderSize = 0;
            this.Atras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Atras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Atras.Location = new System.Drawing.Point(12, 12);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(54, 41);
            this.Atras.TabIndex = 999;
            this.Atras.TabStop = false;
            this.Atras.UseVisualStyleBackColor = false;
            this.Atras.MouseLeave += new System.EventHandler(this.Atras_MouseLeave);
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            this.Atras.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Atras_MouseDown);
            this.Atras.MouseHover += new System.EventHandler(this.Atras_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkOrange;
            this.label11.Location = new System.Drawing.Point(918, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 28);
            this.label11.TabIndex = 1009;
            this.label11.Text = "Ayuda:";
            this.label11.Visible = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Vista.Properties.Resources.Ayuda;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(992, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 38);
            this.button1.TabIndex = 1008;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Min
            // 
            this.Min.BackgroundImage = global::Vista.Properties.Resources.Min;
            this.Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Min.FlatAppearance.BorderSize = 0;
            this.Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Min.Location = new System.Drawing.Point(1313, 4);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(45, 43);
            this.Min.TabIndex = 1016;
            this.Min.UseVisualStyleBackColor = true;
            this.Min.Click += new System.EventHandler(this.Min_Click);
            // 
            // GestionarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1360, 768);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LCE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LV1);
            this.Controls.Add(this.LF1);
            this.Controls.Add(this.LCO2);
            this.Controls.Add(this.LCO1);
            this.Controls.Add(this.LR1);
            this.Controls.Add(this.LA2);
            this.Controls.Add(this.LA1);
            this.Controls.Add(this.LG2);
            this.Controls.Add(this.LG1);
            this.Controls.Add(this.Consultar);
            this.Controls.Add(this.DatagriedInv);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PanelRegistroMateriaprima);
            this.Controls.Add(this.GenerarReporte);
            this.Controls.Add(this.ConsultarInventario);
            this.Controls.Add(this.ActualizarInventario);
            this.Controls.Add(this.RegistrarInventario);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionarInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionarInventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GestionarInventario_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GestionarInventario_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.DatagriedInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelRegistroMateriaprima.ResumeLayout(false);
            this.PanelRegistroMateriaprima.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AD1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Atras;
        private System.Windows.Forms.Button RegistrarInventario;
        private System.Windows.Forms.Button ActualizarInventario;
        private System.Windows.Forms.Button ConsultarInventario;
        private System.Windows.Forms.Button GenerarReporte;
        private System.Windows.Forms.Panel PanelRegistroMateriaprima;
        private System.Windows.Forms.Button CerrarPanelRInventario;
        private System.Windows.Forms.TextBox CajaTam;
        private System.Windows.Forms.Label LaT;
        private System.Windows.Forms.Label LaCaE;
        private System.Windows.Forms.Label LaTp;
        private System.Windows.Forms.TextBox CajaCE;
        private System.Windows.Forms.TextBox CajaTp;
        private System.Windows.Forms.Label TareaXlabel;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.Button Registrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Consultar;
        private System.Windows.Forms.DataGridView DatagriedInv;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LaD;
        private System.Windows.Forms.Label LaE;
        private System.Windows.Forms.TextBox CajaVpro;
        private System.Windows.Forms.Label LaVPro;
        private System.Windows.Forms.RichTextBox CajaDes;
        private System.Windows.Forms.ComboBox CajaEm;
        private System.Windows.Forms.Button AgreProve;
        private System.Windows.Forms.Label LG2;
        private System.Windows.Forms.Label LG1;
        private System.Windows.Forms.Label LA2;
        private System.Windows.Forms.Label LA1;
        private System.Windows.Forms.Label LR1;
        private System.Windows.Forms.PictureBox AD3;
        private System.Windows.Forms.PictureBox AD1;
        private System.Windows.Forms.PictureBox AD5;
        private System.Windows.Forms.PictureBox AD6;
        private System.Windows.Forms.PictureBox AD4;
        private System.Windows.Forms.PictureBox AD7;
        private System.Windows.Forms.Label LInfo;
        private System.Windows.Forms.PictureBox ADG;
        private System.Windows.Forms.Label Lau;
        private System.Windows.Forms.Label LCO2;
        private System.Windows.Forms.Label LCO1;
        private System.Windows.Forms.Label LV1;
        private System.Windows.Forms.Label LF1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LCE;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Min;
    }
}