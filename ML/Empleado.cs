using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public string NumeroEmpleado { get; set; }
        public string RFC { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NSS { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Foto { get; set; }

        public List<object> Empleados { get; set; }

        //Propiedad de Navegacion
        public ML.Empresa Empresa { get; set; }

        //Propiedad de bandera
        public string Accion { get; set; }
    }
}
