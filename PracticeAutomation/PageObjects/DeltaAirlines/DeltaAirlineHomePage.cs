using CynkyDriver;
using OpenQA.Selenium;
using PracticeAutomation.Models.UI;
using PracticeAutomation.PageObjects.CommonPages;

namespace PracticeAutomation.PageObjects.DeltaAirlines
{
    public class DeltaAirlineHomePage : Navigation
    {
        public DeltaAirlineHomePage(IWebDriver driver) : base(driver) { }

        #region Locators

        PageElement Departure_button => new PageElement(_Driver, By.CssSelector("a[id='fromAirportName'] span[class='airport-code d-block']"));
        PageElement Search_textbox => new PageElement(_Driver, By.XPath("//input[@id='search_input']"));
        PageElement SearchResults_option => new PageElement(_Driver, By.XPath("//tab[@id='airport-serach-tab']//li[1]"));
        PageElement Arrival_button => new PageElement(_Driver, By.CssSelector("a[id='toAirportName'] span[class='airport-code d-block']"));

        #endregion

        #region Actions

        public void SearchDepartureLocation(string departureLoc)
        {
            Departure_button.Click();
            Search_textbox.SendKeys(departureLoc);
            SearchResults_option.Click();
        }

        public void SearchArrivalLocation(string arrivalLoc)
        {
            Arrival_button.Click();
            Search_textbox.SendKeys(arrivalLoc);
            SearchResults_option.Click();
        }

        public bool IsFlightLocationDisplayed(string departureLoc, string arrivalLoc)
        {
            return Departure_button.GetText().Equals(departureLoc) && Arrival_button.GetText().Equals(arrivalLoc);
        }

        #endregion
    }
}