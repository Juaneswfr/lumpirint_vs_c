namespace Vista
{
    partial class Iniciodesesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Iniciodesesion));
            this.Documentotxt = new System.Windows.Forms.Label();
            this.Contraseñatxt = new System.Windows.Forms.Label();
            this.CajaNombre = new System.Windows.Forms.TextBox();
            this.MostrarContraseña = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Minimizar = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.CajaDocumento = new System.Windows.Forms.TextBox();
            this.Propiedades = new System.Windows.Forms.PictureBox();
            this.IniciarSesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Propiedades)).BeginInit();
            this.SuspendLayout();
            // 
            // Documentotxt
            // 
            this.Documentotxt.AutoSize = true;
            this.Documentotxt.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Documentotxt.ForeColor = System.Drawing.Color.YellowGreen;
            this.Documentotxt.Location = new System.Drawing.Point(148, 112);
            this.Documentotxt.Name = "Documentotxt";
            this.Documentotxt.Size = new System.Drawing.Size(72, 26);
            this.Documentotxt.TabIndex = 0;
            this.Documentotxt.Text = "Nombre";
            // 
            // Contraseñatxt
            // 
            this.Contraseñatxt.AutoSize = true;
            this.Contraseñatxt.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold);
            this.Contraseñatxt.ForeColor = System.Drawing.Color.DarkOrange;
            this.Contraseñatxt.Location = new System.Drawing.Point(138, 177);
            this.Contraseñatxt.Name = "Contraseñatxt";
            this.Contraseñatxt.Size = new System.Drawing.Size(97, 26);
            this.Contraseñatxt.TabIndex = 2;
            this.Contraseñatxt.Text = "Contraseña";
            // 
            // CajaNombre
            // 
            this.CajaNombre.BackColor = System.Drawing.Color.YellowGreen;
            this.CajaNombre.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CajaNombre.Location = new System.Drawing.Point(134, 141);
            this.CajaNombre.MaxLength = 13;
            this.CajaNombre.Name = "CajaNombre";
            this.CajaNombre.Size = new System.Drawing.Size(100, 26);
            this.CajaNombre.TabIndex = 3;
            this.CajaNombre.TextChanged += new System.EventHandler(this.CajaNombre_TextChanged);
            this.CajaNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaNombre_KeyPress);
            // 
            // MostrarContraseña
            // 
            this.MostrarContraseña.AutoSize = true;
            this.MostrarContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MostrarContraseña.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.MostrarContraseña.ForeColor = System.Drawing.Color.YellowGreen;
            this.MostrarContraseña.Location = new System.Drawing.Point(267, 206);
            this.MostrarContraseña.Name = "MostrarContraseña";
            this.MostrarContraseña.Size = new System.Drawing.Size(164, 28);
            this.MostrarContraseña.TabIndex = 7;
            this.MostrarContraseña.Text = "Mostrar contraseña";
            this.MostrarContraseña.UseVisualStyleBackColor = true;
            this.MostrarContraseña.CheckedChanged += new System.EventHandler(this.MostrarContraseña_CheckedChanged);
            // 
            // Minimizar
            // 
            this.Minimizar.BackColor = System.Drawing.Color.Transparent;
            this.Minimizar.BackgroundImage = global::Vista.Properties.Resources.Min;
            this.Minimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Minimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Minimizar.FlatAppearance.BorderSize = 0;
            this.Minimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Minimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Minimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimizar.Location = new System.Drawing.Point(372, 12);
            this.Minimizar.Name = "Minimizar";
            this.Minimizar.Size = new System.Drawing.Size(31, 28);
            this.Minimizar.TabIndex = 10;
            this.toolTip1.SetToolTip(this.Minimizar, "Minimizar");
            this.Minimizar.UseVisualStyleBackColor = false;
            this.Minimizar.MouseLeave += new System.EventHandler(this.Minimizar_MouseLeave);
            this.Minimizar.Click += new System.EventHandler(this.Minimizar_Click);
            this.Minimizar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Minimizar_MouseDown);
            // 
            // Cerrar
            // 
            this.Cerrar.BackgroundImage = global::Vista.Properties.Resources.Cerrar;
            this.Cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cerrar.FlatAppearance.BorderSize = 0;
            this.Cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cerrar.Location = new System.Drawing.Point(406, 12);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(31, 28);
            this.Cerrar.TabIndex = 999;
            this.toolTip1.SetToolTip(this.Cerrar, "Cerrar");
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.MouseLeave += new System.EventHandler(this.CerrarM);
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            this.Cerrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CerrarP);
            this.Cerrar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CerrarP);
            // 
            // CajaDocumento
            // 
            this.CajaDocumento.BackColor = System.Drawing.Color.DarkOrange;
            this.CajaDocumento.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CajaDocumento.Location = new System.Drawing.Point(137, 209);
            this.CajaDocumento.MaxLength = 13;
            this.CajaDocumento.Name = "CajaDocumento";
            this.CajaDocumento.Size = new System.Drawing.Size(100, 26);
            this.CajaDocumento.TabIndex = 4;
            this.CajaDocumento.TextChanged += new System.EventHandler(this.CajaDocumeto_TextChanged);
            this.CajaDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CajaDocumento_KeyPress);
            // 
            // Propiedades
            // 
            this.Propiedades.Image = global::Vista.Properties.Resources.Logotipo;
            this.Propiedades.Location = new System.Drawing.Point(21, 13);
            this.Propiedades.Name = "Propiedades";
            this.Propiedades.Size = new System.Drawing.Size(345, 93);
            this.Propiedades.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Propiedades.TabIndex = 11;
            this.Propiedades.TabStop = false;
            // 
            // IniciarSesion
            // 
            this.IniciarSesion.BackgroundImage = global::Vista.Properties.Resources.Iniciar_Sesión;
            this.IniciarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.IniciarSesion.FlatAppearance.BorderSize = 0;
            this.IniciarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.IniciarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.IniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IniciarSesion.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniciarSesion.Location = new System.Drawing.Point(95, 258);
            this.IniciarSesion.Name = "IniciarSesion";
            this.IniciarSesion.Size = new System.Drawing.Size(196, 46);
            this.IniciarSesion.TabIndex = 8;
            this.IniciarSesion.UseVisualStyleBackColor = true;
            this.IniciarSesion.MouseLeave += new System.EventHandler(this.IniciarSesion_MouseLeave);
            this.IniciarSesion.Click += new System.EventHandler(this.IniciarSesion_Click);
            this.IniciarSesion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.INICIARSESIÓNP);
            this.IniciarSesion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.INICIARSESIÓNP);
            // 
            // Iniciodesesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 313);
            this.Controls.Add(this.Propiedades);
            this.Controls.Add(this.Minimizar);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.IniciarSesion);
            this.Controls.Add(this.MostrarContraseña);
            this.Controls.Add(this.CajaDocumento);
            this.Controls.Add(this.CajaNombre);
            this.Controls.Add(this.Contraseñatxt);
            this.Controls.Add(this.Documentotxt);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Iniciodesesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIO DE SESION";
            this.Load += new System.EventHandler(this.Iniciodesesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Propiedades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Documentotxt;
        private System.Windows.Forms.Label Contraseñatxt;
        private System.Windows.Forms.TextBox CajaNombre;
        private System.Windows.Forms.CheckBox MostrarContraseña;
        private System.Windows.Forms.Button IniciarSesion;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button Minimizar;
        private System.Windows.Forms.PictureBox Propiedades;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox CajaDocumento;
    }
}

