using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class OwnerViewUploadFileDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    DataTable dt;
    void bindgrid(string userid)
    {
        adp = new SqlDataAdapter("select * from futable where userid=@userid", con);
        adp.SelectCommand.Parameters.AddWithValue("userid", userid);
        dt = new DataTable();
        adp.Fill(dt);
        //int i = 0;
        //for (i = 0; i < dt.Rows.Count; i++)
        //{
        //    string fname = dt.Rows[i]["FileName"].ToString();
        //    fname = fname.Substring(fname.LastIndexOf("_") + 1);
        //    dt.Rows[i]["FileName"] = fname;
        //}
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m4 = (Menu)Master.FindControl("Menu4");
            m4.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["OwnerId"] != null)
                {
                    TextBox1.Text = Session["OwnerId"].ToString();
                    bindgrid(Session["OwnerId"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}