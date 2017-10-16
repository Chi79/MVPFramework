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
                if (client != null)
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

        public string CurrentClientName
        {
            get
            {
                var client = HttpContext.Current.Session["CurrentClientName"].ToString();
                if (client != null)
                {
                    return client.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            { HttpContext.Current.Session["CurrentClientName"] = value; }
        }

        public int? CurrentClientID
        {
            get
            {
                var clientID = HttpContext.Current.Session["CurrentClientID"];
                if (clientID != null)
                {
                    return (int?)clientID;
                }
                else
                {
                    return null;
                }
            }
            set
            { HttpContext.Current.Session["CurrentClientID"] = value; }
        }

        public bool? LoggedInStatus
        {
            get
            {
                var status = HttpContext.Current.Session["LoggedInStatus"];
                if (status != null)
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

        public int? SelectedOrderId
        {
            get
            {
                var orderId = HttpContext.Current.Session["SelectedOrderId"];
                if (orderId != null)
                {

                    return (int)orderId;

                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["SelectedOrderId"] = value; }

        }

        public IEnumerable<object> ItemsInCart
        {
            get
            {
                var items = HttpContext.Current.Session["ItemsInCart"];
                if (items != null)
                {

                    return items as IEnumerable<object>;

                }
                else
                {
                    List<object> newItemsList = new List<object>();
                    return newItemsList;
                }
            }
            set { HttpContext.Current.Session["ItemsInCart"] = value; }

        }


        public bool? OrderHasNotBeenSubmitted
        {
            get
            {
                var status = HttpContext.Current.Session["OrderIsNewSinceLastSubmission"];
                if (status != null)
                {

                    return (bool)status;

                }
                else
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["OrderIsNewSinceLastSubmission"] = value; }
        }
    }

}
