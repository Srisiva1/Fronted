using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class OwnerViewRequestInformation : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    void bindgrid()
    {
        adp = new SqlDataAdapter("select u1.name, u1.emailid,u1.mno,u1.userid,o1.rid,o1.rdate from utable u1, ortable o1 where u1.userid=o1.userid and o1.ownerid=@ownerid and o1.status='Request' ", con);
        adp.SelectCommand.Parameters.AddWithValue("ownerid", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
     protected void Page_Load(object sender, EventArgs e)
    {
        //OwnerId
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
             int rid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
             if (e.CommandName == "ac")
             {
                 cmd = new SqlCommand("select publickey from otable where userid=@userid", con);
                 cmd.Parameters.AddWithValue("userid", TextBox1.Text);
                 rs = cmd.ExecuteReader();
                 string publickey = "";
                 if (rs.Read())
                 {
                     publickey = rs["publickey"].ToString();
                     rs.Close();
                     cmd.Dispose();
                 }
                 else
                 {
                     rs.Close();
                     cmd.Dispose();
                     Label1.Text = "Record Not Found.Check OTable.....";
                     return;
                 }

                 cmd = new SqlCommand("update ortable set opublickey=@opublickey,status=@status where rid=@rid", con);
                 cmd.Parameters.AddWithValue("opublickey", publickey);
                 cmd.Parameters.AddWithValue("status", "Accepted");
                 cmd.Parameters.AddWithValue("rid", rid);
                 cmd.ExecuteNonQuery();
                 cmd.Dispose();
                 Label1.Text = "Status Updated.....";
                 bindgrid();
             }
             else if (e.CommandName == "re")
             {
                 cmd = new SqlCommand("update ortable set status=@status where rid=@rid", con);       
                 cmd.Parameters.AddWithValue("status", "Rejected");
                 cmd.Parameters.AddWithValue("rid", rid);
                 cmd.ExecuteNonQuery();
                 cmd.Dispose();
                 Label1.Text = "Status Updated.....";
                 bindgrid();
             }
         }
         catch (Exception ex)
         {
             Label1.Text = ex.Message;
         }
     }
}