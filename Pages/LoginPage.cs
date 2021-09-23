using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationPratique.Pages {
    public class LoginPage {

        private IWebDriver driver;
        private By byInputEmail;
        private By byInputPassword;
        private By byButtonSignIn;
        private By byMessageInvalidData;

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
            byInputEmail = By.Id("email");
            byInputPassword = By.Id("passwd");
            byButtonSignIn = By.Id("SubmitLogin");
            byMessageInvalidData = By.CssSelector("div[class='alert alert-danger']");
        }

        public LoginPage Visit() {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
            return this;
        }

        public LoginPage SetEmail(string email) {
            driver.FindElement(byInputEmail).SendKeys(email);
            return this;
        }

        public LoginPage SetPassword(string password) {
            driver.FindElement(byInputPassword).SendKeys(password);
            return this;
        }

        public LoginPage SignIn() {
            driver.FindElement(byButtonSignIn).Click();
            return this;
        }

        public string GetInvalidDataMessage() {
            return driver.FindElement(byMessageInvalidData).Text;
        }

        public void LogInWithCredenciais(string email, string password) {
            Visit()
                .SetEmail(email)
                .SetPassword(password)
                .SignIn();
        }
    }
}

