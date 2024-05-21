namespace DBL.Entities
{
    public class Systemgadgets
    {
        public long GadgetId { get; set; }
        public long StationId { get; set; }
        public long TenantId { get; set; }
        public string? GadgetName { get; set; }
        public string? Descriptions { get; set; }
        public string? Imei1 { get; set; }
        public string? Imei12 { get; set; }
        public string? Serialnumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
