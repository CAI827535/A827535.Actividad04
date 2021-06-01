using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayUsuarios = new Usuario[]
            {
            new Usuario(36000900, "ian123"),
            new Usuario(36100800, "martin10"),
            new Usuario(37200700, "lucas123"),
            new Usuario(37300600, "fernanda21"),
            new Usuario(38400500, "mateo789"),
            new Usuario(38500400, "tomas102"),
            new Usuario(39600300, "vanesa1993"),
            new Usuario(39700200, "alejandro1"),
            new Usuario(40800100, "andres124"),
            new Usuario(40900000, "hernan556")
            };
        
            Console.WriteLine("SISTEMA DE GESTIÓN INTEGRAL - FACULTAD DE CIENCIAS ECONÓMICAS");
            Console.WriteLine();

            bool correcto = false;

            do
            {
                bool seguir = false;
                do
                {
                    Console.WriteLine("Ingrese su número de DNI (sin puntos): ");
                    var ingresoDNI = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ingresoDNI))
                    {
                        Console.WriteLine("Debe ingresar un número de DNI válido.");
                        continue;
                    }

                    if (!ingresoDNI.Any(c => Char.IsDigit(c)))
                    {
                        Console.WriteLine("Debe ingresar un número de DNI válido.");
                        continue;
                    }

                    if (int.Parse(ingresoDNI) < 0)
                    {
                        Console.WriteLine("Debe ingresar un número de DNI válido.");
                        continue;
                    }

                    if (ingresoDNI.Length != 8)
                    {
                        Console.WriteLine("Debe ingresar un número de DNI que contenga 8 dígitos.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese su contraseña:");
                        var ingresoContraseña = Console.ReadLine();
                        
                        if (string.IsNullOrWhiteSpace(ingresoContraseña))
                        {
                            Console.WriteLine("Debe ingresar una contraseña válida.");
                            Console.WriteLine();
                            continue;
                        }                        

                        foreach (Usuario user in arrayUsuarios)
                        {
                            if (int.Parse(ingresoDNI) == user.dni && ingresoContraseña == user.contraseña)
                            { 
                                correcto = true;
                                Console.Clear();
                                Console.WriteLine("MENU PRINCIPAL");
                                Console.WriteLine("1. Inscripción a cursos regulares");
                                Console.WriteLine("2. Calificaciones");
                                Console.WriteLine("3. Certificados");
                                Console.WriteLine("4. Campus virtual");
                                Console.WriteLine("9. Salir");
                                Console.WriteLine();
                                Console.WriteLine("Seleccione una opción del menú y presione [ENTER] para continuar");

                                string opcionMenu = Console.ReadLine();

                                bool salirMenu = false;
                                do
                                {
                                    switch (opcionMenu)
                                    {
                                        case "1":
                                            {
                                                Console.Clear();
                                                Inscripcion inscribir = new Inscripcion();                                                
                                                inscribir.Inscribirse();
                                                break;
                                            }

                                        case "2":
                                            {
                                                correcto = true;
                                                seguir = true;
                                                salirMenu = true;
                                                break;
                                            }

                                        case "3":
                                            {
                                                correcto = true;
                                                seguir = true;
                                                salirMenu = true;
                                                break;
                                            }

                                        case "4":
                                            {
                                                correcto = true;
                                                seguir = true;
                                                salirMenu = true;
                                                break;
                                            }

                                        case "9":
                                            {
                                                correcto = true;
                                                seguir = true;
                                                salirMenu = true;
                                                break;
                                            }

                                        default:
                                            {
                                                Console.WriteLine("Por favor, ingrese una opción válida.");                                                
                                                continue;
                                            }
                                    }
                                } while (!salirMenu);
                            }
                        }

                        if (!correcto)
                        {
                            Console.WriteLine("Ingreso al sistema inválido. Por favor, intentelo nuevamente.");
                            Console.WriteLine();
                        }
                    }
                } while (!seguir);
            } while (!correcto);
        }
    }   
}
