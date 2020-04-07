using System;

namespace Agenda_con_Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t1 - Añadir cita");
            Console.WriteLine("\t2 - Añadir contacto");
            Console.WriteLine("\t3 - Consultar cita");
            Console.WriteLine("\t4 - Buscar contacto");
            Console.WriteLine("\t0 - Salir");

            switch(Console.ReadLine())
            {
                case "1":
                    var cita = new Cita();
                    cita.AddCita();
                    break;
                case "2":
                    //
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
