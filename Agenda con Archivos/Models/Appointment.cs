using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Agenda_con_Archivos.Models
{
    public class Appointment
    {
        private readonly string path = "Agenda.txt";
        private DateTime date;
        bool correctDate = false;
        private string description;
        private string nameContact;
        private string data;
        public void Registrar()
        {
            Insertar();
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
        private void Insertar()
        {
            InsertDate();
            InsertDescription();
            InsertContact();
        }
        private void InsertDate()
        {
            while (!correctDate)
            {
                Console.WriteLine("Inserte la fecha y hora de la cita. Ejemplo: 21/05/2001 17:30");
                correctDate = DateTime.TryParse(Console.ReadLine(), out date);
            }
        }
        private void InsertDescription()
        {
            while(string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Inserte el motivo de la cita:");
                description = Console.ReadLine();
            }
        }
        private void InsertContact()
        {
            while(string.IsNullOrEmpty(nameContact))
            {
                Console.WriteLine("Inserte el nombre de su contacto:");
                SearchContact(Console.ReadLine());
            }
        }
        private void SearchContact(string name)
        {
            List<string> similarContacts = new List<string>();
            try
            {
            var allContacts = File.ReadAllLines("Contactos.txt");
            int count = 0;
            foreach(string contact in allContacts)
            {
                if (contact.Contains(name))
                {
                    count++;
                    similarContacts.Add(count.ToString()+" "+contact);
                }
            }
            }
            catch(Exception)
            {
                //La excepción no impide que el programa siga funcionando.
            }
            finally 
            {
                ChooseContact(similarContacts);
            }
        }
        private void ChooseContact(List<string> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No existen contactos con ese nombre, ingrese su contacto:");
                var Contact = new Contact();
                Contact.Registrar();
                SearchContact(Contact.name);
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
                    nameContact = contact.Remove(0,1);
                    return;
                }
            }
            if (chosen == "0")
            {
                Console.WriteLine("Ingrese su contacto:");
                var Contact = new Contact();
                Contact.Registrar();
                SearchContact(Contact.name);
            }
        }
        private bool Confirm()
        {
            data = date.ToString("dd/MM/yyyy HH:mm") + " " + description + " " + nameContact;
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
