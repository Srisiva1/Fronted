using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Collections;

public partial class ACViewDataUser : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
   
    SqlDataAdapter adp;
    DataTable dt;
    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from utable where status='Register'", con);
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

            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                bindgrid();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void mailcoding(string semailid, string spassword, string remailid, string message)
    {
        MailMessage m = new MailMessage();
        m.From = new MailAddress(semailid);
        m.To.Add(remailid);
        m.IsBodyHtml = true;
        m.Subject = "Activated ";
        m.Body = m.From + "<br>Activated Date :" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + "<br>" + message;

        SmtpClient smtp = new SmtpClient();

        smtp.Host = "smtp.gmail.com";
        smtp.Credentials = new System.Net.NetworkCredential(semailid, spassword);

        smtp.EnableSsl = true;
        smtp.Send(m);

    }


    private string GeneratePrivateKey()
    {

        Random r = new Random();
        string s = "", s1 = "";
        s = ((char)r.Next(65, 90)).ToString();
        ArrayList aa = new ArrayList();
        s = s + ((char)r.Next(65, 90)).ToString();
        s = s + ((char)r.Next(65, 90)).ToString();
        s = s + ((char)r.Next(65, 90)).ToString();
        s1 = r.Next(1000, 9999).ToString();
        s = s + s1;
        s1 = "";
        char[] c = s.ToCharArray();
        while (s1.Length != c.Length)
        {
            int n = r.Next(0, c.Length);
            if (!aa.Contains(n))
            {
                s1 = s1 + c[n].ToString();
                aa.Add(n);
            }

        }

        int x = r.Next(1, 5);
        s1 = s1 + x;
        return s1;
    }

    public int generatepublickey()
    {
        Random r = new Random();
        int no = r.Next(1000, 9999);
        return no;
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string userid = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
            string emailid = GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text;
            if (e.CommandName == "aa")
            {
                string privatekey = GeneratePrivateKey();
                int publickey = generatepublickey();
                cmd = new SqlCommand("update utable set status='Accepted',privatekey=@privatekey,publickey=@publickey where userid=@userid", con);
                cmd.Parameters.AddWithValue("privatekey", privatekey);
                cmd.Parameters.AddWithValue("publickey", publickey);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

           
                string message = "You are Activated.<Br>Private Key :" + privatekey;
                mailcoding("customerproject404nf@gmail.com", "nowdlnospvmgsoth", emailid, message);
                bindgrid();

            }
            else if (e.CommandName == "rr")
            {
                cmd = new SqlCommand("update utable set status='Rejected' where userid=@userid", con);
                cmd.Parameters.AddWithValue("userid", userid);
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