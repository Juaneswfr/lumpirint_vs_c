using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;
using Vista.Properties;



namespace Vista
{
    public partial class Iniciodesesion : Form
    {
        public Iniciodesesion()
        {
            InitializeComponent();
        }

        Iniciar_Sesion Login = new Iniciar_Sesion();
        Empleado Em = new Empleado();
        Cargo Ca = new Cargo();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Cerrar_Click(object sender, EventArgs e)
           {
            Application.Exit();
           }


        private void IniciarSesion_Click(object sender, EventArgs e)
        {
            if (CajaNombre.Text == "" && CajaDocumento.Text == "")
            {
                SeguridadCompleteCam formx = new SeguridadCompleteCam();
                formx.ShowDialog();
            }
            else
            {
                if (CajaNombre.Text == "")
                {
                    SeguridadCompleteNom formx = new SeguridadCompleteNom();
                    formx.ShowDialog();

                }
                else if (CajaDocumento.Text == "")
                {
                    SeguridadCompleteContra formx = new SeguridadCompleteContra();
                    formx.ShowDialog();
                }
                else
                {

                    if (CajaNombre.Text != null | CajaDocumento.Text != null)
                    {
                        Empleado Em = Login.IsConsultar(CajaNombre.Text, CajaDocumento.Text);
                        if (Em != null)
                        {
                            MenuPrincipal formx = new MenuPrincipal(Em);
                            formx.Show();
                            this.Hide();
                        }

                        else
                        {
                            Em = Login.VerificarNomb(CajaNombre.Text);
                            if (Em == null)
                            {
                                SNomIncorrec Form = new SNomIncorrec();
                                Form.Show();
                            }
                            else
                            {
                                Em = Login.VerificarCont(CajaDocumento.Text);
                                if (Em == null)
                                {
                                    ContraseñaInco();

                                }
                                else
                                {
                                    ContraseñaInco();
                                }

                            }
                
                            
                        }
                    }
               
                }

            }
        }

        void ContraseñaInco()
        {
             SeguridadIniciodeSesion Seguridad = new SeguridadIniciodeSesion();
                Seguridad.Show();
        }
        private void CerrarP(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.CerrarP));
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void CerrarM(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Cerrar));
        }

        private void Minimizar_MouseDown(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.MinP));
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Min));
        }

        private void INICIARSESIÓNP(object sender, MouseEventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Iniciar_SesiónP));
        }

        private void IniciarSesion_MouseLeave(object sender, EventArgs e)
        {
            var bmp = (Button)sender;
            bmp.BackgroundImage = ((System.Drawing.Image)(Resources.Iniciar_Sesión));
        }
        private void CajaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {

                e.Handled = true;
                return;
            }
        }

        private void CajaDocumento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CajaNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void CajaDocumeto_TextChanged(object sender, EventArgs e)
        {
            if (MostrarContraseña.Checked)
            {
                CajaDocumento.PasswordChar = char.Parse("\0");

            }
            else
                CajaDocumento.PasswordChar = '*';
        }

        private void MostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            CajaDocumento.Text = CajaDocumento.Text + " ";
            if (!string.IsNullOrEmpty(CajaDocumento.Text))
                CajaDocumento.Text = CajaDocumento.Text.ToString().Remove(CajaDocumento.Text.Length - 1);
        }

        private void Iniciodesesion_Load(object sender, EventArgs e)
        {

        }


        }
    }

