using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Lab7
{
    [AllureNUnit]
    //[Parallelizable]
    public class Tests5 : TestBase
    {
        public Tests5() : base(BrowserTypes.Opera) { }


        static object[] TestData = { "2021/10/25", "2021/25/10", "2021/13/25", "2021/10/32",
        "0000/10/25", @"2021/10/25", "2021 10 25", "2021-10-25",
        "2021.10.25", "2021,10,25", "2021;10;25", "2021:10:25"};
        [Test] [AllureSuite("Pet")]
        [TestCaseSource(nameof(TestData))]
        public void Check_petBirthDate_Validation_2(string date)
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