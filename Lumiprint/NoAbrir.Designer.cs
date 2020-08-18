namespace Vista
{
    partial class NoAbrir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoAbrir));
            this.Entendido = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.Entendido.Location = new System.Drawing.Point(147, 74);
            this.Entendido.Name = "Entendido";
            this.Entendido.Size = new System.Drawing.Size(130, 43);
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
            this.label1.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "El documento no se puede abrir porque ya esta en uso.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.YellowGreen;
            this.label2.Location = new System.Drawing.Point(22, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cierre el documento que tenga el mismo nombre.";
            // 
            // NoAbrir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Vista.Properties.Resources.FondoSeguridad;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(423, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Entendido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoAbrir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoAbrir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Entendido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}