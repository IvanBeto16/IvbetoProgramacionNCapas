using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioService
    {
        
        [OperationContract]
        SLWCF.Result Add(ML.Usuario usuario);
        [OperationContract]
        SLWCF.Result Update(ML.Usuario usuario);
        [OperationContract]
        SLWCF.Result Delete(int idUsuario);
        [OperationContract]
        SLWCF.Result GetAll(ML.Usuario usuario);
        [OperationContract]
        SLWCF.Result GetById(int idUsuario);
    }
}
