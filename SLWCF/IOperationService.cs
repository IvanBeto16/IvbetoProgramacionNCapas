using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOperationService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOperationService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        int Sumar(int a, int b);
        [OperationContract]
        int Restar(int a , int b);
        [OperationContract]
        int Multiply(int x, int y);
        [OperationContract]
        int Divide(int x, int y);
    }
}
