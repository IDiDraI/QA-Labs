using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Lab5
{
    [AllureNUnit]
    public class Tests : TestBase
    {
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