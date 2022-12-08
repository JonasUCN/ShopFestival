using Dapper;
using ModelLayer;
using System.Data.SqlClient;

namespace Database_Service.DataAccess
{
    public class DBASP_NetUser : IDBASP_NetUser
    {

        readonly string connectionString;

        public DBASP_NetUser(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnectMsSqlString");
        }

        public User GetUser(string userName)
        {
            User user;

            string query = $"select UserName from AspNetUsers where userName = @UserName";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                user = connection.QuerySingle<User>(query, new { UserName = userName });
            }
            return user;
        }
    }
}
