//---Se llaman las librerias que serán usadas---\\
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Datos;


namespace Logica
{
    //---Se crea la clase Cliente y sus atributos---\\
    public class Cliente
    {
        public Int64 No_Documento_Cl { get; set; }
        public string Tipo_Identificacion_Cl { get; set; }
        public string Nombre_Cl { get; set; }
        public string Apellido_Cl { get; set; }
        public Int64 Celular_Cl { get; set; }
        public string Direccion_Cl { get; set; }
        public string Correo_Cl { get; set; }

        //---Metodo para registrar la informacion del Cliente---\\
        public static int RegistrarCliente(Cliente PCliente)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Registrar_Cliente {0},'{1}' ,'{2}','{3}',{4},'{5}','{6}'",
                    PCliente.No_Documento_Cl, PCliente.Tipo_Identificacion_Cl, PCliente.Nombre_Cl, PCliente.Apellido_Cl,PCliente.Celular_Cl, PCliente.Direccion_Cl, PCliente.Correo_Cl), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }
        //---Metodo para llenar el Combobox con todas las identificaciones del Cliente---\\
        public void IndentiSelectCli(ComboBox CajaIndenti)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand("select No_Documento_Cl from Cliente ", Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    CajaIndenti.Items.Add(LeeerIE["No_Documento_Cl"].ToString());
                }
                LeeerIE.Close();
                Connn.Close();
            }
        }
        //---Metodo para obtener el cliente por medio del No de documento---\\
        public static Cliente ObtenerCli(Int64 X)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Cliente PCliente = new Cliente();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Nombre_Cl, Apellido_Cl from Cliente where No_Documento_Cl={0}", X), Connn);

            SqlDataReader LeeerI = CmdeI.ExecuteReader();
            while (LeeerI.Read())
            {
                PCliente.Nombre_Cl = LeeerI.GetString(0);
                PCliente.Apellido_Cl = LeeerI.GetString(1);


            }
            Connn.Close();
            return PCliente;
        }
    }
}
