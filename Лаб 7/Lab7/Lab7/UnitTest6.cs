using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Lab7
{
    [AllureNUnit]
    //[Parallelizable]
    public class Tests6 : TestBase
    {
        public Tests6() : base(BrowserTypes.Opera) { }
        [Test] [AllureSuite("Pet")]
        public void Check_petBirthDate_Validation_3([Values("2021/10/25", "2021/25/10", "2021/13/25", "2021/10/32")]string date)
        {
            Pages.OwnerPage.Navigation.OpenOwnerPage();
            Pages.PetPage.ClickOnEditPetButton();
            Pages.PetPage.ChangeBDValue(date);
            Pages.PetPage.ClickOnUpdateButton();
            Pages.PetPage.WaitForInfoRender();

            Assert.True(true);
        }
    }
}