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

public partial class admin_view_withdrawal_request : System.Web.UI.Page
{
    string EncryptionKey = "@#future#@touch_!123~!admin@@";
    string EncryptionKey2 = "future@123@adm";
    EncDec EncDec = new EncDec();
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

    public void fillDetails()
    {
        //try
        //{
        SqlConnection con1 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        DataTable dt = new DataTable();
        con1.Open();
        SqlDataReader myReader = null;
        SqlCommand myCommand = new SqlCommand("select * from withdrawal where sr=@sr", con1);
        myCommand.Parameters.AddWithValue("@sr", Request.QueryString["sr"].ToString());
        myReader = myCommand.ExecuteReader();
        if (myReader.HasRows)
        {
            while (myReader.Read())
            {
                //profileimg.ImageUrl = "~/dp/" + myReader["profile_img_url"].ToString();
                if(myReader["request_status"].ToString()=="Success")
                {
                    btn_box.Visible = false;
                }
                if (myReader["request_status"].ToString() == "Rejected")
                {
                    btn_box.Visible = false;
                }
                account_holder_name.Text = myReader["account_holder_name"].ToString();
                bank_name.Text = myReader["bank_name"].ToString();
                account_number.Text = myReader["account_number"].ToString();
                ifsc_code.Text = myReader["ifsc_code"].ToString();
                username_3des_hf.Value = myReader["username_3des"].ToString();

                withdrawal_amount.Text = myReader["withdrawal_amount"].ToString();
                admin_set_transaction_id.Text = myReader["admin_set_transaction_id"].ToString();
                admin_set_note.Text = myReader["admin_set_note"].ToString();

                try
                {
                    username_3ddes_lbl.Text = EncDec.DecryptString(myReader["username_3des"].ToString(),EncryptionKey);
                }
                catch (Exception ex)
                { }
                request_date.Text= myReader["request_date"].ToString();
                withdrawal_amount_lbl.Text= myReader["withdrawal_amount"].ToString();
                try
                {
                    double dbl_withdrawal_amt = Convert.ToDouble(myReader["withdrawal_amount"].ToString());
                    double dbl_charge_amt = dbl_withdrawal_amt * 7 / 100;
                    total_charge_lbl.Text=dbl_charge_amt.ToString();
                    total_payable_lbl.Text=(dbl_withdrawal_amt-dbl_charge_amt).ToString();
                }
                catch(Exception ex)
                {
                }

            }
        }
        else
        {
            //Response.Redirect("dashboard.aspx");
        }
        con1.Close();
        con1.Dispose();
        myReader.Close();
        //}
        //catch (Exception ex)
        //{
        //    //Response.Write(ex.Message);
        //}
    }


