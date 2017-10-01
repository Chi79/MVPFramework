using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Pipeline;

namespace ERP.Presenters.Framework
{
    public class IOC
    {
        public static IContainer Container;

        public static void Reset()
        {
            if(Container == null)
            {
                return;
            }
            Container.Dispose();
            Container = null;
        }

        public static TPresenter GetPresenter<TPresenter>(object view)    //method wil be run each time a new view page is loaded
        {                                                                 //to resolve the required presenter and interfaces
            var explicitArguments = new ExplicitArguments();              //from the IOC container

            foreach (var implementedInterface in view.GetType().GetInterfaces())
            {
                explicitArguments.Set(implementedInterface, view);
            }
            return Container.GetInstance<TPresenter>(explicitArguments);
        }
    }
}
