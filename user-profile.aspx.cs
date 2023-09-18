using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_user_profile : System.Web.UI.Page
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
            //Response.Cookies["uun"].Domain = "epackers.in";
            Response.Cookies["cuun"].Expires = DateTime.Now.AddYears(-5);
            //Response.Cookies["upw"].Domain = "epackers.in";
            Response.Cookies["cupw"].Expires = DateTime.Now.AddYears(-5);
        }
        catch (Exception ex)
        { }
    }

    public void fillDetails()
    {
        try
        {
            SqlConnection con1 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            DataTable dt = new DataTable();
            con1.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from users where username_md5=@username_md5", con1);
            myCommand.Parameters.AddWithValue("@username_md5", Request.QueryString["u"].ToString());
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    full_name_lbl.Text = myReader["full_name"].ToString();
                    profileimg.ImageUrl = "~/dp/" + myReader["profile_img_url"].ToString();

                    gender.Text = myReader["gender"].ToString();
                    full_name.Text = myReader["full_name"].ToString();
                    mobile_no.Text = myReader["mobile_no"].ToString();
                    email_address.Text = myReader["email_address"].ToString();
                    country.Text = myReader["country"].ToString();
                    state.Text = myReader["state"].ToString();
                    city.Text = myReader["city"].ToString();
                    address.Text = myReader["address"].ToString();
                    pin_code.Text = myReader["pin_code"].ToString();
                    account_holder_name.Text = myReader["account_holder_name"].ToString();
                    bank_name.Text = myReader["bank_name"].ToString();
                    account_number.Text = myReader["account_number"].ToString();
                    ifsc_code.Text = myReader["ifsc_code"].ToString();

                    login_hl.NavigateUrl = "auto-login.aspx?u=" + EncDec.DecryptString(myReader["username_3des"].ToString(), EncryptionKey) + "&p=" + EncDec.DecryptString(myReader["password_3des"].ToString(), EncryptionKey);
                    account_status.Text = myReader["account_status"].ToString();
                }
            }
            else
            {
                logout();
                Response.Redirect("../admin/index.aspx");
            }
            con1.Close();
            con1.Dispose();
            myReader.Close();
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.Cookies["acuun"] == null || Request.Cookies["acupw"] == null)
            {
                Response.Redirect("index.aspx");
            }
            fillDetails();
        }
    }


    protected void saveuserdetails_btn_Click(object sender, EventArgs e)
    {
        try
        {
            successdiv.Visible = false;
            errordiv.Visible = false;
            SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            SqlCommand cmd2 = new SqlCommand("update users set gender=@gender,full_name=@full_name,mobile_no=@mobile_no,country=@country,state=@state,city=@city,address=@address,pin_code=@pin_code where username_md5=@username_md5", con2);
            cmd2.Parameters.AddWithValue("@username_md5", Request.QueryString["u"].ToString());
            cmd2.Parameters.AddWithValue("@gender", gender.Text.Trim().ToString());
            cmd2.Parameters.AddWithValue("@full_name", full_name.Text.Trim().ToString());
            cmd2.Parameters.AddWithValue("@mobile_no", mobile_no.Text.Trim().ToString());
            cmd2.Parameters.AddWithValue("@country", country.Text.Trim().ToString());
            cmd2.Parameters.AddWithValue("@state", state.Text.Trim().ToString());
            cmd2.Parameters.AddWithValue("@city", city.Text.Trim().ToString());
            cmd2.Parameters.AddWithValue("@address", address.Text.Trim().ToString());
            cmd2.Parameters.AddWithValue("@pin_code", pin_code.Text.Trim().ToString());

            con2.Open();
            int count = cmd2.ExecuteNonQuery();
            con2.Close();
            con2.Dispose();
            successdiv.Visible = true;
            successlbl.Text = "User Details Updated Sucessfully";
            errordiv.Visible = false;
            successdiv.Focus();
        }
        catch (Exception ex)
        {
            errordiv.Visible = true;
            errorlbl.Text = ex.Message;
            errordiv.Focus();
        }
    }

    protected void savebankdetails_btn_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con1 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            DataTable dt = new DataTable();
            con1.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from users where account_number=@account_number and username_md5<>@username_md5", con1);
            myCommand.Parameters.AddWithValue("@account_number", account_number.Text.Trim().ToString());
            myCommand.Parameters.AddWithValue("@username_md5", Request.QueryString["u"].ToString());
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                errordiv.Visible = true;
                errorlbl.Text = "Bank details already submitted using another account.";
                con1.Close();
                con1.Dispose();
                myReader.Close();
                return;
            }
            else
            {
                successdiv.Visible = false;
                errordiv.Visible = false;
                SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                SqlCommand cmd2 = new SqlCommand("update users set account_holder_name=@account_holder_name,bank_name=@bank_name,account_number=@account_number,ifsc_code=@ifsc_code where username_md5=@username_md5", con2);
                cmd2.Parameters.AddWithValue("@username_md5", Request.QueryString["u"].ToString());
                cmd2.Parameters.AddWithValue("@account_holder_name", account_holder_name.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@bank_name", bank_name.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@account_number", account_number.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@ifsc_code", ifsc_code.Text.Trim().ToString());
                con2.Open();
                int count = cmd2.ExecuteNonQuery();
                con2.Close();
                con2.Dispose();
                successdiv.Visible = true;
                successlbl.Text = "Bank Details Updated Sucessfully";
                errordiv.Visible = false;
                successdiv.Focus();
                con1.Close();
                con1.Dispose();
                myReader.Close();
            }
        }
        catch (Exception ex)
        {
            errordiv.Visible = true;
            errorlbl.Text = ex.Message;
            errordiv.Focus();
        }
    }

    protected void change_status_btn_Click(object sender, EventArgs e)
    {
        successdiv.Visible = false;
        errordiv.Visible = false;
        SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        SqlCommand cmd2 = new SqlCommand("update users set account_status=@account_status where username_md5=@username_md5", con2);
        cmd2.Parameters.AddWithValue("@username_md5", Request.QueryString["u"].ToString());
        cmd2.Parameters.AddWithValue("@account_status", account_status.Text.Trim().ToString());
        con2.Open();
        int count = cmd2.ExecuteNonQuery();
        con2.Close();
        con2.Dispose();
        successdiv.Visible = true;
        successlbl.Text = "Status Updated Sucessfully";
        errordiv.Visible = false;
        successdiv.Focus();
    }

}