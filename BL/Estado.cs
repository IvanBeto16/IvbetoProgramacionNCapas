using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public Estado()
        {

        }

        public static ML.Result GetByIdPais(int id)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    var query = context.EstadoGetByIdPais(id);
                    if(query != null)
                    {
                        
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = item.IdEstado;
                            estado.Nombre = item.Nombre;

                            result.Objects.Add(item);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
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