    public void fillProfileImg()
    {
        //try
        //{
        SqlConnection con1 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        DataTable dt = new DataTable();
        con1.Open();
        SqlDataReader myReader = null;
        SqlCommand myCommand = new SqlCommand("select * from users where username_3des=@username_3des", con1);
        myCommand.Parameters.AddWithValue("@username_3des", username_3des_hf.Value);
        myReader = myCommand.ExecuteReader();
        if (myReader.HasRows)
        {
            while (myReader.Read())
            {
                profile_pic.ImageUrl = "~/dp/" + myReader["profile_img_url"].ToString();
            }
        }
        else
        {
            //Response.Redirect("dashboard.aspx");
        }
        con1.Close();
        con1.Dispose();
        myReader.Close();
        //}
        //catch (Exception ex)
        //{
        //    //Response.Write(ex.Message);
        //}
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
            fillProfileImg();
        }
    }

    protected void saveuserdetails_btn_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    successdiv.Visible = false;
        //    errordiv.Visible = false;

        //    SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        //    SqlCommand cmd2 = new SqlCommand("update users set gender=@gender,full_name=@full_name,mobile_no=@mobile_no,country=@country,state=@state,city=@city,address=@address,pin_code=@pin_code where username_3des=@username_3des", con2);
        //    cmd2.Parameters.AddWithValue("@username_3des", Request.Cookies["cuun"].Value.ToString());
        //    cmd2.Parameters.AddWithValue("@gender", gender.Text.Trim().ToString());
        //    cmd2.Parameters.AddWithValue("@full_name", full_name.Text.Trim().ToString());
        //    cmd2.Parameters.AddWithValue("@mobile_no", mobile_no.Text.Trim().ToString());
        //    cmd2.Parameters.AddWithValue("@country", country.Text.Trim().ToString());
        //    cmd2.Parameters.AddWithValue("@state", state.Text.Trim().ToString());
        //    cmd2.Parameters.AddWithValue("@city", city.Text.Trim().ToString());
        //    cmd2.Parameters.AddWithValue("@address", address.Text.Trim().ToString());
        //    cmd2.Parameters.AddWithValue("@pin_code", pin_code.Text.Trim().ToString());

        //    con2.Open();
        //    int count = cmd2.ExecuteNonQuery();
        //    con2.Close();
        //    con2.Dispose();
        //    successdiv.Visible = true;
        //    successlbl.Text = "User Details Updated Sucessfully";
        //    errordiv.Visible = false;
        //    successdiv.Focus();

        //}
        //catch (Exception ex)
        //{
        //    errordiv.Visible = true;
        //    errorlbl.Text = ex.Message;
        //    errordiv.Focus();
        //}
    }

    protected void savebankdetails_btn_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    successdiv.Visible = false;
        //    errordiv.Visible = false;

        //    SqlConnection con1 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        //    DataTable dt = new DataTable();
        //    con1.Open();
        //    SqlDataReader myReader = null;
        //    SqlCommand myCommand = new SqlCommand("select * from users where account_number=@account_number and username_3des<>@username_3des", con1);
        //    myCommand.Parameters.AddWithValue("@account_number", account_number.Text.Trim().ToString());
        //    myCommand.Parameters.AddWithValue("@username_3des", Request.Cookies["cuun"].Value.ToString());
        //    myReader = myCommand.ExecuteReader();
        //    if (myReader.HasRows)
        //    {
        //        errordiv.Visible = true;
        //        errorlbl.Text = "Bank details already submitted using another account.";
        //        con1.Close();
        //        con1.Dispose();
        //        myReader.Close();
        //        return;
        //    }
        //    else
        //    {
        //        SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        //        SqlCommand cmd2 = new SqlCommand("update users set account_holder_name=@account_holder_name,bank_name=@bank_name,account_number=@account_number,ifsc_code=@ifsc_code where username_3des=@username_3des", con2);
        //        cmd2.Parameters.AddWithValue("@username_3des", Request.Cookies["cuun"].Value.ToString());
        //        cmd2.Parameters.AddWithValue("@account_holder_name", account_holder_name.Text.Trim().ToString());
        //        cmd2.Parameters.AddWithValue("@bank_name", bank_name.Text.Trim().ToString());
        //        cmd2.Parameters.AddWithValue("@account_number", account_number.Text.Trim().ToString());
        //        cmd2.Parameters.AddWithValue("@ifsc_code", ifsc_code.Text.Trim().ToString());
        //        con2.Open();
        //        int count = cmd2.ExecuteNonQuery();
        //        con2.Close();
        //        con2.Dispose();
        //        successdiv.Visible = true;
        //        successlbl.Text = "Bank Details Updated Sucessfully";
        //        errordiv.Visible = false;
        //        successdiv.Focus();

        //        con1.Close();
        //        con1.Dispose();
        //        myReader.Close();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    errordiv.Visible = true;
        //    errorlbl.Text = ex.Message;
        //    errordiv.Focus();
        //}
    }


    protected void approve_btn_Click(object sender, EventArgs e)
    {
        if(confirm_cb.Checked==true)
        {
            try
            {
                successdiv.Visible = false;
                errordiv.Visible = false;
                if(withdrawal_amount.Text.Trim()=="")
                {
                    errordiv.Visible = true;
                    errorlbl.Text = "Withdrawal amount required";
                    confirm_cb.Checked = false;
                    return;
                }
                //if (admin_set_transaction_id.Text.Trim() == "")
                //{
                //    errordiv.Visible = true;
                //    errorlbl.Text = "Transaction ID required";
                //    confirm_cb.Checked = false;
                //    return;
                //}
                SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                SqlCommand cmd2 = new SqlCommand("update withdrawal set withdrawal_amount=@withdrawal_amount,admin_set_transaction_id=@admin_set_transaction_id,admin_set_note=@admin_set_note,request_status=@request_status where sr=@sr", con2);
                cmd2.Parameters.AddWithValue("@sr", Request.QueryString["sr"].ToString());
                cmd2.Parameters.AddWithValue("@withdrawal_amount", withdrawal_amount.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@admin_set_transaction_id", admin_set_transaction_id.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@admin_set_note", admin_set_note.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@request_status", "Success");
                con2.Open();
                int count = cmd2.ExecuteNonQuery();
                con2.Close();
                con2.Dispose();
                successdiv.Visible = true;
                successlbl.Text = "Withdrawal Details Updated Sucessfully";
                errordiv.Visible = false;
                successdiv.Focus();
                btn_box.Visible = false;
            }
            catch (Exception ex)
            {
                errordiv.Visible = true;
                errorlbl.Text = ex.Message;
                errordiv.Focus();
            }
            confirm_cb.Checked = false;
        }
        else
        {
            errordiv.Visible = true;
            errorlbl.Text = "Please confirm first";
            return;
        }
    }

    protected void reject_btn_Click(object sender, EventArgs e)
    {
        if (confirm_cb.Checked == true)
        {
            try
            {
                successdiv.Visible = false;
                errordiv.Visible = false;
                if (withdrawal_amount.Text.Trim() == "")
                {
                    errordiv.Visible = true;
                    errorlbl.Text = "Withdrawal amount required";
                    confirm_cb.Checked = false;
                    return;
                }
                if (admin_set_transaction_id.Text.Trim() == "")
                {
                    errordiv.Visible = true;
                    errorlbl.Text = "Transaction ID required";
                    confirm_cb.Checked = false;
                    return;
                }
                SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                SqlCommand cmd2 = new SqlCommand("update withdrawal set withdrawal_amount=@withdrawal_amount,admin_set_transaction_id=@admin_set_transaction_id,admin_set_note=@admin_set_note,request_status=@request_status where sr=@sr", con2);
                cmd2.Parameters.AddWithValue("@sr", Request.QueryString["sr"].ToString());
                cmd2.Parameters.AddWithValue("@withdrawal_amount", withdrawal_amount.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@admin_set_transaction_id", admin_set_transaction_id.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@admin_set_note", admin_set_note.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@request_status", "Rejected");
                con2.Open();
                int count = cmd2.ExecuteNonQuery();
                con2.Close();
                con2.Dispose();
                successdiv.Visible = true;
                successlbl.Text = "Withdrawal Details Updated Sucessfully";
                errordiv.Visible = false;
                successdiv.Focus();
                btn_box.Visible = false;
            }
            catch (Exception ex)
            {
                errordiv.Visible = true;
                errorlbl.Text = ex.Message;
                errordiv.Focus();
            }
            confirm_cb.Checked = false;
        }
        else
        {
            errordiv.Visible = true;
            errorlbl.Text = "Please confirm first";
            return;
        }
    }

}