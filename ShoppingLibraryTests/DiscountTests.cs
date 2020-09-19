using System;
using System.Collections;
using Xunit;
using ShoppingLibrary.Service;
using ShoppingLibrary.Model;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

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

        [Fact]
        public void ScenarioATest()
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "A", UnitPrice = 50.0 }, Quantity = 1 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "B", UnitPrice = 30.0 }, Quantity = 1 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "C", UnitPrice = 20.0 }, Quantity = 1 });

            Assert.Equal(100, _sut.CalculateTotalCost(cart));
        }


        [Fact]
        public void ScenarioBTest()
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "A", UnitPrice = 50.0 }, Quantity = 5 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "B", UnitPrice = 30.0 }, Quantity = 5 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "C", UnitPrice = 20.0 }, Quantity = 1 });

            Assert.Equal(370, _sut.CalculateTotalCost(cart));
        }

        [Theory]
        [MemberData(nameof(TestCartData))]
        public void ScenarioCTestTheory(params ShoppingCart[] values)
        {
            Assert.Equal(280, _sut.CalculateTotalCost(values.ToList()));
        }
        
        [Theory]
        [MemberData(nameof(TestCartItemCandD))]
        public void TestDifferentQuantitiesStockCAndStockD(params ShoppingCart[] values)
        {
            Assert.Equal(80, _sut.CalculateTotalCost(values.ToList()));
        }



        public static IEnumerable<object[]> TestCartData()
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "A", UnitPrice = 50.0 }, Quantity = 3 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "B", UnitPrice = 30.0 }, Quantity = 5 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "C", UnitPrice = 20.0 }, Quantity = 1 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "D", UnitPrice = 15.0 }, Quantity = 1 });
            yield return cart.ToArray();
        } 
        
        public static IEnumerable<object[]> TestCartItemCandD()
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "C", UnitPrice = 20.0 }, Quantity = 3 });
            cart.Add(new ShoppingCart() { Product = new ShoppingProduct() { Name = "D", UnitPrice = 15.0 }, Quantity = 2 });
            yield return cart.ToArray();
        }
    }
}
