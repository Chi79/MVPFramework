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
    public partial class ConfirmOrderView : ViewBase<ConfirmOrderPresenter> , IConfirmOrderView
    {
        public string Message { set { lblMessage.Text = value; } }

        public bool MessageVisible { set { lblMessage.Visible = value; } }

        public string InfoMessage { set { lblInfoMessage.Text = value; } }

        public IEnumerable<object> SetDataSource { set { gvItems.DataSource = value; } }

        public void BindData()
        {

            gvItems.DataBind();

        }

        public void DisableCartDiv()
        {

            divCartList.Attributes.Add("style", "display:none");

        }

        public void EnableCartDiv()
        {

            divCartList.Attributes.Add("style", "display:inline-block");

        }

        public void RedirectToHomePage()
        {

            Response.Redirect("CustomerHomeView.aspx");

        }


        public void RedirectToLoginPage()
        {

            Response.Redirect("LoginView.aspx");

        }

        public void RedirectToCreateOrderPage()
        {

            Response.Redirect("CreateOrderView.aspx");

        }


        public event EventHandler<EventArgs> PageLoad;

        protected override void OnLoadComplete(EventArgs e)
        {

            base.OnLoadComplete(e);

            PageLoad?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> EditOrderClick;

        protected void btnEditOrder_Click(object sender, EventArgs e)
        {

            EditOrderClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> LogoutClick;

        protected void btnLogoutButton_Click(object sender, EventArgs e)
        {

            LogoutClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> OrderConfirmedClick;

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {

            OrderConfirmedClick?.Invoke(this, EventArgs.Empty);

        }

        public event EventHandler<EventArgs> ViewAllOrdersClick;

        protected void btnViewAllOrders_Click(object sender, EventArgs e)
        {

            ViewAllOrdersClick?.Invoke(this, EventArgs.Empty);

        }
    }
}