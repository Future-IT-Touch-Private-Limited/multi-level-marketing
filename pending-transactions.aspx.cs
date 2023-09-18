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

public partial class admin_pending_transactions : System.Web.UI.Page
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
        string strcon = "select * from transactions where transaction_status=@transaction_status ORDER BY sr DESC";
        SqlCommand cmd = new SqlCommand(strcon, con);
        cmd.Parameters.AddWithValue("@transaction_status", "Submitted");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(dtable);
        con.Close();
        con.Dispose();
        return dtable;
    }

    private void BindDataList()
    {
        //try
        //{
        DataTable dt = GetData();
        pgsource.DataSource = dt.DefaultView;
        pgsource.AllowPaging = true;
        pgsource.PageSize = 20;
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
        //}
        //catch (Exception ex)
        //{

        //}
    }

    private void doPaging()
    {
        //try
        //{
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
        //}
        //catch (Exception ex)
        //{
        //}
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
        //try
        //{
        CurrentPage = 0;
        BindDataList();
        //}
        //catch (Exception ex)
        //{
        //}
    }
    protected void lnkLast_Click(object sender, EventArgs e)
    {
        //try
        //{
        CurrentPage = (Convert.ToInt32(ViewState["totpage"]) - 1);
        BindDataList();
        //}
        //catch (Exception ex)
        //{
        //}
    }
    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        //try
        //{
        CurrentPage -= 1;
        BindDataList();
        //}
        //catch (Exception ex)
        //{
        //}
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        //try
        //{
        CurrentPage += 1;
        BindDataList();
        //}
        //catch (Exception ex)
        //{
        //}
    }
    protected void RepeaterPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //try
        //{
        if (e.CommandName.Equals("newpage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataList();
        }
        //}
        //catch (Exception ex)
        //{
        //}
    }
    protected void RepeaterPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //try
        //{
        LinkButton lnkPage = (LinkButton)e.Item.FindControl("Pagingbtn");
        if (lnkPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkPage.Enabled = false;
            lnkPage.BackColor = System.Drawing.Color.FromName("#FFCC01");
        }
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
    }


    public void all_transactions_count()
    {
        try
        {
            SqlConnection con01 = new SqlConnection(EncDec.DecryptString(System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
            string myScalarQuery01 = "select count(*) from transactions where transaction_status=@transaction_status";
            SqlCommand myCommand01 = new SqlCommand(myScalarQuery01, con01);
            myCommand01.Parameters.AddWithValue("@transaction_status", "Submitted");
            myCommand01.Connection.Open();
            int countuser01 = (int)myCommand01.ExecuteScalar();
            con01.Close();
            con01.Dispose();
            pending_transactions_lbl.Text = countuser01.ToString();
        }
        catch (Exception ex)
        {
            pending_transactions_lbl.Text = "0";
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //try
            //{

            if (Request.Cookies["acuun"] == null || Request.Cookies["acupw"] == null)
            {
                Response.Redirect("index.aspx");
            }
            BindDataList();
            all_transactions_count();
            //}
            //catch (Exception ex)
            //{
            //}
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
        { }
    }

}