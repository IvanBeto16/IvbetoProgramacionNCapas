using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAseguradoraService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAseguradoraService
    {
        [OperationContract]
        SLWCF.Result Add(ML.Aseguradora aseguradora);
        [OperationContract]
        SLWCF.Result Update(ML.Aseguradora aseguradora);
        [OperationContract]
        SLWCF.Result Delete(int idAseguradora);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SLWCF.Result GetById(int idAseguradora);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SLWCF.Result GetAll();
    }
}
