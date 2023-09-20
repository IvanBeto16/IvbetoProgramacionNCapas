using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public Colonia() { }

        public static ML.Result GetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(idMunicipio);
                    if(query != null)
                    {
                        
                        result.Objects = new List<object>();
                        foreach(var entity in query)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.IdColonia = entity.IdColonia;
                            colonia.Nombre = entity.Nombre;
                            colonia.CodigoPostal = entity.CodigoPostal;

                            result.Objects.Add(colonia);
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
                result.Correct =false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
