using System;
using System.Collections.Generic;
using System.IO;

namespace Agenda_con_Archivos
{
    public class Consultor
    {
        public static void BuscarContacto(string nombre)
        {
            List<string> lista = new List<string>();
            try
            {

            using (StreamReader reader = new StreamReader("Contactos.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    var linea = reader.ReadLine();
                    if (linea.Contains(nombre))
                    {
                        lista.Add(linea);
                    }
                }
            }
            }
            catch(Exception exception)
            {
                Console.WriteLine("No existen contactos.");
                throw;
            }
            if (lista.Count >0)
            {
            LeerLista(lista);
            }
        }
        public static void LeerLista(List<string> lista)
        {
            Console.WriteLine("Escoga su contacto ");
            foreach (string linea in lista)
            {
                Console.WriteLine("\t"+ linea);
            }
            Console.WriteLine("\t0 - Salir");
        }
    }
}
