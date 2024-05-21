namespace DBL.Entities
{
    public class AccountEmployeeWeekDayspolicy
    {
        public long EmployeeWeekDaysId { get; set; }

        public long EmployeeId { get; set; }

        public string? WeekDays { get; set; }

        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? EmployeeName { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
