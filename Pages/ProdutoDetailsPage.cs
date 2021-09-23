using OpenQA.Selenium;


namespace WebAutomationPratique.Pages {
    public class ProdutoDetailsPage {

        private IWebDriver Driver;
        private By ByButtonAddToCart;
        private By BylinkAddToWishlist;
        private By ByMessageAddToList;

        public ProdutoDetailsPage(IWebDriver driver) {
            this.Driver = driver;
            ByButtonAddToCart = By.CssSelector("button.exclusive");
            ByMessageAddToList = By.CssSelector("p.fancybox-error");
            BylinkAddToWishlist = By.CssSelector("a[title='Add to my wishlist']");
        }

        public ProdutoDetailsPage Access() {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?id_product=1&controller=product");
            return this;
        }

        public ProdutoDetailsPage AddToWishlist() {
            Driver.FindElement(BylinkAddToWishlist).Click();
            return this;
        }

        public string GetErrorMessageWhenAddingAnItemToWishlist() {
            return Driver.FindElement(ByMessageAddToList).Text;
        }


    }
}
