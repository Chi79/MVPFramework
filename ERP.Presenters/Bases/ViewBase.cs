using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using ERP.Common.ViewInterfaces;
using ERP.Presenters.Framework;

namespace ERP.Presenters.Bases
{
    public abstract class ViewBase<TPresenter> : Page , IView where TPresenter : PresenterBase 
    {
        //Base view class which will be inhereted by all of the views.  It needs an object that is of the type 'PresenterBase', 
        //and implements the IView interface. The generic Tpresenter is created by IOC when the pages OnLoad event fires -
        //then the appropriate PresenterBase method will run depending on the postback conditions.
        private TPresenter _presenter;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoadComplete(e);

            _presenter = CreatePresenter();  //IOC container method is called to create the  generic TPresenter

            if(!IsPostBack)                  //conditions depending on the page lifecyle will determine the config of the 
            {                                //presenter.
                _presenter.FirstTimeInit();
            }
            _presenter.Load();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRenderComplete(e);

            _presenter.PreRender();
            
        }

        protected TPresenter CreatePresenter()
        {
            return IOC.GetPresenter<TPresenter>(this);   //IOC creates the appropriate presenter for the given view
        }

        public virtual Uri Uri     //implements the IView interface method
        {
            get { return HttpContext.Current.Request.Url; }
        }
    }
}
