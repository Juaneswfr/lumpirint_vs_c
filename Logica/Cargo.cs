//---Se llaman las librerias que serán usadas---\\
using System;//---Contiene clases fundamentales y clases base que definen tipos de datos de referencia y de valor de uso frecuente, eventos y controladores de eventos, interfaces, atributos y excepciones de procesamiento---\\
using System.Collections.Generic;  //---Contiene interfaces y clases que definen colecciones genéricas---\\
using System.Linq; //---Proporciona clases e interfaces que admiten consultas que utilizan Language-integrated query---\\
using System.Text; //--- contiene clases que representan codificaciones de caracteres ASCII y Unicode; clases base abstractas para convertir bloques de caracteres a y desde bloques de bytes y una clase auxiliar que manipula y da formato a objetos String sin crear instancias intermedias de String---\\
using System.Data; //---Contienen clases para tener acceso a datos y administrarlos desde distintos orígenes---\\
using System.Data.SqlClient; //---Proveedor de datos .NET Framework para SQL Server---\\
using Datos; //---La capa usada para la clase será la capa Datos---\\

namespace Logica
{
    //---Se crean la clase Cargo lo cual será publica en el sistema---\\
   public class Cargo
    {
        public TipoCargo Nombre_cargo { get; set; }//---El atributo Nombre_cargo se denomina String con enumeración---\\
        public string Descripcion_cargo { get; set; }//---El atributo Descripcion_cargo se denomina String---\\
        public long Salario_cargo { get; set; }//---El atributo Salario_cargo se denomina long---\\
        }
    }
