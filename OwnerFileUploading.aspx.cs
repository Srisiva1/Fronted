using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class OwnerFileUploading : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
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

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    void autonumber()
    {
        cmd = new SqlCommand("Select isnull (max(fileid), 0)+1 from futable", con);
        TextBox3.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            cmd = new SqlCommand("select * from otable where userid=@userid and privatekey=@privatekey", con);
            cmd.Parameters.AddWithValue("userid", TextBox1.Text);
            cmd.Parameters.AddWithValue("privatekey", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b == false)
            {
                LinkButton2.Enabled = false;
                Label1.Text = "Private Key is Invalid.......";
                return;
            }

            LinkButton2.Enabled = true;
            autonumber();
          
            TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {

            if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Upload File is not Selected......";
                return;
            }

            cmd = new SqlCommand("select fileid from futable where fileid=@fileid", con);
            cmd.Parameters.AddWithValue("fileid", TextBox3.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "File Id Already Found......";
                return;
            }

            char[] c = TextBox2.Text.ToCharArray();
            int n = int.Parse(c[c.Length -1].ToString());
            byte x = (byte)n;

            DirectoryInfo d1 = new DirectoryInfo(Server.MapPath("Temp"));
            FileInfo[] f1 = d1.GetFiles();
            foreach (FileInfo f2 in f1)
                f2.Delete();

            string fname = FileUpload1.FileName;

            FileUpload1.PostedFile.SaveAs(Server.MapPath("Temp//") + fname);
            FileStream fs = new FileStream(Server.MapPath("Temp//")+fname, FileMode.Open, FileAccess.Read);
            byte[] b1 = new byte[fs.Length];
            fs.Read(b1, 0, b1.Length);
            fs.Close();

            for (int i = 0; i < b1.Length; i++)
            {
                b1[i] += x;
            }
            fname = fname.Substring(fname.LastIndexOf("\\") + 1);
                      
            //Start Cloud Coding

             /*   FileStream cfs = new FileStream("z:\\" + fname, FileMode.Create, FileAccess.Write);

              cfs.Write(b1, 0, b1.Length);
              cfs.Close();  
             */


            //End Cloud Coding

            
            cmd = new SqlCommand("insert into futable values(@userid,@fileid,@filename,@filecontent,@fudate)", con);
            cmd.Parameters .AddWithValue ("userid",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("fileid",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("filename",fname);
            cmd.Parameters .AddWithValue ("filecontent",b1);
            cmd.Parameters .AddWithValue ("fudate",TextBox4 .Text );
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1.Text = "File Successfully Uploaded......";
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        TextBox3.Text = "";
        autonumber();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("Select privatekey from otable where userid=@userid", con);
            cmd.Parameters.AddWithValue("userid", TextBox1.Text);
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
                Label1.Text = "Record Not Found.Check OTable.....";

            }

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}