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
    public class Produccioon
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();

        public Int64 Id_Produccion { get; set; }
        public Int64 Id_Ma { get; set; }
        public string Tipo_Ma { get; set; }
        public string Nombre_Producto { get; set; }
        public Int64 Valor_Producto { get; set; }
        public string Tamaño { get; set; }
        public string Descripcion { get; set; }
        public string Empresa { get; set; }


        public static int RegistrarProducc(Produccioon PProduccion)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "insert into Produccion (Id_Produccion,Id_Ma,Tipo_Ma,Nombre_Producto, Valor_Producto,Tamaño,Descripcion,Empresa) values({0},{1},'{2}','{3}',{4},'{5}','{6}','{7}')",
                     PProduccion.Id_Produccion ,PProduccion.Id_Ma ,PProduccion.Tipo_Ma,  PProduccion.Nombre_Producto, PProduccion.Valor_Producto, PProduccion.Tamaño, PProduccion.Descripcion, PProduccion.Empresa), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }

        public static List<Produccioon> ConsultarProduccion(string PId)
        {
            Conexión Con = new Conexión();
            List<Produccioon> ListaPC = new List<Produccioon>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdemP = new SqlCommand(string.Format(
                    "select Id_Produccion,Id_Ma,Tipo_Ma,Nombre_Producto, Valor_Producto,Tamaño,Descripcion,Empresa from Produccion where Id_Produccion Like'%{0}%' and Valor_Producto >0 ", PId), Connn);

                SqlDataReader LeeerI = CmdemP.ExecuteReader();
                while (LeeerI.Read())
                {
                    Produccioon PProduccion = new Produccioon();

                    PProduccion.Id_Produccion = LeeerI.GetInt64(0);
                    PProduccion.Id_Ma = LeeerI.GetInt64(1);
                    PProduccion.Tipo_Ma = LeeerI.GetString (2);
                    PProduccion.Nombre_Producto = LeeerI.GetString(3);
                    PProduccion.Valor_Producto = LeeerI.GetInt64(4);
                    PProduccion.Tamaño = LeeerI.GetString(5);
                    PProduccion.Descripcion = LeeerI.GetString(6);
                    PProduccion.Empresa = LeeerI.GetString(7);

                    ListaPC.Add(PProduccion);

                }
                Connn.Close();
                return ListaPC;
            }
        }

        public static int ActualizarProduccion(Produccioon PProduccion)
        {
            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Registrar_Produccion {0},'{1}' ,'{2}',{3},'{4}','{5}','{6}',{7}",
                     PProduccion.Id_Ma, PProduccion.Tipo_Ma , PProduccion.Nombre_Producto,PProduccion.Valor_Producto, PProduccion.Tamaño, PProduccion.Descripcion ,PProduccion.Empresa, PProduccion.Id_Produccion), Connn);
                Retorno = Cmd.ExecuteNonQuery();
            }

            return Retorno;

        }

        public static Produccioon Autoincrementar(Int64 Xe)
        {
            Conexión Con = new Conexión();
            Produccioon Pdi = new Produccioon();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(string.Format("select isnull (max(Id_Produccion),0)+1 from Produccion ", Xe), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Pdi.Id_Produccion = LeeerIE.GetInt64(0);
                }
                Connn.Close();
                return Pdi;
            }
        }

        public static Produccioon ObtenerPro(Int64 X)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Produccioon PProduccion = new Produccioon();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Nombre_Producto, Descripcion, Valor_Producto from Produccion where Id_Produccion={0}", X), Connn);

            SqlDataReader LeeerI = CmdeI.ExecuteReader();
            while (LeeerI.Read())
            {
                PProduccion.Nombre_Producto = LeeerI.GetString(0);
                PProduccion.Descripcion = LeeerI.GetString(1);
                PProduccion.Valor_Producto = LeeerI.GetInt64(2);

            }
            Connn.Close();
            return PProduccion;
        }

        public void ObtenerIdX (ComboBox IdPro)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand("select Id_Produccion from Produccion where Valor_Producto>0", Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    IdPro.Items.Add(LeeerIE["Id_Produccion"].ToString());
                }
                LeeerIE.Close();
                Connn.Close();
            }
        }

    }
}
