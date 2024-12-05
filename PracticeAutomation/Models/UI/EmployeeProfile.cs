using CynkyUtilities;

namespace PracticeAutomation.Models.UI
{
    public class EmployeeProfile
    {
        public string Firstname { get; set; } = StringGenerator.GetRandomString();
        public string Lastname { get; set; } = StringGenerator.GetRandomString();
    }
}
