using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using project1.BLL;
using System.Data;

namespace project1
{
    public partial class AddProduct : System.Web.UI.Page
    {
        ProductBLL productBLL = new ProductBLL();
        CategoryBLL categoryBLL = new CategoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProducts();
            }
        }

        private void LoadCategories()
        {
            DataTable dt = categoryBLL.GetCategories();
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }

        protected void InsertProduct(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProductName.Text) &&
                ddlCategory.SelectedIndex > 0 &&
                decimal.TryParse(txtPrice.Text, out decimal price) &&
                int.TryParse(txtStock.Text, out int stock))
            {
                bool success = productBLL.AddProduct(txtProductName.Text, int.Parse(ddlCategory.SelectedValue), price, stock);
                if (success)
                {
                    lblMessage.Text = "Product added successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    LoadProducts();
                }
                else
                {
                    lblMessage.Text = "Failed to add product.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please fill all fields correctly.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadProducts()
        {
            GridView1.DataSource = productBLL.GetProducts();
            GridView1.DataBind();
        }
    }
}
