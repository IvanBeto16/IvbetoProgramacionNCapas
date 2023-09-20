using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
            {
                var query = context.RolGetAll().ToList();
                if (query != null)
                {
                    result.Objects = new List<object>();
                    foreach (var registro in query)
                    {
                        ML.Rol roles = new ML.Rol();
                        roles.IdRol = registro.IdRol;
                        roles.Nombre = registro.Nombre;
                    
                        result.Objects.Add(roles);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "La tabla esta vacia";
                }
                return result;
            }


        }
    }
}
