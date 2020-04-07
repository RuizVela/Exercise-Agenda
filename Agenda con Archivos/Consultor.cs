using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Agenda_con_Archivos
{
    public class Consultor
    {
        public static List<string> BuscarNombre(string nombre)
        {
            List<string> lista = new List<string>();
            using (StreamReader reader = new StreamReader("Agenda.txt"))
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
            return lista;
        }
        public static void LeerLista(List<string> lista)
        {
            int tecla = 1;
            foreach (string linea in lista)
            {
                Console.WriteLine("\t"+tecla +" - " + linea);
                tecla++;
            }
        }
    }
}
