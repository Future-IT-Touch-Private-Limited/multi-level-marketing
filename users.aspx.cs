using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_users : System.Web.UI.Page
{
    string EncryptionKey = "@#future#@touch_!123~!admin@@";
    string EncryptionKey2 = "future@123@adm";
    EncDec EncDec = new EncDec();
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);


    PagedDataSource pgsource = new PagedDataSource();
    int findex, lindex;
    DataRow dr;
    DataTable GetData()
    {
        DataTable dtable = new DataTable();
        SqlConnection con = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
        string strcon = "";
        if (searchtxt.Text.Trim() != "")
        {
            strcon = "select * from users where gender like '%'+ @sq +'%' or full_name like '%'+ @sq +'%' or email_address like '%'+ @sq +'%' or city like '%'+ @sq +'%' or state like '%'+ @sq +'%' or pin_code like '%'+ @sq +'%' or my_reffer_code like '%'+ @sq +'%' or account_status like '%'+ @sq +'%' or mobile_no like '%'+ @sq +'%' or account_query_date like '%'+ @sq +'%' or username_3des like '%'+ @sq2 +'%' and account_status=@account_status ORDER BY sr DESC";
        }
        else
        {
            strcon = "select * from users where account_status=@account_status order by sr DESC";
        }
        SqlCommand cmd = new SqlCommand(strcon, con);
        cmd.Parameters.AddWithValue("@sq", searchtxt.Text.Trim().ToString());
        cmd.Parameters.AddWithValue("@sq2", EncDec.EncryptString(searchtxt.Text.Trim().ToString(), EncryptionKey));
        cmd.Parameters.AddWithValue("@account_status", "Running");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(dtable);
        con.Close();
        con.Dispose();
        return dtable;
    }

    private void BindDataList()
    {
        try
        {
            DataTable dt = GetData();
        pgsource.DataSource = dt.DefaultView;
        pgsource.AllowPaging = true;
        pgsource.PageSize = 25;
        pgsource.CurrentPageIndex = CurrentPage;
        ViewState["totpage"] = pgsource.PageCount;
        lblpage.Text = "Page " + (CurrentPage + 1) + " of " + pgsource.PageCount;
        lnkPrevious.Enabled = !pgsource.IsFirstPage;
        lnkNext.Enabled = !pgsource.IsLastPage;
        lnkFirst.Enabled = !pgsource.IsFirstPage;
        lnkLast.Enabled = !pgsource.IsLastPage;
        Repeater1.DataSource = pgsource;
        Repeater1.DataBind();
        doPaging();
        RepeaterPaging.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        catch (Exception ex)
        {

        }
    }

    private void doPaging()
    {
        try
        {
            DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        findex = CurrentPage - 5;
        if (CurrentPage > 5)
        {
            lindex = CurrentPage + 5;
        }
        else
        {
            lindex = 10;
        }
        if (lindex > Convert.ToInt32(ViewState["totpage"]))
        {
            lindex = Convert.ToInt32(ViewState["totpage"]);
            findex = lindex - 10;
        }
        if (findex < 0)
        {
            findex = 0;
        }
        for (int i = findex; i < lindex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        RepeaterPaging.DataSource = dt;
        RepeaterPaging.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                return 0;
            }
            else
            {
                return ((int)ViewState["CurrentPage"]);
            }
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }
    protected void lnkFirst_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentPage = 0;
            BindDataList();
        }
        catch (Exception ex)
        {
        }
    }

    protected void lnkLast_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentPage = (Convert.ToInt32(ViewState["totpage"]) - 1);
        BindDataList();
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentPage -= 1;
        BindDataList();
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        try
        {
            CurrentPage += 1;
        BindDataList();
        }
        catch (Exception ex)
        {
        }
    }
    protected void RepeaterPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("newpage"))
            {
                CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
                BindDataList();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void RepeaterPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            LinkButton lnkPage = (LinkButton)e.Item.FindControl("Pagingbtn");
        if (lnkPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkPage.Enabled = false;
            lnkPage.BackColor = System.Drawing.Color.FromName("#FFCC01");
        }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            if (Request.Cookies["acuun"] == null || Request.Cookies["acupw"] == null)
            {
                Response.Redirect("index.aspx");
            }
            BindDataList();
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            Label username_3des = (Label)e.Item.FindControl("username_3des");
            username_3des.Text = EncDec.DecryptString(username_3des.Text, EncryptionKey);
        }
        catch (Exception ex)
        {
        }
        //try
        //{
        //    Label account_status = (Label)e.Item.FindControl("account_status");
        //    if(account_status.Text == "Running")
        //    {
        //        account_status.Text = "<span class='badge badge rounded-pill d-block badge-soft-success'>Running</span>";
        //    }
        //    else
        //    {
        //        account_status.Text = "<span class='badge badge rounded-pill d-block badge-soft-danger'>Blocked</span>";
        //    }
        //}
        //catch(Exception ex)
        //{ }
    }

    protected void search_btn_Click(object sender, EventArgs e)
    {
        BindDataList();
    }

}