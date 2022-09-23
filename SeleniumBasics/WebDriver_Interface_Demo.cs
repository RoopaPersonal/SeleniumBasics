using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace SeleniumBasics
{
    [TestFixture]
    public class WebDriver_Interface_Demo
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void TestMethod()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();            
            string Title = driver.Title;
            Console.WriteLine("PageTitle: " + Title);
            Console.WriteLine(Title);
            driver.Navigate().Refresh();
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input")).SendKeys("UTC Time Now");
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Down).Build().Perform();
            act.SendKeys(Keys.Enter).Build().Perform();
            Thread.Sleep(1000);
            string PageTitleAfterSearch = driver.Title;
            Console.WriteLine("PageTitle: " + PageTitleAfterSearch);
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Close();
            //driver.Quit();
        }
    }
}
