using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_con_Archivos
{
    public class Cita
    {
        private readonly DateTime _fecha;
        private readonly string _descripcion;
        private readonly string _nombre;
        public Cita(DateTime fecha, string descripcion, string nombre)
        {
            _fecha = fecha;
            _descripcion = descripcion;
            _nombre = nombre;
        }
    }
}
