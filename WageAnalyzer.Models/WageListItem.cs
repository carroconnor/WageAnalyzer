using System;

namespace WageAnalyzer.Models
{
    public class WageListItem
    {
        public int WageId { get; set; }

        public float HoursWorkedThatDay { get; set; }

        public float MoneyEarnedThatDay { get; set; }

        public string HoursWorked { get; set; }

        public string MoneyEarned { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"[{WageId}] {HoursWorkedThatDay} {MoneyEarnedThatDay}";
    }
}
