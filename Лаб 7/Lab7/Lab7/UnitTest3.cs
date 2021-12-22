using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Lab7
{
    [AllureNUnit]
    //[Parallelizable]
    public class Tests3 : TestBase
    {
        public Tests3() : base(BrowserTypes.Opera) { }


        [Test, Description("This test adds new pet to existed owner on site")]
        [AllureSuite("Pet")]
        public void Test3()
        {
            Pages.OwnerPage.Navigation.OpenOwnerPage();
            Pages.PetPage.ClickAddPetButton();
            Pages.PetPage.ChangeNameValue(Pets[0].Name);
            Pages.PetPage.ChangeBDValue(Pets[0].BirthDay);
            Pages.PetPage.ChangePetTypeValue(Pets[0].Type);
            Pages.PetPage.ClickOnSavePetButton();
            Pages.PetPage.WaitForInfoRender();
        }
    }
}