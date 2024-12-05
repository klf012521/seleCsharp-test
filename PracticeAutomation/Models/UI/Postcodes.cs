using CsvHelper.Configuration.Attributes;

namespace PracticeAutomation.Models.UI
{
    public class Postcodes
    {
        [Name("postcode")]
        public string Postcode { get; set; }
    }
}
