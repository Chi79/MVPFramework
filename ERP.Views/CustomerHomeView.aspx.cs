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

        public string InfoMessage { set { lblInfoMessage.Text = value; } }

        public object SelectedRowValueDataKey { get { return gvOrders.DataKeys[SelectedRowIndex].Value; } }

        public int SelectedRowIndex { get { return gvOrders.SelectedIndex; } }

        public IEnumerable<object> SetDataSource { set { gvOrders.DataSource = value; } }

        public void BindData()
        {

            gvOrders.DataBind();

        }

        public void RedirectToLoginPage()
        {

            Response.Redirect("LoginView.aspx");

        }

        public void RedirectToOrderPage()
        {

            Response.Redirect("CreateOrderView.aspx");

        }

        public event EventHandler<EventArgs> PageLoad;

        protected override void OnLoadComplete(EventArgs e)
        {

            base.OnLoadComplete(e);

            PageLoad?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> LogoutClick;

        protected void btnLogoutButton_Click(object sender, EventArgs e)
        {

            LogoutClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> CreateNewOrderClick;

        protected void btnCreateNewOrder_Click(object sender, EventArgs e)
        {

            CreateNewOrderClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> ShowAllOrdersClick;
  
        protected void btnShowAllOrders_Click(object sender, EventArgs e)
        {

            ShowAllOrdersClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> ShowAllConfirmedOrdersClick;

        protected void btnShowAllConfirmedOrders_Click(object sender, EventArgs e)
        {

            ShowAllConfirmedOrdersClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> ShowAllOrdersInProductionClick;

        protected void btnShowAllOrdersInProduction_Click(object sender, EventArgs e)
        {

            ShowAllOrdersInProductionClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> ShowAllCompletedOrdersClick;

        protected void btnShowAllCompletedOrders_Click(object sender, EventArgs e)
        {

            ShowAllCompletedOrdersClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> RowSelected;

        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

            RowSelected?.Invoke(this, EventArgs.Empty);

        }


        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvOrders, "Select$" + e.Row.RowIndex);
            }
        }

    }
}