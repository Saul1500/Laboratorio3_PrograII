using Laboratorio3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

class Program
{
    static void Main()
    {
        using (var contextdb = new ContextDB())
        {
            bool Continuar = true;
            while (Continuar)
            {
                Console.WriteLine("***********************************************");
                Console.WriteLine("");
                Console.WriteLine("BIENVENIDOS AL MENU DEL CRUD DE LA BASE DE DATOS");
                Console.WriteLine("");
                Console.WriteLine("***********************************************");
                Console.WriteLine("");
                Console.WriteLine("1 Insertar Datos");
                Console.WriteLine("");
                Console.WriteLine("2 Actualizar Datos");
                Console.WriteLine("");


                int op1 = Convert.ToInt32(Console.ReadLine());

                switch (op1)
                {
                    case 1:
                        contextdb.Database.EnsureCreated();

                        equipos estudiante = new equipos();

                        Console.WriteLine("Ingrese nombre de equipo: ");
                        estudiante.equipo = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese los puntos: ");
                        estudiante.puntos = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese la cantidad de jugadores: ");
                        estudiante.jugadores = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el representante: ");
                        estudiante.representante = Console.ReadLine();

                        Console.WriteLine("");

                        contextdb.Add(estudiante);
                        contextdb.SaveChanges();

                        Console.WriteLine("Datos Agregados Correctamente.");
                        Console.WriteLine("");
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el Id del registro que desea modificar");
                        var id = Console.ReadLine();
                        var persona = contextdb.equipos.FirstOrDefault(p => p.Id == Int32.Parse(id));

                        if (persona != null)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Que opción desea modificar");
                            Console.WriteLine("");
                            Console.WriteLine("1 Equipo");
                            Console.WriteLine("");
                            Console.WriteLine("2 Puntos");
                            Console.WriteLine("");
                            Console.WriteLine("3 Jugadores");
                            Console.WriteLine("");
                            Console.WriteLine("4 Representante");

                            int op = Convert.ToInt32(Console.ReadLine());
                            switch (op)
                            {

                                case 1:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo nombre de equipo: ");
                                    persona.equipo = Console.ReadLine();
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;
                                case 2:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese la nueva cantidad de puntos: ");
                                    persona.puntos = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;
                                case 3:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese la nueva cantidad de jugadores: ");
                                    persona.jugadores = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;
                                case 4:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo representante: ");
                                    persona.representante = Console.ReadLine();
                                    Console.WriteLine("");
                                    Console.WriteLine("Datos Actualizados Correctamente.");
                                    break;
                            }
                            contextdb.SaveChanges();
                        }
                        break;

                }
                Console.WriteLine("");
                Console.WriteLine("Desea continuar (EN MAYUSCULAS S/N)? Precione S/N");
                var cont = Console.ReadLine();
                if (cont.Equals("N"))
                {
                    Continuar = false;
                }

            }
            Console.WriteLine("");

            Console.WriteLine("LISTADO DE LOS DATOS:");
            Console.WriteLine("");

            foreach (var s in contextdb.equipos)
            {
                Console.WriteLine($"Equipo: {s.equipo}, Puntos: {s.puntos}, Jugadores: {s.jugadores}, Representante: {s.representante}");
            }

        }
    }
}

//ALUMNO: JOSE SAUL SIBRIAN SERRANO