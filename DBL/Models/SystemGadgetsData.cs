namespace DBL.Models
{
    public class SystemGadgetsData
    {
        public long GadgetId { get; set; }
        public string? GadgetName { get; set; }
        public string? Descriptions { get; set; }
        public string? Imei1 { get; set; }
        public string? Imei2 { get; set; }
        public string? Serialnumber { get; set; }
        public string? Station { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedbyId { get; set; }
        public long ModifiedbyId { get; set; }
        public string? IsAssigned { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
