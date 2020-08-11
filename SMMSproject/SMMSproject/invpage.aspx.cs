using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMMSproject
{
    public partial class invpage : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static int price, quantity;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkproduct())
            {
                Response.Write("<script>alert('product alrady exist')</script>");
            }
            else
            {
                addnewproduct();
            }
        }

        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deletebyid();
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateitem();
        }
     
        // get id
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getdata();
        }

        void addnewproduct()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO product (id,proName,price,quantity,discrption,exDate,pro_image_link,supplierName) VALUES (@id,@proName,@price,@quantity,@discrption,@exDate,@pro_image_link,@supplierName)", con);
                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@proName",TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@price",TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@quantity", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@discrption", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@exDate", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@pro_image_link", "Image/1.jpg");
                cmd.Parameters.AddWithValue("@supplierName", DropDownList2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool checkproduct()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM product WHERE id='"+TextBox1.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                return false;
            }
        }

        void getdata()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM product WHERE id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["proName"].ToString();
                    TextBox10.Text = dt.Rows[0]["price"].ToString();
                    TextBox4.Text = dt.Rows[0]["quantity"].ToString();
                    DropDownList2.SelectedValue= dt.Rows[0]["supplierName"].ToString();
                    TextBox3.Text = dt.Rows[0]["exDate"].ToString();
                    TextBox6.Text = dt.Rows[0]["discrption"].ToString();

                    price = Convert.ToInt32(dt.Rows[0]["price"].ToString().Trim());
                    quantity = Convert.ToInt32(dt.Rows[0]["quantity"].ToString().Trim());
                }
                else
                {
                    Response.Write("<script>alert('not found')</script>");
                }
            }
            catch (Exception)
            {

            }
        }

      void updateitem()
        {
            try
            {
                if (checkproduct())
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE product SET proName=@proName, price=@price, quantity=@quantity, discrption=@discrption, exDate=@exDate, pro_image_link=@pro_image_link, supplierName=@supplierName WHERE id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@proName", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@quantity", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@discrption", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@exDate", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@pro_image_link", "Image/18.jpg");
                    cmd.Parameters.AddWithValue("@supplierName", DropDownList2.Text.Trim());


                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception)
            {

            }
        }
        void deletebyid()
        {
            try
            {
                if (checkproduct())
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM product WHERE id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}