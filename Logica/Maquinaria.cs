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
    //---Se crea la clase Maquinaria con sus atributos---\\
    public class Maquinaria
    {
        public Int64 Id_Ma { get; set; }
        public string Tipo_Ma { get; set; }
        public string Garantia { get; set; }
        public Int64 NumeroReparacion { get; set; }
        public string Mantenimiento { get; set; }
        public string Estado_Ma { get; set; }

        //---Metodo para registrar Maquinaria---\\
        public static int RegistrarMaquinaria(Maquinaria PMaquinaria)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Registrar_Maquinaria '{0}','{1}',{2},'{3}','{4}'",
                PMaquinaria.Tipo_Ma, PMaquinaria.Garantia, PMaquinaria.NumeroReparacion, PMaquinaria.Mantenimiento, PMaquinaria.Estado_Ma), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }
        //---Metodo para consultar Maquinaria---\\
        public static List<Maquinaria> ConsultarMaquinaria(string PTipo_Ma)
        {
            Conexión Con = new Conexión();
            List<Maquinaria> ListaM = new List<Maquinaria>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmdem = new SqlCommand(string.Format(
                    "Consultar_Maquinaria '%{0}%'", PTipo_Ma), Connn);

                SqlDataReader Leeer = Cmdem.ExecuteReader();
                while (Leeer.Read())
                {
                    Maquinaria PMaquinaria = new Maquinaria();
                    PMaquinaria.Id_Ma = Leeer.GetInt64(0);
                    PMaquinaria.Tipo_Ma = Leeer.GetString(1);
                    PMaquinaria.Garantia = Leeer.GetString(2);
                    PMaquinaria.NumeroReparacion = Leeer.GetInt64(3);
                    PMaquinaria.Mantenimiento = Leeer.GetString(4);
                    PMaquinaria.Estado_Ma = Leeer.GetString(5);
                    ListaM.Add(PMaquinaria);

                }
                Connn.Close();
                return ListaM;
            }
        }
        //---Metodo para obtener Maquinaria por medio de su ID---\\
        public static Maquinaria ObtenerMaquinaria(Int64 Id_Ma)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                Maquinaria PMaquinaria = new Maquinaria();
                SqlCommand Cmdem = new SqlCommand(string.Format(
               "select Id_Ma,Tipo_Ma,Garantia,NumeroReparacion,Mantenimiento,Estado_Ma from Maquinaria where Id_Ma={0}", Id_Ma), Connn);

                SqlDataReader Leeer = Cmdem.ExecuteReader();
                while (Leeer.Read())
                {
                    PMaquinaria.Id_Ma = Leeer.GetInt64(0);
                    PMaquinaria.Tipo_Ma = Leeer.GetString(1);
                    PMaquinaria.Garantia = Leeer.GetString(2);
                    PMaquinaria.NumeroReparacion = Leeer.GetInt64(3);
                    PMaquinaria.Mantenimiento = Leeer.GetString(4);
                    PMaquinaria.Estado_Ma = Leeer.GetString(5);
                }
                Connn.Close();
                return PMaquinaria;
                {
                }
            }
        }
        //---Metodo para Actualizar Maquinaria---\\
        public static int ActualizarMaquinaria(Maquinaria PMaquinaria)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Actualizar_Maquinaria '{0}','{1}',{2},'{3}','{4}',{5}",
                    PMaquinaria.Tipo_Ma, PMaquinaria.Garantia, PMaquinaria.NumeroReparacion, PMaquinaria.Mantenimiento, PMaquinaria.Estado_Ma,  PMaquinaria.Id_Ma), Connn);
                Retorno = Cmd.ExecuteNonQuery();
            }
            return Retorno;
        }
        //---Metodo para llenar un ComboBox con todos los ID's de Maquinaria--\\
        public void IdMaquina(ComboBox Id)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand("select Id_Ma from Maquinaria ", Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Id.Items.Add(LeeerIE["Id_Ma"].ToString());
                }
                LeeerIE.Close();
                Connn.Close();
            }
        }
        //---Metodo para obtener el Tipo de maquinaria por medio de su ID---\\
        public static Maquinaria ObtenerTipoMaqui(Int64 Ma)
        {
            Conexión Con = new Conexión();
            SqlConnection Connn = Con.Conectar();

            Maquinaria PMaquinaria = new Maquinaria();
            SqlCommand CmdeI = new SqlCommand(string.Format(
                "select Tipo_Ma from Maquinaria where Id_Ma={0}", Ma), Connn);
            SqlDataReader LeeerIE = CmdeI.ExecuteReader();
            while (LeeerIE.Read())
            {
                PMaquinaria.Tipo_Ma = LeeerIE.GetString(0);
            }

            Connn.Close();
            return PMaquinaria;

        }

    }

}
