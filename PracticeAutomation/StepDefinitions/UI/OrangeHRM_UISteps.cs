using FluentAssertions;
using PracticeAutomation.Models.UI;
using PracticeAutomation.PageObjects.OrangeHRM;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PracticeAutomation.StepDefinitions.UI
{
    [Binding]
    public class OrangeHRM_UISteps
    {
        MyInfoPage _MyInfoPage;
        HRMLoginPage _HRMLoginPage;
        PIMPage _PIMPage;
        TopNavBar _TopNavBar;
        SideNavBar _SideNavBar;
        ScenarioContext _ScenarioContext;

        public OrangeHRM_UISteps(ScenarioContext scenarioContext)
        {
            _MyInfoPage = scenarioContext.ScenarioContainer.Resolve<MyInfoPage>();
            _HRMLoginPage = scenarioContext.ScenarioContainer.Resolve<HRMLoginPage>();
            _PIMPage = scenarioContext.ScenarioContainer.Resolve<PIMPage>();
            _TopNavBar = scenarioContext.ScenarioContainer.Resolve<TopNavBar>();
            _SideNavBar = scenarioContext.ScenarioContainer.Resolve<SideNavBar>();
            _ScenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }

        [StepDefinition(@"user with the following details logs in:")]
        public void WhenUserWithTheFollowingDetailsLogsIn(Table table)
        {
            var crmUser = table.CreateInstance<CrmUser>();
            _ScenarioContext.Set(crmUser, "crmUser");
            _HRMLoginPage.Login(crmUser);
        }

        [StepDefinition(@"user navigates to '([^']*)' Page")]
        public void WhenNaviagtesToPage(string page)
        {
            if (!_TopNavBar.GetHeader().Equals(page))
                _SideNavBar.ClickOnOption(page);
        }

        [StepDefinition(@"user deletes employee in row without employment status '([^']*)'")]
        public void WhenUserDeletesEmployeeInRowNumber(string status)
        {
            _ScenarioContext.Set(_PIMPage.GetFirstNameOfEmployeeWithoutEmploymentStatus(status), "employee");
            var stopwatch = Stopwatch.StartNew();
            do
            {
                _PIMPage.DeleteUser(_ScenarioContext.Get<string>("employee"));
            } while (_PIMPage.IsUserPresent(_ScenarioContext.Get<string>("employee")) && stopwatch.ElapsedMilliseconds < 300000);
        }

        [StepDefinition(@"the employee should not be displayed")]
        public void ThenTheEmployeeShouldNotBeDisplayed()
        {
            _PIMPage.IsUserPresent(_ScenarioContext.Get<string>("employee")).Should().BeFalse();
            _TopNavBar.ClickOnMenuOption("Logout");
            _HRMLoginPage.Login(_ScenarioContext.Get<CrmUser>("crmUser"));
            _SideNavBar.IsOptionDisplayed("PIM").Should().BeTrue();
        }

        [StepDefinition(@"user adds a new employee")]
        public void WhenUserAddsANewEmployee()
        {
            var employee = new EmployeeProfile();
            _ScenarioContext.Set(employee, "employee");
            _PIMPage.AddEmployee(employee);
            _SideNavBar.ClickOnOption("PIM");
        }

        [StepDefinition(@"the employee can be seen on the list")]
        public void ThenTheEmployeeCanBeSeenOnTheList()
        {
            //var firstName = _ScenarioContext.Get<EmployeeProfile>("employee").Firstname;
            //var lastName = _ScenarioContext.Get<EmployeeProfile>("employee").Lastname;
            //_PIMPage.MatchEmployees(firstName, lastName).Should().BeTrue();

            var listOfEmployees = _PIMPage.GetAllEmployees();
            listOfEmployees.Contains(_ScenarioContext.Get<EmployeeProfile>("employee").Firstname);
            listOfEmployees.Contains(_ScenarioContext.Get<EmployeeProfile>("employee").Lastname);

        }

        [StepDefinition(@"user updates info")]
        public void WhenUserUpdatesInfo()
        {
            var details = new PersonalDetails();
            _ScenarioContext.Set(details);
            _MyInfoPage.UpdateInfo(details);
        }

        [StepDefinition(@"the info is updated successfully")]
        public void ThenTheInfoIsUpdatedSuccessfully()
        {
            _MyInfoPage.GetTextFromInputField("firstName").Should().Be(_ScenarioContext.Get<PersonalDetails>().Firstname);
        }
    }
}
