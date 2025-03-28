using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using project1.BLL;

namespace project1.Admin
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        ProductBLL productBLL = new ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            GridView1.DataSource = productBLL.GetProducts();
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadProducts();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int productId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string productName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtProductName")).Text;
            int categoryId = Convert.ToInt32(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlCategory")).SelectedValue);
            decimal price = Convert.ToDecimal(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPrice")).Text);
            int stock = Convert.ToInt32(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtStock")).Text);

            productBLL.UpdateProduct(productId, productName, categoryId, price, stock);
            GridView1.EditIndex = -1;
            LoadProducts();
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadProducts();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            productBLL.DeleteProduct(productId);
            LoadProducts();
        }

       

    }
}
