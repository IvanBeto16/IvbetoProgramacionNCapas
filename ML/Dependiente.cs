using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Dependiente
    {
        public int IdDependiente { get; set; }
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
        [Display(Name = "Registro Federal del Contribuyente (RFC)")]
        public string RFC { get; set; }
        public List<object> Dependientes { get; set; }

        //Propiedad de Navegacion
        public ML.Empleado Empleado { get; set; }

        //Bandera
        public string Accion { get; set; }
    }
}
