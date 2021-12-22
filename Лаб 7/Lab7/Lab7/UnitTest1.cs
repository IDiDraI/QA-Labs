using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Lab7
{
    [AllureNUnit]
    //[Parallelizable]
    public class Tests1 : TestBase
    {
        public Tests1() : base(BrowserTypes.Chrome) {}

        [Test, Description("This test adds new owner to site")]
        [AllureSuite("Owner")]
        public void Test()
        {
            Pages.OwnerPage.Navigation.OpenAddOwnerPage();
            Pages.OwnerPage.ChangeFirstNameValue(Owners[0].FirstName, false);
            Pages.OwnerPage.ChangeLastNameValue(Owners[0].LastName, false);
            Pages.OwnerPage.ChangeAddressValue(Owners[0].Address, false);
            Pages.OwnerPage.ChangeCityValue(Owners[0].City, false);
            Pages.OwnerPage.ChangePhoneValue(Owners[0].Phone, false);
            Pages.OwnerPage.ClickOnAddButton();
            Pages.OwnerPage.WaitForInfoRender();
        }

    }
}
