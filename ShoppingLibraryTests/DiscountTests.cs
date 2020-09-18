using System;
using System.Collections;
using Xunit;
using ShoppingLibrary.Service;
using ShoppingLibrary.Model;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ShoppingLibraryTests
{
    public class DiscountTests
    {
        private readonly Checkout _sut;

        public DiscountTests()
        {
            _sut = new Checkout(new PromotionalOfferStrategy());
        }

        [Fact]
        public void TestTotalCostWithPromotionalDiscount()
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();

            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "A", UnitPrice = 50.0 }, Quantity = 3 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "B", UnitPrice = 30.0 }, Quantity = 5 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "C", UnitPrice = 20.0 }, Quantity = 1 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "D", UnitPrice = 15.0 }, Quantity = 1 });

            Assert.Equal(280, _sut.CalculateTotalCost(cart));
        }
    }
}
