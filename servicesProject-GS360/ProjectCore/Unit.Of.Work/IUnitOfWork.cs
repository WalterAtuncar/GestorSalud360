using Repositories.calendar;
using Repositories.Login;
using Repositories.person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit.Of.Work
{
    public interface IUnitOfWork
    {
        ILoginRepository ILogin { get; }
        ICalendarRepository ICalendar { get; }
        IPersonRepository IPerson { get; }
    }
}
