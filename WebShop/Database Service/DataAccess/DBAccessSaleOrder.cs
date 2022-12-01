using Dapper;
using ModelLayer;
using System.Data.SqlClient;
using System.Drawing;

namespace Database_Service.DataAccess
{
    public class DBAccessSaleOrder : IDBAccessSaleOrder
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
            string sql = "INSERT INTO[dbo].[SaleOrder] ([orderDate],[orderStatus],[customerNo]) output INSERTED.orderNo VALUES (@OrderDate,@Status,@customerNo)";
            using (var connection = new SqlConnection(connectionString))
            { 
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("OrderDate", saleOrder.OrderDate);
                    cmd.Parameters.AddWithValue("Status", saleOrder.Status);
                    cmd.Parameters.AddWithValue("customerNo", saleOrder.customer.CustomerNo);
                    connection.Open();

                    int modified = (int)cmd.ExecuteScalar();
                    Console.WriteLine(modified + " orderNo");
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    return modified;
                }
            }
        }

        public async Task CreateOrderLine(SaleOrder saleOrder)
        {
            string sql = "INSERT INTO[dbo].[OrderLine] ([quantity],[orderNo],[productNo]) VALUES (@Quantity,@OrderNo,@id)";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var i in saleOrder.orderLines)
                {
                    connection.Execute(sql, new
                    {
                        i.Quantity,
                        saleOrder.OrderNo,
                        i.Product.id
                    });
                }
            }
        }
    }

}

