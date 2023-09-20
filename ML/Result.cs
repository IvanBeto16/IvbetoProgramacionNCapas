using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public string ErrorMessage { get; set; } //Guarda y Manda un mensaje de error
        public bool Correct { get; set; } //Saber si funciona o no
        public object Object { get; set; } //Permite almacenar un objeto
        public List<object> Objects { get; set; } //Lista que permite guardar muchos objetos
        public Exception Ex { get; set; } //Almacena una excepecion completa
    }
}
