using OpenQA.Selenium;
using System;
using System.Threading;
using WebAutomationPratique.Fixture;
using WebAutomationPratique.Pages;
using Xunit;
using Xunit.Abstractions;

namespace WebAutomationPratique.Tests {

    [Collection("Chrome Driver")]
    public class WhenRegistration {

        private IWebDriver driver;

        public WhenRegistration(TestFixture fixture) {
            driver = fixture.Driver;     
        }

        [Fact]
        public void GivenValidInformationAWelcomeMesasgeBeDisplayed() {
            var createAnAccont = new CreateAnAncountPage(driver);
            var homeLogged = new HomeLoggedPage(driver);
            createAnAccont.Access();
            createAnAccont.FillInRegistrationInformation();
            Assert.Equal("Welcome to your account. Here you can manage all of your personal information and orders.", homeLogged.GetMessageWelcomeToYourAccount());
            homeLogged.SignOut();

        }

        [Fact]
        public void GivenInvalidEmailTheErrorMessageWillBeDisplayed() {
            var createAnAccont = new CreateAnAncountPage(driver);
            createAnAccont.Access();
            createAnAccont.CreateEmail("teste");
            Assert.Equal("Invalid email address.", createAnAccont.GetProblemMessageFromEmail());
        }

        [Fact]
        public void GivenExistingEmailTheErrorMessageWillBeDisplayed() {
            var createAnAccont = new CreateAnAncountPage(driver);
            createAnAccont.Access();
            createAnAccont.CreateEmail("mandy_cole14@yahoo.com");
            Assert.Equal("An account using this email address has already been registered. Please enter a valid password or request a new one.", createAnAccont.GetProblemMessageFromEmail());
        }
    }
}
