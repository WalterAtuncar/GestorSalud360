using Business.Logic.ILogic.Login;
using Models.Request;
using Models.Response.Login;
using Services.IServices.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit.Of.Work;

namespace Business.Logic.Logic.Login
{
    public class LoginLogic : ILoginLogic
    {
        private IUnitOfWork _unitOfWork;
        private IUtils _utils;

        public LoginLogic(IUnitOfWork unitOfWork, IUtils utils)
        {
            _unitOfWork = unitOfWork;
            _utils = utils;
        }

        public string CreateToken(UserResponseDTO user)
        {
            return _utils.CreateToken(user);
        }

        public UserResponseDTO Login(UserLoginDTO obj)
        {
            obj.Password = _utils.Encrypt(obj.Password);
            return _unitOfWork.ILogin.Login(obj);
        }
    }
}
