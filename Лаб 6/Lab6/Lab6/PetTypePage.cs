using NUnit.Allure.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class PetTypePage : PageObject
    {
        public PetTypePage(IWebDriver driver) : base(driver) { }

        public Navigation Navigation => new Navigation(Driver);

        [AllureStep("Clicks on add pet type button in type list")]
        public void ClickOnAddPetButton() => FindElement(By.CssSelector(".addPet")).Click();

        [AllureStep("Changes type name")]
        public void ChangeTypeNameValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("name")), value);

        [AllureStep("Clicks on save new pet type button in type list")]
        public void ClickOnSaveTypeButton() => FindElement(By.CssSelector(".saveType")).Click();
    }
}
