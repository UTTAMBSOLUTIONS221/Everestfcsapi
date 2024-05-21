namespace DBL.Entities
{
    public class AccountProductpolicy
    {
        public long AccountProductId { get; set; }

        public long AccountId { get; set; }

        public long ProductVariationId { get; set; }

        public decimal LimitValue { get; set; }

        public string? LimitPeriod { get; set; }
        public string? Masknumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
