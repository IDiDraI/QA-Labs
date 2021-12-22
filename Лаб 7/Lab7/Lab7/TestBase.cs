using Allure.Commons;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab7
{

    public class TestBase
    {
        public static IWebDriver WebDriver;

        public string BaseUrl = "http://20.50.171.10:8080/";

        protected IConfigurationRoot Configuration;

        public List<Owner> Owners { get; set; }
        public List<Pet> Pets { get; set; }
        public enum BrowserTypes
        {
            Chrome,
            Firefox,
            Opera
        }
        private BrowserTypes browserType;
        public TestBase(BrowserTypes browser)
        {
            browserType = browser;
        }

        private void GetTestData()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("TestData.json").Build();

            Owners = new OwnersList(Configuration).Owners;
            Pets = new PetsList(Configuration).Pets;
        }

        private void ChooseBrowser(BrowserTypes browserType)
        {
            var additionalSelenoidCapabilities = new Dictionary<string, object>();
            additionalSelenoidCapabilities.Add("name", "Simple test");
            additionalSelenoidCapabilities.Add("enableVNC", true);
            additionalSelenoidCapabilities.Add("enableVideo", true);
            //additionalSelenoidCapabilities.Add("no-sandbox", true);
            switch (browserType)
            {
                case BrowserTypes.Chrome:
                    var chrome_options = new ChromeOptions();
                    chrome_options.AddAdditionalOption("selenoid:options", additionalSelenoidCapabilities);
                    WebDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chrome_options.ToCapabilities());
                    break;
                case BrowserTypes.Firefox:
                    var firefox_options = new FirefoxOptions();
                    firefox_options.AddAdditionalOption("selenoid:options", additionalSelenoidCapabilities);
                    WebDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefox_options.ToCapabilities());
                    break;
                default:
                    WebDriver = new ChromeDriver(@"D:\ДУЖП\Якість програмного забезпечення та тестування\Лаб 7\Lab7\Lab7\driver\");
                    break;
            }
        }

        [SetUp]
        public void Setup()
        {
            GetTestData();
            ChooseBrowser(browserType);
            WebDriver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            WebDriver.Navigate().GoToUrl(BaseUrl);
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(500);
            WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(500);
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
