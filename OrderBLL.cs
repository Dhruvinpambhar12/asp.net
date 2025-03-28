using System;
using System.Data;

namespace project1
{
    public class OrderBLL
    {
        OrderDAL orderDAL = new OrderDAL();

        // Get Orders
        public DataTable GetOrders()
        {
            return orderDAL.GetOrders();
        }

        // Add Order
        public int AddOrder(string customerName, decimal totalAmount)
        {
            return orderDAL.AddOrder(customerName, totalAmount);
        }

        // Delete Order
        public bool DeleteOrder(int orderId)
        {
            return orderDAL.DeleteOrder(orderId);
        }
    }
}
