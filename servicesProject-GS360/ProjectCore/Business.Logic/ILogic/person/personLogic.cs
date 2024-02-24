using Models.Request;
using Models.Response.person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit.Of.Work;

namespace Business.Logic.ILogic.person
{
    public class personLogic : IPersonLogic
    {
        private IUnitOfWork _unitOfWork;

        public personLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PatientsList BuscarPersonasConFiltro(FilterParams obj)
        {
            return _unitOfWork.IPerson.BuscarPersonasConFiltro(obj);
        }

        public Models.Entities.person GetByIdString(string id)
        {
            return _unitOfWork.IPerson.GetById(id);
        }

        public IEnumerable<Models.Entities.person> GetList()
        {
            return _unitOfWork.IPerson.GetList();
        }

        public int Insert(Models.Entities.person obj)
        {
            return _unitOfWork.IPerson.Insert(obj);
        }

        public bool Update(Models.Entities.person obj)
        {
            return _unitOfWork.IPerson.Update(obj);
        }
    }
}
