using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_con_Archivos.Models
{
    public class Date : IService
    {
        private readonly string path = "Agenda.txt";
        public void Registrar()
        {
            var data = Insertar();
            var confirmedData = Confirm(data);
            if (!File.Exists(path))
            {
                CreateFile();
            }
            AddRegistry(confirmedData);
            Console.WriteLine("Cita creada correctamente");
            Console.ReadLine();
        }
        private string Insertar()
        {
            List<string> dataList = new List<string>();
            Console.WriteLine("Inserte la fecha de la cita. Ejemplo: 21/05/2001");
            dataList.Add(Console.ReadLine());
            Console.WriteLine("Inserte el motivo de la cita:");
            dataList.Add(Console.ReadLine());
            Console.WriteLine("Inserte el nombre de su contacto:");
            dataList.Add(searchContact(Console.ReadLine()));
            string data = string.Join(" ", dataList);
            return data;
        }
        private string searchContact(string name)
        {
            var contacts = File.ReadAllLines("Contactos.txt");
            List<string> names = new List<string>();
            int count = 0;
            foreach(string contact in contacts)
            {
                if (contact.Contains(name))
                {
                    count++;
                    names.Add(count.ToString()+" "+contact);
                }
            }
            return chooseContact(names);
        }
        private string chooseContact(List<string> contacts)
        {
            Console.WriteLine("elige tu contacto");
            foreach (string contact in contacts)
            {
                Console.WriteLine(contact);
            }
            string elegir = Console.ReadLine();
            foreach (string contact in contacts)
            {
                if (elegir == contact[0].ToString())
                {
                    return contact.Remove(0,1);
                }
            }
            return "El contacto no existe";
        }
        private string Confirm(string data)
        {
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
                data = Insertar();
                Confirm(data);
            }
            return data;
        }
        private void CreateFile()
        {
            File.CreateText(path).Close();
        }
        private void AddRegistry(string data)
        {
            File.AppendAllText(path, data + Environment.NewLine);
        }
    }
}
