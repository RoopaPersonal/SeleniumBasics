using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumBasics
{
    class Login
    {
        public static void LoginInformation(string UserEmail, string password, IWebDriver driver)
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[1]/input")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[1]/input")).SendKeys(UserEmail);
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[2]/input")).Click();
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[2]/input")).SendKeys(password);
        }
    }
}
