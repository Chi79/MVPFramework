using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Model.CartObjects;
using ERP.Common.ValidatorInterfaces;
using ERP.Common.CartInterfaces;
using ERP.Model.Utilites;

namespace ERP.Model.Validators
{
    public class ValidateCartItems : Validate<ICartItem> , IValidateCartItems<ICartItem>
    {
        public List<string> FillPropertyList(ICartItem cartItem)
        {

            return PropertiesToStringListConverter<ICartItem>.ConvertPropertiesToStringList(cartItem);

        }
        public override void CheckForBrokenRules(ICartItem cartItem)
        {

            var propertyList = FillPropertyList(cartItem);

            base.CheckForBrokenRules(cartItem);

            if(cartItem.MLs == 0)
            {

                AddBrokenRule("An item must contain some water! Please select the amount in mls before adding the item.");

            }

            if (cartItem.Size == "Large" && (cartItem.MLs < 0 || cartItem.MLs > 50))
            {

                AddBrokenRule("A Large item must contain between 0 to 50ml of water!");

            }

            if (cartItem.Size == "Small" && (cartItem.MLs < 0 || cartItem.MLs > 15))
            {

                AddBrokenRule("A Small item must contain between 0 to 15ml of water!");

            }

        }
    }
}
