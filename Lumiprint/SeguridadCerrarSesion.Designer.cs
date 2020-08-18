namespace Vista
{
    partial class SeguridadCerrarSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeguridadCerrarSesion));
            this.Si = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Si
            // 
            this.Si.BackgroundImage = global::Vista.Properties.Resources.Si;
            this.Si.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Si.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Si.FlatAppearance.BorderSize = 0;
            this.Si.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.Si.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Si.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Si.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Si.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Si.Location = new System.Drawing.Point(82, 79);
            this.Si.Margin = new System.Windows.Forms.Padding(4);
            this.Si.Name = "Si";
            this.Si.Size = new System.Drawing.Size(58, 45);
            this.Si.TabIndex = 0;
            this.Si.TabStop = false;
            this.Si.UseVisualStyleBackColor = true;
            this.Si.MouseLeave += new System.EventHandler(this.Si_MouseLeave);
            this.Si.Click += new System.EventHandler(this.Si_Click);
            this.Si.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Si_MouseDown);
            // 
            // No
            // 
            this.No.BackgroundImage = global::Vista.Properties.Resources.No;
            this.No.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.No.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.No.FlatAppearance.BorderSize = 0;
            this.No.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.No.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.No.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.No.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.No.Location = new System.Drawing.Point(221, 79);
            this.No.Margin = new System.Windows.Forms.Padding(4);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(58, 45);
            this.No.TabIndex = 1;
            this.No.TabStop = false;
            this.No.UseVisualStyleBackColor = true;
            this.No.MouseLeave += new System.EventHandler(this.No_MouseLeave);
            this.No.Click += new System.EventHandler(this.No_Click);
            this.No.MouseDown += new System.Windows.Forms.MouseEventHandler(this.No_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "¿Estas seguro que quieres cerrar sesión?";
            // 
            // SeguridadCerrarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoSeguridad;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(363, 162);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Si);
            this.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SeguridadCerrarSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SeguridadCerrarSesion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Si;
        private System.Windows.Forms.Button No;
        private System.Windows.Forms.Label label1;
    }
}