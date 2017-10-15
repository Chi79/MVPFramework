using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.ModelInterfaces;
using ERP.Common.RepositoryInterfaces;
using ERP.Common.ServiceInterfaces;
using ERP.Model.CartObjects;
using ERP.Common.CartInterfaces;
using ERP.Common.Enums;

namespace ERP.Model
{
    public class ConfirmOrderModel : IConfirmOrderModel
    {

        private readonly ISessionService _session;

        private readonly IUnitOfWork _uOW;

        private IList<object> _cartList;


        public ConfirmOrderModel(ISessionService session, IUnitOfWork uOW)
        {

            _session = session;

            _uOW = uOW;

            _cartList = GetItemsInCart().ToList();

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

        public IEnumerable<object> GetItemsInCart()
        {

            var itemsInCart = _session.ItemsInCart;

            return itemsInCart.ToList();

        }

    }
}
