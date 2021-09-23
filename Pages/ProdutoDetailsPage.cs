using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WebAutomationPratique.Pages {
    public class ProdutoDetailsPage {

        private IWebDriver Driver;
        private By ByButtonAddToCart;
        private By BylinkAddToWishlist;
        private By ByMessageAddToList;
        private By ByLinkCloseMessage;
        private By ByCloseWindow;
        private By ByGetQuantityInCart;
        private By ByMessageAddToCart;

        public ProdutoDetailsPage(IWebDriver driver) {
            this.Driver = driver;
            ByButtonAddToCart = By.CssSelector("button.exclusive");
            ByMessageAddToList = By.CssSelector("p.fancybox-error");
            BylinkAddToWishlist = By.CssSelector("a[title='Add to my wishlist']");
            ByLinkCloseMessage = By.CssSelector("a[title=Close]");
            ByButtonAddToCart = By.CssSelector("button.exclusive");
            ByCloseWindow = By.CssSelector("[title='Close window']");
            ByGetQuantityInCart = By.CssSelector(".ajax_cart_quantity");
            ByMessageAddToCart = By.CssSelector(".layer_cart_product h2");
        }

        public ProdutoDetailsPage Access() {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?id_product=1&controller=product");
            return this;
        }

        public string GetProductMessageAdded() {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(ByMessageAddToCart));
            return Driver.FindElement(ByMessageAddToCart).Text;
        }

        public ProdutoDetailsPage AddToWishlist() {
            Driver.FindElement(BylinkAddToWishlist).Click();
            return this;
        }

        public ProdutoDetailsPage AddToCart() {
            Driver.FindElement(ByButtonAddToCart).Click();
            return this;
        }

        public void CloseAlertMessage() {
            Driver.FindElement(ByLinkCloseMessage).Click();
        }

        public void CloseWindowOfItemAdd() {
            Driver.FindElement(ByCloseWindow).Click();
        }

        public string GetMessageWhenAddingAnItemToWishlist() {
            return Driver.FindElement(ByMessageAddToList).Text;
        }

        public string GetQuantityOfProductInCart() {
            return "Cart "+ Driver.FindElement(ByGetQuantityInCart).Text + " Product";
        }


    }
}
