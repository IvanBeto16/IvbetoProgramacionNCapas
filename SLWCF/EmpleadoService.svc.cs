using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.PeerResolvers;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmpleadoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EmpleadoService.svc o EmpleadoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmpleadoService : IEmpleadoService
    {
        public SLWCF.Result Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.AddEF(empleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }

        public SLWCF.Result Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.UpdateEF(empleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }

        public SLWCF.Result Delete(string numeroEmpleado)
        {
            ML.Result result = BL.Empleado.DeleteEF(numeroEmpleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetAll(ML.Empleado empleado)
        {
            empleado.Empresa = new ML.Empresa();
            empleado.Nombre = "";
            empleado.Empresa.IdEmpresa = 0;
            ML.Result result = BL.Empleado.GetAllEF(empleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                Objects = result.Objects,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetById(string numeroEmpleado)
        {
            ML.Result result = BL.Empleado.GetByIdEF(numeroEmpleado);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                Object = result.Object,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }
    }
}
