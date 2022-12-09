using Database_Service.Model;

namespace Database_Service.DataAccess
{
    public interface IDBASP_NetUser
    {
        User GetUser(string userName);
    }
}
