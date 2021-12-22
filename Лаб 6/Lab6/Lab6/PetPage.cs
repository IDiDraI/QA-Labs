using NUnit.Allure.Steps;
using OpenQA.Selenium;

namespace Lab5
{
    public class PetPage : PageObject
    {
        public PetPage(IWebDriver driver) : base(driver) { }

        public Navigation Navigation => new Navigation(Driver);

        [AllureStep("Changes pet name")]
        public void ChangeNameValue(string value) => Helpers.ClearAndType(FindElement(By.Id("name")), value);

        [AllureStep("Changes birth day")]
        public void ChangeBDValue(string value) => Helpers.ClearAndType(FindElement(By.Name("birthDate")), value);

        [AllureStep("Changes type of your pet")]
        public void ChangePetTypeValue(string value) => Helpers.SelectOption(FindElement(By.Name("type")), value);

        [AllureStep("Clicks on add pet button in owner page")]
        public void ClickAddPetButton() => FindElement(By.CssSelector(".addNewPet")).Click();

        [AllureStep("Clicks on final button to save pet info that are added")]
        public void ClickOnSavePetButton() => FindElement(By.CssSelector(".savePet")).Click();

        [AllureStep("Clicks on update pet button to save changes")]
        public void ClickOnUpdateButton() => FindElement(By.CssSelector(".updatePet")).Click();
        
    }
}
