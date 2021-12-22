using Allure.Commons;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab5
{
    public class TestBase
    {
        public static IWebDriver WebDriver;

        public string BaseUrl = "http://20.50.171.10:8080/";

        protected IConfigurationRoot Configuration;

        public List<Owner> Owners { get; set; }
        public List<Pet> Pets { get; set; }

        private void GetTestData()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("TestData.json").Build();

            Owners = new OwnersList(Configuration).Owners;
            Pets = new PetsList(Configuration).Pets;
        }

        [SetUp]
        public void Setup()
        {
            GetTestData();
            var additionalSelenoidCapabilities = new Dictionary<string, object>();
            additionalSelenoidCapabilities.Add("name", "Simple test");
            additionalSelenoidCapabilities.Add("enableVNC", true);
            additionalSelenoidCapabilities.Add("enableVideo", true);

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddAdditionalCapability("selenoid:options", additionalSelenoidCapabilities, true);
            WebDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions.ToCapabilities());

            WebDriver.Url = BaseUrl;
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
                var fileName = TestContext.CurrentContext.Test.MethodName + "_screenshot" + DateTime.Now.Ticks + ".png";
                var path = $"D:\\allure-results\\{fileName}";
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment(fileName, "image/png", path);
            }

            WebDriver.Quit();
        }
    }
}
