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
    //---Se crea la clase Inventario con sus atributos---\\
    public class Inventario
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();
        public Int64 Id_pz { get; set; }
        public string Tipo_de_pieza { get; set; }
        public string Descripcion { get; set; }
        public string Tamaño { get; set; }
        public Int64 Cantidad_Existente { get; set; }
        public Int64 Id_Prov { get; set; }
        public string Empresa { get; set; }
        public Decimal Valor_Proveedor { get; set; }

        //---Metodo para registrar Materia Prima---\\
        public static int RegistrarMateriaPrima(Inventario PInventario)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Registrar_Materia_Prima '{0}','{1}','{2}',{3},{4},'{5}',{6}",
                    PInventario.Tipo_de_pieza, PInventario.Descripcion, PInventario.Tamaño, PInventario.Cantidad_Existente, PInventario.Valor_Proveedor, PInventario.Empresa, PInventario.Id_Prov), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }

        //---Metodo para obtener Materia Prima por medio de su ID---\\
        public static Inventario ObtenerMateriaPrima(Int64 Id_pz)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                Inventario PInventario = new Inventario();
                SqlCommand CmdeI = new SqlCommand(string.Format(
                    "select Tipo_de_pieza,Descripcion,Tamaño,Cantidad_Existente,Valor_Proveedor,Empresa,Id_pz,Id_Prov from Inventario where Id_Pz={0}", Id_pz), Connn);

                SqlDataReader LeeerI = CmdeI.ExecuteReader();
                while (LeeerI.Read())
                {
                    PInventario.Tipo_de_pieza = LeeerI.GetString(0);
                    PInventario.Descripcion = LeeerI.GetString(1);
                    PInventario.Tamaño = LeeerI.GetString(2);
                    PInventario.Cantidad_Existente = LeeerI.GetInt64(3);
                    PInventario.Valor_Proveedor = LeeerI.GetDecimal(4);
                    PInventario.Empresa = LeeerI.GetString(5);
                    PInventario.Id_pz = LeeerI.GetInt64(6);
                    PInventario.Id_Prov = LeeerI.GetInt64(7);
                }
                Connn.Close();
                return PInventario;
                {
                }
            }
        }

        //---Metodo para actualizar Materia Prima---\\
        public static int ActualizarMateriaPrima(Inventario PInventario)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Actualizar_Materia_Prima'{0}','{1}','{2}',{3} ,{4},'{5}','{6}',{7}",
                      PInventario.Tipo_de_pieza, PInventario.Descripcion, PInventario.Tamaño, PInventario.Cantidad_Existente, PInventario.Valor_Proveedor, PInventario.Empresa, PInventario.Id_Prov, PInventario.Id_pz), Connn);
                Retorno = Cmd.ExecuteNonQuery();
            }
            return Retorno;
        }
        //---Metodo para consultar Materia Prima---\\
        public static List<Inventario> ConsultarMateriaPrima(string PTipo_de_pieza)
        {
            Conexión Con = new Conexión();
            List<Inventario> ListaI = new List<Inventario>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdemP = new SqlCommand(string.Format(
                    "Consultar_Materia_Prima '{0}'", PTipo_de_pieza), Connn);

                SqlDataReader LeeerI = CmdemP.ExecuteReader();
                while (LeeerI.Read())
                {
                    Inventario PInventario = new Inventario();

                    PInventario.Tipo_de_pieza = LeeerI.GetString(0);
                    PInventario.Descripcion = LeeerI.GetString(1);
                    PInventario.Tamaño = LeeerI.GetString(2);
                    PInventario.Cantidad_Existente = LeeerI.GetInt64(3);
                    PInventario.Valor_Proveedor = LeeerI.GetDecimal(4);
                    PInventario.Empresa = LeeerI.GetString(5);
                    PInventario.Id_pz = LeeerI.GetInt64(6);
                    PInventario.Id_Prov = LeeerI.GetInt64(7);
                    ListaI.Add(PInventario);

                }
                Connn.Close();
                return ListaI;
            }
        }


        //---Metodo para llenar ComboBox con los ID's de la Materia Prima que coincidan con la Empresa---\\
        public void IdPzSelect(ComboBox CajaIdIn, string Empresa)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(("select Id_pz from Inventario where Empresa='" + Empresa + "'"), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    CajaIdIn.Items.Add(LeeerIE["Id_pz"].ToString());
                }
                LeeerIE.Close();
                Connn.Close();
            }
        }
        //---Metodo para obtener información de la Materia Prima por medio de su ID---\\
        public static Inventario ObtenerMateriaPrimaX(Int64 X)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Inventario PInventario = new Inventario();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Tipo_de_pieza, Descripcion, Valor_Proveedor,Tamaño from Inventario where Id_Pz={0}", X), Connn);

            SqlDataReader LeeerI = CmdeI.ExecuteReader();
            while (LeeerI.Read())
            {
                PInventario.Tipo_de_pieza = LeeerI.GetString(0);
                PInventario.Descripcion = LeeerI.GetString(1);
                PInventario.Valor_Proveedor = LeeerI.GetDecimal(2);
                PInventario.Tamaño = LeeerI.GetString(3);

            }
            Connn.Close();
            return PInventario;
        }
        //---Metodo para obtener ID de la Materia Prima por medio de la Empresa---\\
        public static Inventario ObtenerIdXEm(string Z)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Inventario PInventario = new Inventario();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Id_pz from Inventario where Empresa={0}", "'" + Z + "'"), Connn);

            SqlDataReader LeeerI = CmdeI.ExecuteReader();
            while (LeeerI.Read())
            {
                PInventario.Id_pz = LeeerI.GetInt64(0);
            }
            Connn.Close();
            return PInventario;
        }
        //---Metodo para llenar ComboBox con el ID de la Materia Prima por medio de la empresa---\\
        public void ObtenerIdXEmm(ComboBox CajaIdIn)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand("select Id_pz from Inventario where Empresa=Empresa", Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    CajaIdIn.Items.Add(LeeerIE["Id_pz"].ToString());
                }
                LeeerIE.Close();
                Connn.Close();
            }
        }
        //---Metodo para obtener ID de el Proveedor por medio de la Empresa---\\
        public static Inventario ObtenerIDEmp(string Em)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Inventario PInventario = new Inventario();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Id_Prov from Proveedor where Empresa='{0}'", Em), Connn);
            SqlDataReader LeeerIE = CmdeI.ExecuteReader();
            while (LeeerIE.Read())
            {
                PInventario.Id_Prov = LeeerIE.GetInt64(0);
            }

            Connn.Close();
            return PInventario;


        }
        //---Metodo para obtener el Tipo de pieza de la Materia Prima por medio del ID---\\
        public static Inventario ConsulNomProd(Int64 X)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Inventario PInventario = new Inventario();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Tipo_de_pieza from Inventario where Id_Pz={0}", X), Connn);

            SqlDataReader LeeerI = CmdeI.ExecuteReader();
            while (LeeerI.Read())
            {
                PInventario.Tipo_de_pieza = LeeerI.GetString(0);
            }
            Connn.Close();
            return PInventario;
        }
        //---Metodo para llenar ComboBox con los ID's que existan en el Inventario---\\
        public void IdPzSelect(ComboBox IdPz)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand("select Id_pz from Inventario ", Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    IdPz.Items.Add(LeeerIE["Id_pz"].ToString());
                }
                LeeerIE.Close();
                Connn.Close();
            }
        }

        public static Inventario ConsulEXISTEN(Int64 X)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Inventario PInventario = new Inventario();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Cantidad_Existente from Inventario where Id_Pz={0}", X), Connn);

            SqlDataReader LeeerI = CmdeI.ExecuteReader();
            while (LeeerI.Read())
            {
                PInventario.Cantidad_Existente = LeeerI.GetInt64(0);
            }
            Connn.Close();
            return PInventario;
        }
        public static Inventario ObtenerMGra(string sas)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                Inventario PInventario = new Inventario();
                SqlCommand CmdeI = new SqlCommand(string.Format(
                    "select Tipo_de_pieza,Descripcion,Tamaño,Cantidad_Existente,Valor_Proveedor,Empresa,Id_pz,Id_Prov from Inventario"), Connn);

                SqlDataReader LeeerI = CmdeI.ExecuteReader();
                while (LeeerI.Read())
                {


                    PInventario.Tipo_de_pieza = LeeerI.GetString(0);
                    PInventario.Descripcion = LeeerI.GetString(1);
                    PInventario.Tamaño = LeeerI.GetString(2);
                    PInventario.Cantidad_Existente = LeeerI.GetInt64(3);
                    PInventario.Valor_Proveedor = LeeerI.GetDecimal(4);
                    PInventario.Empresa = LeeerI.GetString(5);
                    PInventario.Id_pz = LeeerI.GetInt64(6);
                    PInventario.Id_Prov = LeeerI.GetInt64(7);
                }
                Connn.Close();
                return PInventario;
                {
                }
            }
        }
    }
}
