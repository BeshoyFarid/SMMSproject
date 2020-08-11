using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace SMMSproject
{
    public partial class product : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDataList();
            }
        }
        void fillDataList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM product", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                DataSet ds = new DataSet();

                DataTable dt = new DataTable();
                da.Fill(ds);
                DataList1.DataSource = ds;
                DataList1.DataBind();
                con.Close();
            }
            catch (Exception)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string x = ((LinkButton)sender).Text;
            int i = Int32.Parse(x);
                buyfun(i);
        }

        void buyfun(int z)
        {
            int q = z;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM product WHERE id='" + q + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["proid"] = q;
                    Session["proName"] = dr.GetValue(1).ToString();
                    Session["proPrice"] = dr.GetValue(2);
                }
               
            }
            dr.Close();
            SqlCommand cmdd = new SqlCommand("INSERT INTO orders (cus_id,pro_id,cus_name,pro_name,phone,address,pro_price) VALUES (@cus_id,@pro_id,@cus_name,@pro_name,@phone,@address,@pro_price)", con);
            cmdd.Parameters.AddWithValue("@cus_id", Session["cusid"]);
            cmdd.Parameters.AddWithValue("@pro_id", Session["proid"]);
            cmdd.Parameters.AddWithValue("@cus_name", Session["username"]);
            cmdd.Parameters.AddWithValue("@pro_name", Session["proName"]);
            cmdd.Parameters.AddWithValue("@phone", Session["phone"]);
            cmdd.Parameters.AddWithValue("@address", Session["address"]);
            cmdd.Parameters.AddWithValue("@pro_price", Session["proPrice"]);

            cmdd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("profilepage.aspx");
            
          

        }
    }
}