using ShoppingLibrary.Model;
using ShoppingLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingLibraryTests
{
    public class NonDiscountTests
    {
        private readonly Checkout _sut;

        public NonDiscountTests()
        {
            _sut = new Checkout(new RegularOfferStrategy());
        }

        [Fact]
        public void TestTotalCostWithNoDiscount()
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();

            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "A", UnitPrice = 50.0 }, Quantity = 1 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "B", UnitPrice = 30.0 }, Quantity = 1 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "C", UnitPrice = 20.0 }, Quantity = 1 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "D", UnitPrice = 15.0 }, Quantity = 1 });

            Assert.Equal(115, _sut.CalculateTotalCost(cart));
        }
    }
}
