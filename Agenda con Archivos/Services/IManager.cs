using System.Collections.Generic;

namespace Agenda_con_Archivos.Services
{
    public interface IManager
    {
        string path {get;}
        Dictionary<string,string> data { get; }
        bool Register(Dictionary<string, string> data);
        Dictionary<string, string> InsertData();
        bool Confirm(Dictionary<string, string> data);
        bool Search();
    }
}
