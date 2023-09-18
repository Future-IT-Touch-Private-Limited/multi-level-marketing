using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_settings : System.Web.UI.Page
{
    string EncryptionKey = "@#future#@touch_!123~!admin@@";
    string EncryptionKey2 = "future@123@adm";
    EncDec EncDec = new EncDec();
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.Cookies["acuun"] == null || Request.Cookies["acupw"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }
    }

    protected void changepasswordbtn_Click(object sender, EventArgs e)
    {
        try
        {
            currentpassword.Attributes["value"] = currentpassword.Text;
            password.Attributes["value"] = password.Text;
            confirm_password.Attributes["value"] = confirm_password.Text;
            errordiv.Visible = false;
            successdiv.Visible = false;

            if (password.Text.Length < 8)
            {
                errordiv.Visible = true;
                errorlbl.Text = "Minimum 8 digits password required";
                return;
            }
            if (password.Text.Length > 32)
            {
                errordiv.Visible = true;
                errorlbl.Text = "Maximum 32 digits password allowed";
                return;
            }
            if (password.Text.ToString() != confirm_password.Text.ToString())
            {
                errordiv.Visible = true;
                errorlbl.Text = "Password Confirmation Failed";
                return;
            }

            if (Request.Cookies["acuun"] != null)
            {
                SqlConnection con = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                con.Open();
                SqlCommand cmdd = new SqlCommand("select * from admin where username_3des = @username_3des and password_3des=@password_3des", con);
                cmdd.Parameters.AddWithValue("@username_3des", Request.Cookies["cuun"].Value.ToString());
                cmdd.Parameters.AddWithValue("@password_3des", EncDec.EncryptString(currentpassword.Text, EncryptionKey));
                SqlDataReader reader = cmdd.ExecuteReader();

                if (reader.HasRows)
                {
                    con.Close();
                    con.Dispose();
                    reader.Close();

                    SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                    SqlCommand cmd2 = new SqlCommand("update admin set password_3des=@password_3des,password_md5=@password_md5 where sr='1'", con2);
                    cmd2.Parameters.AddWithValue("@password_3des", EncDec.EncryptString(password.Text.ToString(), EncryptionKey));
                    cmd2.Parameters.AddWithValue("@password_md5", EncDec.MD5Hash(password.Text.ToString() + EncryptionKey));
                    con2.Open();
                    int count = cmd2.ExecuteNonQuery();
                    con2.Close();
                    con2.Dispose();
                    successlbl.Text = "Password Changed Sucessfully, Kindly login again. <a href='index.aspx'>Click Here to Login</a>";
                    currentpassword.Text = "";
                    password.Text = "";
                    confirm_password.Text = "";
                    successdiv.Visible = true;
                }
                else
                {
                    con.Close();
                    con.Dispose();
                    reader.Close();
                    errorlbl.Text = "Kindly enter a valid current password";
                    errordiv.Visible = true;
                }
                con.Close();
                con.Dispose();
                reader.Close();
            }
            else
            {
                errorlbl.Text = "You are not logged in";
                errordiv.Visible = true;
            }
        }
        catch (Exception ex)
        {
            errorlbl.Text = ex.Message;
            errordiv.Visible = true;
        }
    }

}