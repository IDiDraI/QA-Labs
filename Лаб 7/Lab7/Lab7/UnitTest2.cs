using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Lab7
{
    [AllureNUnit]
    //[Parallelizable]
    public class Tests2 : TestBase
    {
        public Tests2() : base(BrowserTypes.Firefox) { }


        [Test, Description("This test adds new type of pets to site")]
        [AllureSuite("PetType")]
        public void Test2()
        {
            Pages.PetTypePage.Navigation.OpenPetTypePage();
            Pages.PetTypePage.ClickOnAddPetButton();
            Pages.PetTypePage.ChangeTypeNameValue(Pets[0].Type);
            Pages.PetTypePage.ClickOnSaveTypeButton();
            Pages.PetTypePage.WaitForInfoRender();
        }

    }
}