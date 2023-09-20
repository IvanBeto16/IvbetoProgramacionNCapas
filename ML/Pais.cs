using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pais
    {
        public int? IdPais { get; set; }
        public string Nombre { get; set;}

        public List<object> Paises { get; set; }

        public Pais()
        {

        }

        public Pais(int idPais, string nombre)
        {
            IdPais = idPais;
            Nombre = nombre;
        }
    }
}
