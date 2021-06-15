using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arrayUsuarios = new Usuario[]
            {
            new Usuario(36000900, "ian123", "Ian", "Lopez", 886840),
            new Usuario(36100800, "martin10", "Martin", "Palermo", 886841),
            new Usuario(37200700, "lucas123", "Lucas", "Alario", 886842),
            new Usuario(37300600, "fernanda21", "Fernando", "Fernandez", 886845),
            new Usuario(38400500, "mateo789", "Mateo", "Mates", 865541),
            new Usuario(38500400, "tomas102", "Tomas", "Wagner", 854565),
            new Usuario(39600300, "vanesa1993", "Vanesa", "Salpia", 854645),
            new Usuario(39700200, "alejandro1", "Alejandro", "Hegel", 855647),
            new Usuario(40800100, "andres124", "Andres", "Alvarez", 895655),
            new Usuario(40900000, "hernan556", "Hernan", "Crespo", 895652),
            };

            Console.WriteLine("                          --------------------------------------------------------------------------");
            Console.WriteLine("                          SUBSISTEMA DE GESTIÓN ACADÉMICA DE GRADO - FACULTAD DE CIENCIAS ECONÓMICAS");
            Console.WriteLine("                          --------------------------------------------------------------------------");
            Console.WriteLine();

            bool correcto = false;

            do
            {
                bool seguir = false;
                do
                {
                    Console.WriteLine("Ingrese su número de DNI (sin puntos): ");

                    var ingresoDNI = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ingresoDNI) || !ingresoDNI.Any(c => Char.IsDigit(c)) || int.Parse(ingresoDNI) < 0)
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

                        Usuario user = arrayUsuarios.FirstOrDefault(x => int.Parse(ingresoDNI) == x.dni && ingresoContraseña == x.contraseña);
                        
                        if (user != null)
                        {
                            correcto = true;
                            Console.Clear();
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine("                        MENU PRINCIPAL");
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("1. Inscripción a cursos regulares");
                            Console.WriteLine("9. Salir");
                            Console.WriteLine();
                            Console.WriteLine("-----------------------------------------------------------------");
                            Console.WriteLine("Seleccione una opción del menú y presione [ENTER] para continuar");
                            Console.WriteLine("-----------------------------------------------------------------");

                            string opcionMenu = Console.ReadLine();

                            bool salirMenu = false;
                            do
                            {
                                switch (opcionMenu)
                                {
                                    case "1":
                                        {
                                            ValidaIncr h = new ValidaIncr();

                                            h.SetearIncr();
                                            if (h.anotados.Any(x => x.Alumno == ingresoDNI))
                                            {
                                                string jj;
                                                Console.WriteLine();
                                                Console.WriteLine("Ya hay una solicitud de inscripción realizada por Usted en el sistema.");
                                                StreamReader k = new StreamReader(@"./SolicitudInscripcion-" + ingresoDNI + ".txt");

                                                jj = k.ReadLine();
                                                while (jj != null)
                                                {
                                                    Console.WriteLine(jj);
                                                    jj = k.ReadLine();
                                                }
                                                k.Close();

                                                Console.WriteLine("Presione una tecla para salir de la consola.");
                                                Console.ReadKey();
                                                Environment.Exit(-1);
                                            }
                                            else
                                            {

                                                Console.Clear();
                                                Console.WriteLine("-------------------------------------");
                                                Console.WriteLine("1. Estoy en las ultimas 4 materias");
                                                Console.WriteLine("2. No estoy en las ultimas 4 materias");
                                                Console.WriteLine("-------------------------------------");
                                                string opciónSubmenu = Console.ReadLine();
                                                
                                                bool salirSubMenu = false;
                                                
                                                do
                                                {
                                                    switch (opciónSubmenu)
                                                    {
                                                        case "1":
                                                            {                                                                
                                                                Inscripcion inscribir = new Inscripcion();
                                                                inscribir.InscribirseUlt4(ingresoDNI); 
                                                                break;
                                                            }

                                                        case "2":
                                                            {
                                                                Inscripcion inscribir = new Inscripcion();
                                                                inscribir.Inscribirse(ingresoDNI);
                                                                break;                                                               
                                                            }

                                                        default:
                                                            {                                                           
                                                                Console.WriteLine("Por favor, ingrese una opción válida.");
                                                                Console.ReadKey();
                                                                salirSubMenu=true;   
                                                                break;
                                                            }
                                                    
                                                    }
                                                } while (!salirSubMenu);
                                            
                                            }

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
                                             Console.ReadKey();
                                             salirMenu=true;   
                                             break;
                                        }
                                }
                            } while (!salirMenu);
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