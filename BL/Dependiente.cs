using DLEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace BL
{
    public class Dependiente
    {

        public static ML.Result GetById(int idDependiente)
        {
            ML.Result result = new ML.Result();
            using(IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
            {
                ML.Dependiente dependiente = new ML.Dependiente();
                dependiente.IdDependiente = idDependiente;
                var query = context.DependienteGetById(dependiente.IdDependiente);

                if(query != null)
                {
                    result.Object = new object();
                    foreach(var item in query)
                    {
                        ML.Dependiente aux = new ML.Dependiente();
                        aux.Empleado = new ML.Empleado();

                        aux.IdDependiente = item.IdDependiente;
                        aux.Nombre = item.Nombre;
                        aux.ApellidoPaterno = item.ApellidoPaterno;
                        aux.ApellidoMaterno = item.ApellidoMaterno;
                        aux.FechaNacimiento = Convert.ToDateTime(item.FechaNacimiento);
                        aux.Telefono = item.Telefono;
                        aux.Genero = item.Genero;
                        aux.EstadoCivil = item.EstadoCivil;
                        aux.RFC = item.RFC;
                        aux.Empleado.NumeroEmpleado = item.NumeroEmpleado;
                        aux.Empleado.Nombre = item.NombreEmpleado;
                        aux.Empleado.ApellidoPaterno = item.ApellidoPaternoEmpleado;
                        aux.Empleado.ApellidoMaterno = item.ApellidoMaternoEmpleado;

                        result.Object = aux;
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró al dependiente";
                }
                return result;
            }
        }


        public static ML.Result GetByIdEmpleado(string numeroempleado)
        {
            ML.Result result = new ML.Result();
            using (IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
            {
                ML.Dependiente empleado = new ML.Dependiente();
                empleado.Empleado = new ML.Empleado();
                empleado.Empleado.NumeroEmpleado = numeroempleado;
                var query = context.DependienteGetByIdEmpleado(empleado.Empleado.NumeroEmpleado).ToList();

                if(query != null)
                {
                    result.Objects = new List<object>();
                    foreach(var item in query)
                    {
                        ML.Dependiente auxiliar = new ML.Dependiente();
                        auxiliar.Empleado = new ML.Empleado();

                        auxiliar.IdDependiente = item.IdDependiente;
                        auxiliar.Nombre = item.Nombre;
                        auxiliar.ApellidoPaterno = item.ApellidoPaterno;
                        auxiliar.ApellidoMaterno = item.ApellidoMaterno;
                        auxiliar.FechaNacimiento = Convert.ToDateTime(item.FechaNacimiento);
                        auxiliar.Telefono = item.Telefono;
                        auxiliar.EstadoCivil = item.EstadoCivil;
                        auxiliar.RFC = item.RFC;
                        auxiliar.Genero = item.Genero;
                        auxiliar.Empleado.NumeroEmpleado = item.NumeroEmpleado;
                        auxiliar.Empleado.Nombre = item.NombreEmpleado;
                        auxiliar.Empleado.ApellidoPaterno = item.ApellidoPaternoEmpleado;
                        auxiliar.Empleado.ApellidoMaterno = item.ApellidoMaternoEmpleado;

                        result.Objects.Add(auxiliar);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encuentra el dependiente o el Empleado no tiene dependientes";
                }
                return result;
            }
        }

        public static ML.Result AddEF(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.DependienteAdd(dependiente.Empleado.NumeroEmpleado, dependiente.Nombre,
                        dependiente.ApellidoPaterno, dependiente.ApellidoMaterno, dependiente.FechaNacimiento,
                        dependiente.EstadoCivil, dependiente.Genero, dependiente.Telefono,
                        dependiente.RFC, filasInsertadas);
                    if((int)filasInsertadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar el dependiente";
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

        public static ML.Result UpdateEF(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.DependienteUpdate(dependiente.IdDependiente,dependiente.Nombre,dependiente.ApellidoPaterno,
                        dependiente.ApellidoMaterno,dependiente.FechaNacimiento,dependiente.EstadoCivil,dependiente.Genero,
                        dependiente.Telefono,dependiente.RFC,filasActualizadas);

                    if ((int)filasActualizadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el usuario";
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


        public static ML.Result DeleteEF(int idDependiente)
        {
            ML.Dependiente dependiente = new ML.Dependiente();
            dependiente.IdDependiente = idDependiente;
            ML.Result result = new ML.Result();
            try
            {
                using (IvbetoProgramacionNCapasEntities context = new IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.DependienteDelete(dependiente.IdDependiente, filasEliminadas);

                    if ((int)filasEliminadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar al dependiente. Ocurrio un error";
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
