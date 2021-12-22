using OpenQA.Selenium;

namespace Lab5
{
    public class OwnerPage : PageObject
    {
        public OwnerPage(IWebDriver driver) : base(driver) { }

        public Navigation Navigation => new Navigation(Driver);

        public void ChangeFirstNameValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("firstName")), value);

        public void ChangeLastNameValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("lastName")), value);

        public void ChangeAddressValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("address")), value);

        public void ChangeCityValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("city")), value);

        public void ChangePhoneValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("telephone")), value);

        public void ClickOnAddButton() => FindElement(By.CssSelector(".addOwner")).Click();

        public void ClickOnUpdateButton() => FindElement(By.CssSelector(".updateOwner")).Click();
    }
}
