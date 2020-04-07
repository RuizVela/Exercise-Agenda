using System;

namespace Agenda_con_Archivos
{
    public class Cita
    {
        private DateTime _fecha;
        private string _descripcion;
        private string _nombre;

        public void addCita()
        {
            InsertarFecha();
            InsertarDescripcion();
            InsertarNombre();
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
        private void InsertarDescripcion()
        {
            Console.WriteLine("Inserte el motivo de la cita");
            _descripcion = Console.ReadLine();
        }
        private string  InsertarNombre()
        {
            Console.WriteLine("Inserte el nombre de su contacto");
            _nombre = Console.ReadLine();
            return _nombre;
        }
    }
}
