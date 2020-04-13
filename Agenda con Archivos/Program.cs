using Agenda_con_Archivos.Implementations;
using Agenda_con_Archivos.Models;
using System;

namespace Agenda_con_Archivos
{
    class Program
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
                    //
                    break;
                case "4":
                    //
                    break;
                case "0":
                    //
                    break;
            }
        }
    }
}
