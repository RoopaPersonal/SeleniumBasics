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
using SeleniumBasics.TestDataAccess;
using ExcelDataReader;
using SeleniumBasics.TestDataAccess.Before;

namespace SeleniumBasics
{
    [TestFixture]
    public class Flipkart
    {       

        IWebDriver driver = new ChromeDriver();

        [Test]
        public void FlipkartLoginusingExcel()

        {

            try
            {
                driver.Navigate().GoToUrl("https://www.flipkart.com/");
                Thread.Sleep(1000);
                driver.Manage().Window.Maximize();
                
                //Access to the Excel File loaded to our project 
                string fileName = "C:\\Users\\roopa_r04\\Documents\\SeleniumBasics\\SeleniumBasics\\TestDataAccess\\Credentials.xls";

                //Storing Excel data in to the in-memory collection
                Common.PopulateInCollection(fileName);                

                //Entering User information
                Login.LoginInformation(Common.ReadData(1, "UserEmail"), Common.ReadData(1, "password"), driver);

                //Click on the "Login" button 
                driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[4]/button")).Click();
                                
                Actions actions = new Actions(driver);               
                IWebElement menuOption = driver.FindElement(By.XPath("//*[contains(text(),'Roopa')]"));                
                actions.MoveToElement(menuOption).Perform();
                Console.WriteLine("Logged in Successfully");
                //Logout
                driver.FindElement(By.XPath("//*[@id='container']/div/div[1]/div[1]/div[2]/div[3]/div/div/div[2]/div[2]/div/ul/li[9]/a")).Click();
                Thread.Sleep(100);
                driver.Close();
                driver.Quit();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail();
            }

        }

        [Test]
        public void WithoutLogin()
        {
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("/html/body/div[2]/div/div/button")).Click();           
            Thread.Sleep(1000);
                        
            //Travel Icon
            driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div/div/div[8]/a/div[1]/div/img")).Click();
            Thread.Sleep(1000);

            //Select From           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                       
            driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div[1]/div/div[2]/div/div[2]/form/div/div[1]/div[1]/div[1]/div[1]/input")).Click();
            
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Down).Build().Perform();            
            act.SendKeys(Keys.Enter).Build().Perform();
            Thread.Sleep(1000);
            
            driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div[1]/div/div[2]/div/div[2]/form/div/div[1]/div[3]/div[1]/div[1]/input")).Click();
            act.SendKeys(Keys.Down).Build().Perform();
            act.SendKeys(Keys.Down).Build().Perform();
            act.SendKeys(Keys.Enter).Build().Perform();
            Thread.Sleep(1000); 
            
            act.SendKeys(Keys.Tab).Build().Perform();
            act.SendKeys(Keys.Tab).Build().Perform();
            act.SendKeys(Keys.Tab).Build().Perform();
            act.SendKeys(Keys.Enter).Build().Perform();            
            Thread.Sleep(1000);

            driver.FindElement(By.XPath(" //*[@id='container']/div/div[2]/div/div[2]/div[2]/div[3]/div/div[1]/div[3]/div[1]/div[1]/div[4]")).Click();
            Thread.Sleep(1000);
            driver.Close();
            driver.Quit();
        }
    }
}
