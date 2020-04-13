using Agenda_con_Archivos.Services;

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
