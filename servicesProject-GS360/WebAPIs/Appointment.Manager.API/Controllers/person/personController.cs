using Business.Logic.ILogic.person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request;
using Models.Response.person;

namespace Appointment.Manager.API.Controllers.person
{
    [Route("api/person")]
    [ApiController]
    public class personController : ControllerBase
    {
        private IPersonLogic _person;
        public ResponseDTO _ResponseDTO;
        public personController(IPersonLogic person)
        {
            _person = person;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _person.GetList()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpGet]
        [Route("GetByIdString/{id}")]
        public IActionResult GetByIdString(string id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _person.GetByIdString(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Models.Entities.person obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _person.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("BuscarPersonasConFiltro")]
        public IActionResult BuscarPersonasConFiltro([FromBody] FilterParams obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                PatientsList patients = _person.BuscarPersonasConFiltro(obj);
                return Ok(_ResponseDTO.Success(_ResponseDTO, patients));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Models.Entities.person obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _person.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
