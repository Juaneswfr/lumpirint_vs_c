//---Se llaman las librerias que serán usadas---\\
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Logica
{
    //---Se crea la clase Iniciar Sesion con sus atributos---\\
    public class Iniciar_Sesion
    {
        SqlConnection CNXE = new SqlConnection();
        Conexión Con = new Conexión();

        //---Metodo para consultar el nombre del empleado y la contraseña que en este caso es el No de documento---\\
        public Empleado IsConsultar(string Nombre_em, string Contraseña)
        {
            CNXE = Con.Conectar();
            if (string.IsNullOrEmpty(Nombre_em) || string.IsNullOrEmpty(Contraseña))
                return null;

            SqlCommand CMD = new SqlCommand("select * from Empleado Where No_Documento_em = " + Contraseña + " and Nombre_em = '" + Nombre_em + "'", CNXE);

            SqlDataReader Consultar = CMD.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(Consultar);
            CNXE.Close();

            if (table.HasRows())
                return new Empleado
                {
                    Nombre_cargo = (TipoCargo)Enum.Parse(typeof(TipoCargo), table.Rows[0]["Nombre_cargo"].ToString()),
                    Apellido_em = table.Rows[0]["Apellido_em"].ToString(),
                    Nombre_em = table.Rows[0]["Nombre_em"].ToString(),
                    No_Documento_em = Convert.ToInt64(table.Rows[0]["No_Documento_em"].ToString())
                };
            else return null;
        }
        //---Metodo para verificar la contraseña que en este caso es el No de documento del Empleado---\\
        public Empleado VerificarCont(string Contraseña)
        {
            CNXE = Con.Conectar();
            if (string.IsNullOrEmpty(Contraseña))
                return null;

            SqlCommand CMD = new SqlCommand("select * from Empleado Where No_Documento_em = " + Contraseña + "", CNXE);

            SqlDataReader Consultar = CMD.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(Consultar);
            CNXE.Close();

            if (table.HasRows())
                return new Empleado
                {
                    Nombre_cargo = (TipoCargo)Enum.Parse(typeof(TipoCargo), table.Rows[0]["Nombre_cargo"].ToString()),
                    Apellido_em = table.Rows[0]["Apellido_em"].ToString(),
                    Nombre_em = table.Rows[0]["Nombre_em"].ToString()
                };
            else return null;
        }
        //---Metodo para verificar el nombre del Empleado--\\
        public Empleado VerificarNomb(string Nombre_em)
        {
             CNXE = Con.Conectar();
            if (string.IsNullOrEmpty(Nombre_em))
                return null;

            SqlCommand CMD = new SqlCommand("select * from Empleado Where Nombre_em = '" + Nombre_em + "'", CNXE);
            SqlDataReader Consultar = CMD.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(Consultar);
            CNXE.Close();

            if (table.HasRows())
                return new Empleado
                {
                    Nombre_em = table.Rows[0]["Nombre_em"].ToString()
                };
            else return null;
            
        }

    }


    //---Metodo para las extenciones de las filas---\\
    public static class Extensiones
    {
        public static bool HasRows(this DataTable table)
        {
            return table.Rows.Count >= 1;
        }
    }

}