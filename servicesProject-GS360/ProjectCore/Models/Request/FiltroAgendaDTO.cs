using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class FiltroAgendaDTO
    {
        public DateTime? FechaInicio { get; set; }
        public int? TipoServicio { get; set; }
        public int? Cola { get; set; }
        public string Paciente { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Servicio { get; set; }
        public int? Vip { get; set; }
        public string NroDocumento { get; set; }
        public int? Modalidad { get; set; }
        public int? EstadoCita { get; set; }
    }
}
