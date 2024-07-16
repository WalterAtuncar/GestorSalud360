using Dapper;
using Models.Request;
using Models.Response.person;
using Repositories.person;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.person
{
    public class personRepository : Repository<Models.Entities.person>, IPersonRepository
    {
        public personRepository(string _connectionString) : base(_connectionString)
        {
        }

        public PatientsList BuscarPersonasConFiltro(FilterParams obj)
        {
            PatientsList patientsList = new PatientsList();
            var parameters = new DynamicParameters();
            parameters.Add("@filter", obj.filter, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@page", obj.page, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@pageSize", obj.pageSize, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@totalRows", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                patientsList.Patients = connection.Query<PatientDto>("[dbo].[BuscarPersonasConFiltro]", parameters, commandType: CommandType.StoredProcedure).ToList();
                patientsList.totalRows = parameters.Get<int>("@totalRows");
            }
            return patientsList;
        }
    }
}
