using Models.Request;
using Models.Response.person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.ILogic.person
{
    public interface IPersonLogic
    {
        bool Update(Models.Entities.person obj);
        int Insert(Models.Entities.person obj);
        IEnumerable<Models.Entities.person> GetList();
        Models.Entities.person GetByIdString(string id);
        PatientsList BuscarPersonasConFiltro(FilterParams obj);
    }
}
