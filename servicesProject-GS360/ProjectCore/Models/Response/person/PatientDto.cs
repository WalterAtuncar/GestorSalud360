using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response.person
{
    public class PatientDto
    {
        public string PersonId { get; set; }
        public string PersonImage64 { get; set; } = "https://images.freeimages.com/fic/images/icons/766/base_software/256/user1.png";
        public string DocNumber { get; set; }
        public string Name { get; set; }
        public int SexTypeId { get; set; }
        public string Gender { get; set; }
        public string AddressLocation { get; set; }
        public string TelephoneNumber { get; set; }
        public string Birthdate { get; set; }

    }

    public class PatientsList
    {
        public List<PatientDto> Patients { get; set; }
        public int totalRows { get; set; }
        public PatientsList()
        {
            Patients = new List<PatientDto>();
        }
    }
}
