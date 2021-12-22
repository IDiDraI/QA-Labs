using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Lab7
{
    [AllureNUnit]
    //[Parallelizable]
    public class Tests4 : TestBase
    {
        public Tests4() : base(BrowserTypes.Opera) { }


        [Test, TestCase("25/2021/10")]
        [TestCase("25/2021/10")]
        [AllureSuite("Pet")]
        public void Check_petBirthDate_Validation_1(string date)
        {
            Pages.OwnerPage.Navigation.OpenOwnerPage();
            Pages.PetPage.ClickOnEditPetButton();
            Pages.PetPage.ChangeBDValue(date);
            Pages.PetPage.ClickOnUpdateButton();
            Pages.PetPage.WaitForInfoRender();
        }
    }
}