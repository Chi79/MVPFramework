using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.Common.ViewInterfaces;
using ERP.Presenters.Bases;
using ERP.Presenters.Presenters;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

namespace ERP.Views
{
    public partial class AdminHomeView : ViewBase<AdminHomePresenter> , IAdminHomeView
    {

        public string Message { set { lblMessage.Text = value; } }

        public bool MessageVisible { set { lblMessage.Visible = value; } }

        public string InfoMessage { set { lblInfoMessage.Text = value; } }

        public string NumberOfItemsProduced { set { txtNumberOfCompletedItems.Value = value; } }

        public string NumberOfOrdersCompleted { set { txtNumberOfCompletedOrders.Value = value; } }

        public string NumberOfItemsFailed { set { txtNumberOfFailedItems.Value = value; } }

        public string AvgTimeToProduceAnOrder { set { txtAvgOrderProductionTime.Value = value; } }

        public object SelectedRowValueDataKey { get { return gvOrders.DataKeys[SelectedRowIndex].Value; } }

        public int SelectedRowIndex { get { return gvOrders.SelectedIndex; } }

        public int GridViewRowCount { get { return gvOrders.Rows.Count; } }

        public bool PrintButtonVisible { set { btnGetPDF.Visible = value; } }

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


        //public event EventHandler<EventArgs> CreateNewOrderClick;

        //protected void btnCreateNewOrder_Click(object sender, EventArgs e)
        //{

        //    CreateNewOrderClick?.Invoke(this, EventArgs.Empty);

        //}


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

        public event EventHandler<EventArgs> ShowCurrentItemClick;

        protected void btnCurrentItem_Click(object sender, EventArgs e)
        {

            ShowCurrentItemClick?.Invoke(this, EventArgs.Empty);

        }


        public event EventHandler<EventArgs> ShowCurrentOrderClick;

        protected void btnCurrentOrder_Click(object sender, EventArgs e)
        {

            ShowCurrentOrderClick?.Invoke(this, EventArgs.Empty);

        }

        public void OutputFile()
        {

            byte[] fileAsBytes = Session["file"] as byte[];

            Response.ClearContent();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=myFile2.pdf");
            Response.Buffer = true;
            Response.OutputStream.Write(fileAsBytes, 0, fileAsBytes.Length);
            Response.Flush();
            Response.End();

        }

        public event EventHandler<EventArgs> PDFButtonClick;

        protected void btnGetPDF_Click(object sender, EventArgs e)
        {

            PDFButtonClick?.Invoke(this, EventArgs.Empty);

        }
    }
}