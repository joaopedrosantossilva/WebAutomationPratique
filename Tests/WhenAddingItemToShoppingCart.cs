using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomationPratique.Fixture;
using WebAutomationPratique.Pages;
using Xunit;

namespace WebAutomationPratique.Tests {

    [Collection("Chrome Driver")]
    public class WhenAddingItemToShoppingCart {
        private IWebDriver Driver;

        public WhenAddingItemToShoppingCart(TestFixture fixture) {
            this.Driver = fixture.Driver;
        }

        [Fact]
        public void GivenQuantityGreaterThanZeroItemAdded() {
            var produto = new ProdutoDetailsPage(Driver)
                .Access()
                .AddToCart();
            Assert.Equal("Product successfully added to your shopping cart", produto.GetProductMessageAdded());
            produto.CloseWindowOfItemAdd();
            Assert.Equal("Cart 1 Product", produto.GetQuantityOfProductInCart());
        }


    }
}
