using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationPratique.Fixture {
    
    public class TestFixture : IDisposable {

        public IWebDriver Driver { get; private set; }

        public TestFixture() {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void Dispose() {
            Driver.Quit();

        }
    }
}
