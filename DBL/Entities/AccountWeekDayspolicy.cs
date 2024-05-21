namespace DBL.Entities
{
    public class AccountWeekDayspolicy
    {
        public long AccountWeekDaysId { get; set; }

        public long AccountId { get; set; }

        public string? WeekDays { get; set; }

        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? Masknumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
