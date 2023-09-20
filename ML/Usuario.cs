using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        
        public int IdUsuario { get; set; }
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Se necesita llenar este campo")]
        [Display(Name = "Nombre(s)")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Se necesita llenar este campo")]
        [Display(Name = "Apellido Paterno")]
        [StringLength(50)]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [StringLength(50)]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Correo Electronico")]
        [EmailAddress(ErrorMessage = "Formato de correo no valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public string Sexo { get; set; }
        [StringLength(20, ErrorMessage = "No debe pasar de 20 digitos")]
        [Phone]
        public string Telefono { get; set; }
        [StringLength(20, ErrorMessage = "No debe pasar de 20 digitos")]
        [Phone]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Se necesita llenar este campo")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Curp { get; set; }
        public string Imagen { get; set; }
        public bool Status { get; set; }
        public List<object> Usuarios { get; set; }


        //Propiedades de Navegacion (para llaves foraneas)
        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }



    }
}
