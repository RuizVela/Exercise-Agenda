using System;

namespace Agenda_con_Archivos
{
    public class Cita
    {
        private DateTime _fecha;
        private readonly string _descripcion;
        private readonly string _nombre;

        public void addCita()
        {
            InsertarFecha();
        }
        private void InsertarFecha()
        {
            Console.WriteLine("Inserte fecha de la cita siguiendo el ejemplo:");
            Console.WriteLine("31/12/2020");
            var fecha = Console.ReadLine();
            Console.WriteLine("Inserte fecha de la cita siguiendo el ejemplo:");
            Console.WriteLine("17:30");
            var hora = Console.ReadLine();
            var fechaCompleta = fecha +" "+ hora;
            var data = Convert.ToDateTime(fechaCompleta);
            _fecha = data;
        }
    }
}
