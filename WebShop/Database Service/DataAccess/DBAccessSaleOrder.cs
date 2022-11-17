using Dapper;
using ModelLayer;
using System.Data.SqlClient;
using System.Drawing;

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

        public async Task<int> CreateSaleOrder(SaleOrder saleOrder)
        {
            string sql = "INSERT INTO[dbo].[SaleOrder] ([orderDate],[processedDate],[orderStatus],[customerNo]) output INSERTED.orderNo VALUES (@OrderDate,@ProccessedDate,@OrderStatus,@customerNo)";

            using (var connection = new SqlConnection(connectionString))
                using(SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("OrderDate", saleOrder.OrderDate);
                cmd.Parameters.AddWithValue("ProccessedDate", saleOrder.ProcessedDate);
                cmd.Parameters.AddWithValue("OrderStatus", saleOrder.Status);
                cmd.Parameters.AddWithValue("customerNo", saleOrder.customer.CustomerNo);
                connection.Open();

                int modified = (int)cmd.ExecuteScalar();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return modified;
            }
        }

        public async Task<int> CreateSaleOrder2(SaleOrder saleOrder)
        {
            string sql = "INSERT INTO[dbo].[SaleOrder] ([orderDate],[processedDate],[orderStatus],[customerNo]) VALUES (@OrderDate,@ProccessedDate,@OrderStatus,@customerNo)";
            bool succes = false;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql, new
                {
                    saleOrder.OrderDate,
                    saleOrder.ProcessedDate,
                    saleOrder.Status,
                    saleOrder.customer.CustomerNo

                }) ;
                if (result > 0)
                {
                    succes = true;
                }
            }

            return 1;
        }

    }
}
