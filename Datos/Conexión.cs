//---Se llaman las librerias que serán usadas---\\
using System;//---Contiene clases fundamentales y clases base que definen tipos de datos de referencia y de valor de uso frecuente, eventos y controladores de eventos, interfaces, atributos y excepciones de procesamiento---\\
using System.Collections.Generic;  //---Contiene interfaces y clases que definen colecciones genéricas---\\
using System.Linq; //---Proporciona clases e interfaces que admiten consultas que utilizan Language-integrated query---\\
using System.Text; //--- contiene clases que representan codificaciones de caracteres ASCII y Unicode; clases base abstractas para convertir bloques de caracteres a y desde bloques de bytes y una clase auxiliar que manipula y da formato a objetos String sin crear instancias intermedias de String---\\
using System.Data; //---Contienen clases para tener acceso a datos y administrarlos desde distintos orígenes---\\
using System.Data.SqlClient; //---Proveedor de datos .NET Framework para SQL Server---\\
using System.Windows.Forms; //---Contiene clases para crear aplicaciones basadas en Windows que aprovechan al máximo el usuario enriquecida características disponibles en el sistema operativo Microsoft Windows de la interfaz ---\\

namespace Datos//---La capa usada para la clase será la capa Datos---\\
{

    //---Se crea la Clase Conexión---\\
    public class Conexión
    {
        SqlConnection CNX = new SqlConnection();//---La variable CNX se denomina como una nueva conexión a SQL---\\
       //public string CadenaCNX = "Data Source=.\\SQLEXPRESS; Initial Catalog=LumiPrint; Integrated Security=True";//--- Se crea un conector de valor string---\\
               public string CadenaCNX = "Data Source=.; Initial Catalog=LumiPrint; Integrated Security=True";
        public SqlConnection Conectar()//---Se realiza el metodo que será usado para Conectar SQL en todo el sistema---\\
        {
            try //---Trata de hacer el proceso, si este no es posible o arroja algun error---\\
            {
                CNX.ConnectionString = CadenaCNX; //--- Se crea un conector de valor string---\\
                CNX.Open();//--- La variable CNX Abre la conexión ejecutando la CadenaCNX---\\
                return CNX; //---La variable CNX es retornada y se puede usar con los parametros ya establecidos---\\

            }
            catch//---Si el Try arroja un error, no detiene el programa si no hace el siguiente proceso---\\
            {
              
                //---Muestra un mensaje el cual advierte que no se hizo conexión---\\
                return CNX; //---La variable CNX es retornada sin ninguna asignación---\\
            }

        }
    }
    }
    

