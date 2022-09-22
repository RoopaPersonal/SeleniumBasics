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
using SeleniumExtras.WaitHelpers;

namespace SeleniumBasics
{
    [TestFixture]
    public class Flipkart
    {       

        IWebDriver driver = new ChromeDriver();
        [Test]
        public void TestMethod()
        {
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            //Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            string pageTitleFirst = driver.Title;
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/button")).Click();           
            Thread.Sleep(1000);      
            
            driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div/div/div[8]/a/div[1]/div/img")).Click();
            Thread.Sleep(1000);
            //Select From
            //driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div[1]/div/div[2]/div/div[2]/form/div/div[1]/div[3]/div[1]/div[1]/input")).Click();
            //Thread.Sleep(1000);
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Down).Build().Perform();
            act.SendKeys(Keys.Down).Build().Perform();
            act.SendKeys(Keys.Enter).Build().Perform();
            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div[1]/div/div[2]/div/div[2]/form/div/div[1]/div[3]/div[1]/div[1]/input")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div[1]/div/div[2]/div/div[2]/form/div/div[1]/div[1]/div[1]/div[2]/div/div[2]/div[2]")).Click();
            //Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@class = '_3qBKP_ _1Jqgld']"))).Click();

            //driver.FindElement(By.ClassName("_3qBKP_ _1Jqgld")).Click();
            //driver.FindElement(By.ClassName("_3qBKP_ _1Jqgld")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("_3qBKP_ _1Jqgld")).Click();
            Thread.Sleep(1000);
            Actions act1 = new Actions(driver);
            act1.SendKeys(Keys.Down).Build().Perform();            
            act1.SendKeys(Keys.Enter).Build().Perform();

            //driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div[1]/div/div[2]/div/div[2]/form/div/div[1]/div[3]/div[1]/div[2]/div/div[3]/div[2]")).Click();
            //Thread.Sleep(1000);

            driver.FindElement(By.XPath(" //*[@id='container']/div/div[2]/div[1]/div/div[2]/div/div[2]/form/div/button")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath(" //*[@id='container']/div/div[2]/div/div[2]/div[2]/div[3]/div/div[1]/div[3]/div[1]/div[1]/div[4]")).Click();
            Thread.Sleep(1000);
            driver.Close();
        }
    }
}
