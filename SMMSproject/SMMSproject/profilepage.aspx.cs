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
    public partial class profilepage : System.Web.UI.Page
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
                if (Session["role"].Equals("user"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM order WHERE cus_id='"+ Session["cus_id"] +"'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    DataTable dt = new DataTable();
                    da.Fill(ds);
                    DataList1.DataSource = ds;
                    DataList1.DataBind();
                    con.Close();
                }
               
            }
            catch (Exception)
            {

            }
        }

    }
}