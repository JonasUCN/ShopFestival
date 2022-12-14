using Dapper;
using Database_Service.LogicController;
using Database_Service.Model;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Database_Service.DataAccess
{
    /// <summary>
    /// This class provides methods for accessing and manipulating sale order data in the database.
    /// </summary>
    public class DBAccessSaleOrder
    {

        private LogicProductController _LogicProductController;
        private string connectionString;
        public DBAccessSaleOrder()
        {
            
            connectionString = "Server=hildur.ucn.dk; Database=DMA-CSD-S211_10407530;User=DMA-CSD-S211_10407530;Password=Password1!;TrustServerCertificate=true;"; 
            _LogicProductController = new LogicProductController();
        }

        /// <summary>
        /// This method retrieves a list of all sale orders from the database.
        /// </summary>
        /// <returns>A list of sale orders.</returns>
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

        /// <summary>
        /// This method creates a new sale order in the database.
        /// </summary>
        /// <param name="saleOrder">The sale order to be created.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        public async Task<bool> CreateSaleOrder(SaleOrder saleOrder)
        {
            // Define the SQL statements to insert a sale order, order line, and order address
            string sql = "INSERT INTO[dbo].[SaleOrder] ([orderDate],[orderStatus],[customerNo],[orderAddressNo]) output INSERTED.orderNo VALUES (@OrderDate,@Status,@customerNo,@orderAddressNo)";
            string sql2 = "INSERT INTO[dbo].[OrderLine] ([quantity],[orderNo],[productNo]) VALUES (@Quantity,@OrderNo,@id)";
            string sql3 = "INSERT INTO[dbo].[OrderAddress] ([zipcode], [street], [streetNo]) output INSERTED.orderAddressNo VALUES (@Zipcode,@Street,@StreetNo)";

            // Initialize SqlConnection and SqlTransaction objects
            var connection = new SqlConnection(connectionString);
            SqlTransaction transaction;
            
            // Open the connection and start the transaction
            connection.Open();
            transaction = connection.BeginTransaction(IsolationLevel.Serializable);
            bool state = false;

            try
            {
                // Create a new SqlCommand object to insert an order address
                using (var cmd3 = new SqlCommand(sql3, connection))
                {
                    // Add parameters for the zipcode, street, and street number
                    cmd3.Parameters.AddWithValue("Zipcode", saleOrder.OrderAddress.zipcode);
                    cmd3.Parameters.AddWithValue("Street", saleOrder.OrderAddress.Street);
                    cmd3.Parameters.AddWithValue("StreetNo", saleOrder.OrderAddress.streetNo);

                    // Set the connection and transaction properties of the command
                    cmd3.Connection = connection;
                    cmd3.Transaction = transaction;

                    // Execute the scalar and assign the result to the modified2 variable
                    int modified2 = (int)cmd3.ExecuteScalar();

                    // Set the OrderAddressNo property of the OrderAddress object
                    saleOrder.OrderAddress.OrderAddressNo = modified2;
                }

                // define the SQL INSERT and UPDATE statements for the customer data
                string sqlInsert = "INSERT INTO Customer ([fname], [lname], [zipcode], [street], [streetNo], [phone], [email], [userID]) VALUES (@fname, @lname, @zipcode, @street, @streetno, @phone, @email, @userID)";
                string sqlUpdate = "UPDATE Customer SET fname = @fname, lname = @lname, zipcode = @zipcode, street = @street, streetNo = @streetNo, phone = @phone where userID = @userID";

                // create a new SQL command and add the parameters for the customer dat
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

                    // set the connection and transaction for the command
                    cmd5.Connection = connection;
                    cmd5.Transaction = transaction;
                    
                    // check if a customer record with the given user ID already exists
                    cmd5.CommandText = "SELECT TOP 1 1 FROM Customer WHERE userID = '" + saleOrder.customer.userID + "';";
                    Object i = cmd5.ExecuteScalar();

                    // if no record exists, insert a new one using the sqlInsert statement
                    if (i == null)
                    {
                        cmd5.CommandText = sqlInsert;
                        cmd5.ExecuteNonQuery();
                    }
                    // otherwise, update the existing record using the sqlUpdate statement
                    else
                    {
                        cmd5.CommandText = sqlUpdate;
                        cmd5.ExecuteNonQuery();
                    }
                }

                // create a new SQL command and add the parameters for the sale order data
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("OrderDate", saleOrder.OrderDate);
                    cmd.Parameters.AddWithValue("Status", saleOrder.Status);
                    cmd.Parameters.AddWithValue("customerNo", saleOrder.customer.CustomerNo);
                    cmd.Parameters.AddWithValue("orderAddressNo", saleOrder.OrderAddress.OrderAddressNo);

                    // set the connection and transaction for the command
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;

                    // execute the command and get the number of rows affected
                    int modified = (int)cmd.ExecuteScalar();

                    // set the sale order number to the number of rows affected
                    saleOrder.OrderNo = modified;

                }
                // create a new SQL command and add the parameters for the Orderline data
                using (var cmd2 = new SqlCommand(sql2, connection))
                {
                    // set the connection and transaction for the command
                    cmd2.Connection = connection;
                    cmd2.Transaction = transaction;

                    // add parameters for the query
                    cmd2.Parameters.Add("@Quantity", SqlDbType.Int);
                    cmd2.Parameters.Add("@OrderNo", SqlDbType.Int);
                    cmd2.Parameters.Add("@id", SqlDbType.Int);

                    // loop through each order line
                    foreach (var o in saleOrder.orderLines)
                    {
                        // set the values for the parameters
                        cmd2.Parameters["@Quantity"].Value = o.Quantity;
                        cmd2.Parameters["@OrderNo"].Value = saleOrder.OrderNo;
                        cmd2.Parameters["@id"].Value = o.Product.id;
                        
                        // execute the query
                        cmd2.ExecuteNonQuery();
                    }
                }
                // create a new SQL command
                using (var cmd4 = new SqlCommand())
                {
                    // set the connection and transaction for the command
                    cmd4.Connection = connection;
                    cmd4.Transaction = transaction;

                    // add a parameter for the product id
                    cmd4.Parameters.Add("@id", SqlDbType.Int);

                    // loop through each order line in the sale order
                    foreach (var o in saleOrder.orderLines)
                    {
                        // print the quantity of the current order line
                        Console.WriteLine(o.Quantity);

                        // set the command text to update the stock of the product with the specified id
                        // only update the stock if it is greater than or equal to the quantity of the order line
                        cmd4.CommandText = "UPDATE Product SET Stock -= " + o.Quantity + " where id = @id AND Stock >= " + o.Quantity + ";";

                        // set the value of the id parameter to the id of the product in the current order line
                        cmd4.Parameters["@id"].Value = o.Product.id;

                        // execute the command and store the number of modified rows
                        int modified = cmd4.ExecuteNonQuery();

                        // print the number of modified rows
                        Console.WriteLine(modified);

                        // if no rows were modified, set the state to false and break out of the loop
                        if (modified < 1)
                        {
                            state = false;
                            break;
                        }
                        // set the state to true
                        state = true;
                    }
                }

                // if the state is true, commit the transaction; otherwise, roll it back
                if (state)
                    transaction.Commit();
                else
                    transaction.Rollback();
            }
            catch
            {
                // roll back the transaction if an exception is thrown
                transaction.Rollback();
            }
            finally
            {
                // ensure that the connection is always closed
                connection.Close();
            }
            // return the state of the operations
            return state;
        }
    }

}

