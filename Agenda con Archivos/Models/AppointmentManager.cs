using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Agenda_con_Archivos.Models
{
    public class AppointmentManager : IManager
    {
        public string path { get; } = Properties.Settings.Default.SchedulePath;

        public Dictionary<string, string> data { get; } = new Dictionary<string, string>();
        public bool Register(Dictionary<string, string> data)
        {
            SetId();
            Appointment appointment = new Appointment()
            {
                Id = int.Parse(data["id"]),
                Date = DateTime.Parse(data["date"]),
                Description = data["description"],
                Contact = data["contact"]
            };
            var dataString = appointment.Id.ToString() + " " + appointment.Date.ToString() + " " + appointment.Description + " " + appointment.Contact;
            File.AppendAllText(path, dataString + Environment.NewLine);
            return true;
        }
        public int SetId()
        {
            if (!File.Exists(path)) { File.CreateText(path).Close(); }
            var id = File.ReadLines(path).Count();
            data["id"] = id.ToString();
            return id;
        }
        public Dictionary<string,string> InsertData()
        {
            InsertDate();
            InsertDescription();
            InsertContactName();
            return data;
        }
        private void InsertDate()
        {
            DateTime date;
            bool correctDate = false;
            while (!correctDate)
            {
                Console.WriteLine("Inserte la fecha y hora de la cita. Ejemplo: 21/05/2001 17:30");
                correctDate = DateTime.TryParse(Console.ReadLine(), out date);
                data["date"] = date.ToString();
            }
        }
        private void InsertDescription()
        {
            while (!data.ContainsKey("description") || string.IsNullOrEmpty(data["description"]))
            {
                Console.WriteLine("Inserte el motivo de su cita:");
                data["description"] = Console.ReadLine();
            }
        }
        private void InsertContactName()
        {
            while (!data.ContainsKey("contact") || string.IsNullOrEmpty(data["contactName"]))
            {
                Console.WriteLine("Inserte el nombre de su contacto:");
                data["contact"] = Console.ReadLine();
            }
        }
        private List<string> SearchContact(string name)
        {
            List<string> similarContacts = new List<string>();

            var allContacts = File.ReadAllLines("Contactos.txt");
            foreach (string contact in allContacts) 
                {
                if (contact.Contains(name)) 
                    {
                    similarContacts.Add(contact);
                    }
                }
            return similarContacts;
        }
        private void SelectContact(List<string> contacts)
        {
            if (contacts.Count <= 0)
            {
                Console.WriteLine("El contacto no existe.");
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
                    data["contact"] = contact;
                }
            }
        }

        public bool Confirm(Dictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        public bool Search()
        {
            throw new NotImplementedException();
        }
    }
}
