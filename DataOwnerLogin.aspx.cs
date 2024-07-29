using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class DataOwnerLogin : System.Web.UI.Page
{
 SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";

            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
          
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            //Register,Accepted,Rejected
            cmd = new SqlCommand("select * from otable where userid=@userid and pword=@pword ", con);
            cmd.Parameters.AddWithValue("userid", TextBox1.Text);
            cmd.Parameters.AddWithValue("pword", TextBox2.Text);
            rs = cmd.ExecuteReader();
            string status = "";
            if (rs.Read())
            {
                status = rs["status"].ToString(); 
              
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Invalid UserId or Password....";
                return;
            }

            if (status.Equals("Register"))
            {
                Label1.Text = "Your Status is Register.Process is Going on.Please Wait.....";
                return;
            }
            else if (status.Equals("Rejected"))
            {
                Label1.Text = "Your Status is Rejected.You are not Login.....";
                return;
            }

            else if (status.Equals("Accepted"))
            {
                Session.Add("OwnerId", TextBox1.Text);

                Response.Redirect("OwnerFileUploading.aspx");
            }
          
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}