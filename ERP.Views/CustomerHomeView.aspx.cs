using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Common.ViewInterfaces;
using ERP.Presenters.Bases;
using ERP.Presenters.Presenters;

namespace ERP.Views
{
    public partial class CustomerHomeView : ViewBase<CustomerHomePresenter> , ICustomerHomeView
    {

        public string Message { set { lblMessage.Text = value; } }

        public bool MessageVisible { set { lblMessage.Visible = value; } }

        public void RedirectToLoginPage()
        {

            Response.Redirect("LoginView.aspx");

        }

        public event EventHandler<EventArgs> LogoutClick;

        protected void btnLogoutButton_Click(object sender, EventArgs e)
        {

            if (LogoutClick != null)
            {

                LogoutClick(this, EventArgs.Empty);

            }

        }

        public event EventHandler<EventArgs> PageLoad;

        protected override void OnLoadComplete(EventArgs e)
        {

            base.OnLoadComplete(e);

            if (PageLoad != null)
            {

                PageLoad(this, EventArgs.Empty);

            }

        }
    }
}