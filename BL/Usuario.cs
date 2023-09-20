using Microsoft.Win32;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Objects;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //Metodos sin procedimientos almacenados
        //public static ML.Result Add(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        //todo lo que se ejecute en un using se libera al final
        //        using (SqlConnection connexion = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string cmd = "INSERT INTO USUARIO VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Direccion, @Nacionalidad, @EstadoCivil)";
        //            SqlCommand query = new SqlCommand(cmd, connexion);

        //            //Para reunir todos los parametros solicitados al usuario
        //            SqlParameter[] parametros = new SqlParameter[7];

        //            parametros[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            parametros[0].Value = usuario.Nombre;
        //            parametros[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            parametros[1].Value = usuario.ApellidoPaterno;
        //            parametros[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            parametros[2].Value = usuario.ApellidoMaterno;
        //            parametros[3] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
        //            parametros[3].Value = usuario.FechaNacimiento;
        //            parametros[4] = new SqlParameter("@Direccion", SqlDbType.VarChar);
        //            parametros[4].Value = usuario.Direccion;
        //            parametros[5] = new SqlParameter("@Nacionalidad", SqlDbType.VarChar);
        //            parametros[5].Value = usuario.Nacionalidad;
        //            parametros[6] = new SqlParameter("@EstadoCivil", SqlDbType.VarChar);
        //            parametros[6].Value = usuario.EstadoCivil;

        //            //Agregamos la coleccion de parametros
        //            query.Parameters.AddRange(parametros);
        //            //Abrimos la conexion con la base de datos
        //            query.Connection.Open();
        //            //Para ver el numero de inserciones, verificar que si inserte en la tabla
        //            int inserciones = query.ExecuteNonQuery();
        //            if (inserciones > 0)
        //            {
        //                ;
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se ha podido insertar al usuario";
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //resultado = ex.Message;
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result Update(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //Instruccion para cambiar una fila de la tabla
        //            string com = "UPDATE Usuario SET Nombre=@Nombre, ApellidoPaterno=@ApellidoPaterno, ApellidoMaterno=@ApellidoMaterno, FechaNacimiento=@FechaNacimiento, Direccion=@Direccion, Nacionalidad=@Nacionalidad, EstadoCivil=@EstadoCivil WHERE IdUsuario = @IdUsuario";
        //            SqlCommand comando = new SqlCommand(com, connection);

        //            SqlParameter[] param = new SqlParameter[8];

        //            param[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            param[0].Value = usuario.IdUsuario;
        //            param[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            param[1].Value = usuario.Nombre;
        //            param[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            param[2].Value = usuario.ApellidoPaterno;
        //            param[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            param[3].Value = usuario.ApellidoMaterno;
        //            param[4] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
        //            param[4].Value = usuario.FechaNacimiento;
        //            param[5] = new SqlParameter("@Direccion", SqlDbType.VarChar);
        //            param[5].Value = usuario.Direccion;
        //            param[6] = new SqlParameter("@Nacionalidad", SqlDbType.VarChar);
        //            param[6].Value = usuario.Nacionalidad;
        //            param[7] = new SqlParameter("@EstadoCivil", SqlDbType.VarChar);
        //            param[7].Value = usuario.EstadoCivil;

        //            comando.Parameters.AddRange(param);
        //            comando.Connection.Open();

        //            int cambios = comando.ExecuteNonQuery();
        //            if (cambios > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se ha actualizado el usuario";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}

        //public static ML.Result Delete(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string del = "DELETE FROM USUARIO WHERE IdUsuario = @IdUsuario";
        //            SqlCommand cmd = new SqlCommand(del, connection);

        //            SqlParameter[] param = new SqlParameter[1];

        //            param[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            param[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(param);
        //            cmd.Connection.Open();

        //            int eliminaciones = cmd.ExecuteNonQuery();
        //            if (eliminaciones > 0)
        //            {
        //                result.Correct = true;

        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se ha podido eliminar al usuario";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}

        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, " +
        //                "ApellidoMaterno, FechaNacimiento, Direccion, Nacionalidad, EstadoCivil FROM Usuario";
        //            SqlCommand cmd = new SqlCommand(query, conexion);

        //            //Uso del SQLAdapter en vez del Reader
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsu = new DataTable();
        //            adapter.Fill(tablaUsu);

        //            if (tablaUsu.Rows.Count > 0)
        //            {
        //                //Boxing
        //                result.Objects = new List<object>();
        //                foreach (DataRow row in tablaUsu.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.Nombre = row[1].ToString();
        //                    usuario.ApellidoPaterno = row[2].ToString();
        //                    usuario.ApellidoMaterno = row[3].ToString();
        //                    usuario.FechaNacimiento = Convert.ToDateTime(row[4]);
        //                    usuario.Direccion = row[5].ToString();
        //                    usuario.Nacionalidad = row[6].ToString();
        //                    usuario.EstadoCivil = row[7].ToString();

        //                    result.Objects.Add(usuario);

        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Se ha encontrado un error, no hay registros";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}

        //public static ML.Result GetById(ML.Usuario usuario)
        //{
        //    //Objeto final donde se almacena el resultado
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT IdUsuario,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Direccion,Nacionalidad,EstadoCivil FROM USUARIO WHERE IdUsuario = @IdUsuario";
        //            SqlCommand cmd = new SqlCommand(query, context);

        //            SqlParameter[] param = new SqlParameter[1];
        //            param[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            param[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(param);

        //            //Uso del SQLAdapter en vez del Reader
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsu = new DataTable();
        //            adapter.Fill(tablaUsu);
        //            if (tablaUsu.Rows.Count > 0)
        //            {
        //                DataRow fila = tablaUsu.Rows[0];

        //                ML.Usuario resultado = new ML.Usuario();
        //                resultado.IdUsuario = int.Parse(fila[0].ToString());
        //                resultado.Nombre = fila[1].ToString();
        //                resultado.ApellidoPaterno = fila[2].ToString();
        //                resultado.ApellidoMaterno = fila[3].ToString();
        //                resultado.FechaNacimiento = Convert.ToDateTime(fila[4]);
        //                resultado.Direccion = fila[5].ToString();
        //                resultado.Nacionalidad = fila[6].ToString();
        //                resultado.EstadoCivil = fila[7].ToString();

        //                //Boxing
        //                result.Object = resultado;
        //                result.Correct = true;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Correct = false;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //Metodos con procedimientos almacenados
        //public static ML.Result AddSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioAdd";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter[] param = new SqlParameter[8];
        //            param[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            param[0].Value = usuario.Nombre;
        //            param[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            param[1].Value = usuario.ApellidoPaterno;
        //            param[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            param[2].Value = usuario.ApellidoMaterno;
        //            param[3] = new SqlParameter("@FechaNacimiento", SqlDbType.DateTime);
        //            param[3].Value = usuario.FechaNacimiento;
        //            param[4] = new SqlParameter("@Direccion", SqlDbType.VarChar);
        //            param[4].Value = usuario.Direccion;
        //            param[5] = new SqlParameter("@Nacionalidad", SqlDbType.VarChar);
        //            param[5].Value = usuario.Nacionalidad;
        //            param[6] = new SqlParameter("@EstadoCivil", SqlDbType.VarChar);
        //            param[6].Value = usuario.EstadoCivil;
        //            param[7] = new SqlParameter("@IdRol", SqlDbType.Int);
        //            param[7].Value = usuario.Rol.IdRol;

        //            cmd.Parameters.AddRange(param);
        //            cmd.Connection.Open();

        //            int inserciones = cmd.ExecuteNonQuery();
        //            if (inserciones > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se pudo agregar el usuario";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result UpdateSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioUpdate";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter[] param = new SqlParameter[9];
        //            param[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            param[0].Value = usuario.IdUsuario;
        //            param[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            param[1].Value = usuario.Nombre;
        //            param[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            param[2].Value = usuario.ApellidoPaterno;
        //            param[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            param[3].Value = usuario.ApellidoMaterno;
        //            param[4] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
        //            param[4].Value = usuario.FechaNacimiento;
        //            param[5] = new SqlParameter("@Direccion", SqlDbType.VarChar);
        //            param[5].Value = usuario.Direccion;
        //            param[6] = new SqlParameter("@Nacionalidad", SqlDbType.VarChar);
        //            param[6].Value = usuario.Nacionalidad;
        //            param[7] = new SqlParameter("@EstadoCivil", SqlDbType.VarChar);
        //            param[7].Value = usuario.EstadoCivil;
        //            param[8] = new SqlParameter("@IdRol", SqlDbType.Int);
        //            param[8].Value = usuario.Rol.IdRol;

        //            cmd.Parameters.AddRange(param);
        //            cmd.Connection.Open();

        //            int actualizaciones = cmd.ExecuteNonQuery();
        //            if (actualizaciones > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se puede actualizar al usuario";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Correct = false;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result DeleteSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioDelete";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter[] param = new SqlParameter[1];
        //            param[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            param[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.Add(param);
        //            cmd.Connection.Open();

        //            int eliminaciones = cmd.ExecuteNonQuery();
        //            if (eliminaciones > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se ha podido eliminar al usuario";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}

        //public static ML.Result GetAllSP()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioGetAll";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            //Uso del DataAdapter
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuario = new DataTable();
        //            adapter.Fill(tablaUsuario);

        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                //Proceso de Boxing
        //                result.Objects = new List<object>();
        //                foreach (DataRow row in tablaUsuario.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.Rol = new ML.Rol(); //Llamando al objeto Rol para guardar la llave foranea
        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.Nombre = row[1].ToString();
        //                    usuario.ApellidoPaterno = row[2].ToString();
        //                    usuario.ApellidoMaterno = row[3].ToString();
        //                    usuario.FechaNacimiento = Convert.ToDateTime(row[4]);
        //                    usuario.Direccion = row[5].ToString();
        //                    usuario.Nacionalidad = row[6].ToString();
        //                    usuario.EstadoCivil = row[7].ToString();
        //                    usuario.Rol.IdRol = int.Parse(row[8].ToString());

        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No hay nada en esta tabla";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result GetByIdSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioGetById";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter[] param = new SqlParameter[1];
        //            param[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            param[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(param);

        //            //Uso del SQLAdapter en vez del Reader
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsu = new DataTable();
        //            adapter.Fill(tablaUsu);
        //            if (tablaUsu.Rows.Count > 0)
        //            {
        //                DataRow fila = tablaUsu.Rows[0];

        //                ML.Usuario resultado = new ML.Usuario();
        //                resultado.Rol = new ML.Rol();
        //                resultado.IdUsuario = int.Parse(fila[0].ToString());
        //                resultado.Nombre = fila[1].ToString();
        //                resultado.ApellidoPaterno = fila[2].ToString();
        //                resultado.ApellidoMaterno = fila[3].ToString();
        //                resultado.FechaNacimiento = Convert.ToDateTime(fila[4]);
        //                resultado.Direccion = fila[5].ToString();
        //                resultado.Nacionalidad = fila[6].ToString();
        //                resultado.EstadoCivil = fila[7].ToString();
        //                resultado.Rol.IdRol = int.Parse(fila[8].ToString());
        //                resultado.Rol.Nombre = fila[9].ToString();

        //                //Boxing
        //                result.Object = resultado;
        //                result.Correct = true;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //Metodos para ENTITY FRAMEWORK
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("filasAlteradas", typeof(int));
                    var rowAffected = context.UsuarioAdd(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Email, usuario.Password,
                        usuario.Telefono, usuario.Celular, usuario.Curp, usuario.Sexo,
                        usuario.Rol.IdRol, usuario.UserName, usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia, usuario.Imagen, filasAfectadas);

                    if ((int)filasAfectadas.Value > 0)
                    //if (rowAffected != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se agrego el usuario";
                    }
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasalteradas", typeof(int));
                    var actualizado = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                        usuario.FechaNacimiento, usuario.Email, usuario.Password, usuario.Telefono, usuario.Celular,
                        usuario.Curp, usuario.Sexo, usuario.Rol.IdRol, usuario.UserName, usuario.Direccion.Calle,
                        usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia,
                        usuario.Imagen, filasActualizadas);

                    if ((int)filasActualizadas.Value > 0)
                    //if (actualizado != null)
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
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
            {
                var query = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno).ToList();
                if (query != null)
                {
                    result.Objects = new List<object>();
                    foreach (var registro in query)
                    {
                        ML.Usuario objeto = new ML.Usuario();
                        objeto.Rol = new ML.Rol();
                        objeto.Direccion = new ML.Direccion();
                        objeto.Direccion.Colonia = new ML.Colonia();
                        objeto.Direccion.Colonia.Municipio = new ML.Municipio();
                        objeto.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        objeto.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                        objeto.IdUsuario = registro.IdUsuario;
                        objeto.Status = registro.Status;
                        objeto.UserName = registro.UserName;
                        objeto.Imagen = registro.Imagen;
                        objeto.Nombre = registro.Nombre;
                        objeto.ApellidoPaterno = registro.ApellidoPaterno;
                        objeto.ApellidoMaterno = registro.ApellidoMaterno;
                        objeto.Email = registro.Email;
                        objeto.Password = registro.Password;
                        objeto.Sexo = registro.Sexo;
                        objeto.Telefono = registro.Telefono;
                        objeto.Celular = registro.Celular;
                        objeto.FechaNacimiento = Convert.ToDateTime(registro.FechaNacimiento);
                        objeto.Curp = registro.Curp;
                        objeto.Rol = new ML.Rol();
                        objeto.Rol.IdRol = registro.IdRol;
                        objeto.Rol.Nombre = registro.NombreRol;
                        objeto.Direccion.IdDireccion = registro.IdDireccion;
                        objeto.Direccion.Calle = registro.Calle;
                        objeto.Direccion.NumeroExterior = registro.NumeroExterior;
                        objeto.Direccion.NumeroInterior = registro.NumeroInterior;
                        objeto.Direccion.Colonia.IdColonia = registro.IdColonia;
                        objeto.Direccion.Colonia.Nombre = registro.NombreColonia;
                        objeto.Direccion.Colonia.Municipio.IdMunicipio = registro.IdMunicipio;
                        objeto.Direccion.Colonia.Municipio.Nombre = registro.NombreMunicipio;
                        objeto.Direccion.Colonia.Municipio.Estado.IdEstado = registro.IdEstado;
                        objeto.Direccion.Colonia.Municipio.Estado.Nombre = registro.NombreEstado;
                        objeto.Direccion.Colonia.Municipio.Estado.Pais.IdPais = registro.IdPais;
                        objeto.Direccion.Colonia.Municipio.Estado.Pais.Nombre = registro.NombrePais;

                        result.Objects.Add(objeto);
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
        //Hacer que reciba un valor numero en lugar de un object
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario.IdUsuario = IdUsuario;
                var query = context.UsuarioGetById(usuario.IdUsuario);
                if (query != null)
                {
                    result.Object = new object();
                    foreach (var entity in query)
                    {
                        usuario.Rol = new ML.Rol();
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                        usuario.IdUsuario = entity.IdUsuario;
                        usuario.Status = entity.Status;
                        usuario.UserName = entity.UserName;
                        usuario.Imagen = entity.Imagen;
                        usuario.Nombre = entity.Nombre;
                        usuario.ApellidoPaterno = entity.ApellidoPaterno;
                        usuario.ApellidoMaterno = entity.ApellidoMaterno;
                        usuario.Email = entity.Email;
                        usuario.Password = entity.Password;
                        usuario.Sexo = entity.Sexo;
                        usuario.Telefono = entity.Telefono;
                        usuario.Celular = entity.Celular;
                        usuario.FechaNacimiento = Convert.ToDateTime(entity.FechaNacimiento);
                        usuario.Curp = entity.Curp;
                        usuario.Rol.IdRol = entity.IdRol;
                        usuario.Rol.Nombre = entity.NombreRol;
                        usuario.Direccion.IdDireccion = entity.IdDireccion;
                        usuario.Direccion.Calle = entity.Calle;
                        usuario.Direccion.NumeroExterior = entity.NumeroExterior;
                        usuario.Direccion.NumeroInterior = entity.NumeroInterior;
                        usuario.Direccion.Colonia.IdColonia = entity.IdColonia;
                        usuario.Direccion.Colonia.Nombre = entity.NombreColonia;
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = entity.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = entity.NombreMunicipio;
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = entity.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = entity.NombreEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = entity.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = entity.NombrePais;

                        result.Object = usuario;
                    }

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encuentra el usuario en la tabla";
                }
                return result;
            }
        }

        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var eliminados = context.UsuarioDelete(usuario.IdUsuario, filasEliminadas);

                    if ((int)filasEliminadas.Value > 0)
                    //if(eliminados != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar al usuario";
                    }
                }
            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result ChangeStatus(int IdUsuario, bool Status)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
                {
                    var rowsaffected = context.UsuarioChangeStatus(Status, IdUsuario);
                    if (rowsaffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            } catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Login(string email, string Password)
        {
            ML.Result result = new ML.Result();
            using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
            {
                try
                {
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.Email = email;
                    usuario.Password = Password;
                    var query = context.UsuarioLogin(usuario.Email, usuario.Password).ToList();
                    if (query.Count() > 0)
                    {
                        result.Object = new object();
                        foreach (var entidad in query)
                        {
                            //boxing
                            usuario.Email = entidad.Email;
                            usuario.Password = entidad.Password;

                            result.Object = usuario;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                    result.Ex = ex;
                }
            }
            return result;
        }


        //Para leer un archivo excel
        public static ML.Result LeerExcel(string connectionString)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Hoja1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        //Le pasamos el comando anterior y la conexion al cmd de OleDB
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableUsuario = new DataTable();
                        da.Fill(tableUsuario);
                        if(tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach(DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.Rol = new ML.Rol();
                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Colonia = new ML.Colonia();

                                usuario.UserName = row[0].ToString();
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaNacimiento = Convert.ToDateTime(row[4].ToString());
                                usuario.Email = row[5].ToString();
                                usuario.Password = row[6].ToString();
                                usuario.Telefono = row[7].ToString();
                                usuario.Celular = row[8].ToString();
                                usuario.Curp = row[9].ToString();
                                usuario.Sexo = row[10].ToString();
                                usuario.Rol.IdRol = int.Parse(row[11].ToString());
                                usuario.Imagen = row[12].ToString();
                                usuario.Direccion.Calle = row[13].ToString();
                                usuario.Direccion.NumeroInterior = row[14].ToString();
                                usuario.Direccion.NumeroExterior = row[15].ToString();
                                usuario.Direccion.Colonia.IdColonia = int.Parse(row[16].ToString());

                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                        result.Object = tableUsuario;
                        if(tableUsuario.Rows.Count > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }catch (Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        //Para validar el archivo que si sea excel
        public static ML.Result ValidarExcel(List<object> usuarios)
        {
            ML.Result result = new ML.Result();
            try
            {
                result.Objects = new List<object>(); //lista para los objetos incompletos
                int i = 1;
                foreach(ML.Usuario usuario in usuarios)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;

                    //Validaciones de los campos
                    if(usuario.UserName == "")
                    {
                        error.Mensaje += "Ingrese por favor un Nombre de Usuario ";
                    }
                    if(usuario.Nombre == "")
                    {
                        error.Mensaje += "Ingresar el nombre ";
                    }
                    if(usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Favor de ingresar el Apellido Paterno";
                    }
                    if(usuario.FechaNacimiento == null)
                    {
                        error.Mensaje += "Favor la Fecha de Nacimiento, no es imaginario ";
                    }
                    if(usuario.Email == "")
                    {
                        error.Mensaje += "Favor de ingresar el Correo Electronico, no está en la prehistoria ";
                    }
                    if(usuario.Password == "")
                    {
                        error.Mensaje += "Favor de ingresar una Contraseña, por su propia seguridad ";
                    }
                    if(usuario.Telefono == "")
                    {
                        error.Mensaje += "Favor de ingresar el Telefono de hogar, no vive en una caja ";
                    }
                    if(usuario.Celular == "")
                    {
                        error.Mensaje += "Favor de ingresar el Numero de Celular, no es pobre ";
                    }
                    if(usuario.Curp == "")
                    {
                        error.Mensaje += "Ingrese el CURP ";
                    }
                    if(usuario.Sexo == "")
                    {
                        error.Mensaje += "Ingrese su Genero por favor, que si existe en binarismo ";
                    }
                    if(usuario.Rol.IdRol == 0 || usuario.Rol.IdRol == null)
                    {
                        error.Mensaje += "Ingrese el rol en el sistema, sino, esta violando la seguridad ";
                    }
                    if(usuario.Direccion.Calle == "")
                    {
                        error.Mensaje = "Ingrese su direccion (Calle) correctamente";
                    }
                    if(usuario.Direccion.NumeroExterior == "")
                    {
                        error.Mensaje = "Ingrese su direccion (Numero Exterior) correctamente";
                    }
                    if(usuario.Direccion.NumeroInterior == "")
                    {
                        error.Mensaje = "Ingrese su direccion (Numero Interior) correctamente";
                    }
                    if(usuario.Direccion.Colonia.IdColonia == 0 || usuario.Direccion.Colonia.IdColonia == null)
                    {
                        error.Mensaje = "Ingrese su direccion (Id Colonia o Colonia) correctamente";
                    }


                    //validacion si hay cantidad de mensajes de errores
                    if(error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }
                }
                result.Correct = true;
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        //Metodos usando LINQ
        //public static ML.Result AddLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
        //        {
        //            DLEF.Usuario usu = new DLEF.Usuario();
        //            usu.IdUsuario = usuario.IdUsuario;
        //            usu.Nombre = usuario.Nombre;
        //            usu.ApellidoPaterno = usuario.ApellidoPaterno;
        //            usu.ApellidoMaterno = usuario.ApellidoMaterno;
        //            usu.FechaNacimiento = usuario.FechaNacimiento;
        //            usu.Direccion = usuario.Direccion;
        //            usu.Nacionalidad = usu.Nacionalidad;
        //            usu.EstadoCivil = usuario.EstadoCivil;
        //            usu.Rol.IdRol = usuario.Rol.IdRol.Value;

        //            context.Usuarios.Add(usu);
        //            context.SaveChanges();
        //            result.Correct = true;
        //        }
        //    }catch(Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Correct = false;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result UpdateLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
        //        {
        //            var query = (from i in context.Usuarios
        //                         where i.IdUsuario == usuario.IdUsuario
        //                         select i).SingleOrDefault();
        //            if(query != null)
        //            {
        //                query.IdUsuario = usuario.IdUsuario;
        //                query.Nombre = usuario.Nombre;
        //                query.ApellidoPaterno = usuario.ApellidoPaterno;
        //                query.ApellidoMaterno = usuario.ApellidoMaterno;
        //                query.FechaNacimiento = usuario.FechaNacimiento;
        //                query.Direccion = usuario.Direccion;
        //                query.Nacionalidad = usuario.Nacionalidad;
        //                query.EstadoCivil = usuario.EstadoCivil;
        //                query.IdRol = usuario.Rol.IdRol.Value;

        //                context.SaveChanges();
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se pudo actualizar el usuario";
        //            }
        //        }

        //    }catch( Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Correct = false;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result DeleteLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
        //        {
        //            var query = (from a in context.Usuarios
        //                         where a.IdUsuario == usuario.IdUsuario
        //                         select a).First();

        //            context.Usuarios.Remove(query);
        //            context.SaveChanges();
        //            result.Correct = true;
        //        }

        //    }catch(Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Correct = false;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result GetAllLINQ()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
        //        {
        //            var query = (from users in context.Usuarios
        //                         join roles in context.Rols on users.IdRol equals roles.IdRol
        //                         select new
        //                         {
        //                             IdUsuario = users.IdUsuario,
        //                             Nombre = users.Nombre,
        //                             ApellidoPaterno = users.ApellidoPaterno,
        //                             ApellidoMaterno = users.ApellidoMaterno,
        //                             FechaNacimiento = users.FechaNacimiento,
        //                             Direccion = users.Direccion,
        //                             Nacionalidad = users.Nacionalidad,
        //                             EstadoCivil = users.EstadoCivil,
        //                             IdRol = roles.IdRol,
        //                             NombreRol = roles.Nombre
        //                         }) ;

        //            result.Objects = new List<object>();
        //            if(query != null && query.ToList().Count > 0)
        //            {
        //                foreach(var obj in query)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = obj.IdUsuario;
        //                    usuario.Nombre = obj.Nombre;
        //                    usuario.ApellidoPaterno = obj.ApellidoPaterno;
        //                    usuario.ApellidoMaterno = obj.ApellidoMaterno;
        //                    usuario.FechaNacimiento = obj.FechaNacimiento;
        //                    usuario.Direccion = obj.Direccion;
        //                    usuario.Nacionalidad = obj.Nacionalidad;
        //                    usuario.EstadoCivil = obj.EstadoCivil;
        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol = obj.IdRol;
        //                    usuario.Rol.Nombre = obj.NombreRol;

        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se encontraron usuarios en la tabla";
        //            }
        //        }
        //    } catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Correct = false;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result GetByIdLINQ()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using(DLEF.IvbetoProgramacionNCapasEntities context = new DLEF.IvbetoProgramacionNCapasEntities())
        //        {
        //            var query = (from id in context.Usuarios
        //                         join usuarios in context.Usuarios on id.IdUsuario equals usuarios.IdUsuario
        //                         join roles in context.Rols on id.IdRol equals roles.IdRol
        //                         where id.IdUsuario == usuarios.IdUsuario
        //                         where id.IdRol == roles.IdRol
        //                         select new
        //                         {
        //                             IdUsuario = usuarios.IdUsuario,
        //                             Nombre = usuarios.Nombre,
        //                             ApellidoPaterno = usuarios.ApellidoPaterno,
        //                             ApellidoMaterno = usuarios.ApellidoMaterno,
        //                             FechaNacimiento = usuarios.FechaNacimiento,
        //                             Direccion = usuarios.Direccion,
        //                             Nacionalidad = usuarios.Nacionalidad,
        //                             EstadoCivil = usuarios.EstadoCivil,
        //                             IdRol = roles.IdRol,
        //                             NombreRol = roles.Nombre
        //                         });
        //            result.Object = new Object();
        //            if(query != null && query.ToList().Count > 0)
        //            {
        //                foreach(var item in query)
        //                {
        //                    ML.Usuario usu = new ML.Usuario();
        //                    usu.Rol = new ML.Rol();
        //                    usu.IdUsuario = item.IdUsuario;
        //                    usu.Nombre = item.Nombre;
        //                    usu.ApellidoPaterno = item.ApellidoPaterno;
        //                    usu.ApellidoMaterno = item.ApellidoMaterno;
        //                    usu.FechaNacimiento = item.FechaNacimiento;
        //                    usu.Direccion = item.Direccion;
        //                    usu.Nacionalidad = item.Nacionalidad;
        //                    usu.EstadoCivil = item.EstadoCivil;
        //                    usu.Rol.IdRol = item.IdRol;
        //                    usu.Rol.Nombre = item.NombreRol;

        //                    result.Object = usu;
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se encontro al usuario en la tabla";
        //            }
        //        }

        //    }catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}


        //Version propia del metodo
        //public static string GetAll(ML.Usuario usuario)
        //{
        //    string salida = "";
        //    try
        //    {
        //        using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT * FROM USUARIO";
        //            SqlCommand comando2 = new SqlCommand(query, conexion);

        //            comando2.Connection.Open();
        //            SqlDataReader reader = comando2.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Console.WriteLine("ID: {0} Nombre: {1} Apellido Paterno: {2} Apellido Materno: {3} Fecha Nacimiento: {4} Direccion: {5} Nacionalidad: {6} Estado Civil: {7}"
        //                    ,reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetDateTime(4),reader.GetString(5), reader.GetString(6),reader.GetString(7));
        //            }
        //        }

        //    }catch(Exception ex)
        //    {
        //        salida = ex.Message;
        //    }
        //    return salida;
        //}

        //Version oficial del metodo


        //Version propia del metodo
        //public static string GetByID(ML.Usuario usuario)
        //{
        //    string consulta = "";
        //    try
        //    {
        //        using(SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT * FROM USUARIO WHERE IdUsuario = @IdUsuario";
        //            SqlCommand cmd = new SqlCommand(query, conexion);

        //            SqlParameter[] parametros = new SqlParameter[1];

        //            parametros[0] = new SqlParameter("@IdUsuario", SqlDbType.VarChar);
        //            parametros[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(parametros);
        //            cmd.Connection.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Console.WriteLine("ID: {0} Nombre: {1} Apellido Paterno: {2} Apellido Materno: {3} Fecha Nacimiento: {4} Direccion: {5} Nacionalidad: {6} Estado Civil: {7}"
        //                    , reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
        //            }

        //        }
        //    }catch(Exception ex)
        //    {
        //        consulta = ex.Message;
        //    }
        //    return consulta;
        //}


    }

}