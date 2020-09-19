using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingLibrary.Interfaces;
using ShoppingLibrary.Model;

namespace ShoppingLibrary.Service
{
    /// <summary>
    /// This class introduces a promotional offer as defined in the User Requirements
    /// 3 SKUs of Stock A - 130
    /// 2 SKUs of Stock B - 45
    /// A pair of Stocks C & D cost 30
    /// </summary>
    public class PromotionalOfferStrategy : ICheckoutStrategy
    {
        public const int SKU_A_DISCOUNT_RATE = 130;
        public const int SKU_B_DISCOUNT_RATE = 45;
        public const int SKU_C_D_DISCOUNT_RATE = 30;


        public double CalculateTotalCost(List<ShoppingCart> cart)
        {
            var totalCost = 0.0;

            totalCost = ApplyOffer(cart);

            return totalCost;
        }

        private double ApplyOffer(List<ShoppingCart> cart)
        {
            double totalCost = 0.0;
            uint quantityA = 0;
            uint quantityB = 0;
            uint quantityC = 0;
            uint quantityD = 0;

            double unitPriceA = 0;
            double unitPriceB = 0;
            double unitPriceC = 0;
            double unitPriceD = 0;

            quantityA = cart.Where(item => item.Product.Name == "A")
                                    .Select(item => item.Quantity).FirstOrDefault();
            quantityB = cart.Where(item => item.Product.Name == "B")
                                    .Select(item => item.Quantity).FirstOrDefault();
            quantityC = cart.Where(item => item.Product.Name == "C")
                                    .Select(item => item.Quantity).FirstOrDefault();
            quantityD = cart.Where(item => item.Product.Name == "D")
                                    .Select(item => item.Quantity).FirstOrDefault();

            unitPriceA = cart.Where(item => item.Product.Name == "A")
                                    .Select(item => item.Product.UnitPrice).FirstOrDefault();
            unitPriceB = cart.Where(item => item.Product.Name == "B")
                                    .Select(item => item.Product.UnitPrice).FirstOrDefault();
            unitPriceC = cart.Where(item => item.Product.Name == "C")
                                    .Select(item => item.Product.UnitPrice).FirstOrDefault();
            unitPriceD = cart.Where(item => item.Product.Name == "D")
                                    .Select(item => item.Product.UnitPrice).FirstOrDefault();

            //SKU A Discount logic
            var itemPrice = 0.0;
            itemPrice += ((quantityA / 3) * SKU_A_DISCOUNT_RATE) + ((quantityA % 3) * unitPriceA);
            Console.WriteLine("Total Cost for the Item A with discount applied : {0}", itemPrice);
            totalCost += itemPrice;

            //SKU B Discount logic
            itemPrice = 0.0;
            itemPrice += ((quantityB / 2) * SKU_B_DISCOUNT_RATE) + ((quantityB % 2) * unitPriceB);
            Console.WriteLine("Total Cost for the Item B with discount applied : {0}", itemPrice);
            totalCost += itemPrice;

            //Discount logic when C&D are purchased together
            itemPrice = 0.0;
            if (quantityC > 0 || quantityD > 0)
            {
                if (quantityC == quantityD)
                {
                    itemPrice += quantityC * SKU_C_D_DISCOUNT_RATE;
                }
                else if (quantityC > quantityD)
                {
                    itemPrice += Math.Abs(quantityC - quantityD) * unitPriceC + quantityD * SKU_C_D_DISCOUNT_RATE;
                }
                else if (quantityC < quantityD)
                {
                    itemPrice += Math.Abs(quantityC - quantityD) * unitPriceD + quantityC * SKU_C_D_DISCOUNT_RATE;
                }
            }
            Console.WriteLine("Total Cost for the Item C & D with discount applied : {0}", itemPrice);
            totalCost += itemPrice;

            return totalCost;

        }
    }
}
