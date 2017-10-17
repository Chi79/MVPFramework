using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Presenters.Bases;
using ERP.Common.ViewInterfaces;
using ERP.Common.ModelInterfaces;
using ERP.Common.Enums;

namespace ERP.Presenters.Presenters
{
    public class CustomerHomePresenter : PresenterBase
    {

        private readonly ICustomerHomeView _view;

        private readonly ICustomerHomeModel _model;


        public CustomerHomePresenter(ICustomerHomeView view, ICustomerHomeModel model)
        {

            _view = view;

            _model = model;

            WireUpEvents();

        }

        private void WireUpEvents()
        {

            _view.PageLoad += OnPageLoaded;

            _view.LogoutClick += OnLogoutClicked;

            _view.ShowAllOrdersClick += OnShowAllOrdersClicked;

            _view.ShowAllConfirmedOrdersClick += OnShowAllConfirmedOrdersClicked;

            _view.ShowAllOrdersInProductionClick += OnShowAllOrdersInProductionClicked;

            _view.ShowAllCompletedOrdersClick += OnShowAllCompletedOrdersClicked;

            _view.RowSelected += OnRowSelected;

            _view.CreateNewOrderClick += OnCreateNewOrderClicked;

        }


        public override void FirstTimeInit()
        {

            base.FirstTimeInit();

            DisplaytWelcomeMessage();

            OnShowAllOrdersClicked(this, EventArgs.Empty);

        }

        private void OnPageLoaded(object sender, EventArgs e)
        {
            bool IsValid = _model.CheckLoggedInStatus();
            if (!IsValid)
            {

                _view.RedirectToLoginPage();

            }


        }

        public void DisplaytWelcomeMessage()
        {

            _view.MessageVisible = true;

            _view.Message = "Welcome " + _model.GetCurrentClientName();

        }


        private void OnLogoutClicked(object sender, EventArgs e)
        {

            _model.ResetSession();

            _view.RedirectToLoginPage();

        }

        private void OnCreateNewOrderClicked(object sender, EventArgs e)
        {

            _view.RedirectToOrderPage();

        }

        private void OnShowAllOrdersClicked(object sender, EventArgs e)
        {     

            FetchCustomerOrderData(OrdersToFetch.AllOrders);

        }

        private void OnShowAllConfirmedOrdersClicked(object sender, EventArgs e)
        {

            FetchCustomerOrderData(OrdersToFetch.AllConfirmed);

        }

        private void OnShowAllOrdersInProductionClicked(object sender, EventArgs e)
        {

            FetchCustomerOrderData(OrdersToFetch.AllInProduction);

        }

        private void OnShowAllCompletedOrdersClicked(object sender, EventArgs e)
        {

            FetchCustomerOrderData(OrdersToFetch.AllCompleted);

        }

        public void FetchCustomerOrderData(OrdersToFetch ordersToFetch)
        {

            _view.SetDataSource = _model.FetchOrderData(ordersToFetch);

            _view.BindData();

            _view.InfoMessage = _model.FetchOrderDataInfoMessage(ordersToFetch);

        }

        private void OnRowSelected(object sender, EventArgs e)
        {

            int orderId = (int)_view.SelectedRowValueDataKey;

            _model.SetSelectedOrderIdToSession(orderId);

            ShowItemsInSelecetedOrder(ItemsToFetch.AllItemsInOrder);

        }

        public void ShowItemsInSelecetedOrder(ItemsToFetch itemsToFetch)
        {
       
            _view.SetDataSource = _model.FetchItemsData(itemsToFetch);

            _view.BindData();

            _view.InfoMessage = _model.FetchItemDataInfoMessage(itemsToFetch);

        }

    }
}
