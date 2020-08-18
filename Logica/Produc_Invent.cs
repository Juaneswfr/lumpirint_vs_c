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
    public class Produc_Invent
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();

        public Int64 Id_PROINV { get; set; }
        public Int64 Cantidad_Necesitada { get; set; }
        public Int64 Id_Produccion { get; set; }
        public Int64 Id_pz { get; set; }
        public string Tipo_de_pieza { get; set; }

        public static int RegistrarProduccTT(Produc_Invent PProducInvent)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "insert into Produc_Invent (Cantidad_Necesitada, Id_Produccion, Id_pz, Tipo_de_pieza) values({0},{1},{2},'{3}')",
                     PProducInvent.Cantidad_Necesitada, PProducInvent.Id_Produccion, PProducInvent.Id_pz, PProducInvent.Tipo_de_pieza), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }

        public static List<Produc_Invent> ConsultarProduccTT(string PId)
        {
            Conexión Con = new Conexión();
            List<Produc_Invent> ListaPC = new List<Produc_Invent>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdemP = new SqlCommand(string.Format(
                    "select Id_PROINV, Id_pz, Tipo_de_pieza, Cantidad_Necesitada,Id_Produccion from Produc_Invent where Id_Produccion Like'%{0}%' ", PId), Connn);

                SqlDataReader LeeerI = CmdemP.ExecuteReader();
                while (LeeerI.Read())
                {
                    Produc_Invent PProducInvent = new Produc_Invent();

                    PProducInvent.Id_PROINV = LeeerI.GetInt64(0);
                    PProducInvent.Id_pz = LeeerI.GetInt64(1);
                    PProducInvent.Tipo_de_pieza = LeeerI.GetString(2);
                    PProducInvent.Cantidad_Necesitada = LeeerI.GetInt64(3);
                    PProducInvent.Id_Produccion = LeeerI.GetInt64(4);

                    ListaPC.Add(PProducInvent);

                }
                Connn.Close();
                return ListaPC;
            }
        }
    }
}
