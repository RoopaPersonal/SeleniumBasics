using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumBasics
{
    [TestFixture]
    public class Assert1
    {
        IWebDriver driver;
        string url = "http://10.82.181.26/Automation/PackAndGo_v2/";
        string driverPath = "C:\\Users\\roopa_r04\\Documents\\SeleniumBasics\\packages\\Selenium.WebDriver.ChromeDriver.105.0.5195.5200\\driver\\win32";
        [SetUp]
        public void SetupMethod()
        {
            driver = new ChromeDriver(driverPath);
            // Maximizing the browser screen
            driver.Manage().Window.Maximize();
            // Opening the AUT
            driver.Navigate().GoToUrl(url);
        }
        [Test]
        public void TestMethod()
        {
            //Fetching the page title before login
            string PageTitleBeforeLogin = driver.Title;
            Console.WriteLine("PageTitle: " + PageTitleBeforeLogin);
            driver.FindElement(By.LinkText(" Login")).Click();
            // Entering the credentials and clicking on Login button
            driver.FindElement(By.Id("usernameLogin")).SendKeys("pgScarlet");
            driver.FindElement(By.Name("passwordL")).SendKeys("freezeray");
            driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[3]/button[1]")).Click();
            //Fetching the page title after login
            string PageTitleAfterLogin = driver.Title;
            Console.WriteLine("PageTitle: " + PageTitleAfterLogin);
            driver.FindElement(By.LinkText(" LogOut")).Click();

            //Assert whether the PageTitleBeforeLogin and PageTitleAfterLogin are not equal.
            Assert.AreNotEqual(PageTitleBeforeLogin, PageTitleAfterLogin);
            //Find out the logout link and click
            driver.FindElement(By.LinkText("LogOut")).Click();
        }
        [TearDown]
        public void TearDownMethod()
        {
            // Close the browser
            driver.Close();
        }
    }
}
