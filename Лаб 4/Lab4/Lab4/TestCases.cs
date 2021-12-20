using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Lab4
{
    public class TestCases
    {
        public IWebDriver driver;
        public string BaseUrl = "http://20.50.171.10:8080/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("driver");
            driver.Url = BaseUrl;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestCase1()
        {
            var pageObject = new PageObject(driver);
            pageObject.CreateOwnerPage();
            pageObject.ChangeFirstNameValue("Lab4", false);
            pageObject.ChangeLastNameValue("test1", false);
            pageObject.ChangeAddressValue("test2", false);
            pageObject.ChangeCityValue("test3", false);
            pageObject.ChangeTelephoneValue("123", false);
            pageObject.ClickOnAddButton();
        }

        [Test]
        public void TestCase2()
        {
            var pageObject = new PageObject(driver);
            pageObject.OpenPetTypePage();
            pageObject.ChangePetTypeValue("Lab4NewPetType");
            pageObject.ClickOnSavePetTypeButton();
        }

        [Test]
        public void TestCase3()
        {
            var pageObject = new PageObject(driver);
            pageObject.OpenOwnerPage();
            pageObject.OpenAddPetToOwnerPage();
            pageObject.ChangePetNameValue("Lab4Pet");
            pageObject.ChangePetBDValue("2021/01/21");
            pageObject.ChangePetType("Lab4NewPetType");
            pageObject.ClickOnSavePetButton();
        }
    }
}