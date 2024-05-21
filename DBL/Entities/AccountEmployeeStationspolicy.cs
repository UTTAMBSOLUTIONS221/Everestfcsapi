namespace DBL.Entities
{
    public class AccountEmployeeStationspolicy
    {
        public long EmployeeStationId { get; set; }

        public long EmployeeId { get; set; }

        public List<long>? StationId { get; set; }

        public string? EmployeeName { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
