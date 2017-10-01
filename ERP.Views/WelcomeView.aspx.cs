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
    public partial class WelcomeView : ViewBase<WelcomePresenter> , IWelcomeView
    {
        public string WelcomeMessage
        {

            set { txtWelcomeMessage.Text = value; }

        }

        public string WelcomeTitle
        {

            set { txtWelcomeTitle.Text = value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
    }
}