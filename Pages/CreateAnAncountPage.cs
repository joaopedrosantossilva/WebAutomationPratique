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

        private IWebDriver Driver;
        private By ByInputEmailAddress;
        private By ByButtonCreateAnAccount;
        private By ByInputTitle;
        private By ByInputFirstName;
        private By ByInputLastName;
        private By ByInputEmail;
        private By ByInputPassword;
        private By BySelectDays;
        private By BySelectMonths;
        private By BySelectYears;
        private By ByInputCompany;
        private By ByInputAddress;
        private By ByInputCity;
        private By BySelectState;
        private By ByInputPostalCode;
        private By BySelectCountry;
        private By ByInputMobilePhone;
        private By ByEmailFutureReference;
        private By ByButtonRegistrer;
        private By ByTextWelcomeToYourAccount;
        private FakeDataGenerator Generator;
        public string Email;
        private By ByMessageEmailInvalid;

        public CreateAnAncountPage(IWebDriver driver) {
            this.Driver = driver;
            ByInputEmailAddress = By.Id("email_create");
            ByButtonCreateAnAccount = By.Id("SubmitCreate");
            ByInputTitle = By.CssSelector("div[class='radio-inline'] input:nth-child(1)");
            ByInputFirstName = By.Id("customer_firstname");
            ByInputLastName = By.Id("customer_lastname");
            ByInputEmail = By.Id("email");
            ByInputPassword = By.Id("passwd");
            BySelectDays = By.Id("days");
            BySelectMonths = By.Id("months");
            BySelectYears = By.Id("years");
            ByInputCompany = By.Id("company");
            ByInputAddress = By.Id("address1");
            ByInputCity = By.Id("city");
            BySelectState = By.Id("id_state");
            ByInputPostalCode = By.Id("postcode");
            BySelectCountry = By.Id("id_country");
            ByInputMobilePhone = By.Id("phone_mobile");
            ByEmailFutureReference = By.Id("alias");
            ByButtonRegistrer = By.Id("submitAccount");
            ByTextWelcomeToYourAccount = By.ClassName("info-account");
            ByMessageEmailInvalid = By.CssSelector("#create_account_error li");
            Generator = new FakeDataGenerator();
        }

        public string GetProblemMessageFromEmail() {
            return Driver.FindElement(ByMessageEmailInvalid).Text;
        }

        public void Access() {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication#account-creation");
        }

        public void CreateEmail(string email) {
            Driver.FindElement(ByInputEmailAddress).SendKeys(email);
            Driver.FindElement(ByButtonCreateAnAccount).Click();
        }


        public void SetTitle() {
            Driver.FindElement(ByInputTitle).Click();
        }

        public void SetFirstName() {
            Driver.FindElement(ByInputFirstName).SendKeys(Generator.FirstName);
        }

        public void SetLastName() {
            Driver.FindElement(ByInputLastName).SendKeys(Generator.LastName);
        }


        public void SetPassword(string valor) {
            Driver.FindElement(ByInputPassword).SendKeys(valor);
        }

        public void SelectDateOfBirth() {
            //Days
            var elementDays = Driver.FindElement(BySelectDays);
            var selectDays = new SelectElement(elementDays);
            selectDays.SelectByValue("2");
            //Months
            var elementMonths = Driver.FindElement(BySelectMonths);
            var selectMonths = new SelectElement(elementMonths);
            selectMonths.SelectByValue("5");

            //Years
            var elementYears = Driver.FindElement(BySelectYears);
            var selectYears = new SelectElement(elementYears);
            selectYears.SelectByValue("1996");
        }

        public void SetCompany() {
            Driver.FindElement(ByInputCompany).SendKeys(Generator.Componay);
        }

        public void SetAddress() {
            Driver.FindElement(ByInputAddress).SendKeys(Generator.Address);
        }

        public void SetCity() {
            Driver.FindElement(ByInputCity).SendKeys(Generator.City);
        }

        public void SelectState() {
            var elementState = Driver.FindElement(BySelectState);
            var selectState = new SelectElement(elementState);
            selectState.SelectByValue("6");
        }

        public void SetPostalCode() {
            Driver.FindElement(ByInputPostalCode).SendKeys("56421");
        }

        public void SetMobilePhone() {
            Driver.FindElement(ByInputMobilePhone).SendKeys("8155424561");
        }

        public void SetAddressFutureReference() {
            Driver.FindElement(ByEmailFutureReference).SendKeys("teste");
        }

        public void Register() {
            Driver.FindElement(ByButtonRegistrer).Click();
        }

        public void FillInRegistrationInformation() {
            Email = Generator.Email;
            CreateEmail(Email);
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
