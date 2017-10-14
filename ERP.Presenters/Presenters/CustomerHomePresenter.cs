using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Presenters.Bases;
using ERP.Common.ViewInterfaces;
using ERP.Common.ModelInterfaces;

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

            OnShowAllOrdersClicked(this, EventArgs.Empty);

        }

        private void OnPageLoaded(object sender, EventArgs e)
        {

            bool? IsValid = _model.CheckLoggedInStatus();
            if ((bool)IsValid)
            {

                DisplaytWelcomeMessage();

            }
            else
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

            _view.SetDataSource = _model.GetAllOrders();

            _view.BindData();

            _view.InfoMessage = "Viewing all orders. Please click a row to view the order items.";

        }

        private void OnShowAllConfirmedOrdersClicked(object sender, EventArgs e)
        {

            _view.SetDataSource = _model.GetAllConfirmedOrders();

            _view.BindData();

            _view.InfoMessage = "Viewing confirmed orders awaiting production. Please click a row to view the order items.";

        }

        private void OnShowAllOrdersInProductionClicked(object sender, EventArgs e)
        {

            _view.SetDataSource = _model.GetAllOrdersInProduction();

            _view.BindData();

            _view.InfoMessage = "Viewing orders currently in production. Please click a row to view the order items.";
        }

        private void OnShowAllCompletedOrdersClicked(object sender, EventArgs e)
        {
           
            _view.SetDataSource = _model.GetAllCompletedOrders();

            _view.BindData();

            _view.InfoMessage = "Viewing all completed orders. Please click a row to view the order items.";

        }

        private void OnRowSelected(object sender, EventArgs e)
        {

            int orderId = (int)_view.SelectedRowValueDataKey;

            _model.SetSelectedOrderIdToSession(orderId);

            ShowItemsInSelecetedOrder();

        }

        public void ShowItemsInSelecetedOrder()
        {

            int orderId = _model.GetSelectedOrderIdFromSession();

            _view.SetDataSource = _model.GetAllItemsForOrder(orderId);

            _view.BindData();

            _view.InfoMessage = "Viewing all items in the selected order.";

        }
    }
}
