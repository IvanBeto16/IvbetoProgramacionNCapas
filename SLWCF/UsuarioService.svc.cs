using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioService.svc o UsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : IUsuarioService
    {
        public SLWCF.Result Add(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);
            //SLWCF.Result resultService = new SLWCF.Result();
            //resultService.Correct = result.Correct;
            //return resultService;
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
            };

        }

        public SLWCF.Result Update(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEF(usuario);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
            };
        }
        

        public SLWCF.Result Delete(int idUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(idUsuario);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
            };
        }

        public SLWCF.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
            };
        }

        public SLWCF.Result GetById(int iduUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEF(iduUsuario);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
            };
        }
    }
}
