using System;
using System.IO;

namespace Agenda_con_Archivos.Models
{
    public class DateSearcher
    {
        public void Search()
        {
            var date = InsertDate();
            DateSearch(date);
            Console.ReadLine();
        }
        private DateTime InsertDate()
        {
            bool correctDate = false;
            DateTime date = new DateTime();
            while (!correctDate)
            {
                Console.WriteLine("Inserte la fecha de la cita. Ejemplo: 21/05/2001");
                correctDate = DateTime.TryParse(Console.ReadLine(), out date);
            }
            return date;
        }
        private void DateSearch(DateTime day)
        {
                bool dateExists = false;
            try
            {
                var allDates = File.ReadAllLines("Agenda.txt");
                foreach (string date in allDates)
                {
                    if (date.Contains(day.ToString("dd/MM/yyyy")))
                    {
                    Console.WriteLine(date);
                    dateExists = true;
                    }
                }
                if (!dateExists)
                {
                    Console.WriteLine("No existen citas para ese día.");
                }
            }
            catch (Exception)
            {
                //La excepción no impide que el programa siga funcionando.
            }
        }
    }
}
