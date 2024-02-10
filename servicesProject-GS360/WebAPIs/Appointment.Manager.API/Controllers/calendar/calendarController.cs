using Business.Logic.ILogic.calendar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request;

namespace Appointment.Manager.API.Controllers.calendar
{
    [Route("api/calendar")]
    [ApiController]
    public class calendarController : ControllerBase
    {
        private ICalendarLogic _calendar;
        public ResponseDTO _ResponseDTO;
        public calendarController(ICalendarLogic calendar)
        {
            _calendar = calendar;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _calendar.GetList()));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }        

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetByIdString(string id)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _calendar.GetById(id)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Models.Entities.calendar.calendar obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _calendar.Insert(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPost]
        [Route("ObtenerListaAgendados")]
        public IActionResult ObtenerListaAgendados([FromBody] FiltroAgendaDTO obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _calendar.ObtenerListaAgendados(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Models.Entities.calendar.calendar obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _calendar.Update(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody]  Models.Entities.calendar.calendar obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                return Ok(_ResponseDTO.Success(_ResponseDTO, _calendar.Delete(obj)));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
