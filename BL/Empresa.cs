using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    var comando = context.EmpresaGetAll();
                    if (comando != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var empresa in comando)
                        {
                            ML.Empresa enterprice = new ML.Empresa();
                            enterprice.IdEmpresa = empresa.IdEmpresa;
                            enterprice.Nombre = empresa.Nombre;
                            enterprice.Telefono = empresa.Telefono;
                            result.Objects.Add(enterprice);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                } //hora de comida

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }
}
