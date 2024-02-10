using Dapper;
using Models.Request;
using Models.Response;
using Models.Response.Login;
using Repositories.calendar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.calendar
{
    public class calendarRepository : Repository<Models.Entities.calendar.calendar>, ICalendarRepository
    {
        public calendarRepository(string _connectionString) : base(_connectionString)
        {
        }

        public IEnumerable<ListaAgendaDTO> ObtenerListaAgendados(FiltroAgendaDTO obj)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@nroDoc", ValidateString(obj.NroDocumento));
                    parameters.Add("@fi", obj.FechaInicio);
                    parameters.Add("@ff", obj.FechaFin);
                    parameters.Add("@servicio", ValidateId(obj.Servicio));
                    parameters.Add("@modalidad", ValidateId(obj.Modalidad));
                    parameters.Add("@cola", ValidateId(obj.Cola));
                    parameters.Add("@vip", ValidateId(obj.Vip));
                    parameters.Add("@estadoCita", ValidateId(obj.EstadoCita));
                    parameters.Add("@paciente", ValidateString(obj.Paciente));

                    return connection.Query<ListaAgendaDTO>("[dbo].[GetObtenerListaAgendados_Optimizado]", parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        private static int? ValidateId(int? value) => value > 0 ? value : null;
        private static string ValidateString(string? value) => string.IsNullOrEmpty(value) ? null : value;
    }
}
