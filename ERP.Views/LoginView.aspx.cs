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
    public partial class LoginView : ViewBase<LoginPresenter> , ILoginView
    {

        public string Email { get { return txtEmail.Value; } }

        public string Password { get { return txtPassword.Text; } }

        public string Message { set { lblMessage.Text = value; } }

        public bool MessageVisible { set { messagePanel.Visible = value; } }


        public event EventHandler<EventArgs> LoginClick;

        protected void btnLoginButton_Click(object sender, EventArgs e)
        {

            LoginClick?.Invoke(this, EventArgs.Empty);

        }

        public void RedirectToCustomerHomePage()
        {

            Response.Redirect("CustomerHomeView.aspx");

        }

        public void RedirectToOperatorHomePage()
        {

            Response.Redirect("OperatorHomeView.aspx");

        }

        public void RedirectToAdminHomePage()
        {

            Response.Redirect("AdminHomeView.aspx");
                
        }

    }
}