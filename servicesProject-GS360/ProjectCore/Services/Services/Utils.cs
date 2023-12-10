using Services.IServices.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Models.Response.Login;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Services.Services
{
    public class Utils : IUtils
    {
        private IConfiguration _configuration;
        public Utils(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(UserResponseDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("jwtPassword"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.i_SystemUserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Encrypt(string pData)
        {
            UnicodeEncoding parser = new UnicodeEncoding();
            byte[] _original = parser.GetBytes(pData);
            MD5CryptoServiceProvider Hash = new MD5CryptoServiceProvider();
            byte[] _encrypt = Hash.ComputeHash(_original);
            return Convert.ToBase64String(_encrypt);
        }
    }
}
