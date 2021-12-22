using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab7
{

    public static class Helpers
    {
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
