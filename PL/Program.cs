using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int opcion;
            do
            {
                Console.WriteLine("\nProyecto de prueba de conexiones a base de datos");
                Console.WriteLine("Teclee el numero de la opcion que desea realizar: ");
                Console.WriteLine("1)Agregar usuario\n2)Modificar Usuario\n3)Mostrar tabla\n4)Mostrar usuario\n5)Eliminar Usuario\n6)Carga Masiva\7)Salir\n");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        PL.Usuario.Add();
                        break;
                    case 2:
                        PL.Usuario.Update();
                        break;
                    case 3:
                        PL.Usuario.GetAll();
                        break;
                    case 4:
                        PL.Usuario.GetById();
                        break;
                    case 5:
                        PL.Usuario.Delete();
                        break;
                    case 6:
                        PL.Usuario.CargaMasivaTxt();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo");
                        break;

                }
            } while (opcion <7);
            */

            PL.Usuario.CargaMasivaTxt();
            Console.ReadKey();
        }
    }
}
