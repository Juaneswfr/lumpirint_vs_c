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
    public class Proveedor
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();
        public Int64 Id_Prov { get; set; }
        public string Empresa { get; set; }
        public Int64 Telefono_Prov { get; set; }
        public Int64 Nit_Prov { get; set; }
        public string Correo_Prov { get; set; }
        public string Estado_Prov { get; set; }
      

        public static int RegistrarProveedor(Proveedor PProveedor)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Registrar_Proveedor '{0}',{1},{2},'{3}','{4}'",
                    PProveedor.Empresa, PProveedor.Nit_Prov,PProveedor.Telefono_Prov, PProveedor.Correo_Prov, PProveedor.Estado_Prov), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }
        public static List<Proveedor> ConsultarProveedor(string Empresa)
        {
            Conexión Con = new Conexión();
            List<Proveedor> ListaP = new List<Proveedor>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdemP = new SqlCommand(string.Format(
                    "Consultar_Proveedor '{0}'", Empresa), Connn);

                SqlDataReader LeeerP = CmdemP.ExecuteReader();
                while (LeeerP.Read())
                {
                    Proveedor PProveedor = new Proveedor();
                    PProveedor.Id_Prov = LeeerP.GetInt64(0);
                    PProveedor.Empresa = LeeerP.GetString(1);
                    PProveedor.Telefono_Prov = LeeerP.GetInt64(2);
                    PProveedor.Nit_Prov = LeeerP.GetInt64(3);
                    PProveedor.Correo_Prov = LeeerP.GetString(4);
                    PProveedor.Estado_Prov = LeeerP.GetString(5);
                    ListaP.Add(PProveedor);

                }
                Connn.Close();
                return ListaP;
            }
        }
        public static Proveedor ObtenerProveedor(Int64 Id_Prov)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                Proveedor PProveedor = new Proveedor();
                SqlCommand Cmdem = new SqlCommand(string.Format(
                    "select Id_Prov,Empresa,Telefono_Prov,Nit_Prov,Correo_Prov,Estado_Prov from Proveedor where Id_Prov={0}", Id_Prov), Connn);

                SqlDataReader Leeer = Cmdem.ExecuteReader();
                while (Leeer.Read())
                {
                    PProveedor.Id_Prov = Leeer.GetInt64(0);
                    PProveedor.Empresa = Leeer.GetString(1);
                    PProveedor.Telefono_Prov = Leeer.GetInt64(2);
                    PProveedor.Nit_Prov = Leeer.GetInt64(3);
                    PProveedor.Correo_Prov = Leeer.GetString(4);
                    PProveedor.Estado_Prov = Leeer.GetString(5);
                }
                Connn.Close();
                return PProveedor;
                {
                }
            }
        }
        public static int ActualizarProveedor(Proveedor PProveedor)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Actualizar_Proveedor {0},'{1}','{2}',{3}",
                     PProveedor.Telefono_Prov,PProveedor.Correo_Prov, PProveedor.Estado_Prov, PProveedor.Id_Prov), Connn);
                
                Retorno = Cmd.ExecuteNonQuery();
            }
            return Retorno;
        }
        public void EmpresaSelect(DataTable Empresas)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand("select Empresa from Proveedor where Estado_Prov='Activo'", Connn);
                SqlDataAdapter LeeerIE = new SqlDataAdapter(CmdeI);
                LeeerIE.Fill(Empresas);
                Connn.Close();

            }
        }
        public static Proveedor ObtenerIDProv(string Empresa)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                Proveedor PProveedor = new Proveedor();
                SqlCommand CmdeI = new SqlCommand(string.Format(
                    "select Id_Prov from Proveedor where Empresa='{0}'", Empresa), Connn);

                SqlDataReader LeeerI = CmdeI.ExecuteReader();
                while (LeeerI.Read())
                {
                    PProveedor.Id_Prov = LeeerI.GetInt64(0);
                }
                Connn.Close();
                return PProveedor;
                {
                }
            }
        }
    }
}
