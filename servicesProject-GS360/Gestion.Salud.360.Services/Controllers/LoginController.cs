using Business.Logic.ILogic.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Request;

namespace Gestion.Salud._360.Services.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginLogic _login;
        public ResponseDTO _ResponseDTO;
        public LoginController(ILoginLogic login)
        {
            _login = login;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginDTO obj)
        {
            _ResponseDTO = new ResponseDTO();
            try
            {
                Thread.Sleep(5000);
                var user = _login.Login(obj);
                if (user != null)
                {
                    _ResponseDTO.token = _login.CreateToken(user);
                }
                return Ok(_ResponseDTO.Success(_ResponseDTO, user));
            }
            catch (Exception e)
            {
                return BadRequest(_ResponseDTO.Failed(_ResponseDTO, e.Message));
            }
        }
    }
}
