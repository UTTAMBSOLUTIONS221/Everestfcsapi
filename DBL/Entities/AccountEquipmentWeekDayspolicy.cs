namespace DBL.Entities
{
    public class AccountEquipmentWeekDayspolicy
    {
        public long EquipmentWeekDaysId { get; set; }

        public long EquipmentId { get; set; }

        public string? WeekDays { get; set; }

        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? EquipmentNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
