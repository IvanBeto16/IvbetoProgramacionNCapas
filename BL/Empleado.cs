using DLEF;
using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAllEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
            {
                var query = context.EmpleadoGetAll(empleado.Empresa.IdEmpresa, empleado.Nombre);
                if (query != null)
                {
                    result.Objects = new List<object>();
                    foreach (var registro in query)
                    {
                        ML.Empleado auxiliar = new ML.Empleado();
                        auxiliar.Empresa = new ML.Empresa();

                        auxiliar.NumeroEmpleado = registro.NumeroEmpleado;
                        auxiliar.Foto = registro.Foto;
                        auxiliar.RFC = registro.RFC;
                        auxiliar.Nombre = registro.Nombre;
                        auxiliar.ApellidoPaterno = registro.ApellidoPaterno;
                        auxiliar.ApellidoMaterno = registro.ApellidoMaterno;
                        auxiliar.Email = registro.Email;
                        auxiliar.Telefono = registro.Telefono;
                        auxiliar.FechaNacimiento = Convert.ToDateTime(registro.FechaNacimiento);
                        auxiliar.NSS = registro.NSS;
                        auxiliar.FechaIngreso = Convert.ToDateTime(registro.FechaIngreso);
                        auxiliar.Empresa.IdEmpresa = registro.IdEmpresa;
                        auxiliar.Empresa.Nombre = registro.NombreEmpresa;


                        result.Objects.Add(auxiliar);
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


        public static ML.Result GetByIdEF(string numeroEmpleado)
        {
            ML.Result result = new ML.Result();
            using (IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
            {
                ML.Empleado empleado = new ML.Empleado();
                empleado.NumeroEmpleado = numeroEmpleado;
                var query = context.EmpleadoGetById(empleado.NumeroEmpleado);

                if (query != null)
                {
                    result.Object = new object();
                    foreach (var entity in query)
                    {
                        empleado.Empresa = new ML.Empresa();

                        empleado.NumeroEmpleado = entity.NumeroEmpleado;
                        empleado.Nombre = entity.Nombre;
                        empleado.ApellidoPaterno = entity.ApellidoPaterno;
                        empleado.ApellidoMaterno = entity.ApellidoMaterno;
                        empleado.Telefono = entity.Telefono;
                        empleado.FechaNacimiento = Convert.ToDateTime(entity.FechaNacimiento);
                        empleado.Email = entity.Email;
                        empleado.RFC = entity.RFC;
                        empleado.FechaIngreso = Convert.ToDateTime(entity.FechaIngreso);
                        empleado.Foto = entity.Foto;
                        empleado.NSS = entity.NSS;
                        empleado.Empresa.IdEmpresa = entity.IdEmpresa;

                        result.Object = empleado;
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encuentra al empleado en la tabla";
                }
                return result;
            }
        }

        public static ML.Result AddEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.EmpleadoAdd(empleado.NumeroEmpleado, empleado.Nombre, empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno, empleado.Email, empleado.Telefono, empleado.RFC,
                        empleado.FechaNacimiento, empleado.NSS, empleado.Foto
                        , empleado.Empresa.IdEmpresa, filasInsertadas);

                    if ((int)filasInsertadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar al empleado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.EmpleadoUpdate(empleado.NumeroEmpleado,empleado.RFC,empleado.Nombre,
                        empleado.ApellidoPaterno,empleado.ApellidoMaterno,empleado.Email,empleado.Telefono,
                        empleado.FechaNacimiento,empleado.NSS,empleado.Foto,empleado.Empresa.IdEmpresa,filasActualizadas);

                    if((int)filasActualizadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el usuario";
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

        public static ML.Result DeleteEF(string numeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numeroEmpleado;
            ML.Result result = new ML.Result();

            try
            {
                using(IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.EmpleadoDelete(empleado.NumeroEmpleado, filasEliminadas);

                    if((int)filasEliminadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido eliminar al empleado";
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
    }

}
