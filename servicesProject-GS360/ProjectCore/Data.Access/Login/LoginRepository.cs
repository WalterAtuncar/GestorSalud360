using Dapper;
using Models.Request;
using Models.Response.Login;
using Repositories.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Login
{
    public class LoginRepository : Repository<UserLoginDTO>, ILoginRepository
    {
        public LoginRepository(string _connectionString) : base(_connectionString)
        {
        }

        public UserResponseDTO Login(UserLoginDTO obj)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@User", obj.User);
                    parameters.Add("@Password", obj.Password);

                    return connection.Query<UserResponseDTO>("[dbo].[spValidateSystemUser_Login]", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
    }
}
