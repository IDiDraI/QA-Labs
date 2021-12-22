using NUnit.Allure.Steps;
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

        [AllureStep("Wait till table with info to display")]
        public void WaitForInfoRender()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(e => !string.IsNullOrEmpty(FindElement(By.CssSelector("table")).Text));
        }
    }
}
