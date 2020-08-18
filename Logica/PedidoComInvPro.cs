using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using System.Windows.Forms;

namespace Logica
{
    public class PedidoComInvPro
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();

        public Int64 IdPCIV { get; set; }
        public Int64 Id_Pc { get; set; }
        public Int64 Id_pz { get; set; }
        public string Tipo_de_pieza { get; set; }
        public string Tamaño { get; set; }
        public string Descripcion { get; set; }
        public Int64 CantidadPedido { get; set; }
        public Decimal Valor_Proveedor { get; set; }
        public Decimal ValorTotalProv { get; set; }
        public string Empresa { get; set; }
        public Int64 Id_Prov { get; set; }




        public static int RegistrarPCIV(PedidoComInvPro PPedido_PCIV)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Insert into Pedido_Comp_Inv_Prov (Id_Pc,Id_pz,CantidadPedido, ValorTotalProv,Id_Prov,Empresa,Tipo_de_pieza,Descripcion,Tamaño,Valor_Proveedor) values({0},{1},{2},{3},{4},'{5}','{6}','{7}','{8}',{9})",
                     PPedido_PCIV.Id_Pc, PPedido_PCIV.Id_pz, PPedido_PCIV.CantidadPedido, PPedido_PCIV.ValorTotalProv, PPedido_PCIV.Id_Prov, PPedido_PCIV.Empresa, PPedido_PCIV.Tipo_de_pieza, PPedido_PCIV.Descripcion, PPedido_PCIV.Tamaño, PPedido_PCIV.Valor_Proveedor), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }

        public static List<PedidoComInvPro> ConsultarComInvPro(string PIdPCIV)
        {
            Conexión Con = new Conexión();
            List<PedidoComInvPro> ListaPCIV = new List<PedidoComInvPro>();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdemP = new SqlCommand(string.Format(
          "Select IdPCIV, Id_Pc,Inventario.Id_Pz, CantidadPedido, ValorTotalProv,Proveedor.Empresa,Proveedor.Id_Prov,Inventario.Tipo_de_pieza,Inventario.Tamaño,Inventario.Valor_Proveedor,Inventario.Descripcion from Pedido_Comp_Inv_Prov Inner Join Inventario on Pedido_Comp_Inv_Prov.Id_pz = Inventario.Id_pz Inner Join Proveedor on Pedido_Comp_Inv_Prov.Id_Prov =Proveedor.Id_Prov where Id_Pc Like'%{0}%'", PIdPCIV), Connn);

                SqlDataReader LeeerI = CmdemP.ExecuteReader();
                while (LeeerI.Read())
                {
                    PedidoComInvPro PPedido_PCIV = new PedidoComInvPro();
                    Inventario PInv = new Inventario();

                    PPedido_PCIV.IdPCIV = LeeerI.GetInt64(0);
                    PPedido_PCIV.Id_Pc = LeeerI.GetInt64(1);
                    PPedido_PCIV.Id_pz = LeeerI.GetInt64(2);
                    PPedido_PCIV.CantidadPedido = LeeerI.GetInt64(3);
                    PPedido_PCIV.ValorTotalProv = LeeerI.GetDecimal(4);
                    PPedido_PCIV.Empresa = LeeerI.GetString(5);
                    PPedido_PCIV.Id_Prov = LeeerI.GetInt64(6);
                    PPedido_PCIV.Tipo_de_pieza = LeeerI.GetString(7);
                    PPedido_PCIV.Tamaño = LeeerI.GetString(8);
                    PPedido_PCIV.Valor_Proveedor = LeeerI.GetDecimal(9);
                    PPedido_PCIV.Descripcion = LeeerI.GetString(10);

                    ListaPCIV.Add(PPedido_PCIV);

                }
                Connn.Close();
                return ListaPCIV;
            }
        }

        public static int EliminarProducto(Int64 IdPCI)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format("delete from Pedido_Comp_Inv_Prov where IdPCIV={0}", IdPCI), Connn);          
                Retorno = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return Retorno;
        }
        
    }
}
