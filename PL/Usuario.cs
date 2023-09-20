using ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol(); //Haciendo referencia a la llave foranea en la tabla usuario
            ML.Result result = new ML.Result();

            Console.WriteLine("Agregar usuario");
            Console.WriteLine("Ingrese su UserName: ");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese su nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su Email: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese la contraseña para su usuario: ");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese su Genero (Sexo) con una letra M(Masculino) o F(Femenino): ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese su telefono de casa: ");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese su numero celular: ");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese su fecha de nacimiento: ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese su CURP: ");
            usuario.Curp = Console.ReadLine();
            Console.WriteLine("Ingrese el ID de su Rol: ");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());


            //Imprimimos el resultado de la insercion
            result = BL.Usuario.AddEF(usuario);
            if (result.Correct)
            {
                Console.WriteLine("Se ha agregado al usuario");
            }
            else
            {
                Console.WriteLine("Se produjo un error" + result.ErrorMessage);
            }
        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol(); //Haciendo referencia a la llave foranea en la tabla usuario
            ML.Result salida = new ML.Result();

            Console.WriteLine("ACTUALIZAR REGISTRO");
            Console.WriteLine("Ingrese el ID del usuario a modificar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo UserName del usuario: ");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo apellido paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo apellido materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo Email del usuario: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese su nueva contraseña: ");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo Genero(Sexo) del usuario M(Masculino) o F(Femenino): ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo telefono de hogar: ");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo numero celular: ");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrse la nueva fecha de nacimiento: ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo CURP: ");
            usuario.Curp = Console.ReadLine();
            Console.WriteLine("Ingrese el ID de su nuevo Rol: ");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            salida = BL.Usuario.UpdateEF(usuario);
            if (salida.Correct)
            {
                Console.WriteLine("Se ha actualizado al usuario");
            }
            else
            {
                Console.WriteLine("Se produjo un error" + salida.ErrorMessage);
            }
        }

        public static void GetAll()
        {
            Console.WriteLine("VISTA DE LA TABLA");
            ML.Usuario aux = new ML.Usuario();
            aux.Nombre = "";
            aux.ApellidoPaterno = "";
            ML.Result result = BL.Usuario.GetAllEF(aux);
            if (result.Correct)
            {
                //Unboxing
                foreach(ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine("ID: " + usuario.IdUsuario);
                    Console.WriteLine("UserName: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Password: " + usuario.Password);
                    Console.WriteLine("Sexo (Genero): " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Numero Celular: " + usuario.Celular);
                    Console.WriteLine("Fecha Nacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("CURP: " + usuario.Curp);
                    Console.WriteLine("Rol: " + usuario.Rol.IdRol);
                    Console.WriteLine("Nombre Rol: " + usuario.Rol.Nombre);
                    Console.WriteLine("****************************");
                }
            }
            else
            {
                Console.WriteLine("Error " + result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("VISTA POR USUARIO");
            Console.WriteLine("Ingrese el ID del usuario que desea consultar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result consulta = BL.Usuario.GetByIdEF(usuario.IdUsuario);
            if (consulta.Correct)
            {
                //Unboxing
                usuario = (ML.Usuario)consulta.Object;
                Console.WriteLine("****************************");
                Console.WriteLine("ID: " + usuario.IdUsuario);
                Console.WriteLine("UserName: " + usuario.UserName);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Password: " + usuario.Password);
                Console.WriteLine("Sexo (Genero): " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Numero Celular: " + usuario.Celular);
                Console.WriteLine("Fecha Nacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("CURP: " + usuario.Curp);
                Console.WriteLine("Rol: " + usuario.Rol.IdRol);
                Console.WriteLine("Nombre Rol: " + usuario.Rol.Nombre);
                Console.WriteLine("****************************");
            }
            else
            {
                Console.WriteLine("Error " + consulta.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultado = new ML.Result();
            Console.WriteLine("Eliminacion de un usuario");
            Console.WriteLine("Ingrese el ID del usuario que desea eliminar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            resultado = BL.Usuario.DeleteEF(usuario.IdUsuario);
            if (resultado.Correct)
            {
                Console.WriteLine("Se ha eliminado el usuario exitosamente");
            }
            else
            {
                Console.WriteLine("Se produjo un error" + resultado.ErrorMessage);
            }
        }



        //Carga Masiva
        public static void CargaMasivaTxt()
        {

            string archivo = @"C:\Users\ALIEN 70\Documents\Ivan_Alejandro_Beto_Perez\IvbetoProgramacionNCapas\PL_MVC\Files\CargaMasiva.txt";
            if (File.Exists(archivo))
            {
                StreamReader textReader = new StreamReader(archivo);
                string line = textReader.ReadLine(); //Lee la primera linea, de los headers y la salta

                while((line = textReader.ReadLine()) != null)
                {
                    string[] fila = line.Split('|');
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.Rol = new ML.Rol();
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();

                    usuario.UserName = fila[0];
                    usuario.Nombre = fila[1];
                    usuario.ApellidoPaterno = fila[2];
                    usuario.ApellidoMaterno = fila[3];
                    usuario.Email = fila[4];
                    usuario.FechaNacimiento = Convert.ToDateTime(fila[5]);
                    usuario.Password = fila[6];
                    usuario.Telefono = fila[7];
                    usuario.Celular = fila[8];
                    usuario.Curp = fila[9];
                    usuario.Sexo = fila[10];
                    usuario.Rol.IdRol = Convert.ToInt32(fila[11]);
                    if (fila[12] == "null")
                    {
                        fila[12] = null;
                        usuario.Imagen = fila[12];
                    }
                    usuario.Direccion.Calle = fila[13];
                    usuario.Direccion.NumeroInterior = fila[14];
                    usuario.Direccion.NumeroExterior = fila[15];
                    usuario.Direccion.Colonia.IdColonia = Convert.ToInt32(fila[16]);

                    BL.Usuario.AddEF(usuario);
                    Console.WriteLine("Se ha insertado un usuario exitosamente");
                }
            }
        }
    }
}
