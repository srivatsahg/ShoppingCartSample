
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingLibrary.Interfaces;
using ShoppingLibrary.Model;

namespace ShoppingLibrary.Service
{
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
