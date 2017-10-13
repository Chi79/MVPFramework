using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common.CartInterfaces
{
    public interface ICartItem
    {

        int ID { get; set; }

        string ItemType { get; set; }

        int MLs { get; set; }

        double Price { get; set; }

        double CalculatePrice();

    }
}
