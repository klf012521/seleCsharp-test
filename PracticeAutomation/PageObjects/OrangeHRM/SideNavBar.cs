using CynkyDriver;
using OpenQA.Selenium;
using PracticeAutomation.PageObjects.CommonPages;

namespace PracticeAutomation.PageObjects.OrangeHRM
{
    public class SideNavBar : Navigation
    {
        public SideNavBar(IWebDriver driver) : base(driver) { }

        #region Locators

        PageElement Option_link(string text) => new PageElement(_Driver, By.XPath($"//a[contains(.,\"{text}\")]"));

        #endregion

        #region Actions

        public void ClickOnOption(string option)
        {
            ClickLink(option);
        }

        public bool IsOptionDisplayed(string text)
        {
            return Option_link(text).IsDisplayed();
        }

        #endregion
    }
}