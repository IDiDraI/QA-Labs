using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab5
{

    public static class Helpers
    {
        private static  IWebDriver driver;
        public static void ClearAndType(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        internal static void SelectOption(IWebElement element, string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(value);
        }
    }
}
