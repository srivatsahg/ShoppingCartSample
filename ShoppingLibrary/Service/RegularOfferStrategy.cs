using System.Collections.Generic;
using ShoppingLibrary.Interfaces;
using ShoppingLibrary.Model;

namespace ShoppingLibrary.Service
{
    public class RegularOfferStrategy : ICheckoutStrategy
    {
        public double CalculateTotalCost(List<ShoppingCart> cart)
        {
            double totalCost = 0.0;

            //use linq to iterate and get the prices
            cart.ForEach(item =>
            {
                totalCost += item.Product.UnitPrice * item.Quantity;
            });

            return totalCost;
        }
    }
}
