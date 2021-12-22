using OpenQA.Selenium;

namespace Lab7
{
    public class Navigation
    {
        private IWebDriver driver;

        public Navigation(IWebDriver driver) => this.driver = driver;

        public IWebElement OwnerTab() => driver.FindElement(By.CssSelector(".ownerTab"));

        public IWebElement OwnerListButton() => driver.FindElement(By.CssSelector(".open li:nth-child(1) > a"));

        public IWebElement AddOwnerButton() => driver.FindElement(By.CssSelector(".open li:nth-child(2) span:nth-child(2)"));

        public IWebElement CurrentOwnerLink() => driver.FindElement(By.LinkText("Lab7 Lab7"));

        public IWebElement EditOwnerButton() => driver.FindElement(By.CssSelector(".editOwner"));

        public IWebElement PetTypesButton() => driver.FindElement(By.CssSelector("li:nth-child(4) > a"));

        public void OpenAddOwnerPage()
        {
            OwnerTab().Click();
            AddOwnerButton().Click();
        }
        public void OpenOwnersList()
        {
            OwnerTab().Click();
            OwnerListButton().Click();
        }
        public void OpenOwnerPage()
        {
            OwnerTab().Click();
            OwnerListButton().Click();
            CurrentOwnerLink().Click();
        }
        
        public void OpenPetTypePage()
        {
            PetTypesButton().Click();
        }
    }
}
