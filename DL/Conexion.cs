using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {

        //Traer la cadena de conexion
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IvbetoProgramacionNCapas"].ConnectionString.ToString();
        }
        

        
       
    }
}
