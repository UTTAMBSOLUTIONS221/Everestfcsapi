namespace DBL.Models
{
    public class SystemStationData
    {
        public long StationId{get;set;}
        public bool Extra { get; set; }
        public string? Stationcode { get; set; }
        public string? Sname{get;set;}
        public string? Semail { get;set;}
        public string? Phonenumber { get; set; }
        public string? Addresses { get;set;}
        public string? City { get;set;}
        public string? Street { get;set;}
        public long SubscriptionId { get;set;}
        public bool Issubscribed { get;set;}
        public string? Subkey { get;set;}
        public bool IsDefault { get;set;}
        public bool IsActive { get;set;}
        public bool IsDeleted { get;set;}
        public DateTime SubExpiry { get;set; }
        public string? CreatedBy { get;set;}
    public DateTime DateCreated { get; set;}
    }
}
