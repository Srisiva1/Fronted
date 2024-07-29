using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UserSendOwnerRequest : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
  SqlDataAdapter adp;
    DataTable dt;
    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from otable where userid not in (select ownerid from ortable where userid=@userid and (status='Accepted' or status='Request'))", con);
        adp.SelectCommand.Parameters.AddWithValue("userid", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
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
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "sr")
            {
                string ownerid = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();

                cmd = new SqlCommand("Select isnull(max(rid), 100)+1 from ortable", con);
                int rid = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("insert into ortable(rid,userid,ownerid,rdate,status) values(@rid,@userid,@ownerid,@rdate,@status)", con);
                cmd.Parameters.AddWithValue("rid", rid);
                cmd.Parameters.AddWithValue("userid", TextBox1.Text);
                cmd.Parameters.AddWithValue("ownerid", ownerid);
                cmd.Parameters.AddWithValue("rdate", DateTime.Now.ToString("dd-MMM-yyyy"));
                cmd.Parameters.AddWithValue("status", "Request");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = "Request Details Inserted......";

                bindgrid();



            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}