using ModelLayer;
using System.Data.SqlClient;

namespace Database_Service.DataAccess
{
    public class DBAccessOrderLine
    {
        private ConfigurationManager configuration = new ConfigurationManager();
        private string connectionString;

        public DBAccessOrderLine()
        {
            string String = configuration["ConnectionStringToUse"];
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; //configuration.GetConnectionString(String);

        }

        
    }
}
