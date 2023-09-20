using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public Pais()
        {

        }
        //Para obtener todos los paises disponibles en la base
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    var comando = context.PaisGetAll().ToList();
                    if(comando != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var pais in comando)
                        {
                            ML.Pais paises = new ML.Pais(pais.IdPais, pais.Nombre);
                            result.Objects.Add(paises);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                } //hora de comida

            }catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }
}
