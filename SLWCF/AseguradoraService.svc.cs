using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AseguradoraService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AseguradoraService.svc o AseguradoraService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AseguradoraService : IAseguradoraService
    {
        public SLWCF.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.AddEF(aseguradora);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
            };
        }

        public SLWCF.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }

        public SLWCF.Result Delete(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(idAseguradora);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllEF();
            return new SLWCF.Result
            {
                Objects = result.Objects,
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex
            };
        }

        public SLWCF.Result GetById(int idAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetByIdEF(idAseguradora);
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
