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
    public class WelcomePresenter : PresenterBase
    {

        private readonly IWelcomeView _view;

        private readonly IWelcomeModel _model;

        public WelcomePresenter(IWelcomeView view, IWelcomeModel model)
        {

            _view = view;

            _model = model;

            _view.GoToLoginButtonClicked += OnGoToLoginButtonClicked;

        }

        public override void Load()
        {

            _view.WelcomeTitle = _model.GetWelcomeTitle();

            _view.WelcomeMessage = _model.GetWelcomeMessage();

        }

        private void OnGoToLoginButtonClicked(object sender, EventArgs e)
        {

            _view.RedirectToLoginView();

        }
    }
}
