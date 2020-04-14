using Agenda_con_Archivos.Implementations;
using Agenda_con_Archivos.Models;
using System;

namespace Agenda_con_Archivos
{
    static class Program
    {
        private static void Main()
        {
            Console.WriteLine("\t1 - Añadir cita");
            Console.WriteLine("\t2 - Añadir contacto");
            Console.WriteLine("\t3 - Consultar cita");
            Console.WriteLine("\t4 - Buscar contacto");
            Console.WriteLine("\t0 - Salir");

            switch(Console.ReadLine())
            {
                case "1":
                    var date = new Recorder(new Date());
                    date.Registrar();
                    Main();
                    break;
                case "2":
                    var contact = new Recorder(new Contact());
                    contact.Registrar();
                    Main();
                    break;
                case "3":
                    SelectSearcher();
                    Main();
                    break;
                case "4":
                    //
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
               default:
                    Console.WriteLine("Por favor ingrese un numero de la lista");
                    Main();
                    break;
            }
        }
        private static void SelectSearcher()
        {
            Console.WriteLine("\t1 - Consultar por fecha");
            Console.WriteLine("\t2 - Consultar por contacto");
            Console.WriteLine("\t0 - Volver al menú principal");
            switch (Console.ReadLine())
            {
                case "1":
                    var dateSearcher = new Searcher(new DateSearcher());
                    dateSearcher.Search();
                    SelectSearcher();
                    break;
                case "2":
                    var contactSearcher = new Searcher(new ContactSearcher());
                    contactSearcher.Search();
                    SelectSearcher();
                    break;
                case "0":
                    Main();
                    break;
                default:
                    Console.WriteLine("Por favor ingrese un numero de la lista");
                    SelectSearcher();
                    break;
            }
        }
    }
}
