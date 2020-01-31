using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumGridTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow("firefox")]
        [DataRow("chrome")]
        [DataTestMethod]
        public void TestMethod1(string browser)
        {
            var uri = "http://localhost:4444/wd/hub";

            ICapabilities capabilities = null;

            if (browser == "firefox")
                capabilities = new FirefoxOptions().ToCapabilities();
            else if (browser == "chrome")
                capabilities = new ChromeOptions().ToCapabilities();


            var commandTimeout = TimeSpan.FromMinutes(5);
            var driver = new RemoteWebDriver(new Uri(uri), capabilities, commandTimeout);
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            driver.Quit();
        }
    }
}
