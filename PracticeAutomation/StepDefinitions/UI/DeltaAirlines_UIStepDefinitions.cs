using System;
using PracticeAutomation.Models.UI;
using PracticeAutomation.PageObjects.DeltaAirlines;
using TechTalk.SpecFlow;

namespace PracticeAutomation.StepDefinitions.UI
{
    [Binding]
    public class DeltaAirlines_UIStepDefinitions
    {
        DeltaAirlineHomePage _DeltaAirlineHomePage;
        ScenarioContext _ScenarioContext;

        public DeltaAirlines_UIStepDefinitions(ScenarioContext scenarioContext)
        {
            _DeltaAirlineHomePage = scenarioContext.ScenarioContainer.Resolve<DeltaAirlineHomePage>();
            _ScenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }

        [When(@"user searches a flight from '([^']*)' to '([^']*)'")]
        public void WhenUserSearchesAFlightFromTo(string departureLoc, string arrivalLoc)
        {
            _ScenarioContext.Set(departureLoc, "deptLoc");
            _ScenarioContext.Set(arrivalLoc, "arrLoc");

            _DeltaAirlineHomePage.SearchDepartureLocation(departureLoc);
            _DeltaAirlineHomePage.SearchArrivalLocation(arrivalLoc);    
        }

        [Then(@"available flights should be shown")]
        public void ThenAvailableFlightsShouldBeShown()
        {
            _DeltaAirlineHomePage.IsFlightLocationDisplayed(_ScenarioContext.Get<string>("deptLoc"), _ScenarioContext.Get<string>("arrLoc"));
        }
    }
}
