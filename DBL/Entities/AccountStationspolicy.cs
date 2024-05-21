namespace DBL.Entities
{
    public class AccountStationspolicy
    {
        public long AccountStationId { get; set; }

        public long AccountId { get; set; }

        public List<long> StationId { get; set; }

        public string? Masknumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
