using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasAlteradas", typeof(int));
                    var query = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.FechaCreacion, 
                        aseguradora.Usuario.IdUsuario, filasInsertadas);
                    if((int)filasInsertadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar la aseguradora";
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

        public static ML.Result UpdateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre, 
                        aseguradora.Usuario.IdUsuario, filasActualizadas);
                    if((int)filasActualizadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar la aseguradora";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdAseguradora)
        {
            ML.Aseguradora seguro = new ML.Aseguradora();
            seguro.IdAseguradora = IdAseguradora;
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.AseguradoraDelete(seguro.IdAseguradora, filasEliminadas);

                    if ((int)filasEliminadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el objecto correctamente";
                    }
                }
            } catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
            {
                var query = context.AseguradoraGetAll();
                if(query != null)
                {
                    result.Objects = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = item.IdAseguradora;
                        aseguradora.Nombre = item.Nombre;
                        aseguradora.FechaCreacion = Convert.ToDateTime(item.FechaCreacion);
                        aseguradora.FechaModificacion = Convert.ToDateTime(item.FechaModificacion);
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = item.IdUsuario;
                        aseguradora.Usuario.Nombre = item.NombreUsuario;
                        aseguradora.Usuario.ApellidoPaterno = item.ApellidoPaterno;

                        result.Objects.Add(aseguradora);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No hay registros en la tabla";
                }
                return result;
            }
        }

        public static ML.Result GetByIdEF(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
            {
                ML.Aseguradora aseguradora = new ML.Aseguradora();
                aseguradora.IdAseguradora = IdAseguradora;
                var query = context.AseguradoraGetById(aseguradora.IdAseguradora);
                if(query != null)
                {
                    result.Object = new object();
                    foreach(var index in query)
                    {
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.IdAseguradora = index.IdAseguradora;
                        aseguradora.Nombre = index.Nombre;
                        aseguradora.FechaCreacion = Convert.ToDateTime(index.FechaCreacion);
                        aseguradora.FechaModificacion = Convert.ToDateTime(index.FechaModificacion);
                        aseguradora.Usuario.IdUsuario = index.IdUsuario;
                        aseguradora.Usuario.Nombre = index.NombreUsuario;
                        aseguradora.Usuario.ApellidoPaterno = index.ApellidoPaterno;

                        result.Object = index;
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se ha encontrado la aseguradora";
                }
                return result;
            }
    
        }
    }
}
