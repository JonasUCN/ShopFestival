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
            //configuration.GetConnectionString(String); FIX KIG NED
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; 
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
                using (var cmd3 = new SqlCommand(sql3, connection))
                {
                    cmd3.Parameters.AddWithValue("Zipcode", saleOrder.OrderAddress.zipcode);
                    cmd3.Parameters.AddWithValue("Street", saleOrder.OrderAddress.Street);
                    cmd3.Parameters.AddWithValue("StreetNo", saleOrder.OrderAddress.streetNo);

                    cmd3.Connection = connection;
                    cmd3.Transaction = transaction;

                    int modified2 = (int)cmd3.ExecuteScalar();
                    saleOrder.OrderAddress.OrderAddressNo = modified2;
                }

                string sqlInsert = "INSERT INTO Customer ([fname], [lname], [zipcode], [street], [streetNo], [phone], [email], [userID]) VALUES (@fname, @lname, @zipcode, @street, @streetno, @phone, @email, @userID)";
                string sqlUpdate = "UPDATE Customer SET fname = @fname, lname = @lname, zipcode = @zipcode, street = @street, streetNo = @streetNo, phone = @phone where userID = @userID";

                using (var cmd5 = new SqlCommand())
                {
                    cmd5.Parameters.AddWithValue("fname", saleOrder.customer.fname);
                    cmd5.Parameters.AddWithValue("lname", saleOrder.customer.lname);
                    cmd5.Parameters.AddWithValue("zipcode", saleOrder.customer.ZipCode);
                    cmd5.Parameters.AddWithValue("street", saleOrder.customer.Street);
                    cmd5.Parameters.AddWithValue("streetNo", saleOrder.customer.StreetNo);
                    cmd5.Parameters.AddWithValue("phone", saleOrder.customer.Phone);
                    cmd5.Parameters.AddWithValue("email", saleOrder.customer.Email);
                    cmd5.Parameters.AddWithValue("userID", saleOrder.customer.userID);

                    cmd5.Connection = connection;
                    cmd5.Transaction = transaction;

                    cmd5.CommandText = "SELECT TOP 1 1 FROM Customer WHERE userID = '" + saleOrder.customer.userID + "';";
                    Object i = cmd5.ExecuteScalar();

                    if (i == null)
                    {
                        cmd5.CommandText = sqlInsert;
                        cmd5.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd5.CommandText = sqlUpdate;
                        cmd5.ExecuteNonQuery();
                    }
                }

                using (var cmd = new SqlCommand(sql, connection))
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
                
                using (var cmd4 = new SqlCommand())
                {
                    cmd4.Connection = connection;
                    cmd4.Transaction = transaction;
                    cmd4.Parameters.Add("@id", SqlDbType.Int);

                    foreach (var o in saleOrder.orderLines)
                    {
                        Console.WriteLine(o.Quantity);
                        cmd4.CommandText = "UPDATE Product SET Stock -= " + o.Quantity + " where id = @id AND Stock >= " + o.Quantity + ";";
                        
                        cmd4.Parameters["@id"].Value = o.Product.id;
                        int modified = cmd4.ExecuteNonQuery();
                        Console.WriteLine(modified);
                        if(modified < 1)
                        {
                            throw new Exception();
                        }
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
            }
            finally
            {
                connection.Close();
            }

            return state;
        }
    }

}

