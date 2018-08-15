using System;

namespace WageAnalyzer.Models
{
    public class WageDetail
    {
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int WageId { get; set; }
        public float HoursWorkedThatDay { get; set; }
        public float MoneyEarnedThatDay { get; set; }
    }
}
