namespace Vista
{
    partial class MenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.label1 = new System.Windows.Forms.Label();
            this.AvisoLabel = new System.Windows.Forms.Label();
            this.Nombrelabel = new System.Windows.Forms.Label();
            this.Apellidolabel = new System.Windows.Forms.Label();
            this.Gcompraslabel = new System.Windows.Forms.Label();
            this.Gempleadoslabel = new System.Windows.Forms.Label();
            this.Gmaterialabel = new System.Windows.Forms.Label();
            this.Gproveedoreslabel = new System.Windows.Forms.Label();
            this.Gmaquinarialabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Min = new System.Windows.Forms.Button();
            this.ApeEmLabel = new System.Windows.Forms.Label();
            this.CargoLabel = new System.Windows.Forms.Label();
            this.NomApLabel = new System.Windows.Forms.Label();
            this.GVentasLabel = new System.Windows.Forms.Label();
            this.CempleadoLabel = new System.Windows.Forms.Label();
            this.CmateriaLabel = new System.Windows.Forms.Label();
            this.CMaquinariaLabel = new System.Windows.Forms.Label();
            this.CventasLabel = new System.Windows.Forms.Label();
            this.CcomprasLabel = new System.Windows.Forms.Label();
            this.CProveedorLabel = new System.Windows.Forms.Label();
            this.ConsultaProveedor = new System.Windows.Forms.Button();
            this.ConsultarCompra = new System.Windows.Forms.Button();
            this.ConsultarVenta = new System.Windows.Forms.Button();
            this.ConsultarMaquina = new System.Windows.Forms.Button();
            this.ConsultarMateriaPrima = new System.Windows.Forms.Button();
            this.ConsultarEmpleados = new System.Windows.Forms.Button();
            this.GestionarVentas = new System.Windows.Forms.Button();
            this.Gestion_Inventario = new System.Windows.Forms.Button();
            this.GestionEmpleados = new System.Windows.Forms.Button();
            this.GestionMaquinaria = new System.Windows.Forms.Button();
            this.GestionProveedores = new System.Windows.Forms.Button();
            this.GestionCompras = new System.Windows.Forms.Button();
            this.CerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(558, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "MENÚ PRINCIPAL";
            // 
            // AvisoLabel
            // 
            this.AvisoLabel.AutoSize = true;
            this.AvisoLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvisoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AvisoLabel.Location = new System.Drawing.Point(236, 89);
            this.AvisoLabel.Name = "AvisoLabel";
            this.AvisoLabel.Size = new System.Drawing.Size(220, 33);
            this.AvisoLabel.TabIndex = 12;
            this.AvisoLabel.Text = "Sesion iniciada como:";
            this.AvisoLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // Nombrelabel
            // 
            this.Nombrelabel.AutoSize = true;
            this.Nombrelabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombrelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Nombrelabel.Location = new System.Drawing.Point(667, 89);
            this.Nombrelabel.Name = "Nombrelabel";
            this.Nombrelabel.Size = new System.Drawing.Size(97, 33);
            this.Nombrelabel.TabIndex = 14;
            this.Nombrelabel.Text = "Nombre:";
            // 
            // Apellidolabel
            // 
            this.Apellidolabel.AutoSize = true;
            this.Apellidolabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Apellidolabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Apellidolabel.Location = new System.Drawing.Point(908, 89);
            this.Apellidolabel.Name = "Apellidolabel";
            this.Apellidolabel.Size = new System.Drawing.Size(97, 33);
            this.Apellidolabel.TabIndex = 15;
            this.Apellidolabel.Text = "Apellido:";
            // 
            // Gcompraslabel
            // 
            this.Gcompraslabel.AutoSize = true;
            this.Gcompraslabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gcompraslabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.Gcompraslabel.Location = new System.Drawing.Point(274, 187);
            this.Gcompraslabel.Name = "Gcompraslabel";
            this.Gcompraslabel.Size = new System.Drawing.Size(161, 28);
            this.Gcompraslabel.TabIndex = 19;
            this.Gcompraslabel.Text = "Gestionar compras";
            // 
            // Gempleadoslabel
            // 
            this.Gempleadoslabel.AutoSize = true;
            this.Gempleadoslabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gempleadoslabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Gempleadoslabel.Location = new System.Drawing.Point(274, 410);
            this.Gempleadoslabel.Name = "Gempleadoslabel";
            this.Gempleadoslabel.Size = new System.Drawing.Size(177, 28);
            this.Gempleadoslabel.TabIndex = 20;
            this.Gempleadoslabel.Text = "Gestionar empleados";
            // 
            // Gmaterialabel
            // 
            this.Gmaterialabel.AutoSize = true;
            this.Gmaterialabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gmaterialabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.Gmaterialabel.Location = new System.Drawing.Point(592, 410);
            this.Gmaterialabel.Name = "Gmaterialabel";
            this.Gmaterialabel.Size = new System.Drawing.Size(210, 28);
            this.Gmaterialabel.TabIndex = 21;
            this.Gmaterialabel.Text = "Gestionar materia prima";
            this.Gmaterialabel.Click += new System.EventHandler(this.Gmaterialabel_Click);
            // 
            // Gproveedoreslabel
            // 
            this.Gproveedoreslabel.AutoSize = true;
            this.Gproveedoreslabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gproveedoreslabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Gproveedoreslabel.Location = new System.Drawing.Point(592, 187);
            this.Gproveedoreslabel.Name = "Gproveedoreslabel";
            this.Gproveedoreslabel.Size = new System.Drawing.Size(189, 28);
            this.Gproveedoreslabel.TabIndex = 21;
            this.Gproveedoreslabel.Text = "Gestionar proveedores";
            // 
            // Gmaquinarialabel
            // 
            this.Gmaquinarialabel.AutoSize = true;
            this.Gmaquinarialabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gmaquinarialabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.Gmaquinarialabel.Location = new System.Drawing.Point(938, 187);
            this.Gmaquinarialabel.Name = "Gmaquinarialabel";
            this.Gmaquinarialabel.Size = new System.Drawing.Size(185, 28);
            this.Gmaquinarialabel.TabIndex = 22;
            this.Gmaquinarialabel.Text = "Gestionar maquinaria";
            // 
            // Min
            // 
            this.Min.BackgroundImage = global::Vista.Properties.Resources.Min;
            this.Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Min.FlatAppearance.BorderSize = 0;
            this.Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Min.Location = new System.Drawing.Point(1303, 5);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(50, 46);
            this.Min.TabIndex = 998;
            this.Min.TabStop = false;
            this.toolTip1.SetToolTip(this.Min, "Minimizar");
            this.Min.UseVisualStyleBackColor = true;
            this.Min.MouseLeave += new System.EventHandler(this.Min_MouseLeave);
            this.Min.Click += new System.EventHandler(this.Min_Click);
            this.Min.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Min_MouseDown);
            // 
            // ApeEmLabel
            // 
            this.ApeEmLabel.AutoSize = true;
            this.ApeEmLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApeEmLabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.ApeEmLabel.Location = new System.Drawing.Point(1012, 89);
            this.ApeEmLabel.Name = "ApeEmLabel";
            this.ApeEmLabel.Size = new System.Drawing.Size(91, 33);
            this.ApeEmLabel.TabIndex = 28;
            this.ApeEmLabel.Text = "Apellido";
            // 
            // CargoLabel
            // 
            this.CargoLabel.AutoSize = true;
            this.CargoLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargoLabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.CargoLabel.Location = new System.Drawing.Point(467, 89);
            this.CargoLabel.Name = "CargoLabel";
            this.CargoLabel.Size = new System.Drawing.Size(71, 33);
            this.CargoLabel.TabIndex = 29;
            this.CargoLabel.Text = "Cargo";
            this.CargoLabel.Click += new System.EventHandler(this.CargoLabel_Click_1);
            // 
            // NomApLabel
            // 
            this.NomApLabel.AutoSize = true;
            this.NomApLabel.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomApLabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.NomApLabel.Location = new System.Drawing.Point(771, 88);
            this.NomApLabel.Name = "NomApLabel";
            this.NomApLabel.Size = new System.Drawing.Size(91, 33);
            this.NomApLabel.TabIndex = 30;
            this.NomApLabel.Text = "Nombre";
            // 
            // GVentasLabel
            // 
            this.GVentasLabel.AutoSize = true;
            this.GVentasLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVentasLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.GVentasLabel.Location = new System.Drawing.Point(791, 410);
            this.GVentasLabel.Name = "GVentasLabel";
            this.GVentasLabel.Size = new System.Drawing.Size(145, 28);
            this.GVentasLabel.TabIndex = 32;
            this.GVentasLabel.Text = "Gestionar ventas";
            // 
            // CempleadoLabel
            // 
            this.CempleadoLabel.AutoSize = true;
            this.CempleadoLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CempleadoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CempleadoLabel.Location = new System.Drawing.Point(776, 187);
            this.CempleadoLabel.Name = "CempleadoLabel";
            this.CempleadoLabel.Size = new System.Drawing.Size(178, 28);
            this.CempleadoLabel.TabIndex = 34;
            this.CempleadoLabel.Text = "Consultar empleados";
            // 
            // CmateriaLabel
            // 
            this.CmateriaLabel.AutoSize = true;
            this.CmateriaLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmateriaLabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.CmateriaLabel.Location = new System.Drawing.Point(432, 187);
            this.CmateriaLabel.Name = "CmateriaLabel";
            this.CmateriaLabel.Size = new System.Drawing.Size(211, 28);
            this.CmateriaLabel.TabIndex = 35;
            this.CmateriaLabel.Text = "Consultar materia prima";
            // 
            // CMaquinariaLabel
            // 
            this.CMaquinariaLabel.AutoSize = true;
            this.CMaquinariaLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMaquinariaLabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.CMaquinariaLabel.Location = new System.Drawing.Point(427, 410);
            this.CMaquinariaLabel.Name = "CMaquinariaLabel";
            this.CMaquinariaLabel.Size = new System.Drawing.Size(186, 28);
            this.CMaquinariaLabel.TabIndex = 37;
            this.CMaquinariaLabel.Text = "Consultar maquinaria";
            // 
            // CventasLabel
            // 
            this.CventasLabel.AutoSize = true;
            this.CventasLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CventasLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.CventasLabel.Location = new System.Drawing.Point(974, 410);
            this.CventasLabel.Name = "CventasLabel";
            this.CventasLabel.Size = new System.Drawing.Size(146, 28);
            this.CventasLabel.TabIndex = 40;
            this.CventasLabel.Text = "Consultar ventas";
            // 
            // CcomprasLabel
            // 
            this.CcomprasLabel.AutoSize = true;
            this.CcomprasLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CcomprasLabel.ForeColor = System.Drawing.Color.YellowGreen;
            this.CcomprasLabel.Location = new System.Drawing.Point(440, 581);
            this.CcomprasLabel.Name = "CcomprasLabel";
            this.CcomprasLabel.Size = new System.Drawing.Size(162, 28);
            this.CcomprasLabel.TabIndex = 41;
            this.CcomprasLabel.Text = "Consultar compras";
            // 
            // CProveedorLabel
            // 
            this.CProveedorLabel.AutoSize = true;
            this.CProveedorLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CProveedorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CProveedorLabel.Location = new System.Drawing.Point(267, 581);
            this.CProveedorLabel.Name = "CProveedorLabel";
            this.CProveedorLabel.Size = new System.Drawing.Size(190, 28);
            this.CProveedorLabel.TabIndex = 43;
            this.CProveedorLabel.Text = "Consultar proveedores";
            // 
            // ConsultaProveedor
            // 
            this.ConsultaProveedor.BackgroundImage = global::Vista.Properties.Resources.ConsultarProveedor;
            this.ConsultaProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultaProveedor.FlatAppearance.BorderSize = 0;
            this.ConsultaProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConsultaProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConsultaProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultaProveedor.Location = new System.Drawing.Point(268, 615);
            this.ConsultaProveedor.Name = "ConsultaProveedor";
            this.ConsultaProveedor.Size = new System.Drawing.Size(136, 119);
            this.ConsultaProveedor.TabIndex = 44;
            this.ConsultaProveedor.TabStop = false;
            this.ConsultaProveedor.UseVisualStyleBackColor = true;
            this.ConsultaProveedor.Click += new System.EventHandler(this.ConsultaProveedor_Click);
            // 
            // ConsultarCompra
            // 
            this.ConsultarCompra.BackgroundImage = global::Vista.Properties.Resources.ConsultarCompra;
            this.ConsultarCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultarCompra.FlatAppearance.BorderSize = 0;
            this.ConsultarCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConsultarCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConsultarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultarCompra.Location = new System.Drawing.Point(431, 615);
            this.ConsultarCompra.Name = "ConsultarCompra";
            this.ConsultarCompra.Size = new System.Drawing.Size(136, 119);
            this.ConsultarCompra.TabIndex = 42;
            this.ConsultarCompra.TabStop = false;
            this.ConsultarCompra.UseVisualStyleBackColor = true;
            this.ConsultarCompra.Click += new System.EventHandler(this.ConsultarCompra_Click);
            // 
            // ConsultarVenta
            // 
            this.ConsultarVenta.BackgroundImage = global::Vista.Properties.Resources.ConsultarVentas;
            this.ConsultarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultarVenta.FlatAppearance.BorderSize = 0;
            this.ConsultarVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConsultarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConsultarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultarVenta.Location = new System.Drawing.Point(942, 444);
            this.ConsultarVenta.Name = "ConsultarVenta";
            this.ConsultarVenta.Size = new System.Drawing.Size(136, 119);
            this.ConsultarVenta.TabIndex = 39;
            this.ConsultarVenta.TabStop = false;
            this.ConsultarVenta.UseVisualStyleBackColor = true;
            this.ConsultarVenta.Click += new System.EventHandler(this.ConsultarVenta_Click);
            // 
            // ConsultarMaquina
            // 
            this.ConsultarMaquina.BackgroundImage = global::Vista.Properties.Resources.ConsultarMaquinaria;
            this.ConsultarMaquina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultarMaquina.FlatAppearance.BorderSize = 0;
            this.ConsultarMaquina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConsultarMaquina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConsultarMaquina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultarMaquina.Location = new System.Drawing.Point(431, 444);
            this.ConsultarMaquina.Name = "ConsultarMaquina";
            this.ConsultarMaquina.Size = new System.Drawing.Size(136, 119);
            this.ConsultarMaquina.TabIndex = 38;
            this.ConsultarMaquina.TabStop = false;
            this.ConsultarMaquina.UseVisualStyleBackColor = true;
            this.ConsultarMaquina.Click += new System.EventHandler(this.ConsultarMaquina_Click);
            // 
            // ConsultarMateriaPrima
            // 
            this.ConsultarMateriaPrima.BackgroundImage = global::Vista.Properties.Resources.ConsultarMateriaPrima;
            this.ConsultarMateriaPrima.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultarMateriaPrima.FlatAppearance.BorderSize = 0;
            this.ConsultarMateriaPrima.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConsultarMateriaPrima.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConsultarMateriaPrima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultarMateriaPrima.Location = new System.Drawing.Point(436, 226);
            this.ConsultarMateriaPrima.Name = "ConsultarMateriaPrima";
            this.ConsultarMateriaPrima.Size = new System.Drawing.Size(136, 119);
            this.ConsultarMateriaPrima.TabIndex = 36;
            this.ConsultarMateriaPrima.TabStop = false;
            this.ConsultarMateriaPrima.UseVisualStyleBackColor = true;
            this.ConsultarMateriaPrima.Click += new System.EventHandler(this.ConsultarMateriaPrima_Click);
            // 
            // ConsultarEmpleados
            // 
            this.ConsultarEmpleados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ConsultarEmpleados.BackgroundImage")));
            this.ConsultarEmpleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConsultarEmpleados.FlatAppearance.BorderSize = 0;
            this.ConsultarEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ConsultarEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ConsultarEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultarEmpleados.Location = new System.Drawing.Point(780, 226);
            this.ConsultarEmpleados.Name = "ConsultarEmpleados";
            this.ConsultarEmpleados.Size = new System.Drawing.Size(136, 119);
            this.ConsultarEmpleados.TabIndex = 33;
            this.ConsultarEmpleados.TabStop = false;
            this.ConsultarEmpleados.UseVisualStyleBackColor = true;
            this.ConsultarEmpleados.Click += new System.EventHandler(this.ConsultarEmpleados_Click);
            // 
            // GestionarVentas
            // 
            this.GestionarVentas.BackgroundImage = global::Vista.Properties.Resources.GestionarVentas;
            this.GestionarVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GestionarVentas.FlatAppearance.BorderSize = 0;
            this.GestionarVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GestionarVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GestionarVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GestionarVentas.Location = new System.Drawing.Point(795, 450);
            this.GestionarVentas.Name = "GestionarVentas";
            this.GestionarVentas.Size = new System.Drawing.Size(119, 106);
            this.GestionarVentas.TabIndex = 31;
            this.GestionarVentas.TabStop = false;
            this.GestionarVentas.UseVisualStyleBackColor = true;
            this.GestionarVentas.Click += new System.EventHandler(this.GestionVentas_Click);
            // 
            // Gestion_Inventario
            // 
            this.Gestion_Inventario.BackgroundImage = global::Vista.Properties.Resources.Inventario;
            this.Gestion_Inventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Gestion_Inventario.FlatAppearance.BorderSize = 0;
            this.Gestion_Inventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Gestion_Inventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Gestion_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gestion_Inventario.Location = new System.Drawing.Point(622, 450);
            this.Gestion_Inventario.Name = "Gestion_Inventario";
            this.Gestion_Inventario.Size = new System.Drawing.Size(119, 106);
            this.Gestion_Inventario.TabIndex = 27;
            this.Gestion_Inventario.TabStop = false;
            this.Gestion_Inventario.UseVisualStyleBackColor = true;
            this.Gestion_Inventario.Click += new System.EventHandler(this.Gestion_Inventario_Click);
            // 
            // GestionEmpleados
            // 
            this.GestionEmpleados.BackgroundImage = global::Vista.Properties.Resources.Empleados;
            this.GestionEmpleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GestionEmpleados.FlatAppearance.BorderSize = 0;
            this.GestionEmpleados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GestionEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GestionEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GestionEmpleados.Location = new System.Drawing.Point(278, 450);
            this.GestionEmpleados.Name = "GestionEmpleados";
            this.GestionEmpleados.Size = new System.Drawing.Size(119, 106);
            this.GestionEmpleados.TabIndex = 26;
            this.GestionEmpleados.TabStop = false;
            this.GestionEmpleados.UseVisualStyleBackColor = true;
            this.GestionEmpleados.Click += new System.EventHandler(this.GestionEmpleados_Click);
            // 
            // GestionMaquinaria
            // 
            this.GestionMaquinaria.BackgroundImage = global::Vista.Properties.Resources.Maquinaria;
            this.GestionMaquinaria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GestionMaquinaria.FlatAppearance.BorderSize = 0;
            this.GestionMaquinaria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GestionMaquinaria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GestionMaquinaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GestionMaquinaria.Location = new System.Drawing.Point(953, 232);
            this.GestionMaquinaria.Name = "GestionMaquinaria";
            this.GestionMaquinaria.Size = new System.Drawing.Size(119, 106);
            this.GestionMaquinaria.TabIndex = 25;
            this.GestionMaquinaria.TabStop = false;
            this.GestionMaquinaria.UseVisualStyleBackColor = true;
            this.GestionMaquinaria.Click += new System.EventHandler(this.GestionMaquinaria_Click);
            // 
            // GestionProveedores
            // 
            this.GestionProveedores.BackgroundImage = global::Vista.Properties.Resources.Proveedores;
            this.GestionProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GestionProveedores.FlatAppearance.BorderSize = 0;
            this.GestionProveedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GestionProveedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GestionProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GestionProveedores.Location = new System.Drawing.Point(596, 226);
            this.GestionProveedores.Name = "GestionProveedores";
            this.GestionProveedores.Size = new System.Drawing.Size(136, 119);
            this.GestionProveedores.TabIndex = 25;
            this.GestionProveedores.TabStop = false;
            this.GestionProveedores.UseVisualStyleBackColor = true;
            this.GestionProveedores.Click += new System.EventHandler(this.GestionProveedores_Click);
            // 
            // GestionCompras
            // 
            this.GestionCompras.BackgroundImage = global::Vista.Properties.Resources.Compras;
            this.GestionCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GestionCompras.FlatAppearance.BorderSize = 0;
            this.GestionCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GestionCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GestionCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GestionCompras.Location = new System.Drawing.Point(280, 232);
            this.GestionCompras.Name = "GestionCompras";
            this.GestionCompras.Size = new System.Drawing.Size(119, 106);
            this.GestionCompras.TabIndex = 23;
            this.GestionCompras.TabStop = false;
            this.GestionCompras.UseVisualStyleBackColor = true;
            this.GestionCompras.Click += new System.EventHandler(this.GestionCompras_Click);
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.BackColor = System.Drawing.Color.White;
            this.CerrarSesion.BackgroundImage = global::Vista.Properties.Resources.Cerrar_sesión;
            this.CerrarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CerrarSesion.FlatAppearance.BorderSize = 0;
            this.CerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CerrarSesion.Location = new System.Drawing.Point(10, 9);
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Size = new System.Drawing.Size(213, 46);
            this.CerrarSesion.TabIndex = 999;
            this.CerrarSesion.TabStop = false;
            this.CerrarSesion.UseVisualStyleBackColor = false;
            this.CerrarSesion.MouseLeave += new System.EventHandler(this.CerrarSesion_MouseLeave);
            this.CerrarSesion.Click += new System.EventHandler(this.CerrarSesion_Click);
            this.CerrarSesion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CerrarSesion_MouseDown);
            this.CerrarSesion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CerrarSesion_KeyPress);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1355, 746);
            this.Controls.Add(this.ConsultaProveedor);
            this.Controls.Add(this.CProveedorLabel);
            this.Controls.Add(this.ConsultarCompra);
            this.Controls.Add(this.CcomprasLabel);
            this.Controls.Add(this.CventasLabel);
            this.Controls.Add(this.ConsultarVenta);
            this.Controls.Add(this.ConsultarMaquina);
            this.Controls.Add(this.CMaquinariaLabel);
            this.Controls.Add(this.ConsultarMateriaPrima);
            this.Controls.Add(this.CmateriaLabel);
            this.Controls.Add(this.CempleadoLabel);
            this.Controls.Add(this.ConsultarEmpleados);
            this.Controls.Add(this.GVentasLabel);
            this.Controls.Add(this.GestionarVentas);
            this.Controls.Add(this.NomApLabel);
            this.Controls.Add(this.CargoLabel);
            this.Controls.Add(this.ApeEmLabel);
            this.Controls.Add(this.Gestion_Inventario);
            this.Controls.Add(this.GestionEmpleados);
            this.Controls.Add(this.GestionMaquinaria);
            this.Controls.Add(this.GestionProveedores);
            this.Controls.Add(this.GestionCompras);
            this.Controls.Add(this.Gmaquinarialabel);
            this.Controls.Add(this.Gproveedoreslabel);
            this.Controls.Add(this.Gmaterialabel);
            this.Controls.Add(this.Gempleadoslabel);
            this.Controls.Add(this.Gcompraslabel);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Apellidolabel);
            this.Controls.Add(this.Nombrelabel);
            this.Controls.Add(this.AvisoLabel);
            this.Controls.Add(this.CerrarSesion);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuPrincipal";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MenuPrincipal_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CerrarSesion;
        private System.Windows.Forms.Label AvisoLabel;
        private System.Windows.Forms.Label Nombrelabel;
        private System.Windows.Forms.Label Apellidolabel;
        private System.Windows.Forms.Button Min;
        private System.Windows.Forms.Label Gcompraslabel;
        private System.Windows.Forms.Label Gempleadoslabel;
        private System.Windows.Forms.Label Gmaterialabel;
        private System.Windows.Forms.Label Gproveedoreslabel;
        private System.Windows.Forms.Label Gmaquinarialabel;
        private System.Windows.Forms.Button GestionCompras;
        private System.Windows.Forms.Button GestionProveedores;
        private System.Windows.Forms.Button GestionMaquinaria;
        private System.Windows.Forms.Button GestionEmpleados;
        private System.Windows.Forms.Button Gestion_Inventario;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label ApeEmLabel;
        private System.Windows.Forms.Label CargoLabel;
        private System.Windows.Forms.Label NomApLabel;
        private System.Windows.Forms.Button GestionarVentas;
        private System.Windows.Forms.Label GVentasLabel;
        private System.Windows.Forms.Button ConsultarEmpleados;
        private System.Windows.Forms.Label CempleadoLabel;
        private System.Windows.Forms.Label CmateriaLabel;
        private System.Windows.Forms.Button ConsultarMateriaPrima;
        private System.Windows.Forms.Button ConsultarMaquina;
        private System.Windows.Forms.Label CMaquinariaLabel;
        private System.Windows.Forms.Button ConsultarVenta;
        private System.Windows.Forms.Label CventasLabel;
        private System.Windows.Forms.Button ConsultarCompra;
        private System.Windows.Forms.Label CcomprasLabel;
        private System.Windows.Forms.Button ConsultaProveedor;
        private System.Windows.Forms.Label CProveedorLabel;
    }
}