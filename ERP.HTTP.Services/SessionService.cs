using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ERP.Common.ServiceInterfaces;

namespace ERP.HTTP.Services
{
    public class SessionService : ISessionService
    {
        public string CurrentClientEmail
        {
            get
            {
                var client = HttpContext.Current.Session["CurrentClientEmail"].ToString();
                if(client != null)
                {
                    return client.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            { HttpContext.Current.Session["CurrentClientEmail"] = value; }
        }

        public bool? LoggedInStatus
        {
            get
            {
                var status = HttpContext.Current.Session["LoggedInStatus"];
                if(status != null)
                {

                    return (bool)status;

                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["LoggedInStatus"] = value; }
        }
      
    }
}
