using System;

namespace Agenda_con_Archivos
{
    public class Cita
    {
        private DateTime _fecha;
        private string _descripcion;
        private string _contacto;

        public void addCita()
        {
            InsertarFecha();
            InsertarDescripcion();
            InsertarContacto();
            var lista = Consultor.BuscarContacto(_contacto);
            Consultor.LeerLista(lista);
            Console.ReadLine();
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
        private void  InsertarContacto()
        {
            Console.WriteLine("Inserte el nombre de su contacto");
            _contacto = Console.ReadLine();
        }
    }
}
