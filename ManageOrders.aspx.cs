using System;
using System.Data;
using System.Web.UI.WebControls;

namespace project1.Admin
{
    public partial class ManageOrders : System.Web.UI.Page
    {
        OrderBLL orderBLL = new OrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            GridView1.DataSource = orderBLL.GetOrders();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int orderId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            orderBLL.DeleteOrder(orderId);
            LoadOrders();
        }
    }
}
