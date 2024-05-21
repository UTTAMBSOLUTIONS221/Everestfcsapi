namespace DBL.Models
{
    public class SystemTenantsCardData
    {
        public int CardId { get; set; }
        public string? CardUID { get; set; }
        public string? CardSNO { get; set; }
        public string? CardCode { get; set; }
        public string? CustomerName { get; set; }
        public string? PIN { get; set; }
        public string? PinHarsh { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsReplaced { get; set; }
        public int TagtypeId { get; set; }
        public string? TagTypeName { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedByFullName { get; set; }
        public string? ModifiedByFullName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
