using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMMSproject
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            loginfun();
        }
        void loginfun()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE email='" + TextBox1.Text.Trim() + "'and password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["username"] = dr.GetValue(1).ToString();
                        Session["role"] = "user";
                        Session["cusid"] = dr.GetValue(0);
                        Session["phone"] = dr.GetValue(2).ToString();
                        Session["address"] = dr.GetValue(4).ToString();
                    }
                    Response.Redirect("main.aspx");
                }
                else
                {
                    Response.Write("<script>alert('invalid user or password')</script>");
                }
            }
            catch(Exception)
            {
                Response.Write("<script>alert('error while loading')</script>");
            }
        }
    }
}