using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_con_Archivos.Implementations
{
    public class Recorder
    {
        protected IService _service;
        public Recorder(IService service)
        {
            _service = service;
        }
        public void Registrar()
        {
            _service.Registrar();
        }
    }
}
