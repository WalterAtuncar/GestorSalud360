using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities.calendar;
using Models.Request;
using Models.Response;

namespace Repositories.calendar
{
    public interface ICalendarRepository : IRepository<Models.Entities.calendar.calendar>
    {
        IEnumerable<ListaAgendaDTO> ObtenerListaAgendados(FiltroAgendaDTO obj);
    }
}
