namespace Vista
{
    partial class Consulta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
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
            this.Entendido.Location = new System.Drawing.Point(127, 68);
            this.Entendido.Name = "Entendido";
            this.Entendido.Size = new System.Drawing.Size(130, 43);
            this.Entendido.TabIndex = 999;
            this.Entendido.TabStop = false;
            this.Entendido.UseVisualStyleBackColor = true;
            this.Entendido.MouseLeave += new System.EventHandler(this.Entendido_MouseLeave);
            this.Entendido.Click += new System.EventHandler(this.Entendido_Click);
            this.Entendido.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Entendido_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Realice una consulta para generar reporte.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoSeguridad;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 139);
            this.Controls.Add(this.Entendido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.Consulta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Entendido;
        private System.Windows.Forms.Label label1;
    }
}