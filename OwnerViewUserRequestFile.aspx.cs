using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class OwnerViewUserRequestFile : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from frtable where ownerid=@ownerid and status='Request'", con);
        adp.SelectCommand.Parameters.AddWithValue("ownerid", TextBox1.Text);
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
            int frid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            if (e.CommandName == "ac")
            {
                int fid = int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                cmd = new SqlCommand("select uprivatekey from frtable where frid=@frid", con);
                cmd.Parameters.AddWithValue("frid", frid);
                rs = cmd.ExecuteReader();
                string uprivatekey = "";
                if (rs.Read())
                {
                    uprivatekey = rs["uprivatekey"].ToString();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Record Not Found.Check FRTable.....";
                    return;
                }


                cmd = new SqlCommand("select privatekey from otable where userid=(select userid from futable where fileid=@fileid)", con);
                cmd.Parameters.AddWithValue("fileid", fid);
                rs = cmd.ExecuteReader();
                string oprivatekey = "";
                if (rs.Read())
                {
                    oprivatekey = rs["privatekey"].ToString();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Record Not Found.Check OTable and FUTable....";
                    return;
                }


                cmd = new SqlCommand("select filecontent from futable where fileid=@fileid", con);
                cmd.Parameters.AddWithValue("fileid", fid);
                rs = cmd.ExecuteReader();
                byte[] filecontent = { 0 };
                if (rs.Read())
                {
                    filecontent = (byte[])rs["filecontent"];
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


                char[] c = oprivatekey .ToCharArray();
                int n = int.Parse(c[c.Length - 1].ToString());
                byte x = (byte)n;

               

                for (int i = 0; i <filecontent.Length; i++)
                {
                   filecontent [i] -= x;
                }


                char[] c1 = uprivatekey.ToCharArray();
                int n1 = int.Parse(c1[c1.Length - 1].ToString());
                byte x1 = (byte)n1;

                for (int i = 0; i < filecontent.Length; i++)
                {
                    filecontent[i] += x1;
                }


                cmd = new SqlCommand("update frtable set status='Accepted', fcontent=@fcontent where frid=@frid", con);
                cmd.Parameters.AddWithValue("fcontent", filecontent);
                cmd.Parameters.AddWithValue("frid", frid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = "File Status is Accepted.....";
                bindgrid();
            }
            else if (e.CommandName == "re")
            {
                cmd = new SqlCommand("update frtable set status='Rejected' where frid=@frid", con);
                cmd.Parameters.AddWithValue("frid", frid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}