using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomationPratique.Fixture;
using WebAutomationPratique.Pages;
using Xunit;

namespace WebAutomationPratique.Tests {

    [Collection("Chrome Driver")]
    public class WhenAddingItemToWishlist {

        private IWebDriver driver;  

        public WhenAddingItemToWishlist(TestFixture fixture) {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void GivenUserNotLoggedInErrorMessageWillBeDisplayed() {
            var produto = new ProdutoDetailsPage(driver)
                .Access()
                .AddToWishlist();
            Assert.Equal("You must be logged in to manage your wishlist.", produto.GetErrorMessageWhenAddingAnItemToWishlist());

        }
    }
}
