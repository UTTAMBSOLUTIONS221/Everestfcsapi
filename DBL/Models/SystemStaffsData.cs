namespace DBL.Models
{
    public class SystemStaffsData
    {
        public long Userid { get; set; }
        public long StationId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Pin { get; set; }
        public string? PinHarsh { get; set; }
        public long RoleId { get; set; }
        public string? Rolename { get; set; }
        public long LimitTypeId { get; set; }
        public string? LimitTypename { get; set; }
        public decimal TopupLimit { get; set; }
        public int LoginStatus { get; set; }
        public DateTime Lastlogin { get; set; }
        public DateTime Passwordchange { get; set; }
        public bool IsDefault { get; set; }
        public bool PortalAccess { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
