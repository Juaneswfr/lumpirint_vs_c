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
    public class PedidoCliente
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();

        public Int64 Id_Pcli { get; set; }
        public string Fecha_Realizacion_Pcli { get; set; }
        public string Fecha_Entrega_Pcli { get; set; }
        public string Observaciones { get; set; }
        public Int64 Iva_Pcli { get; set; }
        public decimal Subtotal_Pcli { get; set; }
        public Int64 Valor_Total_Pcli { get; set; }
        public Int64 No_Documento_em { get; set; }
        public string Nombre_em { get; set; }
        public string Apellido_em { get; set; }
        public Int64 No_Documento_Cl { get; set; }
        public string Nombre_Cl { get; set; }
        public string Apellido_Cl { get; set; }
        public Int64 Abono_Pcli { get; set; }
        public Int64 Saldo_Pcli { get; set; }
        public string Estado_Pcli { get; set; }

        public static int RegistrarPedidoCliente(PedidoCliente PPedido_Cliente)
        {
            int RetornR = 0;
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Insert into Pedido_Cliente(Id_Pcli,Fecha_Realizacion_Pcli,Fecha_Entrega_Pcli,Observaciones,Iva_Pcli,Subtotal_Pcli,Valor_Total_Pcli,No_Documento_em,Nombre_em,Apellido_em,No_Documento_Cl,Nombre_Cl,Apellido_Cl,Abono_Pcli,Saldo_Pcli,Estado_Pcli) values({0},'{1}','{2}','{3}',{4}, {5},{6},{7},'{8}','{9}',{10},'{11}','{12}',{13},{14},'{15}') ",
                    PPedido_Cliente.Id_Pcli, PPedido_Cliente.Fecha_Realizacion_Pcli, PPedido_Cliente.Fecha_Entrega_Pcli, PPedido_Cliente.Observaciones, PPedido_Cliente.Iva_Pcli, PPedido_Cliente.Subtotal_Pcli, PPedido_Cliente.Valor_Total_Pcli, PPedido_Cliente.No_Documento_em, PPedido_Cliente.Nombre_em, PPedido_Cliente.Apellido_em, PPedido_Cliente.No_Documento_Cl, PPedido_Cliente.Nombre_Cl, PPedido_Cliente.Apellido_Cl, PPedido_Cliente.Abono_Pcli, PPedido_Cliente.Saldo_Pcli, PPedido_Cliente.Estado_Pcli), Connn);

                RetornR = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return RetornR;
        }

        public static PedidoCliente ObtenerPedidoCliente(Int64 Id_Pcli)
        {
            Conexión Con = new Conexión();
            using (SqlConnection Connn = Con.Conectar())
            {
                PedidoCliente PPedidoCliente = new PedidoCliente();
                SqlCommand CmdeI = new SqlCommand(string.Format(
                    "select  CONVERT(VARCHAR(50),Fecha_Realizacion_Pcli,120), CONVERT(VARCHAR(50),Fecha_Entrega_Pcli,120),Id_Pcli,Observaciones,Valor_Total_Pcli,No_Documento_em,Nombre_em,Apellido_em,No_Documento_Cl,Nombre_Cl,Apellido_Cl,Abono_Pcli,Saldo_Pcli,Estado_Pcli,Subtotal_Pcli,Iva_Pcli from Pedido_Cliente where Id_Pcli={0}", Id_Pcli), Connn);

                SqlDataReader LeeerI = CmdeI.ExecuteReader();
                while (LeeerI.Read())
                {
                    PPedidoCliente.Fecha_Realizacion_Pcli = LeeerI.GetString(0);
                    PPedidoCliente.Fecha_Entrega_Pcli = LeeerI.GetString(1);
                    PPedidoCliente.Id_Pcli = LeeerI.GetInt64(2);
                    PPedidoCliente.Observaciones = LeeerI.GetString(3);
                    PPedidoCliente.Valor_Total_Pcli = LeeerI.GetInt64(4);
                    PPedidoCliente.No_Documento_em = LeeerI.GetInt64(5);
                    PPedidoCliente.Nombre_em = LeeerI.GetString(6);
                    PPedidoCliente.Apellido_em = LeeerI.GetString(7);
                    PPedidoCliente.No_Documento_Cl = LeeerI.GetInt64(8);
                    PPedidoCliente.Nombre_Cl = LeeerI.GetString(9);
                    PPedidoCliente.Apellido_Cl = LeeerI.GetString(10);
                    PPedidoCliente.Abono_Pcli = LeeerI.GetInt64(11);
                    PPedidoCliente.Saldo_Pcli = LeeerI.GetInt64(12);
                    PPedidoCliente.Estado_Pcli = LeeerI.GetString(13);
                    PPedidoCliente.Subtotal_Pcli = LeeerI.GetInt64(14);
                    PPedidoCliente.Iva_Pcli = LeeerI.GetInt64(15);
                }
                Connn.Close();
                return PPedidoCliente;
                {
                }
            }
        }

        public static int ActualizarPedidoCliente(PedidoCliente PPedido_Cliente)
        {
            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format(
                    "Update Pedido_Cliente set Fecha_Realizacion_Pcli='{0}',Fecha_Entrega_Pcli='{1}',Observaciones='{2}',Iva_Pcli={3},Subtotal_Pcli={4},Valor_Total_Pcli={5},No_Documento_em={6},Nombre_em='{7}',Apellido_em='{8}',No_Documento_Cl={9},Nombre_Cl='{10}',Apellido_Cl='{11}',Abono_Pcli={12},Saldo_Pcli={13},Estado_Pcli='{14}' where Id_Pcli={15}",
                     PPedido_Cliente.Fecha_Realizacion_Pcli, PPedido_Cliente.Fecha_Entrega_Pcli, PPedido_Cliente.Observaciones, PPedido_Cliente.Iva_Pcli, PPedido_Cliente.Subtotal_Pcli, PPedido_Cliente.Valor_Total_Pcli, PPedido_Cliente.No_Documento_em, PPedido_Cliente.Nombre_em, PPedido_Cliente.Apellido_em, PPedido_Cliente.No_Documento_Cl, PPedido_Cliente.Nombre_Cl, PPedido_Cliente.Apellido_Cl, PPedido_Cliente.Abono_Pcli, PPedido_Cliente.Saldo_Pcli, PPedido_Cliente.Estado_Pcli, PPedido_Cliente.Id_Pcli), Connn);
                Retorno = Cmd.ExecuteNonQuery();
            }

            return Retorno;

        }

        public static List<PedidoCliente> ConsultarPedidoCli(string PId_Pcli)
        {
            Conexión Con = new Conexión();
            List<PedidoCliente> ListaPC = new List<PedidoCliente>();
            using (SqlConnection Connn = Con.Conectar())
            {
                if (PId_Pcli.Contains("-") | PId_Pcli.Contains("/"))
                {
                    SqlCommand CmdemP = new SqlCommand(string.Format(
                        "select Id_Pcli,Fecha_Realizacion_Pcli,Fecha_Entrega_Pcli,Observaciones,Iva_Pcli,Subtotal_Pcli,Valor_Total_Pcli,No_Documento_em,Nombre_em,No_Documento_Cl,Nombre_Cl,Apellido_Cl,Abono_Pcli,Saldo_Pcli,Estado_Pcli,Apellido_em from Pedido_Cliente where Fecha_Realizacion_Pc=convert(datetime,{0}, 121) or Fecha_Entrega_Pc=convert(datetime,{0}, 121)", PId_Pcli), Connn);
                    SqlDataReader LeeerI = CmdemP.ExecuteReader();
                    while (LeeerI.Read())
                    {
                        PedidoCliente PPedidoCliente = new PedidoCliente();

                        PPedidoCliente.Id_Pcli = LeeerI.GetInt64(0);
                        PPedidoCliente.Fecha_Realizacion_Pcli = Convert.ToString(LeeerI.GetDateTime(1));
                        PPedidoCliente.Fecha_Entrega_Pcli = Convert.ToString(LeeerI.GetDateTime(2));
                        PPedidoCliente.Observaciones = LeeerI.GetString(3);
                        PPedidoCliente.Iva_Pcli = LeeerI.GetInt64(4);
                        PPedidoCliente.Subtotal_Pcli = LeeerI.GetInt64(5);
                        PPedidoCliente.Valor_Total_Pcli = LeeerI.GetInt64(6);
                        PPedidoCliente.No_Documento_em = LeeerI.GetInt64(7);
                        PPedidoCliente.Nombre_em = LeeerI.GetString(8);
                        PPedidoCliente.No_Documento_Cl = LeeerI.GetInt64(9);
                        PPedidoCliente.Nombre_Cl = LeeerI.GetString(10);
                        PPedidoCliente.Apellido_Cl = LeeerI.GetString(11);
                        PPedidoCliente.Abono_Pcli = LeeerI.GetInt64(12);
                        PPedidoCliente.Saldo_Pcli = LeeerI.GetInt64(13);
                        PPedidoCliente.Estado_Pcli = LeeerI.GetString(14);
                        PPedidoCliente.Apellido_em = LeeerI.GetString(15);
                        ListaPC.Add(PPedidoCliente);

                    }
                    Connn.Close();
                    return ListaPC;
                }
                else
                {
                    SqlCommand CmdemP = new SqlCommand(string.Format(
                    "select Id_Pcli,Fecha_Realizacion_Pcli,Fecha_Entrega_Pcli,Observaciones,Iva_Pcli,Subtotal_Pcli,Valor_Total_Pcli,No_Documento_em,Nombre_em,No_Documento_Cl,Nombre_Cl,Apellido_Cl,Abono_Pcli,Saldo_Pcli,Estado_Pcli,Apellido_em from Pedido_Cliente where Id_Pcli Like'%{0}%' or No_Documento_Cl Like'%{0}%' or Nombre_Cl Like'%{0}%'", PId_Pcli), Connn);
                    SqlDataReader LeeerI = CmdemP.ExecuteReader();
                    while (LeeerI.Read())
                    {
                        PedidoCliente PPedidoCliente = new PedidoCliente();

                        PPedidoCliente.Id_Pcli = LeeerI.GetInt64(0);
                        PPedidoCliente.Fecha_Realizacion_Pcli = Convert.ToString(LeeerI.GetDateTime(1));
                        PPedidoCliente.Fecha_Entrega_Pcli = Convert.ToString(LeeerI.GetDateTime(2));
                        PPedidoCliente.Observaciones = LeeerI.GetString(3);
                        PPedidoCliente.Iva_Pcli = LeeerI.GetInt64(4);
                        PPedidoCliente.Subtotal_Pcli = LeeerI.GetInt64(5);
                        PPedidoCliente.Valor_Total_Pcli = LeeerI.GetInt64(6);
                        PPedidoCliente.No_Documento_em = LeeerI.GetInt64(7);
                        PPedidoCliente.Nombre_em = LeeerI.GetString(8);
                        PPedidoCliente.No_Documento_Cl = LeeerI.GetInt64(9);
                        PPedidoCliente.Nombre_Cl = LeeerI.GetString(10);
                        PPedidoCliente.Apellido_Cl = LeeerI.GetString(11);
                        PPedidoCliente.Abono_Pcli = LeeerI.GetInt64(12);
                        PPedidoCliente.Saldo_Pcli = LeeerI.GetInt64(13);
                        PPedidoCliente.Estado_Pcli = LeeerI.GetString(14);
                        PPedidoCliente.Apellido_em = LeeerI.GetString(15);
                        ListaPC.Add(PPedidoCliente);

                    }
                    Connn.Close();
                    return ListaPC;
                }
            }
        }

        public static PedidoCliente AutoincrementarCli(Int64 X)
        {
            Conexión Con = new Conexión();
            PedidoCliente Pdi = new PedidoCliente();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(string.Format("select isnull (max(Id_Pcli),0)+1 from Pedido_Cliente ", X), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Pdi.Id_Pcli = LeeerIE.GetInt64(0);
                }
                Connn.Close();
                return Pdi;
            }
        }

        public static PedidoCliente CalcularSubTotal(Int64 Xee)
        {
            Conexión Con = new Conexión();
            PedidoCliente Pdi = new PedidoCliente();
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand CmdeI = new SqlCommand(string.Format("select Sum(Valor_Total_PeInv) as Sub from PedidoCliente_Produc where Id_Pcli={0}", Xee), Connn);
                SqlDataReader LeeerIE = CmdeI.ExecuteReader();
                while (LeeerIE.Read())
                {
                    Pdi.Subtotal_Pcli = LeeerIE.GetDecimal(0);
                    //Pdi.Subtotal_Pc = Convert.ToInt64(LeeerIE.GetInt64(0));

                }
                Connn.Close();
                return Pdi;
            }
        }
        public static int EliminarPCli(Int64 zee)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format("begin delete PedidoCliente_Produc from PedidoCliente_Produc inner join Pedido_Cliente on PedidoCliente_Produc.Id_Pcli=Pedido_Cliente.Id_Pcli where Pedido_Cliente.Valor_Total_Pcli = {0} Delete from Pedido_Cliente where Subtotal_Pcli = {0}  end", zee), Connn);
                Retorno = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return Retorno;
        }

        public static int EliminarVentaa(Int64 IdPCl)
        {

            Conexión Con = new Conexión();
            int Retorno = 0;
            using (SqlConnection Connn = Con.Conectar())
            {
                SqlCommand Cmd = new SqlCommand(string.Format("delete from Pedido_Cliente where Id_Pcli={0}", IdPCl), Connn);
                Retorno = Cmd.ExecuteNonQuery();
                Connn.Close();
            }
            return Retorno;
        }
        
    }
}
