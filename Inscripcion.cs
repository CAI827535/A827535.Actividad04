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
        public void InscribirseUlt4(string dni)
        {
            Oferta oferta = new Oferta();

            oferta.mostrarOfertaCalificadault4(dni);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Continuar con la inscripción.");
            Console.WriteLine("2. Salir de la consola.");
            Console.WriteLine();
            Console.WriteLine("Ingrese una opción y presione [ENTER] para continuar.");
            Console.WriteLine("-----------------------------------------------------");
            var seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case "1":
                    {
                        bool vald = false;
                        Oferta ofer1 = new Oferta();
                        string IngresoMat1 = "";
                        while (!vald)
                        {

                            Console.WriteLine("Seleccione el curso original en el que se desea inscribir para la materia 1 [código materia - código curso]: ");
                            IngresoMat1 = Console.ReadLine();
                            if (IngresoMat1 != "")
                            {
                                ofer1 = oferta.SeleccionCurso(IngresoMat1);
                                vald = true;
                            }
                            else
                            {
                                Console.WriteLine("Error, vuleva a ingresar el dato.");
                            }
                        }

                        if (IngresoMat1 != null)
                        {
                            Console.WriteLine("Seleccione el curso alternativo en el que se desea inscribir para la materia 1 [código materia - código curso]: ");

                            var IngresoMatAlt = Console.ReadLine();
                            var alt1 = oferta.SeleccionCursoAlt(IngresoMatAlt);
                            string materia = IngresoMat1.Split('-')[0];
                            string materiaalt = IngresoMatAlt.Split('-')[0];

                            if (IngresoMat1 != IngresoMatAlt && materia == materiaalt)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Seleccione el curso original en el que se desea inscribir para la materia 2 [código materia - código curso]: ");

                                var IngresoMat2 = Console.ReadLine();
                                var ofer2 = oferta.SeleccionCurso(IngresoMat2);

                                if (IngresoMat1 != IngresoMat2 && IngresoMat1 != IngresoMatAlt)
                                {
                                    Console.WriteLine("Seleccione el curso alternativo en el que se desea inscribir para la materia 2 [código materia - código curso]: ");

                                    var IngresoMatAlt2 = Console.ReadLine();
                                    var alt2 = oferta.SeleccionCursoAlt(IngresoMatAlt2);
                                    string materia2 = IngresoMat2.Split('-')[0];
                                    string materiaalt2 = IngresoMatAlt2.Split('-')[0];

                                    if (IngresoMat1 != IngresoMatAlt && materia2 == materiaalt2)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Seleccione el curso original en el que se desea inscribir para la materia 3 [código materia - código curso]:  ");

                                        var IngresoMat3 = Console.ReadLine();
                                        var ofer3 = oferta.SeleccionCurso(IngresoMat3);

                                        if (IngresoMat1 != IngresoMat2 && IngresoMat2 != IngresoMat3 && IngresoMat1 != IngresoMat3 && IngresoMat1 != IngresoMat2)
                                        {
                                            StreamWriter sw = File.CreateText(@"./SolicitudInscripcion-" + dni + ".txt");
                                            Console.WriteLine("Seleccione el curso alternativo en el que se desea inscribir para la materia 3 [código materia - código curso]: ");
                                            var IngresoMatAlt3 = Console.ReadLine();
                                            var alt3 = oferta.SeleccionCursoAlt(IngresoMatAlt3);
                                            string materia3 = IngresoMat3.Split('-')[0];
                                            string materiaalt3 = IngresoMatAlt3.Split('-')[0];
                                           
                                            if (IngresoMat3 != null && IngresoMat3 != IngresoMat1 && materia3 == materiaalt3)
                                            {
                                                sw.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                sw.WriteLine("Usuario: " + dni);
                                                sw.WriteLine("Fecha de inscripción: " + DateTime.Now);
                                                sw.WriteLine();
                                                sw.WriteLine("Materia 1: " + ofer1.nombreMateria + " con el profesor: " + ofer1.profesorCurso + ", los dias " + ofer1.diaCurso + " en el horario de: " + ofer1.horarioCurso);
                                                sw.WriteLine("Alt.Mat.1: " + alt1.nombreMateria + " con el profesor: " + alt1.profesorCurso + ", los dias " + alt1.diaCurso + " en el horario de: " + alt1.horarioCurso);
                                                sw.WriteLine("Materia 2: " + ofer2.nombreMateria + " con el profesor: " + ofer2.profesorCurso + ", los dias " + ofer2.diaCurso + " en el horario de: " + ofer2.horarioCurso);
                                                sw.WriteLine("Alt.Mat.2: " + alt2.nombreMateria + " con el profesor: " + alt2.profesorCurso + ", los dias " + alt2.diaCurso + " en el horario de: " + alt2.horarioCurso);
                                                sw.WriteLine("Materia 3: " + ofer3.nombreMateria + " con el profesor: " + ofer3.profesorCurso + ", los dias " + ofer3.diaCurso + " en el horario de: " + ofer3.horarioCurso);
                                                sw.WriteLine("Alt.Mat.3: " + alt3.nombreMateria + " con el profesor: " + alt3.profesorCurso + ", los dias " + alt3.diaCurso + " en el horario de: " + alt3.horarioCurso);
                                                sw.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                sw.Close();

                                                using (var mostrarCursos = new StreamReader(@"./SolicitudInscripcion-" + dni + ".txt"))
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("Usted ha elegido los siguientes cursos: ");

                                                    while (!mostrarCursos.EndOfStream)
                                                    {
                                                        Console.WriteLine(mostrarCursos.ReadLine());
                                                    }
                                                }

                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea confirmar la solicitud de inscripción? [S - Confirmar] - [R - Repetir proceso de inscripción].");
                                                var tecla = Console.ReadLine();

                                                if (tecla.ToUpper() == "S")
                                                {
                                                    StreamWriter grabar = new StreamWriter(@"./GuardarSolicitudInscripcion.txt", append: true);
                                                    grabar.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                    grabar.WriteLine("Usuario: " + dni);
                                                    grabar.WriteLine("Fecha de inscripción: " + DateTime.Now);
                                                    grabar.WriteLine();
                                                    grabar.WriteLine("Materia 1: " + ofer1.nombreMateria + " con el profesor: " + ofer1.profesorCurso + ", los dias " + ofer1.diaCurso + " en el horario de: " + ofer1.horarioCurso);
                                                    grabar.WriteLine("Alt.Mat.1: " + alt1.nombreMateria + " con el profesor: " + alt1.profesorCurso + ", los dias " + alt1.diaCurso + " en el horario de: " + alt1.horarioCurso);
                                                    grabar.WriteLine("Materia 2: " + ofer2.nombreMateria + " con el profesor: " + ofer2.profesorCurso + ", los dias " + ofer2.diaCurso + " en el horario de: " + ofer2.horarioCurso);
                                                    grabar.WriteLine("Alt.Mat.2: " + alt2.nombreMateria + " con el profesor: " + alt2.profesorCurso + ", los dias " + alt2.diaCurso + " en el horario de: " + alt2.horarioCurso);
                                                    grabar.WriteLine("Materia 3: " + ofer3.nombreMateria + " con el profesor: " + ofer3.profesorCurso + ", los dias " + ofer3.diaCurso + " en el horario de: " + ofer3.horarioCurso);
                                                    grabar.WriteLine("Alt.Mat.3: " + alt3.nombreMateria + " con el profesor: " + alt3.profesorCurso + ", los dias " + alt3.diaCurso + " en el horario de: " + alt3.horarioCurso);
                                                    grabar.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                    grabar.Close();
                                                    Console.WriteLine("Su solicitud de inscripción se ha registrado correctamente en el sistema.");
                                                    Console.WriteLine("Presione una tecla para salir de la consola.");
                                                    
                                                    StreamWriter grabar1 = new StreamWriter(@"./ValidaciónInscripción.txt", append: true);
                                                    grabar1.WriteLine("Usuario|Inscripto");
                                                    grabar1.WriteLine(dni + "|SI");//+ datos.dni );
                                                    grabar1.Close();
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
                                        }
                                        else
                                        {
                                            Console.WriteLine("Usted ya ha seleccionado esa materia para la solicitud de inscripción.");
                                        }
                                    }
                                }
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

        public void Inscribirse(string dni)
        {
            Oferta oferta = new Oferta();

            oferta.mostrarOfertaCalificada();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Opciones:");
            Console.WriteLine("1. Continuar con la inscripción.");
            Console.WriteLine("2. Salir de la consola.");
            Console.WriteLine();
            Console.WriteLine("Ingrese una opción y presione [ENTER] para continuar.");
            Console.WriteLine("-----------------------------------------------------");
            var seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case "1":
                    {
                        bool vald = false;
                        Oferta ofer1 = new Oferta();
                        string IngresoMat1 = "";

                        while (!vald)
                        {
                            Console.WriteLine("Seleccione el curso original en el que se desea inscribir para la materia 1 [código materia - código curso]: ");
                            IngresoMat1 = Console.ReadLine();
                            if (IngresoMat1 != "")
                            {
                                ofer1 = oferta.SeleccionCurso(IngresoMat1);
                                vald = true;
                            }
                            else
                            {
                                Console.WriteLine("Error, vuleva a ingresar el dato.");
                            }
                        }

                        if (IngresoMat1 != null)
                        {
                            Console.WriteLine("Seleccione el curso alternativo en el que se desea inscribir para la materia 1 [código materia - código curso]: ");

                            var IngresoMatAlt = Console.ReadLine();
                            var alt1 = oferta.SeleccionCursoAlt(IngresoMatAlt);
                            string materia = IngresoMat1.Split('-')[0];
                            string materiaalt = IngresoMatAlt.Split('-')[0];

                            if (IngresoMat1 != IngresoMatAlt && materia == materiaalt)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Seleccione el curso original en el que se desea inscribir para la materia 2 [código materia - código curso]: ");

                                var IngresoMat2 = Console.ReadLine();
                                var ofer2 = oferta.SeleccionCurso(IngresoMat2);

                                if (IngresoMat1 != IngresoMat2 && IngresoMat1 != IngresoMatAlt)
                                {
                                    Console.WriteLine("Seleccione el curso alternativo en el que se desea inscribir para la materia 2 [código materia - código curso]: ");

                                    var IngresoMatAlt2 = Console.ReadLine();
                                    var alt2 = oferta.SeleccionCursoAlt(IngresoMatAlt2);
                                    string materia2 = IngresoMat2.Split('-')[0];
                                    string materiaalt2 = IngresoMatAlt2.Split('-')[0];

                                    if (IngresoMat1 != IngresoMatAlt && materia2 == materiaalt2)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Seleccione el curso original en el que se desea inscribir para la materia 3 [código materia - código curso]: ");

                                        var IngresoMat3 = Console.ReadLine();
                                        var ofer3 = oferta.SeleccionCurso(IngresoMat3);

                                        if (IngresoMat1 != IngresoMat2 && IngresoMat2 != IngresoMat3 && IngresoMat1 != IngresoMat3 && IngresoMat1 != IngresoMat2)
                                        {
                                            StreamWriter sw = File.CreateText(@"./SolicitudInscripcion-" + dni + ".txt");
                                            Console.WriteLine("Seleccione el curso alternativo en el que se desea inscribir para la materia 3 [código materia - código curso]: ");
                                            var IngresoMatAlt3 = Console.ReadLine();
                                            var alt3 = oferta.SeleccionCursoAlt(IngresoMatAlt3);
                                            string materia3 = IngresoMat3.Split('-')[0];
                                            string materiaalt3 = IngresoMatAlt3.Split('-')[0];

                                            if (IngresoMat3 != null && IngresoMat3 != IngresoMat1 && materia3 == materiaalt3)
                                            {
                                                sw.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                sw.WriteLine("Usuario: " + dni);
                                                sw.WriteLine("Fecha de inscripción: " + DateTime.Now);
                                                sw.WriteLine();
                                                sw.WriteLine("Materia 1: " + ofer1.nombreMateria + " con el profesor: " + ofer1.profesorCurso + ", los dias " + ofer1.diaCurso + " en el horario de: " + ofer1.horarioCurso);
                                                sw.WriteLine("Alt.Mat.1: " + alt1.nombreMateria + " con el profesor: " + alt1.profesorCurso + ", los dias " + alt1.diaCurso + " en el horario de: " + alt1.horarioCurso);
                                                sw.WriteLine("Materia 2: " + ofer2.nombreMateria + " con el profesor: " + ofer2.profesorCurso + ", los dias " + ofer2.diaCurso + " en el horario de: " + ofer2.horarioCurso);
                                                sw.WriteLine("Alt.Mat.2: " + alt2.nombreMateria + " con el profesor: " + alt2.profesorCurso + ", los dias " + alt2.diaCurso + " en el horario de: " + alt2.horarioCurso);
                                                sw.WriteLine("Materia 3: " + ofer3.nombreMateria + " con el profesor: " + ofer3.profesorCurso + ", los dias " + ofer3.diaCurso + " en el horario de: " + ofer3.horarioCurso);
                                                sw.WriteLine("Alt.Mat.3: " + alt3.nombreMateria + " con el profesor: " + alt3.profesorCurso + ", los dias " + alt3.diaCurso + " en el horario de: " + alt3.horarioCurso);
                                                sw.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                sw.Close();

                                                using (var mostrarCursos = new StreamReader(@"./SolicitudInscripcion-" + dni + ".txt"))
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("Usted ha elegido los siguientes cursos: ");

                                                    while (!mostrarCursos.EndOfStream)
                                                    {
                                                        Console.WriteLine(mostrarCursos.ReadLine());
                                                    }
                                                }

                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea confirmar la solicitud de inscripción? [S - Confirmar] - [R - Repetir proceso de inscripción].");
                                                var tecla = Console.ReadLine();

                                                if (tecla.ToUpper() == "S")
                                                {
                                                    StreamWriter grabar = new StreamWriter(@"./GuardarSolicitudInscripcion.txt", append: true);
                                                    grabar.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                    grabar.WriteLine("Usuario: " + dni);//+ datos.dni );
                                                    grabar.WriteLine("Fecha de inscripción: " + DateTime.Now);
                                                    grabar.WriteLine();
                                                    grabar.WriteLine("Materia 1: " + ofer1.nombreMateria + " con el profesor: " + ofer1.profesorCurso + ", los dias " + ofer1.diaCurso + " en el horario de: " + ofer1.horarioCurso);
                                                    grabar.WriteLine("Alt.Mat.1: " + alt1.nombreMateria + " con el profesor: " + alt1.profesorCurso + ", los dias " + alt1.diaCurso + " en el horario de: " + alt1.horarioCurso);
                                                    grabar.WriteLine("Materia 2: " + ofer2.nombreMateria + " con el profesor: " + ofer2.profesorCurso + ", los dias " + ofer2.diaCurso + " en el horario de: " + ofer2.horarioCurso);
                                                    grabar.WriteLine("Alt.Mat.2: " + alt2.nombreMateria + " con el profesor: " + alt2.profesorCurso + ", los dias " + alt2.diaCurso + " en el horario de: " + alt2.horarioCurso);
                                                    grabar.WriteLine("Materia 3: " + ofer3.nombreMateria + " con el profesor: " + ofer3.profesorCurso + ", los dias " + ofer3.diaCurso + " en el horario de: " + ofer3.horarioCurso);
                                                    grabar.WriteLine("Alt.Mat.3: " + alt3.nombreMateria + " con el profesor: " + alt3.profesorCurso + ", los dias " + alt3.diaCurso + " en el horario de: " + alt3.horarioCurso);
                                                    grabar.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                    grabar.Close();
                                                    Console.WriteLine("Su solicitud de inscripción se ha registrado correctamente en el sistema.");
                                                    Console.WriteLine("Presione una tecla para salir de la consola.");

                                                    StreamWriter grabar1 = new StreamWriter(@"./ValidaciónInscripción.txt", append: true);
                                                    grabar1.WriteLine("Usuario|Inscripto");
                                                    grabar1.WriteLine(dni + "|SI");//+ datos.dni );
                                                    grabar1.Close();
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
                                        }
                                        else
                                        {
                                            Console.WriteLine("Usted ya ha seleccionado esa materia para la solicitud de inscripción.");
                                        }
                                    }

                                }
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