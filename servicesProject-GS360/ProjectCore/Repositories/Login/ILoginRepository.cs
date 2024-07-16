using Models.Request;
using Models.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Login
{
    public interface ILoginRepository : IRepository<UserLoginDTO>
    {
        UserResponseDTO Login(UserLoginDTO obj);
    }
}
