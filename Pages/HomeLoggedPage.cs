using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationPratique.Pages {
    public class HomeLoggedPage {

        private IWebDriver driver;
        private By byTextWelcomeToYourAccount;
        private By byLinkSignOut;

        public HomeLoggedPage(IWebDriver driver) {
            this.driver = driver;
            byTextWelcomeToYourAccount = By.ClassName("info-account");
            byLinkSignOut = By.LinkText("Sign out");
        }

        public void SignOut() {
            driver.FindElement(byLinkSignOut).Click();
        }

        public string GetMessageWelcomeToYourAccount() {
            return driver.FindElement(byTextWelcomeToYourAccount).Text;
        }
    }
}
