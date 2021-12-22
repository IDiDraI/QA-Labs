using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            WebDriver = new ChromeDriver("driver");
            WebDriver.Url = BaseUrl;
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }
    }
}
