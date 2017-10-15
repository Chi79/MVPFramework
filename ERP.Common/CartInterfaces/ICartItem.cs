using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Common.Enums;

namespace ERP.Common.CartInterfaces
{
    public interface ICartItem
    {

        int ID { get; set; }

        int MLs { get; }

        double Price { get; }

        string Size { get; }

        string Colour { get; }
    }
}
