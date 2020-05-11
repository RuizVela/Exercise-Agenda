using System;
using System.Collections.Generic;
using System.IO;

namespace Agenda_con_Archivos.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get;  set; }
        private readonly string path = "Agenda.txt";
        public string Description { get; set; }
        public string Contact { get; set; }
        private string data;
        public void Registrar()
        {
            if(!Confirm())
            {
                return;
            }
            if (!File.Exists(path))
            {
                CreateFile();
            }
            AddRegistry(data);
            Console.WriteLine("Cita creada correctamente");
            Console.ReadLine();
        }
 
        private void ChooseContact(List<string> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No existen contactos con ese nombre, ingrese su contacto:");
                var Contact = new Contact();
                //Contact.Register();
                //SearchContact(Contact.Name);
                return;
            }
            Console.WriteLine("Elige tu contacto");
            foreach (string contact in contacts)
            {
                Console.WriteLine(contact);
            }
            Console.WriteLine("0 Mi contacto no está en la lista");
            string chosen = Console.ReadLine();
            foreach (string contact in contacts)
            {
                if (chosen == contact[0].ToString())
                {
                    Contact = contact.Remove(0,1);
                    return;
                }
            }
            if (chosen == "0")
            {
                Console.WriteLine("Ingrese su contacto:");
                var Contact = new Contact();
                //Contact.Register();
               // SearchContact(Contact.Name);
            }
        }
        private bool Confirm()
        {
            data = Date.ToString("dd/MM/yyyy HH:mm") + " " + Description + " " + Contact;
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
                Console.WriteLine("Operación cancelada");
                return false;
            }
            return true;
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
