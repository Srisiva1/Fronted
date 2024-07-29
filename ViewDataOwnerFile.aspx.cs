using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ViewDataOwnerFile : System.Web.UI.Page
{
    SqlConnection con;
 
    SqlDataAdapter adp;
    DataTable dt;

    void bindgrid()
    {

        adp = new SqlDataAdapter("select * from futable where userid=(select distinct(ownerid) from ortable where userid=@userid and status='Accepted') and fileid not in (select fid from frtable where ruserid=@ruserid and (status='Request' or status='Accepted'))", con);
        adp.SelectCommand .Parameters.AddWithValue("userid", TextBox1.Text);
        adp.SelectCommand.Parameters.AddWithValue("ruserid", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //frid, fid,fname, ownerid, ruserid,rdate, opublic key, uprivate key, status
        try
        {
            Label1.Text = "";
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    TextBox1.Text = Session["UserId"].ToString();
                    bindgrid();
                }
            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}