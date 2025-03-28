using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace project1
{
    public class ProductDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        // ✅ Insert Product
        public bool AddProduct(string productName, int categoryId, decimal price, int stock)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Product (ProductName, CategoryID, Price, Stock) VALUES (@ProductName, @CategoryID, @Price, @Stock)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Stock", stock);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        // ✅ Updated GetProducts() Method
        public DataTable GetProducts()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"
    SELECT 
        p.ProductID, 
        p.ProductName, 
        p.CategoryID,
        c.CategoryName,  
        p.Price, 
        p.Stock 
    FROM Product p
    JOIN Category c ON p.CategoryID = c.CategoryID";  // Update table name

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



        // ✅ Update Product (Fixed `con` issue)
        public bool ModifyProduct(int productId, string name, int categoryId, decimal price, int stock)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "UPDATE Product SET ProductName=@name, CategoryID=@categoryId, Price=@price, Stock=@stock WHERE ProductID=@productId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // ✅ Delete Product (Fixed `con` issue)
        public bool RemoveProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Product WHERE ProductID=@productId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@productId", productId);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
