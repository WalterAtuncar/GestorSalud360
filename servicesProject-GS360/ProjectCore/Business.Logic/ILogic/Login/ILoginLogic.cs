using Models.Request;
using Models.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic.ILogic.Login
{
    public interface ILoginLogic
    {
        string CreateToken(UserResponseDTO user);
        UserResponseDTO Login(UserLoginDTO obj);
    }
}
