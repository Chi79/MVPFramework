using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ViewInterfaces
{
    public interface IView
    {
        //The base interface for all views - will be implemented by the ViewBase class. All attributes here will be globaly 
        //available to all views.

        Uri Uri { get; }  // Uri simply returns the Http.Context.Current.Request.URL

    }
}
