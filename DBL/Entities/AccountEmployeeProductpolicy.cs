namespace DBL.Entities
{
    public class AccountEmployeeProductpolicy
    {
        public long EmployeeProductId { get; set; }

        public long EmployeeId { get; set; }

        public long ProductVariationId { get; set; }

        public decimal LimitValue { get; set; }

        public string? LimitPeriod { get; set; }
        public string? EmployeeName { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
