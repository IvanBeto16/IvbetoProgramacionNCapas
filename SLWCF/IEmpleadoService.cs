using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmpleadoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpleadoService
    {
        [OperationContract]
        SLWCF.Result Add(ML.Empleado empleado);
        [OperationContract]
        SLWCF.Result Update(ML.Empleado empleado);
        [OperationContract]
        SLWCF.Result Delete(string numeroEmpleado);
        [OperationContract]
        SLWCF.Result GetAll(ML.Empleado empleado);
        [OperationContract]
        SLWCF.Result GetById(string numeroEmpleado);
    }
}
