using Dapper;
using ModelLayer;
using System.Data.SqlClient;

namespace Database_Service.DataAccess
{
    public class DBAccessSaleOrder
    {


        public string connectionString;
        public DBAccessSaleOrder()
        {
            
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; //configuration.GetConnectionString(String);

        }
        public async Task<List<SaleOrder>> GetAllSaleOrders()
        {
            string sql = "select * from SaleOrder";
            List<SaleOrder> saleOrder = new List<SaleOrder>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                saleOrder = (List<SaleOrder>)connection.Query<SaleOrder>(sql);
            }
            return saleOrder;

        }

    }
}
