namespace DBL.Entities
{
    public class SystemLoyaltyScheme
    {
        public long LSchemeId { get; set; }
        public string? LSchemeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
