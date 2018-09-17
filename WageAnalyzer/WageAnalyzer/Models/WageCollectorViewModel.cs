using SQLite;

namespace WageAnalyzer.Models
{
    [Table("wages")]
    public class WageCollectorViewModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int WageId { get; set; }
        public float DayWages { get; set; }
        public float DayHours { get; set; }
        public float DayMinutes { get; set; }
        [MaxLength(10)]
        public string JobTitle { get; set; }
        [MaxLength(70)]
        public string Restaurant { get; set; }
    }
}
