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
            Assert.Equal("You must be logged in to manage your wishlist.", produto.GetMessageWhenAddingAnItemToWishlist());

        }

        [Fact]
        public void GivenUserLoggedASucessMessageWillBeDisplayed() {
            var login = new LoginPage(driver);
            var produto = new ProdutoDetailsPage(driver);
            var homeLogged = new HomeLoggedPage(driver);

            login.LogInWithCredenciais("mandy_cole14@yahoo.com", "123456789");
            produto
                .Access()
                .AddToWishlist();
            Assert.Equal("Added to your wishlist.", produto.GetMessageWhenAddingAnItemToWishlist());
            produto.CloseAlertMessage();
            homeLogged.SignOut();
        }
    }
}
