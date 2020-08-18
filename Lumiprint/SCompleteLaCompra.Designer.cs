namespace Vista
{
    partial class SCompleteLaCompra
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
            this.label1 = new System.Windows.Forms.Label();
            this.No = new System.Windows.Forms.Button();
            this.Si = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.var = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "¿Estas seguro que quieres acabar ";
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
            this.No.Location = new System.Drawing.Point(196, 78);
            this.No.Margin = new System.Windows.Forms.Padding(4);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(58, 45);
            this.No.TabIndex = 4;
            this.No.TabStop = false;
            this.No.UseVisualStyleBackColor = true;
            this.No.Click += new System.EventHandler(this.No_Click);
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
            this.Si.Location = new System.Drawing.Point(42, 78);
            this.Si.Margin = new System.Windows.Forms.Padding(4);
            this.Si.Name = "Si";
            this.Si.Size = new System.Drawing.Size(58, 45);
            this.Si.TabIndex = 3;
            this.Si.TabStop = false;
            this.Si.UseVisualStyleBackColor = true;
            this.Si.Click += new System.EventHandler(this.Si_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.YellowGreen;
            this.label2.Location = new System.Drawing.Point(92, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = " la compra?";
            // 
            // var
            // 
            this.var.AutoSize = true;
            this.var.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.var.ForeColor = System.Drawing.Color.YellowGreen;
            this.var.Location = new System.Drawing.Point(218, 87);
            this.var.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.var.Name = "var";
            this.var.Size = new System.Drawing.Size(24, 28);
            this.var.TabIndex = 7;
            this.var.Text = "0";
            // 
            // SCompleteLaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoSeguridad;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(303, 147);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Si);
            this.Controls.Add(this.var);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SCompleteLaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCompleteLaCompra";
            this.Load += new System.EventHandler(this.SCompleteLaCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button No;
        private System.Windows.Forms.Button Si;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label var;
    }
}