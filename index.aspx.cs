using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sunil_index : System.Web.UI.Page
{
    string EncryptionKey = "@#future#@touch_!123~!admin@@";
    string EncryptionKey2 = "future@123@adm";
    EncDec EncDec = new EncDec();
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

    public void logout()
    {
        try
        {
            //remove cookies
            //Response.Cookies["un"].Domain = "epackers.in";
            Response.Cookies["acuun"].Expires = DateTime.Now.AddYears(-5);
            //Response.Cookies["pw"].Domain = "epackers.in";
            Response.Cookies["acupw"].Expires = DateTime.Now.AddYears(-5);
        }
        catch (Exception ex)
        { }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies["acuun"] != null)
                {
                    SqlConnection con = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                    con.Open();
                    SqlCommand cmdd = new SqlCommand("select * from users where username_3des=@username_3des and password_3des=@password_3des", con);
                    cmdd.Parameters.AddWithValue("@username_3des", Request.Cookies["acuun"].Value.ToString());
                    cmdd.Parameters.AddWithValue("@password_3des", Request.Cookies["acupw"].Value.ToString());
                    SqlDataReader reader = cmdd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        con.Close();
                        con.Dispose();
                        reader.Close();
                        Response.Redirect("dashboard.aspx");
                    }
                    else
                    {
                        con.Close();
                        con.Dispose();
                        reader.Close();
                        logout();
                    }
                }
            }
            catch (Exception ex)
            {
                errorlbl.Text = ex.Message;
                errordiv.Visible = true;
                return;
            }
        }
    }


    protected void loginbtn_Click(object sender, EventArgs e)
    {
        errordiv.Visible = false;
        //logout();
        try
        {
            string encryptedmobile = EncDec.EncryptString(username.Text.Trim().ToString(), EncryptionKey);
            string encryptedpass = EncDec.EncryptString(password.Text, EncryptionKey);
            SqlConnection con = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            con.Open();
            SqlCommand cmdd = new SqlCommand("select * from admin where username_3des=@username_3des and password_3des=@password_3des", con);
            cmdd.Parameters.AddWithValue("@username_3des", encryptedmobile);
            cmdd.Parameters.AddWithValue("@password_3des", encryptedpass);
            SqlDataReader reader = cmdd.ExecuteReader();

            if (reader.HasRows)
            {
                //create login cookies
                try
                {
                    //create username
                    HttpCookie unCookie = new HttpCookie("acuun");
                    unCookie.Value = EncDec.EncryptString(username.Text.Trim().ToString(), EncryptionKey);
                    unCookie.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(unCookie);
                    //create password
                    HttpCookie pwCookie = new HttpCookie("acupw");
                    pwCookie.Value = EncDec.EncryptString(password.Text.ToString(), EncryptionKey);
                    pwCookie.Expires = DateTime.Now.AddMonths(6);
                    Response.Cookies.Add(pwCookie);
                    Response.Redirect("dashboard.aspx");
                }
                catch (Exception ex)
                {
                    errorlbl.Text = "Error While Login";
                    errordiv.Visible = true;
                }
                con.Close();
                con.Dispose();
                reader.Close();
            }
            else
            {
                con.Close();
                con.Dispose();
                reader.Close();
                errorlbl.Text = "Invalid username or password";
                errordiv.Visible = true;
                //logout();
            }
            con.Close();
            con.Dispose();
            reader.Close();
        }
        catch (Exception ex)
        {
            errorlbl.Text = ex.Message;
            errordiv.Visible = true;
        }
    }
}