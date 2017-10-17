using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP.Views
{
    public partial class MasterView : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var status = Session["LoggedInStatus"].ToString();
                if ((bool)Session["LoggedInStatus"] == false || Session["LoggedInStatus"] == null)
                {
                    Response.Redirect("LoginView.aspx");
                }
                else
                {
                    Response.ClearHeaders();
                    Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                    Response.AddHeader("Pragma", "no-cache");
                }
            }
        }
    }
}