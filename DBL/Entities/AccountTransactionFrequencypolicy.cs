namespace DBL.Entities
{
    public class AccountTransactionFrequencypolicy
    {
        public long AccountFrequencyId { get; set; }

        public long AccountId { get; set; }

        public int Frequency { get; set; }

        public string? FrequencyPeriod { get; set; }
        public string? Masknumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
