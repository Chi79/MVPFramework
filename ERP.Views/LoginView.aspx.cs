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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Email { get { return txtEmail.Text; } }

        public string Password { get { return txtPassword.Text; } }

        public string Message { set { lblMessage.Text = value; } }


        public event EventHandler<EventArgs> LoginAttempt;

        protected void btnLoginButton_Click(object sender, EventArgs e)
        {

            if(LoginAttempt != null)
            {

                LoginAttempt(this, EventArgs.Empty);

            }

        }

        public void RedirectToCustomerHomePage()
        {

            lblMessage.Text = "Customer Home Page Coming Soon...";

        }

        public void RedirectToOperatorHomePage()
        {

            lblMessage.Text = "Operator Home Page Coming Soon...";

        }

        public void RedirectToAdminHomePage()
        {

            lblMessage.Text = "Admin Home Page Coming Soon...";

        }
    }
}