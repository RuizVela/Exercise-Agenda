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
        public void Registrar()
        {
            var data = Insertar();
            var confirmedData = Confirm(data);
            if (!File.Exists(path))
            {
                CreateFile();
            }
            AddRegistry(confirmedData);
            Console.WriteLine("Contacto agregado correctamente.");
            Console.ReadLine();
        }
        private string Insertar()
        {
            List<string> dataList = new List<string>();
            Console.WriteLine("Inserte el nombre:");
            dataList.Add(Console.ReadLine());
            Console.WriteLine("Inserte los apellidos:");
            dataList.Add(Console.ReadLine());
            Console.WriteLine("Inserte el numero de telefono:");
            dataList.Add(Console.ReadLine());
            Console.WriteLine("Inserte la localidad:");
            dataList.Add(Console.ReadLine());
            string data = string.Join(" ", dataList);
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
    }
}
