using PracticeAutomation.PageObjects.CommonPages;
using TechTalk.SpecFlow;

namespace PracticeAutomation.StepDefinitions.UI.Common
{
    [Binding]
    public class Common_UISteps
    {
        Navigation _Navigation;

        public Common_UISteps(ScenarioContext scenarioContext)
        {
            _Navigation = scenarioContext.ScenarioContainer.Resolve<Navigation>();
        }

        [StepDefinition(@"user is on the Orange HRM homepage")]
        public void GivenINavigateToOrangeHRMTheHomePage()
        {
            _Navigation.NavigateToOrangeHRMLandingPage();
        }

        [StepDefinition(@"user is on the Delta Airlines homepage")]
        public void GivenINavigateToDeltaAirlinesHomePage()
        {
            _Navigation.NavigateToDeltaAirlinesLandingPage();
        }
    }
}
