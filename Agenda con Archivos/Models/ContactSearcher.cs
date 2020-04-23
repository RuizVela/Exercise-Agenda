using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Agenda_con_Archivos.Models
{
    public class ContactSearcher
    {
        readonly string[] allContacts = File.ReadAllLines("Contactos.txt");
        string contactName;
        readonly List<string> contactList = new List<string>();
        public void Search()
        {
            InsertContact(); 
            SearchContact();
            ChooseContact();
            Console.ReadLine();
        }
        private void InsertContact()
        {
            string nameContact = null;
            while (string.IsNullOrEmpty(nameContact))
            {
                Console.WriteLine("Inserte el nombre de su contacto:");
                nameContact = Console.ReadLine();
            }
            contactName = nameContact;
        }
        private void SearchContact()
        {
            try
            {
                int id = 0;
                foreach (string contact in allContacts)
                {
                    if (contact.Contains(contactName))
                    {
                        id++;
                        string contactWithId = id.ToString() + " " + contact;
                        Console.WriteLine(contactWithId);
                        contactList.Add(contactWithId);
                    }
                }
                if (contactList.Count == 0)
                {
                    Console.WriteLine("No existen contactos con ese nombre");
                    return;
                }
                Console.WriteLine("0 Mi contacto no está en la lista");
            }
            catch (Exception)
            {
                Console.WriteLine("No existe un archivo de contactos.");
            }
        }
        private void ChooseContact()
        {
            if (contactList.Count == 0)
            {
                return;
            }
            Console.WriteLine("Elige tu contacto");
            string chosen = Console.ReadLine();
            foreach (string contact in contactList)
            {
                bool dateExists = false;
                try
                {
                if (chosen == contact[0].ToString())
                {
                    var allDates = File.ReadAllLines("Agenda.txt");
                    foreach (string date in allDates)
                    {
                        if (date.Contains(contact.Remove(0, 2)))
                        {
                            Console.WriteLine(date);
                            dateExists = true;
                        }
                    }
                }
                }
                catch (Exception) 
                {
                    //La excepcion no impide al metodo  
                }
                finally
                {
                    if (!dateExists)
                    {
                        Console.WriteLine("El contacto seleccionado no tiene citas.");
                    }
                }
            }
        }
    }
}
