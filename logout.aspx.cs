using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sunil_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //remove cookies
            //Response.Cookies["un"].Domain = "epackers.in";
            Response.Cookies["acuun"].Expires = DateTime.Now.AddYears(-5);
            //Response.Cookies["pw"].Domain = "epackers.in";
            Response.Cookies["acupw"].Expires = DateTime.Now.AddYears(-5);
            Response.Redirect("index.aspx");
        }
        catch (Exception ex)
        { }
    }
}