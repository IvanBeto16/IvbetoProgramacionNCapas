using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public Municipio() { }

        public static ML.Result GetByIdEstado(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    var comando = context.MunicipioGetByIdEstado(id);
                    if (comando != null)
                    {
                        
                        result.Objects = new List<object>();
                        foreach(var item in comando)
                        {
                            ML.Municipio municipio = new ML.Municipio();
                            municipio.IdMunicipio = item.IdMunicipio;
                            municipio.Nombre = item.Nombre;
                            
                            result.Objects.Add(item);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
    }
}
