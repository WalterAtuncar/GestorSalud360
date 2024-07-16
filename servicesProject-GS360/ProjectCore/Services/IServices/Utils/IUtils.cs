using Models.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices.Utils
{
    public interface IUtils
    {
        string CreateToken(UserResponseDTO user);
        string Encrypt(string pData);
    }
}
