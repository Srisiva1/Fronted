using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserSendFileRequest : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        // FileId
        try
        {
            Label1.Text = "";
            Menu m5 = (Menu)Master.FindControl("Menu5");
            m5.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Request.QueryString.Get("FileId") != null && Request.QueryString.Get("OwnerId") != null)
                {
                    TextBox1.Text = Request.QueryString.Get("FileId");
                    TextBox3.Text = Request.QueryString.Get("OwnerId");
                    TextBox4.Text = Session["UserId"].ToString();
                    TextBox5.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                    cmd = new SqlCommand("Select filename from futable where fileid=@fileid", con);
                    cmd.Parameters.AddWithValue("fileid", TextBox1.Text);
                    rs = cmd.ExecuteReader();
                    string filename = "";
                    if (rs.Read())
                    {
                        filename = rs["filename"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "Record Not Found.Check FUTable.....";
                        return;
                    }

                    //  filename = filename.Substring(filename.LastIndexOf("_") + 1);
                    TextBox2.Text = filename;

                }
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

            cmd = new SqlCommand("select * from ortable where userid=@userid and ownerid=@ownerid and status='Accepted' and opublickey=@opublickey", con);
            cmd.Parameters.AddWithValue("userid", TextBox4.Text);
            cmd.Parameters.AddWithValue("ownerid", TextBox3.Text);
            cmd.Parameters.AddWithValue("opublickey", TextBox6.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b == false)
            {
                Label1.Text = "Owner Public Key is Invalid....";
                return;
            }

            cmd = new SqlCommand("select * from utable where userid=@userid and privatekey=@privatekey", con);
            cmd.Parameters.AddWithValue("userid", TextBox4.Text);
            cmd.Parameters.AddWithValue("privatekey", TextBox7.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b == false)
            {
                Label1.Text = "User Private Key is Invalid......";
                return;
            }


            cmd = new SqlCommand("select isnull(max(frid), 1000)+1 from frtable", con);
            int frid = int.Parse(cmd.ExecuteScalar().ToString());
            cmd.Dispose();


            cmd = new SqlCommand("insert into frtable(frid,fid,fname,ownerid,ruserid,rdate,opublickey,uprivatekey,status) values(@frid,@fid,@fname,@ownerid,@ruserid,@rdate,@opublickey,@uprivatekey,@status)", con);
            cmd.Parameters.AddWithValue("frid", frid);
            cmd.Parameters.AddWithValue("fid", TextBox1.Text);
            cmd.Parameters.AddWithValue("fname", TextBox2.Text);
            cmd.Parameters.AddWithValue("ownerid", TextBox3.Text);
            cmd.Parameters.AddWithValue("ruserid", TextBox4.Text);
            cmd.Parameters.AddWithValue("rdate", TextBox5.Text);
            cmd.Parameters.AddWithValue("opublickey", TextBox6.Text);
            cmd.Parameters.AddWithValue("uprivatekey", TextBox7.Text);
            cmd.Parameters.AddWithValue("status", "Request");
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "File Request Details Inserted......";

            LinkButton1.Enabled = false;






        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("Select privatekey from utable where userid=@userid", con);
            cmd.Parameters.AddWithValue("userid", TextBox4.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                Label1.Text = "Your Private Key is :" + rs["privatekey"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Record Not Found.Check UTable.....";

            }
        }
        
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}