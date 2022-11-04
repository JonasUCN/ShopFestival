using System.Data.SqlClient;
using Dapper;
using Model;
using Microsoft.Extensions.Configuration;

namespace Database_Service.DataAccess
{
    public class DBAccessSaleOrder
    {
        ConfigurationManager configuration = new ConfigurationManager();

        public string connectionString { get; set; }

        public DBAccessSaleOrder()
        {
            string String = configuration["ConnectionStringToUse"];
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;"; //configuration.GetConnectionString(String);
        }
        public async Task<List<SaleOrder>> GetAllSaleOrders()
        {
            string sql = "select * from SaleOrder";
            List<SaleOrder> saleOrders = new List<SaleOrder>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                saleOrders = (List<SaleOrder>)connection.Query<SaleOrder>(sql);
            }

            return saleOrders;

        }
    }
}
