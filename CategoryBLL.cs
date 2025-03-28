using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace project1.BLL
{
    public class CategoryBLL
    {
        CategoryDAL dal = new CategoryDAL();

        public bool AddCategory(string categoryName)
        {
            return dal.InsertCategory(categoryName);
        }

        public DataTable GetCategories()
        {
            return dal.FetchCategories();
        }
    }
}