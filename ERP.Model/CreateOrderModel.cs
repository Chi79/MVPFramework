using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.Enums;

namespace ERP.Model
{
    public class CreateOrderModel : ICreateOrderModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;

        public CreateOrderModel(ISessionService session, IUnitOfWork uOW)
        {

            _session = session;

            _uOW = uOW;

        }

        public string GetCurrentClientName()
        {

            return _session.CurrentClientName;

        }

        public bool? CheckLoggedInStatus()
        {

            return _session.LoggedInStatus;

        }

        public void ResetSession()
        {

            _session.CurrentClientEmail = string.Empty;

            _session.CurrentClientName = string.Empty;

            _session.LoggedInStatus = false;

        }

        public string AddItemToCart(string amountInMls)
        {
            int amount = Convert.ToInt32(amountInMls);

            int empty = 0;

            if (amount == empty)
            {
                return "An item must contain some water! Please select the amount in mls before adding the item.";
            }
            else
            {
                return "One small clear bottle with " + amount.ToString() + " millileters has been added to your order.";

                //TODO: add the item to the list of items and display the list in view
            }

        }

    }
}
