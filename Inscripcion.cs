using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico
{
    class Inscripcion
    {
        public void Inscribirse()
        {
            StreamWriter sw = new StreamWriter(@"./SolicitudInscripcion.txt");

            Oferta oferta = new Oferta();

            oferta.mostrarOfertaCalificada();            

            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Continuar con la inscripción.");
            Console.WriteLine("2. Salir de la consola.");
            Console.WriteLine();
            Console.WriteLine("Ingrese una opción y presione [ENTER] para continuar.");

            var seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case "1":
                    {
                        Console.WriteLine("Seleccione el curso en el que se desea inscribir para la materia 1: ");
                        var IngresoMat1 = Console.ReadLine();
                        var ofer1 = oferta.SeleccionCurso(IngresoMat1);

                        if (IngresoMat1 != null)
                        {
                            Console.WriteLine("Seleccione el curso en el que se desea inscribir para la materia 2: ");
                            var IngresoMat2 = Console.ReadLine();
                            var ofer2 = oferta.SeleccionCurso(IngresoMat2);

                            if (IngresoMat2 != null || IngresoMat2 != IngresoMat1)
                            {
                                Console.WriteLine("Seleccione el curso en el que se desea inscribir para la materia 3: ");
                                var IngresoMat3 = Console.ReadLine();
                                var ofer3 = oferta.SeleccionCurso(IngresoMat3);

                                sw.WriteLine("Materia 1: " + ofer1.nombreMateria + " con el profesor: " + ofer1.profesorCurso);
                                sw.WriteLine("Materia 2: " + ofer2.nombreMateria + " con el profesor: " + ofer2.profesorCurso);
                                sw.WriteLine("Materia 3: " + ofer3.nombreMateria + " con el profesor: " + ofer3.profesorCurso);
                                sw.Close();

                                using (var mostrarCursos = new StreamReader(@"./SolicitudInscripcion.txt"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Usted ha elegido los siguientes cursos: ");

                                    while (!mostrarCursos.EndOfStream)
                                    {
                                        Console.WriteLine(mostrarCursos.ReadLine());
                                    }
                                }
                                        
                                Console.WriteLine();
                                Console.WriteLine("¿Desea confirmar solicitud de inscripción? [S - confirmar] / [R - repetir proceso de inscripción].");
                                var tecla = Console.ReadLine();

                                if (tecla.ToUpper() == "S")
                                {
                                    StreamWriter grabar = new StreamWriter(@"./GuardarSolicitudInscripcion.txt", append: true);
                                    grabar.WriteLine("Materia 1: " + ofer1.nombreMateria + " con el profesor: " + ofer1.profesorCurso);
                                    grabar.WriteLine("Materia 2: " + ofer2.nombreMateria + " con el profesor: " + ofer2.profesorCurso);
                                    grabar.WriteLine("Materia 3: " + ofer3.nombreMateria + " con el profesor: " + ofer3.profesorCurso);
                                    grabar.Close();
                                    Console.WriteLine("Su solicitud de inscripción se ha registrado correctamente en el sistema.");
                                    Console.WriteLine("Presione una tecla para salir de la consola.");
                                    Console.ReadKey();
                                    Environment.Exit(-1);
                                }
                                else if (tecla.ToUpper() == "R")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Debe elegir una opción válida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Usted ya ha seleccionado esa materia para la solicitud de inscripción.");
                            }
                        }

                       break;
                    }

                case "2":
                    {
                        Environment.Exit(-1);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("No ha ingresado una opción válida.");
                        break;
                    }
            }
        }
    }
}
