using Database_Service.Model;

/// <summary>
/// Interface for accessing ASP.NET user data in a database
/// </summary>
namespace Database_Service.DataAccess
{
    public interface IDBASP_NetUser
    {
        /// <summary>
        /// Get a single user from the database by username
        /// </summary>
        User GetUser(string userName);
    }
}
