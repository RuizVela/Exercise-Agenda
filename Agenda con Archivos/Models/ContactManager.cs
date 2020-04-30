using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Agenda_con_Archivos.Models
{
    public class ContactManager : IManager
    {
        public string path { get; } = Properties.Settings.Default.ContactsPath;

        public Dictionary<string, string> data { get; } = new Dictionary<string, string>();
        public Contact Register(Dictionary<string, string> data)
        {
            SetId();
            Contact contact = new Contact()
            {
                Id = int.Parse(data["id"]),
                Name = data["name"],
                Surname = data["surname"],
                PhoneNumber = int.Parse(data["phoneNumber"]),
                Location = data["location"],
            };
            var dataString = contact.Id.ToString() + " " + contact.Name + " " + contact.Surname + " " + contact.PhoneNumber.ToString() + " " + contact.Location;
            File.AppendAllText(path, dataString + Environment.NewLine);
            return contact;
        }
        public Dictionary<string, string> InsertData()
        {
            InsertName();
            InsertSurname();
            InsertPhoneNumber();
            InsertLocation();
            return data;
        }
        public int SetId()
        {
            if (!File.Exists(path)) { File.CreateText(path).Close(); }
            var id = File.ReadLines(path).Count();
            data["id"] = id.ToString();
            return id;
        }
        private void InsertName()
        {
            while (!data.ContainsKey("name") || string.IsNullOrEmpty(data["name"]))
            {
                Console.WriteLine("Inserte el nombre:");
                
                data["name"] = Console.ReadLine();
            }
        }
        private void InsertSurname()
        {
            while (!data.ContainsKey("surname") || string.IsNullOrEmpty(data["surname"]))
            {
                Console.WriteLine("Inserte los apellidos:");
                data["surname"] =  Console.ReadLine();
            }
        }
        private void InsertPhoneNumber()
        {
            int phoneNumber = 0;
            bool correctPhoneNumber = false;
            while (phoneNumber.ToString().Length != 9 || !correctPhoneNumber)
            {
                Console.WriteLine("Inserte el numero de telefono:");
                correctPhoneNumber = int.TryParse(Console.ReadLine(), out phoneNumber);
            }
            data.Add("phoneNumber", phoneNumber.ToString());
        }
        private void InsertLocation()
        {
            while (!data.ContainsKey("location") || string.IsNullOrEmpty(data["location"]))
            {
                Console.WriteLine("Inserte la localidad:");
                data["location"] =  Console.ReadLine();
            }
        }
        public bool Confirm(Dictionary<string, string> data)
        {
            string dataString;
            var dataStringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> entry in data)
            {
                dataStringBuilder.AppendFormat("{0} ", entry.Value);
            }
            dataString = dataStringBuilder.ToString();
            Console.WriteLine("¿Es correcta esta información? s/n");
            Console.WriteLine(dataString);
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
        public Contact Search()
        {
            throw new NotImplementedException();
        }
    }
}
