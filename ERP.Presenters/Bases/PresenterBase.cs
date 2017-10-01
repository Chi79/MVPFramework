using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Presenters.Bases
{
    public abstract class PresenterBase
    {
        //The base presenter class for all presenters - contains three virtual methods to be overridden so that we have control 
        //over the stages of the page object lifecycle with regards to postbacks ect. Load will be run when 'OnLoad' event is 
        //fired ect....

        public virtual void Load() { }
        public virtual void PreRender() { }
        public virtual void FirstTimeInit() { }   // will run when a page loads for the first time and is not a postback
    }
}
