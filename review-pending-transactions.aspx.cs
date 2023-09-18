using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_transactions_pending_review : System.Web.UI.Page
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
        //try
        //{
        SqlConnection con1 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        DataTable dt = new DataTable();
        con1.Open();
        SqlDataReader myReader = null;
        SqlCommand myCommand = new SqlCommand("select * from transactions where sr=@sr", con1);
        myCommand.Parameters.AddWithValue("@sr", Request.QueryString["sr"].ToString());
        myReader = myCommand.ExecuteReader();
        if (myReader.HasRows)
        {
            while (myReader.Read())
            {
                transaction_amt.Text = myReader["transaction_amt"].ToString();
                transaction_mode.Text = myReader["transaction_mode"].ToString();
                transaction_date.Text = myReader["transaction_date"].ToString();
                transaction_id.Text = myReader["transaction_id"].ToString();
                package_name_lbl.Text = myReader["package_name"].ToString() + " (" + myReader["package_id"].ToString() + ")";

                username_3des_hf.Value = myReader["username_3des"].ToString();
                referr_income_hf.Value = myReader["referr_income"].ToString();
                referrer_1_hf.Value = myReader["transaction_amt"].ToString();
                first_transaction_id_hf.Value = myReader["transaction_id"].ToString();
                referr_package_id_hf.Value = myReader["package_id"].ToString();

                Label1.Text = myReader["referr_income"].ToString();
                if (myReader["transaction_status"].ToString() == "Success")
                {
                    tool_box.Visible = false;
                }
                if (myReader["transaction_status"].ToString() == "Cancelled")
                {
                    tool_box.Visible = false;
                }

            }
        }
        else
        {
            Response.Redirect("pending-transactions.aspx");
        }
        con1.Close();
        con1.Dispose();
        myReader.Close();
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
    }

    //generate salery
    public void generateWeeklySalery()
    {
        int int_query_current_date = Convert.ToInt32(indianTime.ToString("yyyyMMdd"));
        int int_query_last_7th_day = Convert.ToInt32(indianTime.AddDays(-7).ToString("yyyyMMdd"));
        int int_total_referr_transactions = 0;
        try
        {
            SqlConnection con01 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            string myScalarQuery01 = "select count(*) from transactions where referrer_1=@referrer_1 and query_approved_date  > @int_query_last_7th_day and query_approved_date <= int_query_last_7th_day";
            SqlCommand myCommand01 = new SqlCommand(myScalarQuery01, con01);
            myCommand01.Parameters.AddWithValue("@referrer_1", referrer_1_hf.Value);
            myCommand01.Parameters.AddWithValue("@query_approved_date", referrer_1_hf.Value);
            myCommand01.Parameters.AddWithValue("@int_query_current_date", int_query_current_date);
            myCommand01.Parameters.AddWithValue("@int_query_last_7th_day", int_query_last_7th_day);
            myCommand01.Connection.Open();
            int countuser01 = (int)myCommand01.ExecuteScalar();
            con01.Close();
            con01.Dispose();
            int_total_referr_transactions = countuser01;
        }
        catch (Exception ex)
        {
            int_total_referr_transactions = 0;
        }
        Response.Write(int_total_referr_transactions.ToString());
    }

    //generate referr income
    public void generateReferrIncome()
    {
        //try
        //{
            SqlConnection con1 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            DataTable dt = new DataTable();
            con1.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from users where username_3des=@username_3des and referr_income_status=@referr_income_status", con1);
            myCommand.Parameters.AddWithValue("@username_3des", username_3des_hf.Value);
            myCommand.Parameters.AddWithValue("@referr_income_status", "Pending");
            myReader = myCommand.ExecuteReader();
            if (myReader.HasRows)
            {
                SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                SqlCommand cmd2 = new SqlCommand("update users set reffer_income=@reffer_income,first_package_amt=@first_package_amt,referr_income_status=@referr_income_status,referr_package_name=@referr_package_name,referr_package_id=@referr_package_id,first_payment_date=@first_payment_date,query_first_payment_date=@query_first_payment_date,first_transaction_id=@first_transaction_id where username_3des=@username_3des", con2);
                cmd2.Parameters.AddWithValue("@username_3des", username_3des_hf.Value);
                cmd2.Parameters.AddWithValue("@reffer_income", referr_income_hf.Value);
                cmd2.Parameters.AddWithValue("@first_package_amt", transaction_amt.Text.Trim().ToString());
                cmd2.Parameters.AddWithValue("@referr_income_status", "Success");
                cmd2.Parameters.AddWithValue("@referr_package_name", package_name_lbl.Text);
                cmd2.Parameters.AddWithValue("@referr_package_id", referr_package_id_hf.Value);
                cmd2.Parameters.AddWithValue("@first_payment_date", indianTime.ToString("dd MMM yyy hh:mm:ss tt"));
                cmd2.Parameters.AddWithValue("@query_first_payment_date", indianTime.ToString("yyyyMMdd"));
                cmd2.Parameters.AddWithValue("@first_transaction_id", first_transaction_id_hf.Value);
                //cmd2.Parameters.AddWithValue("@reffer_income", referr_income_hf.Value);
                //cmd2.Parameters.AddWithValue("@first_transaction_id", first_transaction_id_hf.Value);
                con2.Open();
                int count = cmd2.ExecuteNonQuery();
                con2.Close();
                con2.Dispose();
            }
            else
            {
                Response.Write("Not found");
                con1.Close();
                con1.Dispose();
                myReader.Close();
            }
            con1.Close();
            con1.Dispose();
            myReader.Close();
        //}
        //catch(Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
    }

    public void getPastWeek()
    {
        // Get the current date
        DateTime currentDate = DateTime.Now;
        // Calculate the start date of the previous week
        DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 6);
        // Calculate the end date of the previous week
        DateTime endDate = startDate.AddDays(6);
        // Display the results
        //Response.Write("Previous week start date: " + startDate.ToString("dd/MM/yyyy"));
        //Response.Write("Previous week end date: " + endDate.ToString("dd/MM/yyyy"));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["acuun"] == null || Request.Cookies["acupw"] == null)
            {
                Response.Redirect("index.aspx");
            }
            getPastWeek();
            //generateWeeklySalery();
            //return;
            fillDetails();
        }
    }

    protected void approve_btn_Click(object sender, EventArgs e)
    {
        try
        {
            successdiv.Visible = false;
            errordiv.Visible = false;
            if (confirm_cb.Checked == true)
            {
                generateReferrIncome();
                SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                SqlCommand cmd2 = new SqlCommand("update transactions set transaction_status=@transaction_status where sr=@sr", con2);
                cmd2.Parameters.AddWithValue("@sr", Request.QueryString["sr"].ToString());
                cmd2.Parameters.AddWithValue("@transaction_status", "Success");
                con2.Open();
                int count = cmd2.ExecuteNonQuery();
                con2.Close();
                con2.Dispose();
                successdiv.Visible = true;
                successlbl.Text = "Transaction Approved";
                errordiv.Visible = false;
                confirm_cb.Checked=false;
                Response.Redirect("pending-transactions.aspx");
            }
            else
            {
                errordiv.Visible = true;
                errorlbl.Text = "Kindly confirm to approve transaction";
            }
        }
        catch (Exception ex)
        {
            errordiv.Visible = true;
            errorlbl.Text = ex.Message;
        }
    }

    protected void reject_btn_Click(object sender, EventArgs e)
    {
        try
        {
            successdiv.Visible = false;
            errordiv.Visible = false;

            if (confirm_cb.Checked == true)
            {
                SqlConnection con2 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            SqlCommand cmd2 = new SqlCommand("update transactions set transaction_status=@transaction_status where sr=@sr", con2);
            cmd2.Parameters.AddWithValue("@sr", Request.QueryString["sr"].ToString());
            cmd2.Parameters.AddWithValue("@transaction_status", "Cancelled");
            con2.Open();
            int count = cmd2.ExecuteNonQuery();
            con2.Close();
            con2.Dispose();
            successdiv.Visible = true;
            successlbl.Text = "Transaction Cancelled";
            errordiv.Visible = false;
                confirm_cb.Checked = false;
            Response.Redirect("pending-transactions.aspx");
            }
            else
            {
                errordiv.Visible = true;
                errorlbl.Text = "Kindly confirm to approve transaction";
            }
        }
        catch (Exception ex)
        {
            errordiv.Visible = true;
            errorlbl.Text = ex.Message;
        }
    }

}