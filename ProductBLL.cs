using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace project1
{
    public class ProductBLL
    {
        ProductDAL dal = new ProductDAL();

        public bool AddProduct(string productName, int categoryId, decimal price, int stock)
        {
            return dal.AddProduct(productName, categoryId, price, stock);
        }

        public DataTable GetProducts()
        {
            return dal.GetProducts();
        }


        // ✅ Add Update Product method
        public bool UpdateProduct(int productId, string name, int categoryId, decimal price, int stock)
        {
            return dal.ModifyProduct(productId, name, categoryId, price, stock);
        }

        // ✅ Add Delete Product method
        public bool DeleteProduct(int productId)
        {
            return dal.RemoveProduct(productId);
        }
    }

}