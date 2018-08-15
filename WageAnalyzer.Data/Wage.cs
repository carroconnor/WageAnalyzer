using System;

namespace WageAnalyzer.Data
{
    public class Wage
    {
        public DateTimeOffset CreatedUtc { get; set; }
        public float HoursWorkedThatDay { get; set; }
        public float MoneyEarnedThatDay { get; set; }
    }
}
