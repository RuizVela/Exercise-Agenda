using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Agenda_con_Archivos.Models
{
    public class ContactSearcher : ISearcher
    {
            string nameContact;

        public void Search()
        {
            InsertContact();
            Console.ReadLine();
        }
        private void InsertContact()
        {
            while (string.IsNullOrEmpty(nameContact))
            {
                Console.WriteLine("Inserte el nombre de su contacto:");
                nameContact = Console.ReadLine();
            }
                SearchContact(nameContact);
        }
        private void SearchContact(string name)
        {
            
            List<string> dates = new List<string>();
            try
            {
                int count = 0;
                var allDates = File.ReadAllLines("Contactos.txt");
                foreach (string date in allDates)
                {
                    if (date.Contains(name))
                    {
                        count++;
                        dates.Add(count.ToString() + " " + date);
                    }
                }
            }
            catch (Exception)
            {
                //La excepción no impide que el programa siga funcionando.
            }
            finally
            {
                ChooseContact(dates);
            }
        }
        private void ChooseContact(List<string> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No existen contactos con ese nombre");
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
