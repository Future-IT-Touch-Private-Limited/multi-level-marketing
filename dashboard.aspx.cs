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

public partial class admin_dashboard : System.Web.UI.Page
{
    string EncryptionKey = "@#future#@touch_!123~!admin@@";
    string EncryptionKey2 = "future@123@adm";
    EncDec EncDec = new EncDec();
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

    int int_fromDate = 0;
    int int_endDate = 0;
    string str_from_full_date = "";
    string str_to_full_date = "";

    //=====================================================
    //=====================================================

    public void calculatePastWeekFromToDate()
    {
        DateTime currentDate = indianTime;
        // Calculate the start date of the week
        DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek - 6);
        DateTime endDate = startDate.AddDays(6);
        // Display the results
        int_fromDate = Convert.ToInt32(startDate.ToString("yyyyMMdd"));
        int_endDate = Convert.ToInt32(endDate.ToString("yyyyMMdd"));


        str_from_full_date = startDate.ToString("dd MMM yyyy");
        str_to_full_date = endDate.ToString("dd MMM yyy");
    }

    //========================================================================
    //========================================================================
    //--today referral income-----
    public string today_referral_income()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(reffer_income) from users where query_first_payment_date=@query_first_payment_date and referr_income_status=@referr_income_status";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@query_first_payment_date", indianTime.ToString("yyyyMMdd"));
        command.Parameters.AddWithValue("@referr_income_status", "Success");
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }
    public string today_weekly_salery_income()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(salery_income) from weekly_salery where query_get_date=@query_get_date";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@query_get_date", indianTime.ToString("yyyyMMdd"));
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }
    public string today_daily_level_income()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(income) from daily_income where query_get_date=@query_get_date and status=@status";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@query_get_date", indianTime.ToString("yyyyMMdd"));
        command.Parameters.AddWithValue("@status", "Success");
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }


    //--total referral income
    public string total_referral_income()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(reffer_income) from users where referr_income_status=@referr_income_status";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@referr_income_status", "Success");
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }
    public string total_weekly_salery_income()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(salery_income) from weekly_salery";
        SqlCommand command = new SqlCommand(query, connection);
        //command.Parameters.AddWithValue("@query_get_date", indianTime.ToString("yyyyMMdd"));
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }
    public string total_daily_level_income()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(income) from daily_income where status=@status";
        SqlCommand command = new SqlCommand(query, connection);
        //command.Parameters.AddWithValue("@query_get_date", indianTime.ToString("yyyyMMdd"));
        command.Parameters.AddWithValue("@status", "Success");
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }
    //--weekly salery income
    public string weekly_salery_income()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(salery_income) from weekly_salery";
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }
    //--total recharge
    public string total_recharge()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(transaction_amt) from transactions where transaction_status=@transaction_status";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@transaction_status", "Success");
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }
    public string total_withdrawal()
    {
        SqlConnection connection = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string query = "select sum(withdrawal_amount) from withdrawal where (request_status='Success' or request_status='Submitted')";
        SqlCommand command = new SqlCommand(query, connection);
        //command.Parameters.AddWithValue("@username_3des", Request.Cookies["cuun"].Value.ToString());
        //command.Parameters.AddWithValue("@query_get_date", indianTime.ToString("yyyyMMdd"));
        //command.Parameters.AddWithValue("@request_status", "Success");
        //command.Parameters.AddWithValue("@request_status2", "Submitted");
        connection.Open();
        object total = command.ExecuteScalar();
        connection.Close();
        string str_total = total.ToString();
        if (str_total == "" || str_total == null)
        {
            str_total = "0";
        }
        return str_total.ToString();
    }

    public void total_available_balance()
    {
        double availableBalance = (Convert.ToDouble(total_referral_income()) + Convert.ToDouble(total_weekly_salery_income()) + Convert.ToDouble(total_daily_level_income())) - Convert.ToDouble(total_withdrawal());
        total_available_balance_lbl.Text = availableBalance.ToString();
    }

    //count total users
    public void total_users_count()
    {
        try
        {
            SqlConnection con01 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            string myScalarQuery01 = "select count(*) from users";
            SqlCommand myCommand01 = new SqlCommand(myScalarQuery01, con01);
            myCommand01.Connection.Open();
            int countuser01 = (int)myCommand01.ExecuteScalar();
            con01.Close();
            con01.Dispose();
            total_users_count_lbl.Text = countuser01.ToString();
        }
        catch (Exception ex)
        {
            total_users_count_lbl.Text = "0";
        }
    }
    //count premium users
    public void total_premium_users_count()
    {
        try
        {
            SqlConnection con01 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            string myScalarQuery01 = "select count(*) from users where referr_income_status=@referr_income_status";
            SqlCommand myCommand01 = new SqlCommand(myScalarQuery01, con01);
            myCommand01.Parameters.AddWithValue("@referr_income_status", "Success");
            myCommand01.Connection.Open();
            int countuser01 = (int)myCommand01.ExecuteScalar();
            con01.Close();
            con01.Dispose();
            premium_users_count_lbl.Text = countuser01.ToString();
        }
        catch (Exception ex)
        {
            premium_users_count_lbl.Text = "0";
        }
    }
    //count basic users
    public void total_basic_users_count()
    {
        try
        {
            SqlConnection con01 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            string myScalarQuery01 = "select count(*) from users where referr_income_status<>@referr_income_status";
            SqlCommand myCommand01 = new SqlCommand(myScalarQuery01, con01);
            myCommand01.Parameters.AddWithValue("@referr_income_status", "Success");
            myCommand01.Connection.Open();
            int countuser01 = (int)myCommand01.ExecuteScalar();
            con01.Close();
            con01.Dispose();
            basic_users_count_lbl.Text = countuser01.ToString();
        }
        catch (Exception ex)
        {
            basic_users_count_lbl.Text = "0";
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
            calculatePastWeekFromToDate();

            int total_valid_users = 0;

            try
            {
                SqlConnection con01 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
                string myScalarQuery01 = "select count(*) from users where referr_income_status=@referr_income_status and query_first_payment_date >= @int_fromDate and query_first_payment_date <= @int_endDate";
                SqlCommand myCommand01 = new SqlCommand(myScalarQuery01, con01);
                myCommand01.Parameters.AddWithValue("@referr_income_status", "Success");
                myCommand01.Parameters.AddWithValue("@int_fromDate", int_fromDate);
                myCommand01.Parameters.AddWithValue("@int_endDate", int_endDate);
                myCommand01.Parameters.AddWithValue("@start_date", str_from_full_date);
                myCommand01.Parameters.AddWithValue("@end_date", str_to_full_date);
                myCommand01.Connection.Open();
                int countuser01 = (int)myCommand01.ExecuteScalar();
                con01.Close();
                con01.Dispose();
                total_valid_users = countuser01;
            }
            catch (Exception ex)
            {
                total_valid_users = 0;
            }

            //-----
            today_income_lbl.Text = (Convert.ToDouble(today_referral_income()) + Convert.ToDouble(today_daily_level_income()) + Convert.ToDouble(today_weekly_salery_income())).ToString();
            referral_income_lbl.Text = total_referral_income();
            weekly_salery_income_lbl.Text = weekly_salery_income();
            total_recharge_lbl.Text = total_recharge();
            today_income_lbl.Text = (Convert.ToDouble(today_referral_income()) + Convert.ToDouble(today_weekly_salery_income()) + Convert.ToDouble(today_daily_level_income())).ToString();
            total_income_lbl.Text = (Convert.ToDouble(total_referral_income()) + Convert.ToDouble(total_weekly_salery_income()) + Convert.ToDouble(total_daily_level_income())).ToString();
            today_daily_level_income_lbl.Text = today_daily_level_income();
            today_referral_income_lbl.Text = today_referral_income();
            total_withdrawal_lbl.Text = total_withdrawal();
            total_available_balance();
            total_users_count();
            total_premium_users_count();
            total_basic_users_count();
        }
    }

}