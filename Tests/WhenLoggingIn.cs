using OpenQA.Selenium;
using System;
using WebAutomationPratique.Fixture;
using WebAutomationPratique.Pages;
using Xunit;

namespace WebAutomationPratique.Tests {

    [Collection("Chrome Driver")]
    public class WhenLoggingIn {

        private IWebDriver driver;

        public WhenLoggingIn(TestFixture fixture) {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void GivenValidInformationAWelcomeMessageBeDisplayed() {
            var login = new LoginPage(driver);
            var homeLogged = new HomeLoggedPage(driver);
            login.LogInWithCredenciais(email: "mandy_cole14@yahoo.com", password: "123456789");
            Assert.Equal("Welcome to your account. Here you can manage all of your personal information and orders.", homeLogged.GetMessageWelcomeToYourAccount());
            homeLogged.SignOut();
        }

        [Fact]
        public void GivenInvalidPasswordTheErrorMessageWillBeDisplayed() {
            var login = new LoginPage(driver);
            var homeLogged = new HomeLoggedPage(driver);
            login.LogInWithCredenciais(email: "mandy_cole14@yahoo.com", password: "12345");
            Assert.Equal("There is 1 error\r\n" +
                "Authentication failed.", login.GetInvalidDataMessage());
        }
   
        [Fact]
        public void GivenInvalidEmailTheErrorMessageWillBeDisplayed() {
            var login = new LoginPage(driver);
            var homeLogged = new HomeLoggedPage(driver);
            login.LogInWithCredenciais(email: "teste", password:"12345");
            Assert.Equal("There is 1 error\r\n" +
                "Invalid email address.", login.GetInvalidDataMessage());
        }
    }
}
