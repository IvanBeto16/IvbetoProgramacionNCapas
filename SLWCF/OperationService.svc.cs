using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "OperationService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione OperationService.svc o OperationService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OperationService : IOperationService
    {
        public void DoWork()
        {
        }

        public int Divide(int x, int y)
        {
            return x/y;
        }

        public int Multiply(int x, int y)
        {
            return x*y;
        }

        public int Restar(int a, int b)
        {
            return a-b;
        }

        public int Sumar(int a, int b)
        {
            return a+b;
        }
    }
}
