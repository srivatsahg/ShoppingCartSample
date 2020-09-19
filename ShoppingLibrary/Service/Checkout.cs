
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingLibrary.Interfaces;
using ShoppingLibrary.Model;

namespace ShoppingLibrary.Service
{
    /// <summary>
    /// The Main Checkout class which has one responsibility of selecting a strategy 
    /// 1.  Regular Costing 
    /// 2.  Applying promotional discount strategy
    /// </summary>
    public class Checkout
    {
        private ICheckoutStrategy applyDiscountStrategy;

        public Checkout(ICheckoutStrategy checkoutStrategy)
        {
            this.applyDiscountStrategy = checkoutStrategy;
        }

        public double CalculateTotalCost(List<ShoppingCart> shoppingCart)
        {
            return applyDiscountStrategy.CalculateTotalCost(shoppingCart);
        }

    }
}
