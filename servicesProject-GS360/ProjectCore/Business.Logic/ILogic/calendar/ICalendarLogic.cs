using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.ILogic.calendar
{
    public interface ICalendarLogic
    {
        bool Update(Models.Entities.calendar.calendar obj);
        int Insert(Models.Entities.calendar.calendar obj);
        IEnumerable<Models.Entities.calendar.calendar> GetList();
        Models.Entities.calendar.calendar GetById(string id);
        IEnumerable<ListaAgendaDTO> ObtenerListaAgendados(FiltroAgendaDTO obj);
    }
}
