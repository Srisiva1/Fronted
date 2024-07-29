using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class DataUserRegistration : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                TextBox9.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            }
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
            if (RadioButtonList1.SelectedIndex == -1)
            {
                Label1.Text = "Select  Gender......";
                return;
            }

            cmd = new SqlCommand("select userid from utable where userid=@userid", con);
            cmd.Parameters.AddWithValue("userid", TextBox7.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "UserId Already Found......";
                return;
            }

            cmd = new SqlCommand("insert into utable(name,gender,dob,age,address,emailid,mno,userid,pword,rdate,status) values(@name,@gender,@dob,@age,@address,@emailid,@mno,@userid,@pword,@rdate,@status)", con);
            cmd.Parameters.AddWithValue("name", TextBox1.Text);
            cmd.Parameters.AddWithValue("gender", RadioButtonList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("dob", TextBox2.Text);
            cmd.Parameters.AddWithValue("age", TextBox3.Text);
            cmd.Parameters.AddWithValue("address", TextBox4.Text);
            cmd.Parameters.AddWithValue("emailid", TextBox5.Text);
            cmd.Parameters.AddWithValue("mno", TextBox6.Text);
            cmd.Parameters.AddWithValue("userid", TextBox7.Text);
            cmd.Parameters.AddWithValue("pword", TextBox8.Text);
            cmd.Parameters.AddWithValue("rdate", TextBox9.Text);
            cmd.Parameters.AddWithValue("status", "Register");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "User Details Successfully Registered......";
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        RadioButtonList1.SelectedIndex = -1;
        TextBox1.Focus();
    }
}