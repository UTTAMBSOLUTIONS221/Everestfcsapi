namespace DBL.Entities
{
    public class AccountEmployeeTransactionFrequencypolicy
    {
        public long EmployeeFrequencyId { get; set; }

        public long EmployeeId { get; set; }

        public int Frequency { get; set; }

        public string? FrequencyPeriod { get; set; }
        public string? EmployeeName { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}

