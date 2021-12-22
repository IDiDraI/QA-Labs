using OpenQA.Selenium;

namespace Lab5
{
    public class PetPage : PageObject
    {
        public PetPage(IWebDriver driver) : base(driver) { }

        public Navigation Navigation => new Navigation(Driver);

        public void ChangeNameValue(string value) => Helpers.ClearAndType(FindElement(By.Id("name")), value);

        public void ChangeBDValue(string value) => Helpers.ClearAndType(FindElement(By.Name("birthDate")), value);

        public void ChangePetTypeValue(string value) => Helpers.SelectOption(FindElement(By.Name("type")), value);

        public void ClickAddPetButton() => FindElement(By.CssSelector(".addNewPet")).Click();

        public void ClickOnSavePetButton() => FindElement(By.CssSelector(".savePet")).Click();

        public void ClickOnUpdateButton() => FindElement(By.CssSelector(".updatePet")).Click();
        
    }
}
