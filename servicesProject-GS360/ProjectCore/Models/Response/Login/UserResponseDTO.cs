using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response.Login
{
    public class UserResponseDTO
    {
        public int id { get; set; }
        public string img { get; set; }
        public string username { get; set; }
        public string personId { get; set; }
        public int? professionId { get; set; } 
        public int? roleId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
    }
}
