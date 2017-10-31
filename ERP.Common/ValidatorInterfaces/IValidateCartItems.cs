using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.ValidatorInterfaces
{
    public interface IValidateCartItems<T> where T : class 
    {
        List<string> FillPropertyList(T client);
    }
}
