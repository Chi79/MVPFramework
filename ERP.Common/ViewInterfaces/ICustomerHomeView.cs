﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface ICustomerHomeView
    {

        string Message { set; }

        bool MessageVisible { set; }

        void RedirectToLoginPage();

        event EventHandler<EventArgs> LogoutClick;

        event EventHandler<EventArgs> PageLoad;

    }
}