using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserFileDownload2 : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
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
                if (Session["UserId"] != null && Request.QueryString.Get("FRID") != null)
                {
                    TextBox1.Text = Session["UserId"].ToString();
                    int frid = int.Parse(Request.QueryString.Get("FRID"));

                    cmd = new SqlCommand("select * from frtable where frid=@frid", con);
                    cmd.Parameters.AddWithValue("frid", frid);
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        TextBox2.Text = rs["fid"].ToString();
                        TextBox3.Text = rs["fname"].ToString();
                        TextBox4.Text = rs["ownerid"].ToString();
                        rs.Close();
                        cmd.Dispose();
                        TextBox5.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "Record Not Found.Check FRTable.....";
                        return;
                    }

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

            cmd = new SqlCommand("select fname,fcontent from frtable where frid=@frid and opublickey=@opublickey and uprivatekey=@uprivatekey", con);
            cmd.Parameters.AddWithValue("frid", Request.QueryString.Get("FRID"));
            cmd.Parameters.AddWithValue("opublickey", TextBox6.Text);
            cmd.Parameters.AddWithValue("uprivatekey", TextBox7.Text);
            rs = cmd.ExecuteReader();
            byte[] filecontent = { 0 };
            string fname = "";
            if (rs.Read())
            {
                fname = rs["fname"].ToString();
                filecontent = (byte[])rs["fcontent"];
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Owner Public Key or User Private Key is Invalid......";
                return;
            }

            char[] c = TextBox7.Text.ToCharArray();
            int  n = int.Parse(c[c.Length - 1].ToString ());
            byte x = (byte)n;

            for (int i = 0; i < filecontent.Length; i++)
                filecontent[i] -= x;


            HttpResponse hr = HttpContext.Current.Response;
            hr.Buffer = true;
            hr.AddHeader("content-Disposition", "attachment;filename=\"" + fname + "\"");
            hr.BinaryWrite(filecontent);


            cmd = new SqlCommand("insert into dtable values (@duserid,@fownerid,@fileid,@filename,@ddate)", con);
            cmd.Parameters .AddWithValue ("duserid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("fownerid",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("fileid",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("filename",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("ddate",DateTime .Now .ToString ("dd-MMM-yyyy"));
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();

            hr.End();

            Label1.Text = "File Downloaded.....";



        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}