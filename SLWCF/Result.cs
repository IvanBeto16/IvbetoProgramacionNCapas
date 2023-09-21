using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SLWCF
{
    [DataContract]
    //[KnownType(typeof(ML.Empleado))]
    //[KnownType(typeof(ML.Aseguradora))]
    public class Result
    {
        [DataMember]
        public string ErrorMessage { get; set; } //Guarda y Manda un mensaje de error
        [DataMember]
        public bool Correct { get; set; } //Saber si funciona o no
        [DataMember]
        public object Object { get; set; } //Permite almacenar un objeto
        [DataMember]
        public List<object> Objects { get; set; } //Lista que permite guardar muchos objetos
        [DataMember]
        public Exception Ex { get; set; } //Almacena una excepecion completa
    }
}