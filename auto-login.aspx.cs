using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class admin_auto_login : System.Web.UI.Page
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
            Response.Cookies["cuun"].Expires = DateTime.Now.AddYears(-5);
            //Response.Cookies["pw"].Domain = "epackers.in";
            Response.Cookies["cupw"].Expires = DateTime.Now.AddYears(-5);
        }
        catch (Exception ex)
        { }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.Cookies["acuun"] == null || Request.Cookies["acupw"] == null)
            {
                Response.Redirect("index.aspx");
            }
            logout();
            if (Request.QueryString["u"] == null)
            {
                Response.Write("Invalid Credentials");
                return;
            }
            if (Request.QueryString["p"] == null)
            {
                Response.Write("Invalid Credentials");
                return;
            }
            try
            {
                string encryptedmobile = EncDec.EncryptString(Request.QueryString["u"].ToString(), EncryptionKey);
                string encryptedpass = EncDec.EncryptString(Request.QueryString["p"].ToString(), EncryptionKey);
                SqlConnection con = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                con.Open();
                SqlCommand cmdd = new SqlCommand("select * from users where username_3des = @username_3des and password_3des=@password_3des and account_status<>@account_status", con);
                cmdd.Parameters.AddWithValue("@username_3des", encryptedmobile);
                cmdd.Parameters.AddWithValue("@password_3des", encryptedpass);
                cmdd.Parameters.AddWithValue("@account_status", "Blocked");
                SqlDataReader reader = cmdd.ExecuteReader();

                if (reader.HasRows)
                {
                    //create login cookies
                    try
                    {
                        //create username
                        HttpCookie unCookie = new HttpCookie("cuun");
                        unCookie.Value = EncDec.EncryptString(Request.QueryString["u"].ToString(), EncryptionKey);
                        unCookie.Expires = DateTime.Now.AddMonths(6);
                        Response.Cookies.Add(unCookie);
                        //create password
                        HttpCookie pwCookie = new HttpCookie("cupw");
                        pwCookie.Value = EncDec.EncryptString(Request.QueryString["p"].ToString(), EncryptionKey);
                        pwCookie.Expires = DateTime.Now.AddMonths(6);
                        Response.Cookies.Add(pwCookie);
                        Response.Redirect("../user/dashboard.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error While Login");
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
                    Response.Write("Invalid username or password");
                    logout();
                }
                con.Close();
                con.Dispose();
                reader.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

}