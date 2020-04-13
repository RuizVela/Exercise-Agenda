using Agenda_con_Archivos.Services;

namespace Agenda_con_Archivos.Implementations
{
    public class Recorder
    {
        protected IRecorder _service;
        public Recorder(IRecorder service)
        {
            _service = service;
        }
        public void Registrar()
        {
            _service.Registrar();
        }
    }
}
