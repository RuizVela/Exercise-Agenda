using Agenda_con_Archivos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_con_Archivos.Implementations
{
    public class Searcher
    {
        protected ISearcher _service;
        public Searcher(ISearcher service)
        {
            _service = service;
        }
        public void Search()
        {
            _service.Search();
        }
    }
}
