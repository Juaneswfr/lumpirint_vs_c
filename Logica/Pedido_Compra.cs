//---Se llaman las librerias que serán usadas---\\
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
    //---Se crea la clase Pedido_Compra con sus atributos---\\
    public class Pedido_Compra
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();

        public string Estado_Pc { get; set; }
        public Int64 Id_Pc { get; set; }
        public string Fecha_Realizacion_Pc { get; set; }
        public string Fecha_Entrega_Pc { get; set; }
        public Int64 Valor_Total_Pc { get; set; }
        public Int64 Subtotal_Pc { get; set; }
        public Int64 Iva_Pc { get; set; }
        public Int64 Id_Prov { get; set; }
        public string Empresa { get; set; }


        //---Metodo para registrar un Pedido de Compra---\\
        public static int RegistrarPedidoCompra(Pedido_Compra PPedido_Compra)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Registrar_Pedido_Compra {0},'{1}','{2}',{3},{4}, {5},{6},'{7}','{8}' ",
                    PPedido_Compra.Id_Pc, PPedido_Compra.Fecha_Realizacion_Pc, PPedido_Compra.Fecha_Entrega_Pc, PPedido_Compra.Valor_Total_Pc, PPedido_Compra.Subtotal_Pc, PPedido_Compra.Iva_Pc, PPedido_Compra.Id_Prov, PPedido_Compra.Empresa, PPedido_Compra.Estado_Pc), Connn);
                
                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }
        //---Metodo para obtener un Pedido de Compra por medio de su ID---\\
        public static Pedido_Compra ObtenerPedidoCompra(Int64 Id_Pc)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                Pedido_Compra PPedido_Compra = new Pedido_Compra();
                SqlCommand CmdeI = new SqlCommand(string.Format(
                    "select  CONVERT(VARCHAR(50),Fecha_Realizacion_Pc,120), CONVERT(VARCHAR(50),Fecha_Entrega_Pc,120),Valor_Total_Pc,Empresa,Id_Pc,Id_Prov,Subtotal_Pc,Estado_Pc,Iva_Pc from Pedido_Compra where Id_Pc={0}", Id_Pc), Connn);

                SqlDataReader LeeerI = CmdeI.ExecuteReader();
                while (LeeerI.Read())
                {
                    PPedido_Compra.Fecha_Realizacion_Pc = LeeerI.GetString(0);
                    PPedido_Compra.Fecha_Entrega_Pc = LeeerI.GetString(1);
                    PPedido_Compra.Valor_Total_Pc = LeeerI.GetInt64(2);
                    PPedido_Compra.Empresa = LeeerI.GetString(3);
                    PPedido_Compra.Id_Pc = LeeerI.GetInt64(4);
                    PPedido_Compra.Id_Prov = LeeerI.GetInt64(5);
                    PPedido_Compra.Subtotal_Pc = LeeerI.GetInt64(6);
                    PPedido_Compra.Estado_Pc = LeeerI.GetString(7);
                    PPedido_Compra.Iva_Pc = LeeerI.GetInt64(8);
                }
                Connn.Close();
                return PPedido_Compra;
                {
                }
            }
        }

        //---Metodo para actualizar un Pedido de Compra---\\
        public static int ActualizarPedidoCompra(Pedido_Compra PPedido_Compra)
        {
            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Actualizar_Pedido_Compra '{0}','{1}',{2},{3},{4},'{5}',{6},'{7}',{8}",
                     PPedido_Compra.Fecha_Realizacion_Pc, PPedido_Compra.Fecha_Entrega_Pc, PPedido_Compra.Valor_Total_Pc, PPedido_Compra.Subtotal_Pc, PPedido_Compra.Iva_Pc, PPedido_Compra.Empresa, PPedido_Compra.Id_Prov, PPedido_Compra.Estado_Pc, PPedido_Compra.Id_Pc), Connn);
                Retorno = Cmd.ExecuteNonQuery();
            }

            return Retorno;

        }
        public static int ActualizarPedidoCompraDos(Pedido_Compra PPedido_Compra)
        {
            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Actualizar_Pedido_Compra_Dos '{0}',{1}",
                     PPedido_Compra.Estado_Pc, PPedido_Compra.Id_Pc), Connn);
                Retorno = Cmd.ExecuteNonQuery();
            }

            return Retorno;

        }



        //---Metodo para consultar un Pedido de Compra por medio de su fecha de realización, o de entrega (If) y por medio de su ID, o Empresa---\\
        public static List<Pedido_Compra> ConsultarPedido_Compra(string PId_Pc)
        {
            Conexión Con = new Conexión();
            List<Pedido_Compra> ListaPC = new List<Pedido_Compra>();
            using (SqlConnection Connn = Con.Conectar())
            {
                if (PId_Pc.Contains("-") | PId_Pc.Contains("/"))
                {
                    SqlCommand CmdemP = new SqlCommand(string.Format(
                    "Consultar_Fecha_Pedido_Compra '{0}'", PId_Pc), Connn);
                    SqlDataReader LeeerI = CmdemP.ExecuteReader();
                    while (LeeerI.Read())
                    {
                        Pedido_Compra PPedido_Compra = new Pedido_Compra();

                        PPedido_Compra.Id_Pc = LeeerI.GetInt64(0);
                        PPedido_Compra.Fecha_Realizacion_Pc = Convert.ToString(LeeerI.GetDateTime(1));
                        PPedido_Compra.Fecha_Entrega_Pc = Convert.ToString(LeeerI.GetDateTime(2));
                        PPedido_Compra.Valor_Total_Pc = LeeerI.GetInt64(3);
                        PPedido_Compra.Subtotal_Pc = LeeerI.GetInt64(4);
                        PPedido_Compra.Iva_Pc = LeeerI.GetInt64(5);
                        PPedido_Compra.Id_Prov = LeeerI.GetInt64(6);
                        PPedido_Compra.Empresa = LeeerI.GetString(7);
                        PPedido_Compra.Estado_Pc = LeeerI.GetString(8);
                        ListaPC.Add(PPedido_Compra);

                    }
                }
                else
                {
                    SqlCommand CmdemP = new SqlCommand(string.Format(
               "Consultar_Pedido_Compra '{0}'", PId_Pc), Connn);
                    SqlDataReader LeeerI = CmdemP.ExecuteReader();
                    while (LeeerI.Read())
                    {
                        Pedido_Compra PPedido_Compra = new Pedido_Compra();

                        PPedido_Compra.Id_Pc = LeeerI.GetInt64(0);
                        PPedido_Compra.Fecha_Realizacion_Pc = Convert.ToString(LeeerI.GetDateTime(1));
                        PPedido_Compra.Fecha_Entrega_Pc = Convert.ToString(LeeerI.GetDateTime(2));
                        PPedido_Compra.Valor_Total_Pc = LeeerI.GetInt64(3);
                        PPedido_Compra.Subtotal_Pc = LeeerI.GetInt64(4);
                        PPedido_Compra.Iva_Pc = LeeerI.GetInt64(5);
                        PPedido_Compra.Id_Prov = LeeerI.GetInt64(6);
                        PPedido_Compra.Empresa = LeeerI.GetString(7);
                        PPedido_Compra.Estado_Pc = LeeerI.GetString(8);
                        ListaPC.Add(PPedido_Compra);

                    }
                }
                Connn.Close();
                return ListaPC;
            }
        }
        //---Metodo para auto incrimentar el ID del Pedido de Compra---\\
        public static Pedido_Compra Autoincrementaaar(Int64 Xe)
        {
            Conexión Con = new Conexión();
            Pedido_Compra Pdi = new Pedido_Compra();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(string.Format("select isnull (max(Id_Pc),0)+1 from Pedido_Compra ", Xe), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Pdi.Id_Pc = LeeerIE.GetInt64(0);
                }
                Connn.Close();
                return Pdi;
            }
        }
        //---Metodo para auto incrimentar el ID del Pedido de Compra---\\
        public static Pedido_Compra Autoincrementar(Int64 Xe)
        {
            Conexión Con = new Conexión();
            Pedido_Compra Pdi = new Pedido_Compra();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(string.Format("select isnull (max(Id_Pc),0)+1 from Pedido_Compra ", Xe), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Pdi.Id_Pc = LeeerIE.GetInt64(0);
                }
                Connn.Close();
                return Pdi;
            }
        }

        //---Metodo para obtener el SubTotal--\\
        public static Pedido_Compra TotalSubTotal(Int64 Xee)
        {
            Conexión Con = new Conexión();
            Pedido_Compra Pdi = new Pedido_Compra();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(string.Format("select Sum(ValorTotalProv) as Sub from Pedido_Comp_Inv_Prov where Id_Pc={0}", Xee), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Pdi.Subtotal_Pc = Convert.ToInt64(LeeerIE.GetDecimal(0));

                }
                Connn.Close();
                return Pdi;
            }
        }
        //---Eliminar todos los Pedidos de Compra que tengan campos vacios---\\
        public static int EliminarPC(Int64 zee)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format("begin delete Pedido_Comp_Inv_Prov from Pedido_Comp_Inv_Prov inner join Pedido_Compra on Pedido_Comp_Inv_Prov.Id_pc=Pedido_Compra.Id_pc where Pedido_Compra.Valor_Total_Pc = {0} Delete from Pedido_Compra where subtotal_pc = {0}  end", zee), Connn);
                Retorno = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return Retorno;
        }

        public static int EliminarCompraa(Int64 IdPC)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format("delete from Pedido_Compra where Id_Pc={0}", IdPC), Connn);
                Retorno = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return Retorno;
        }

        public static Pedido_Compra AutoincrementarEli(Int64 Xe)
        {
            Conexión Con = new Conexión();
            Pedido_Compra Pdi = new Pedido_Compra();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(string.Format("select isnull (max(Id_Pc),0)+0 from Pedido_Compra ", Xe), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Pdi.Id_Pc = LeeerIE.GetInt64(0);
                }
                Connn.Close();
                return Pdi;
            }
        }

    }
}
