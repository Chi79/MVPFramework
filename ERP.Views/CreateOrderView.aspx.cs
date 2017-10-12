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
    public partial class CreateOrderView : ViewBase<CreateOrderPresenter> , ICreateOrderView
    {
        public string Message { set { lblMessage.Text = value; } }

        public bool MessageVisible { set { lblMessage.Visible = value; } }

        public string InfoMessage { set { lblInfoMessage.Text = value; } }

        public void RedirectToHomePage()
        {
            Response.Redirect("CustomerHomeView.aspx");
        }

        public void RedirectToLoginPage()
        {
            Response.Redirect("LoginView.aspx");
        }

        public event EventHandler<EventArgs> PageLoad;

        protected override void OnLoadComplete(EventArgs e)
        {

            base.OnLoadComplete(e);

            PageLoad?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> ViewOrdersClick;

        protected void btnViewOrders_Click(object sender, EventArgs e)
        {

            ViewOrdersClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> LogoutClick;

        protected void btnLogoutButton_Click(object sender, EventArgs e)
        {

            LogoutClick?.Invoke(this, EventArgs.Empty);

        }
    }
}
