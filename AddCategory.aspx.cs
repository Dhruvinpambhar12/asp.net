using project1.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project1.Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        CategoryBLL bll = new CategoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        protected void InsertCategory(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                bool success = bll.AddCategory(txtCategory.Text);
                if (success)
                {
                    lblMessage.Text = "Category added successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    LoadCategories();
                }
                else
                {
                    lblMessage.Text = "Failed to add category.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please enter a category name.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadCategories()
        {
            GridView1.DataSource = bll.GetCategories();
            GridView1.DataBind();
        }
    }
}