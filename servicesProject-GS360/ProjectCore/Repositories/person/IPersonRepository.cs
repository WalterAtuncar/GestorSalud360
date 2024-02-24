using Models.Request;
using Models.Response.person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.person
{
    public interface IPersonRepository : IRepository<Models.Entities.person>
    {
        PatientsList BuscarPersonasConFiltro(FilterParams obj);
    }
}
