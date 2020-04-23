using Agenda_con_Archivos.Services;
using System.Collections.Generic;

namespace Agenda_con_Archivos.Implementations
{
    public class FileManager
    {
        protected IManager _service;
        public FileManager(IManager service)
        {
            _service = service;
        }
        public void Register(Dictionary<string, string> data)
        {
            _service.Register(data);
        }
        public Dictionary<string, string> InsertData()
        {
           return _service.InsertData();
        }
        public bool Confirm(Dictionary<string,string> data)
        {
            return _service.Confirm(data);
        }
        public void Search()
        {
            _service.Search();
        }
    }
}
