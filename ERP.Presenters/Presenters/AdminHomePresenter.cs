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
    public class AdminHomePresenter : PresenterBase
    {

        private readonly IAdminHomeView _view;

        private readonly IAdminHomeModel _model;


        public AdminHomePresenter(IAdminHomeView view, IAdminHomeModel model)
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

            _view.ShowCurrentItemClick += OnShowCurrentItemClicked;

            _view.ShowCurrentOrderClick += OnShowCurrentOrderClicked;


        }


        public override void FirstTimeInit()
        {

            base.FirstTimeInit();

            DisplaytWelcomeMessage();

            OnShowCurrentItemClicked(this, EventArgs.Empty);

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

        private void SetProductionStats()
        {

            _view.AvgTimeToProduceAnItem = _model.GetAvgTimeToProduceAnItem();

            _view.NumberOfItemsFailed = _model.GetNumberOfFailedItems();

            _view.NumberOfItemsProduced = _model.GetNumberOfCompleteItems();

            _view.NumberOfOrdersCompleted = _model.GetNumberOfCompleteOrders();

        }


        private void OnLogoutClicked(object sender, EventArgs e)
        {

            _model.ResetSession();

            _view.RedirectToLoginPage();

        }


        private void OnShowCurrentOrderClicked(object sender, EventArgs e)
        {

            FetchOrderData(OrdersToFetch.CurrentOrder);

        }


        private void OnShowCurrentItemClicked(object sender, EventArgs e)
        {

            FetchOrderData(OrdersToFetch.CurrentItem);

        }

        private void OnShowAllOrdersClicked(object sender, EventArgs e)
        {

            FetchOrderData(OrdersToFetch.AllOrders);


        }

        private void OnShowAllConfirmedOrdersClicked(object sender, EventArgs e)
        {

            FetchOrderData(OrdersToFetch.AllConfirmed);


        }

        private void OnShowAllOrdersInProductionClicked(object sender, EventArgs e)
        {

            FetchOrderData(OrdersToFetch.AllInProduction);


        }

        private void OnShowAllCompletedOrdersClicked(object sender, EventArgs e)
        {

            FetchOrderData(OrdersToFetch.AllCompleted);

        }

        public void FetchOrderData(OrdersToFetch ordersToFetch)
        {

            _view.SetDataSource = _model.FetchOrderData(ordersToFetch);

            _view.BindData();

            _view.Message = _model.FetchOrderDataInfoMessage(ordersToFetch);

            SetProductionStats();

        }

        private void OnRowSelected(object sender, EventArgs e)
        {

            int orderId = (int)_view.SelectedRowValueDataKey;

            _model.SetSelectedOrderIdToSession(orderId);

            ShowItemsInSelecetedOrder(ItemsToFetch.AllItemsInOrderAdmin);

        }

        public void ShowItemsInSelecetedOrder(ItemsToFetch itemsToFetch)
        {

            _view.SetDataSource = _model.FetchItemsData(itemsToFetch);

            _view.BindData();

            _view.Message = _model.FetchItemDataInfoMessage(itemsToFetch);

        }

    }
}

