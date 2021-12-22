using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab5
{
    public class PageObject
    {
        protected IWebDriver Driver;

        public PageObject(IWebDriver driver) => Driver = driver;

        public IWebElement FindElement(By elementSelector) => Driver.FindElement(elementSelector);

        public void WaitForOwnerInformationRender()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(e => !string.IsNullOrEmpty(FindElement(By.CssSelector("table")).Text));
        }
    }
}
