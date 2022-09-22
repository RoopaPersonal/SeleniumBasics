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
    public class WebDriver_Interface_Demo
    {
        [Test]
        public void TestMethod()
        {
            IWebDriver driver;
            string driverPath = "C:\\Users\\roopa_r04\\Documents\\SeleniumBasics\\packages\\Selenium.WebDriver.ChromeDriver.105.0.5195.5200\\driver\\win32";
            driver = new ChromeDriver(driverPath);
            driver.Navigate().GoToUrl("https://www.google.com");
            string Title = driver.Title;
            driver.Manage().Window.Maximize();
            Console.WriteLine(Title);
            driver.Navigate().Refresh();
            string PgSource = driver.PageSource;
            driver.Navigate().Forward();
            driver.Close();
            //driver.Quit();
        }
    }
}
