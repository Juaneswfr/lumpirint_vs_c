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
    //---Se crea una enumeración que sera el Tipo de cargo que tiene cada empleado---\\
    public enum TipoCargo
    {
        Gerente,
        Administrador,
        Diseñador,
        Contador

    }
    //---Se crea la clase Empleado con sus atributos---\\
    public class Empleado
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();
        public Int64 Id_em { get; set; }
        public Int64 No_Documento_em { get; set; }
        public string Nombre_em { get; set; }
        public string Apellido_em { get; set; }
        public TipoCargo Nombre_cargo { get; set; }
        public Int64 Celular_em { get; set; }
        public Nullable<Int64> Telefono_em { get; set; }
        public string Direccion_em { get; set; }
        public string Correo_em { get; set; }
        public string Estado_em { get; set; }


        private string op;

        //---Metodo para registrar Empleado---\\
        public static int RegistrarEmpleado(Empleado PEmpleado)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Registrar_Empleado {0},'{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}'",
                    PEmpleado.No_Documento_em, PEmpleado.Nombre_em, PEmpleado.Apellido_em, PEmpleado.Celular_em,
                    PEmpleado.Telefono_em , PEmpleado.Direccion_em, PEmpleado.Correo_em, PEmpleado.Estado_em, PEmpleado.Nombre_cargo), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }

        //---Metodo para Consultar Empleado---\\

        public static List<Empleado> ConsultarEmpleado(string Consulta)
        {
            
            Conexión Con = new Conexión();
            List<Empleado> ListaE = new List<Empleado>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmdem = new SqlCommand(string.Format(
                    "Consultar_Empleado '{0}'", Consulta), Connn);

                SqlDataReader Leeer = Cmdem.ExecuteReader();
                while (Leeer.Read())
                {
                    Empleado PEmpleado = new Empleado();
                    PEmpleado.Id_em = Leeer.GetInt64(0);
                    PEmpleado.Nombre_em = Leeer.GetString(1);
                    PEmpleado.No_Documento_em = Leeer.GetInt64(2);
                    PEmpleado.Apellido_em = Leeer.GetString(3);
                    PEmpleado.Celular_em = Leeer.GetInt64(4);
                    if (!Leeer.IsDBNull(5))
                    {
                        PEmpleado.Telefono_em = Leeer.GetInt64(5);
                    }
                    else
                    {
                        PEmpleado.Telefono_em = 0;
                    }
                    PEmpleado.Direccion_em = Leeer.GetString(6);
                    PEmpleado.Correo_em = Leeer.GetString(7);
                    PEmpleado.Estado_em = Leeer.GetString(8);
                    PEmpleado.Nombre_cargo = (TipoCargo)Enum.Parse(typeof(TipoCargo), Leeer.GetString(9));
                    ListaE.Add(PEmpleado);

                }
                Connn.Close();
                return ListaE;
            }
        }

        //---Metodo para obtener el ID Del empleado---\\
        public static Empleado ObtenerEmpleado(Int64 Id_em)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                Empleado PEmpleado = new Empleado();
                SqlCommand Cmdem = new SqlCommand(string.Format(
                    "select Id_em,Nombre_Em,No_Documento_em,Apellido_em,Celular_em,Telefono_em,Direccion_em,Correo_em, Estado_em,Nombre_cargo from Empleado where Id_em={0}", Id_em), Connn);

                SqlDataReader Leeer = Cmdem.ExecuteReader();
                while (Leeer.Read())
                {
                    PEmpleado.Id_em = Leeer.GetInt64(0);
                    PEmpleado.Nombre_em = Leeer.GetString(1);
                    PEmpleado.No_Documento_em = Leeer.GetInt64(2);
                    PEmpleado.Apellido_em = Leeer.GetString(3);
                    PEmpleado.Celular_em = Leeer.GetInt64(4);
                    if (!Leeer.IsDBNull(5))
                    {
                        PEmpleado.Telefono_em = Leeer.GetInt64(5);
                    }
                    else
                    {
                        PEmpleado.Telefono_em = 0;
                    }
                    PEmpleado.Direccion_em = Leeer.GetString(6);
                    PEmpleado.Correo_em = Leeer.GetString(7);
                    PEmpleado.Estado_em = Leeer.GetString(8);
                    PEmpleado.Nombre_cargo = (TipoCargo)Enum.Parse(typeof(TipoCargo), Leeer.GetString(9));
                }
                Connn.Close();
                return PEmpleado;
                {
                }
            }
        }
        //---Metodo para actualizar Empleado---\\
        public static int ActualizarEmpleado(Empleado PEmpleado)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Actualizar_Empleado {0},'{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}',{9}",
                    PEmpleado.No_Documento_em, PEmpleado.Nombre_em, PEmpleado.Apellido_em, PEmpleado.Celular_em, PEmpleado.Telefono_em, PEmpleado.Direccion_em, PEmpleado.Correo_em, PEmpleado.Estado_em, PEmpleado.Nombre_cargo, PEmpleado.Id_em), Connn);
                Retorno = Cmd.ExecuteNonQuery();
            }
            return Retorno;
        }
        //---Metodo para obtener existencia del Empleado por medio del documento---\\
        public string Existencia_Empleado(string PDocumento)
        {
            SqlConnection Connn = Con.Conectar();
            SqlCommand coman = new SqlCommand("Select No_Documento_em from Empleado where No_Documento_em=" + PDocumento + " ", Connn);
            SqlDataReader consultar = coman.ExecuteReader();
            if (consultar.Read())
            {
                op = consultar[0] + "";
            }
            else
            {
                op = "No existe";
            }
           
            Connn.Close();
            return op;
        }
        //---Metodo para obtener Documento del empleado por medio del nombre, apellido, y cargo---\\
        public static Empleado ObtenerDocuEmple(string X, string Y, string Z)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Empleado PEmpleado = new Empleado();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select No_Documento_em from Empleado where Nombre_em ='{0}' and Apellido_em='{1}' and Nombre_cargo= '{2}'", X, Y, Z), Connn);

            SqlDataReader LeeerI = CmdeI.ExecuteReader();
            while (LeeerI.Read())
            {
                PEmpleado.No_Documento_em = LeeerI.GetInt64(0);
            }
            Connn.Close();
            return PEmpleado;
        }
    }

}
