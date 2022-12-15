using Dapper;
using Database_Service.Model;
using System.Data.SqlClient;

namespace Database_Service.DataAccess
{
    /// <summary>
    /// Represents a database access object for ASP.NET users.
    /// Implements the IDBASP_NetUser interface.
    /// </summary>
    public class DBASP_NetUser : IDBASP_NetUser
    {
        // readonly field that stores the connection string used to connect to the database
        readonly string connectionString;

        /// <summary>
        /// Constructor that takes an IConfiguration object and initializes the connectionString field.
        /// </summary>
        /// <param name="configuration">The IConfiguration object containing the connection string.</param>
        public DBASP_NetUser(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnectMsSqlString");
        }

        /// <summary>
        /// Method that returns a User object with the given userName.
        /// If no such user is found, returns null.
        /// </summary>
        /// <param name="userName">The userName of the User to be returned.</param>
        /// <returns>A User object with the given userName, or null if no such user is found.</returns>
        public User GetUser(string userName)
        {
            User user;

            // Query to be executed on the database
            string query = $"select UserName from AspNetUsers where userName = @UserName";

            // Use a SQL connection to execute the query and get the user
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                user = connection.QuerySingle<User>(query, new { UserName = userName });
            }
            return user;
        }
    }
}
