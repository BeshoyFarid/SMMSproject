using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMMSproject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty((String)Session["role"]))
                {
                    LinkButtonp.Visible = false;//cart
                    LinkButton1.Visible = false;//product page
                    LinkButton2.Visible = true; //login
                    LinkButton3.Visible = true;//signup
                    LinkButton4.Visible = false;//logout
                    LinkButton5.Visible = false;//hello

                    //admin links

                    LinkButton6.Visible = true; //admin login
                    LinkButton7.Visible = false;//employee
                    LinkButton8.Visible = false;//orders
                    LinkButton9.Visible = false;//product 
                    LinkButton10.Visible = false;//invintory
                }
                //user loged in
                else if (Session["role"].Equals("user"))
                {
                    LinkButtonp.Visible = false;//cart
                    LinkButton1.Visible = true;//product page
                    LinkButton2.Visible = false; //login
                    LinkButton3.Visible = false;//signup
                    LinkButton4.Visible = true;//logout
                    LinkButton5.Visible = true;//hello
                    LinkButton5.Text = "Hello " + Session["username"];

                    //admin links

                    LinkButton6.Visible = true; //admin login
                    LinkButton7.Visible = false;//employee
                    LinkButton8.Visible = false;//orders
                    LinkButton9.Visible = false;//product 
                    LinkButton10.Visible = false;//invintory
                }
                //admin login
                else if (Session["role"].Equals("admin"))
                {
                    LinkButtonp.Visible = false;//cart
                    LinkButton1.Visible = false;//product page
                    LinkButton2.Visible = false; //login
                    LinkButton3.Visible = false;//signup
                    LinkButton4.Visible = true;//logout
                    LinkButton5.Visible = true;//hello
                    LinkButton5.Text = "Hello admin";

                    //admin links

                    LinkButton6.Visible = false; //admin login
                    LinkButton7.Visible = true;//employee
                    LinkButton8.Visible = true;//orders
                    LinkButton9.Visible = true;//product 
                    LinkButton10.Visible = true;//invintory
                }

            }
            catch (Exception ex )
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            //no one loged in
          
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["role"] = "";


            LinkButton2.Visible = true; //login
            LinkButton3.Visible = true;//signup
            LinkButton4.Visible = false;//logout
            LinkButton5.Visible = false;//hello

            //admin links

            LinkButton6.Visible = true; //admin login
            LinkButton7.Visible = false;//employee
            LinkButton8.Visible = false;//orders
            LinkButton9.Visible = false;//product 
            LinkButton10.Visible = false;//invintory
            Response.Redirect("main.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("empage.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("orderpage.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("product.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("invpage.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("product.aspx");
        }

        protected void LinkButtonp_Click(object sender, EventArgs e)
        {
            Response.Redirect("profilepage.aspx");
        }
    }
}