using project1.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CategoryBLL categoryBLL = new CategoryBLL();
        ProductBLL productBLL = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProducts();
                
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Get the CommandArgument value
            string cmdArg = btn.CommandArgument;

            // Debugging: Print the CommandArgument value to the browser console
            Response.Write("<script>console.log('CommandArgument: " + cmdArg + "');</script>");

            // Check if CommandArgument is empty
            if (string.IsNullOrEmpty(cmdArg))
            {
                Response.Write("<script>alert('Error: CommandArgument is empty or null!');</script>");
                return;
            }

            // Convert CommandArgument to an integer
            if (!int.TryParse(cmdArg, out int productId))
            {
                Response.Write("<script>alert('Invalid Product ID! Received: " + cmdArg + "');</script>");
                return;
            }

            // Get cart from session or create a new one
            List<int> cart = Session["Cart"] as List<int> ?? new List<int>();

            // Add product to cart
            cart.Add(productId);

            // Store updated cart in session
            Session["Cart"] = cart;

            Response.Write("<script>alert('Product added to cart!');</script>");
            Response.Redirect("Cart.aspx");
        }




        private void LoadCategories()
        {
            DataTable dt = categoryBLL.GetCategories();
            showcategory.DataSource = dt;
            showcategory.DataTextField = "CategoryName"; // Display category name
            showcategory.DataValueField = "CategoryID";  // Hidden category ID
            showcategory.DataBind();
        }

        private void LoadProducts()
        {
            DataTable dt = productBLL.GetProducts();
            showproduct.DataSource = dt;
            showproduct.DataTextField = "ProductName"; // Display product name
            showproduct.DataValueField = "ProductID";  // Hidden product ID
            showproduct.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("webform2.aspx");
        }


        protected void showcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = showcategory.SelectedItem.Text;
            Response.Write("<script>alert('You selected: " + selectedCategory + "');</script>");

        }

        protected void showproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = showproduct.SelectedItem.Text;
            Response.Write("<script>alert('Product selected: " + selectedProduct + "');</script>");

        }
    }
}