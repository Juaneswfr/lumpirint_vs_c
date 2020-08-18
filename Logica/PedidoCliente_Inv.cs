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
    public class PedidoCliente_Inv
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();

        public Int64 Id_PeInv { get; set; }
        public Int64 Id_Pcli { get; set; }
        public Int64 Id_Produccion { get; set; }
        public Int64 Cantidad_PeInv { get; set; }
        
        public string Nombre_Producto { get; set; }
        public string Descripcion { get; set; }
        public Decimal Valor_Total_PeInv { get; set; }


        public static int RegistrarPeInv(PedidoCliente_Inv PPedidoCliente_Inv)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Insert into PedidoCliente_Produc (Id_Pcli,Id_Produccion,Cantidad_PeInv, Valor_Total_PeInv) values({0},{1},{2},{3})",
                     PPedidoCliente_Inv.Id_Pcli, PPedidoCliente_Inv.Id_Produccion, PPedidoCliente_Inv.Cantidad_PeInv, PPedidoCliente_Inv.Valor_Total_PeInv), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }

        public static List<PedidoCliente_Inv> ConsultarPedidoCliente_Inv(string PIdPCIV)
        {
            Conexión Con = new Conexión();
            List<PedidoCliente_Inv> ListaPCIV = new List<PedidoCliente_Inv>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdemP = new SqlCommand(string.Format(
            "Select Id_PeInv, Id_Pcli,Produccion.Id_Produccion, Nombre_Producto, Descripcion, Cantidad_PeInv, Valor_Total_PeInv from PedidoCliente_Produc Inner Join Produccion on PedidoCliente_Produc.Id_Produccion = Produccion.Id_Produccion where Id_Pcli Like'%{0}%'", PIdPCIV), Connn);

                SqlDataReader LeeerI = CmdemP.ExecuteReader();
                while (LeeerI.Read())
                {
                    PedidoCliente_Inv PPedidoCliente_Inv = new PedidoCliente_Inv();
                    Inventario PInv = new Inventario();

                    PPedidoCliente_Inv.Id_PeInv = LeeerI.GetInt64(0);
                    PPedidoCliente_Inv.Id_Pcli = LeeerI.GetInt64(1);
                    PPedidoCliente_Inv.Id_Produccion = LeeerI.GetInt64(2);
                    PPedidoCliente_Inv.Nombre_Producto = LeeerI.GetString(3);
                    PPedidoCliente_Inv.Descripcion = LeeerI.GetString(4);
                    PPedidoCliente_Inv.Cantidad_PeInv = LeeerI.GetInt64(5);
                    PPedidoCliente_Inv.Valor_Total_PeInv = LeeerI.GetDecimal(6);



                    ListaPCIV.Add(PPedidoCliente_Inv);

                }
                Connn.Close();
                return ListaPCIV;
            }
        }

        public static int EliminarProduc(Int64 Id_PeInv)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format("delete from PedidoCliente_Produc where Id_PeInv={0}", Id_PeInv), Connn);
                Retorno = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return Retorno;
        }

    }
}
