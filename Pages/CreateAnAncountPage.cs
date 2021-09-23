using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomationPratique.helpers;
using Xunit.Abstractions;

namespace WebAutomationPratique.Pages {
    public class CreateAnAncountPage {

        private IWebDriver driver;
        private By byInputEmailAddress;
        private By byButtonCreateAnAccount;
        private By byInputTitle;
        private By byInputFirstName;
        private By byInputLastName;
        private By byInputEmail;
        private By byInputPassword;
        private By bySelectDays;
        private By bySelectMonths;
        private By bySelectYears;
        private By byInputCompany;
        private By byInputAddress;
        private By byInputCity;
        private By bySelectState;
        private By byInputPostalCode;
        private By bySelectCountry;
        private By byInputMobilePhone;
        private By byEmailFutureReference;
        private By byButtonRegistrer;
        private By byTextWelcomeToYourAccount;
        private FakeDataGenerator generator;
        public string email;
        private By byMessageEmailInvalid;

        public CreateAnAncountPage(IWebDriver driver) {
            this.driver = driver;
            byInputEmailAddress = By.Id("email_create");
            byButtonCreateAnAccount = By.Id("SubmitCreate");
            byInputTitle = By.CssSelector("div[class='radio-inline'] input:nth-child(1)");
            byInputFirstName = By.Id("customer_firstname");
            byInputLastName = By.Id("customer_lastname");
            byInputEmail = By.Id("email");
            byInputPassword = By.Id("passwd");
            bySelectDays = By.Id("days");
            bySelectMonths = By.Id("months");
            bySelectYears = By.Id("years");
            byInputCompany = By.Id("company");
            byInputAddress = By.Id("address1");
            byInputCity = By.Id("city");
            bySelectState = By.Id("id_state");
            byInputPostalCode = By.Id("postcode");
            bySelectCountry = By.Id("id_country");
            byInputMobilePhone = By.Id("phone_mobile");
            byEmailFutureReference = By.Id("alias");
            byButtonRegistrer = By.Id("submitAccount");
            byTextWelcomeToYourAccount = By.ClassName("info-account");
            byMessageEmailInvalid = By.CssSelector("#create_account_error li");
            generator = new FakeDataGenerator();
        }

        public string GetProblemMessageFromEmail() {
            return driver.FindElement(byMessageEmailInvalid).Text;
        }

        public void Access() {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication#account-creation");
        }

        public void CreateEmail(string email) {
            driver.FindElement(byInputEmailAddress).SendKeys(email);
            driver.FindElement(byButtonCreateAnAccount).Click();
        }


        public void SetTitle() {
            driver.FindElement(byInputTitle).Click();
        }

        public void SetFirstName() {
            driver.FindElement(byInputFirstName).SendKeys(generator.FirstName);
        }

        public void SetLastName() {
            driver.FindElement(byInputLastName).SendKeys(generator.LastName);
        }


        public void SetPassword(string valor) {
            driver.FindElement(byInputPassword).SendKeys(valor);
        }

        public void SelectDateOfBirth() {
            //Days
            var elementDays = driver.FindElement(bySelectDays);
            var selectDays = new SelectElement(elementDays);
            selectDays.SelectByValue("2");
            //Months
            var elementMonths = driver.FindElement(bySelectMonths);
            var selectMonths = new SelectElement(elementMonths);
            selectMonths.SelectByValue("5");

            //Years
            var elementYears = driver.FindElement(bySelectYears);
            var selectYears = new SelectElement(elementYears);
            selectYears.SelectByValue("1996");
        }

        public void SetCompany() {
            driver.FindElement(byInputCompany).SendKeys(generator.Componay);
        }

        public void SetAddress() {
            driver.FindElement(byInputAddress).SendKeys(generator.Address);
        }

        public void SetCity() {
            driver.FindElement(byInputCity).SendKeys(generator.City);
        }

        public void SelectState() {
            var elementState = driver.FindElement(bySelectState);
            var selectState = new SelectElement(elementState);
            selectState.SelectByValue("6");
        }

        public void SetPostalCode() {
            driver.FindElement(byInputPostalCode).SendKeys("56421");
        }

        public void SetMobilePhone() {
            driver.FindElement(byInputMobilePhone).SendKeys("8155424561");
        }

        public void SetAddressFutureReference() {
            driver.FindElement(byEmailFutureReference).SendKeys("teste");
        }

        public void Register() {
            driver.FindElement(byButtonRegistrer).Click();
        }

        public void FillInRegistrationInformation() {
            email = generator.Email;
            CreateEmail(email);
            SetTitle();
            SetFirstName();
            SetLastName();
            SetPassword("123456789");
            SelectDateOfBirth();
            SetCompany();
            SetAddress();
            SetCity();
            SelectState();
            SetPostalCode();
            SetMobilePhone();
            SetAddressFutureReference();
            Register();
        }

    }

}
