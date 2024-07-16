using Data.Access.calendar;
using Data.Access.Login;
using Data.Access.person;
using Repositories.calendar;
using Repositories.Login;
using Repositories.person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit.Of.Work;

namespace Data.Access
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILoginRepository ILogin { get; }

        public ICalendarRepository ICalendar { get; }

        public IPersonRepository IPerson { get; }

        public UnitOfWork(string connectionString)
        {
            ILogin = new LoginRepository(connectionString);
            ICalendar = new calendarRepository(connectionString);
            IPerson = new personRepository(connectionString);
        }        
    }
}
