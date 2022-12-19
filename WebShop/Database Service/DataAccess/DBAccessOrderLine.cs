using System.Data.SqlClient;

namespace Database_Service.DataAccess
{
    /// <summary>
    /// Class for accessing order line data in the database
    /// </summary>
    public class DBAccessOrderLine
    {
        /// <summary>
        /// Configuration manager for accessing connection string information
        /// </summary>
        private ConfigurationManager configuration = new ConfigurationManager();

        /// <summary>
        /// Connection string for connecting to the database
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Constructor for creating a new instance of the DBAccessOrderLine class
        /// </summary>
        public DBAccessOrderLine()
        {
            string String = configuration["ConnectionStringToUse"];
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; 

        }
    }
}
