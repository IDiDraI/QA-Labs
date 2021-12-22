using NUnit.Allure.Steps;
using OpenQA.Selenium;

namespace Lab5
{
    public class OwnerPage : PageObject
    {
        public OwnerPage(IWebDriver driver) : base(driver) { }

        public Navigation Navigation => new Navigation(Driver);

        [AllureStep("Changes first name")]
        public void ChangeFirstNameValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("firstName")), value);

        [AllureStep("Changes last name")]
        public void ChangeLastNameValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("lastName")), value);

        [AllureStep("Changes address")]
        public void ChangeAddressValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("address")), value);

        [AllureStep("Changes city")]
        public void ChangeCityValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("city")), value);

        [AllureStep("Changes phone")]
        public void ChangePhoneValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("telephone")), value);

        [AllureStep("Clicks on add button")]
        public void ClickOnAddButton() => FindElement(By.CssSelector(".addOwner")).Click();

        [AllureStep("Clicks on update button")]
        public void ClickOnUpdateButton() => FindElement(By.CssSelector(".updateOwner")).Click();
    }
}
