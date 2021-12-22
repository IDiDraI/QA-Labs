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

        public void ClickOnAddPetButton() => FindElement(By.CssSelector(".addPet")).Click();

        public void ChangeTypeNameValue(string value, bool overwrite = true) => Helpers.ClearAndType(FindElement(By.Id("name")), value);

        public void ClickOnSaveTypeButton() => FindElement(By.CssSelector(".saveType")).Click();
    }
}
