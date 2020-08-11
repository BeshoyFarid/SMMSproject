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
    public partial class usersignup : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
      
   
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            signupnewmem();
        }

        void signupnewmem()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
               if(password.Text.Trim() == conpass.Text.Trim())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Name,phone,email,address,password,bDate) VALUES (@Name,@phone,@email,@address,@password,@bDate)", con);
                    cmd.Parameters.AddWithValue("@Name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                    cmd.Parameters.AddWithValue("@bDate", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Go to login page');</script>");
                }
                else
                {
                    Response.Write("<script>alert('confirm password');</script>");
                }
               
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}