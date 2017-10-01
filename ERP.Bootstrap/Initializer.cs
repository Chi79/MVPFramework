using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ERP.Presenters.Framework;

namespace ERP.Bootstrap
{
    public class Initializer : IHttpModule  //Is the fist thing that will run at startup and is added to WebConfig
                                            //be careful when entering the directory in Webconfig that the name is correct and
                                            //that there are no extra whitespaces between the comma!
    {
        public void Init(HttpApplication context)
        {
            var bootstrapper = new Bootstrapper();     //the bootstrapper will create a new container with all the classes
            bootstrapper.BootstrapStructureMap();      //that need dependencies resolved
            IOC.Container = bootstrapper.Container;
        }
        public void Dispose()
        {

        }
    }
}
