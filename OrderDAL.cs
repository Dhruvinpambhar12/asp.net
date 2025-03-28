using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace project1
{
    public class OrderDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // Get All Orders
        public DataTable GetOrders()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Orders";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Insert Order
        public int AddOrder(string customerName, decimal totalAmount)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Orders (CustomerName, TotalAmount) OUTPUT INSERTED.OrderID VALUES (@CustomerName, @TotalAmount)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerName", customerName);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                con.Open();
                int orderId = (int)cmd.ExecuteScalar();
                return orderId;
            }
        }

        // Delete Order
        public bool DeleteOrder(int orderId)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Orders WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OrderID", orderId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
