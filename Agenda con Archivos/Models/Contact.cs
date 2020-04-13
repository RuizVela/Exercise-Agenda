using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_con_Archivos.Models
{
    public class Contact : IRecorder
    {
        private readonly string path = "Contactos.txt";
        private string name;
        private string surname;
        private int phoneNumber;
        bool correctPhoneNumber = false;
        private string location;
        public void Registrar()
        {
            Insertar();
            var confirmedData = Confirm();
            if (!File.Exists(path))
            {
                CreateFile();
            }
            AddRegistry(confirmedData);
            Console.WriteLine("Contacto agregado correctamente.");
            Console.ReadLine();
        }
        private void Insertar()
        {
            InsertName();
            InsertSurname();
            InsertPhoneNumber();
            InsertLocation();
        }
        private void InsertName()
        {
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Inserte el nombre:");
                name = Console.ReadLine();
            }
        }
        private void InsertSurname()
        {
            while (string.IsNullOrEmpty(surname))
            {
                Console.WriteLine("Inserte los apellidos:");
                surname = Console.ReadLine();
            }
        }
        private void InsertPhoneNumber()
        {
            while(phoneNumber.ToString().Length !=9 || !correctPhoneNumber)
            {
                Console.WriteLine("Inserte el numero de telefono:");
                correctPhoneNumber = Int32.TryParse(Console.ReadLine(), out phoneNumber);
            }
        }
        private void InsertLocation()
        {
            while (string.IsNullOrEmpty(location))
            {
                Console.WriteLine("Inserte la localidad:");
                location = Console.ReadLine();
            }
        }
        private void CreateFile()
        {
                File.CreateText(path).Close();
        }
        private void AddRegistry(string data)
        {
            File.AppendAllText(path, data + Environment.NewLine);
        }
        private string Confirm()
        {
            var data = name + surname + phoneNumber.ToString() + location;
            Console.WriteLine("¿Es correcta esta información? s/n");
            Console.WriteLine(data);
            string confirmed = Console.ReadLine();
            while (confirmed != "s" && confirmed != "n")
            {
                Console.WriteLine("Por favor, responda con s o n");
                confirmed = Console.ReadLine();
            }
            if (confirmed != "s")
            {
                Console.WriteLine("Volvamos a empezar");
                Insertar();
                Confirm();
            }
            return data;

        }
    }
}
