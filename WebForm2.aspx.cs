using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using System.Security.Permissions;

namespace project1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        String s = ConfigurationManager.ConnectionStrings["dbconnect"].ToString();
        String fnm, h1, h2, h3;
        string[] hb = new string[3];

        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
            filldrid();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            uploading();
            hobbies();
            getcon();

            for (int i = 0; i < 1; i++)
            {
                if (hb[i] == "Cricket")
                {
                    h1 = "Cricket";
                    i++;
                }
                else
                {
                    h1 = "null";
                    i++;
                }
                if (hb[i] == "vollyball")
                {
                    h2 = "vollyball";
                    i++;
                }
                else
                {
                    h2 = "null";
                    i++;
                }
                if (hb[i] == "football")
                {
                    h3 = "football";
                    i++;
                }
                else
                {
                    h3 = "null";
                }
            }

            cmd = new SqlCommand("INSERT INTO [PersonalDetails] (Name,Gender,Hobby1,Hobby2,Hobby3,City,Address,Country,Img) " +
                "VALUES  ('" + txtunm.Text + "','" + rdbgen.Text + "','" + h1 + "','" + h2 + "','" + h3 + "','" + txtcity.Text + "','" + txtadd.Text + "','" + ddlcountry.Text + "','" + fnm + "')", con);

            cmd.ExecuteNonQuery();
            filldrid();
        }

        void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        void uploading()
        {
            if (FileUpload1.HasFile)
            {
                fnm = "Data/" + FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(fnm));
            }
        }

        void hobbies()
        {
            for (int i = 0; i < hb.Length; i++)
            {
                if (Chkhb.Items[i].Selected == true)
                {
                    hb[i] = Chkhb.Items[i].Text;
                }
            }
        }

        void filldrid()
        {
            getcon();
            da = new SqlDataAdapter("select * from [PersonalDetails]", con);
            ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}