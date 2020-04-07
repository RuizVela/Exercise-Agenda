using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_con_Archivos
{
    public class Contacto
    {
        private string _nombre;
        private string _apellidos;
        private int _telefono;
        private string _localidad;
        private const string path = "Contactos.txt";

        public void AddContacto()
        {
            InsertarNombre();
            InsertarApellidos();
            InsertarTelefono();
            InsertarLocalidad();
            GuardarContacto();
        }
        private void InsertarNombre()
        {
            Console.WriteLine("Inserte el nombre del contacto");
            _nombre = Console.ReadLine();
        }
        private void InsertarApellidos()
        {
            Console.WriteLine("Inserte los apellidos");
            _apellidos = Console.ReadLine();
        }
        private void InsertarTelefono()
        {
            Console.WriteLine("Inserte el numero de telefono");
            _telefono = Int32.Parse(Console.ReadLine());
        }
        private void InsertarLocalidad()
        {
            Console.WriteLine("Inserte la localidad");
            _localidad = Console.ReadLine();
        }
        private void GuardarContacto()
        {
            if (!File.Exists(path))
            {
                CreateFile();
            }
            RegistrarContacto();
        }
        private void CreateFile()
        {
            File.CreateText(path).Close();
        }
        private void RegistrarContacto()
        {
            var linea = _nombre + " " + _apellidos + " " + _telefono + " " + _localidad;
            Console.WriteLine("¿Es correcta esta informacion?");
            Console.WriteLine(linea);
            Console.WriteLine("s/n");
            if(Console.ReadLine() == "s")
            {
            File.AppendAllText(path, linea + Environment.NewLine);
            }
        }
    }
}
