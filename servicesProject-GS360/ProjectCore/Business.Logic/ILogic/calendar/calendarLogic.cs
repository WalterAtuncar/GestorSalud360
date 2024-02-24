using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit.Of.Work;

namespace Business.Logic.ILogic.calendar
{
    public class calendarLogic : ICalendarLogic
    {
        private IUnitOfWork _unitOfWork;

        public calendarLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Models.Entities.calendar.calendar GetById(string id)
        {
            return _unitOfWork.ICalendar.GetById(id);
        }

        public IEnumerable<Models.Entities.calendar.calendar> GetList()
        {
            return _unitOfWork.ICalendar.GetList();
        }

        public int Insert(Models.Entities.calendar.calendar obj)
        {
            return _unitOfWork.ICalendar.Insert(obj);
        }

        public bool Update(Models.Entities.calendar.calendar obj)
        {
            return _unitOfWork.ICalendar.Update(obj);
        }

        public IEnumerable<ListaAgendaDTO> ObtenerListaAgendados(FiltroAgendaDTO obj)
        {
            return _unitOfWork.ICalendar.ObtenerListaAgendados(obj);
        }
    }
}
