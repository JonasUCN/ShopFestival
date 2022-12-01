using Dapper;
using Database_Service.LogicController;
using ModelLayer;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Database_Service.DataAccess
{
    public class DBAccessSaleOrder
    {

        private LogicProductController _LogicProductController;
        private string connectionString;
        public DBAccessSaleOrder()
        {
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; //configuration.GetConnectionString(String);
            _LogicProductController = new LogicProductController();
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

        public async Task<bool> CreateSaleOrder(SaleOrder saleOrder)
        {
            string sql = "INSERT INTO[dbo].[SaleOrder] ([orderDate],[orderStatus],[customerNo],[orderAddressNo]) output INSERTED.orderNo VALUES (@OrderDate,@Status,@customerNo,@orderAddressNo)";
            string sql2 = "INSERT INTO[dbo].[OrderLine] ([quantity],[orderNo],[productNo]) VALUES (@Quantity,@OrderNo,@id)";
            string sql3 = "INSERT INTO[dbo].[OrderAddress] ([zipcode], [street], [streetNo]) output INSERTED.orderAddressNo VALUES (@Zipcode,@Street,@StreetNo)";

            var connection = new SqlConnection(connectionString);
            SqlTransaction transaction;
            connection.Open();
            transaction = connection.BeginTransaction();
            bool state = false;

            try
            {
                using (SqlCommand cmd3 = new SqlCommand(sql3, connection))
                {
                    cmd3.Parameters.AddWithValue("Zipcode", saleOrder.OrderAddress.zipcode);
                    cmd3.Parameters.AddWithValue("Street", saleOrder.OrderAddress.Street);
                    cmd3.Parameters.AddWithValue("StreetNo", saleOrder.OrderAddress.streetNo);

                    cmd3.Connection = connection;
                    cmd3.Transaction = transaction;

                    int modified2 = (int)cmd3.ExecuteScalar();
                    saleOrder.OrderAddress.OrderAddressNo = modified2;
                }

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("OrderDate", saleOrder.OrderDate);
                    cmd.Parameters.AddWithValue("Status", saleOrder.Status);
                    cmd.Parameters.AddWithValue("customerNo", saleOrder.customer.CustomerNo);
                    cmd.Parameters.AddWithValue("orderAddressNo", saleOrder.OrderAddress.OrderAddressNo);

                    cmd.Connection = connection;
                    cmd.Transaction = transaction;

                    int modified = (int)cmd.ExecuteScalar();
                    saleOrder.OrderNo = modified;

                }

                using (var cmd2 = new SqlCommand(sql2, connection))
                {

                    cmd2.Connection = connection;
                    cmd2.Transaction = transaction;
                    cmd2.Parameters.Add("@Quantity", SqlDbType.Int);
                    cmd2.Parameters.Add("@OrderNo", SqlDbType.Int);
                    cmd2.Parameters.Add("@id", SqlDbType.Int);


                    foreach (var o in saleOrder.orderLines)
                    {
                        cmd2.Parameters["@Quantity"].Value = o.Quantity;
                        cmd2.Parameters["@OrderNo"].Value = saleOrder.OrderNo;
                        cmd2.Parameters["@id"].Value = o.Product.id;
                        cmd2.ExecuteNonQuery();
                    }
                }
                
                using (var cmd3 = new SqlCommand())
                {
                    cmd3.Connection = connection;
                    cmd3.Transaction = transaction;
                    cmd3.Parameters.Add("@id", SqlDbType.Int);

                    foreach (var o in saleOrder.orderLines)
                    {
                        cmd3.CommandText = "UPDATE Product SET Stock -= " + o.Quantity + " where id = @id AND Stock >= " + o.Quantity + ";";
                        
                        cmd3.Parameters["@id"].Value = o.Product.id;
                        cmd3.ExecuteNonQuery();
                    }
                }
                state = true;

                if (state)
                {
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }

            return state;
        }
    }

}

