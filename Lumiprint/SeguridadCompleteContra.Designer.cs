﻿namespace Vista
{
    partial class SeguridadCompleteContra
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
            this.Entendido = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Entendido
            // 
            this.Entendido.BackgroundImage = global::Vista.Properties.Resources.Entendido;
            this.Entendido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Entendido.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Entendido.FlatAppearance.BorderSize = 0;
            this.Entendido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Entendido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Entendido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Entendido.Location = new System.Drawing.Point(74, 71);
            this.Entendido.Name = "Entendido";
            this.Entendido.Size = new System.Drawing.Size(117, 37);
            this.Entendido.TabIndex = 10;
            this.Entendido.TabStop = false;
            this.Entendido.UseVisualStyleBackColor = true;
            this.Entendido.MouseLeave += new System.EventHandler(this.Entendido_MouseLeave);
            this.Entendido.Click += new System.EventHandler(this.Entendido_Click);
            this.Entendido.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Entendido_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Complete la contraseña";
            // 
            // SeguridadCompleteContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoSeguridad;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(272, 128);
            this.Controls.Add(this.Entendido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeguridadCompleteContra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeguridadCompleteContra";
            this.Load += new System.EventHandler(this.SeguridadCompleteContra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Entendido;
        private System.Windows.Forms.Label label1;
    }
}