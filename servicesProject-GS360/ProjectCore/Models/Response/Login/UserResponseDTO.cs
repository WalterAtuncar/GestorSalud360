using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response.Login
{
    public class UserResponseDTO
    {
        public int i_SystemUserId { get; set; }
        public string v_UserName { get; set; }
        public string v_PersonId { get; set; }
        public int? i_RolVentaId { get; set; } 
        public int? i_ProfesionId { get; set; }
    }
}
