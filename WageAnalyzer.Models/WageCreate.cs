using System;

namespace WageAnalyzer.Models
{
    public class WageCreate
    {
        public DateTimeOffset CreatedUtc { get; set; }
        public float HoursWorkedThatDay { get; set; }
        public float MoneyEarnedThatDay { get; set; }
    }
}
