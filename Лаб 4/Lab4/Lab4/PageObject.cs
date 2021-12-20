using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab4
{
    public class PageObject
    {
        protected IWebDriver driver;

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ChangeInputValue(By inputSelector, string newValue, bool overwrite)
        {
            var element = driver.FindElement(inputSelector);
            if (overwrite)
                element.Clear();
            element.SendKeys(newValue);
        }

        public bool IsElementVisible(By elementSelector)
        {
            try
            {
                return driver.FindElement(elementSelector) != null;
            }
            catch
            {
                return false;
            }
        }

        public void CreateOwnerPage()
        {
            driver.FindElement(By.CssSelector(".ownerTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(2) span:nth-child(2)")).Click();
        }

        public void OpenOwnerPage()
        {
            driver.FindElement(By.CssSelector(".ownerTab")).Click();
            driver.FindElement(By.CssSelector(".open li:nth-child(1) > a")).Click();
            driver.FindElement(By.LinkText("Lab4 test1")).Click();
        }

        public void OpenPetTypePage() => driver.FindElement(By.CssSelector("li:nth-child(4) > a")).Click();

        public void OpenAddPetToOwnerPage() => driver.FindElement(By.CssSelector(".addNewPet")).Click();

        public void ChangeFirstNameValue(string value, bool overwrite = true) => ChangeInputValue(By.Id("firstName"), value, overwrite);

        public void ChangeLastNameValue(string value, bool overwrite = true) => ChangeInputValue(By.Id("lastName"), value, overwrite);

        public void ChangeAddressValue(string value, bool overwrite = true) => ChangeInputValue(By.Id("address"), value, overwrite);

        public void ChangeCityValue(string value, bool overwrite = true) => ChangeInputValue(By.Id("city"), value, overwrite);

        public void ChangeTelephoneValue(string value, bool overwrite = true) => ChangeInputValue(By.Id("telephone"), value, overwrite);

        public void ChangePetTypeValue(string value, bool overwrite = true)
        {
            driver.FindElement(By.CssSelector(".addPet")).Click();
            ChangeInputValue(By.Id("name"), value, overwrite);
        }

        public void ChangePetNameValue(string value, bool overwrite = true) => ChangeInputValue(By.Id("name"), value, overwrite);

        public void ChangePetBDValue(string value, bool overwrite = true) => ChangeInputValue(By.Name("birthDate"), value, overwrite);

        public void ChangePetType(string value) {
            var selectElement = new SelectElement(driver.FindElement(By.Name("type")));
            selectElement.SelectByText(value);
        }

        public void ClickOnAddButton() => driver.FindElement(By.CssSelector(".addOwner")).Click();

        public void ClickOnUpdateButton() => driver.FindElement(By.CssSelector(".updateOwner")).Click();

        public void ClickOnSavePetTypeButton() => driver.FindElement(By.CssSelector(".saveType")).Click();

        public void ClickOnSavePetButton() => driver.FindElement(By.CssSelector(".savePet")).Click();
    }
}
