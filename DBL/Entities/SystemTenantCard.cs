namespace DBL.Entities
{
    public class SystemTenantCard
    {
        public int CardId { get; set; }
        public int TenantId { get; set; }
        public string? CardUID { get; set; }
        public string? CardSNO { get; set; }
        public string? PIN { get; set; }
        public string? PinHash { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsReplaced { get; set; }
        public int TagtypeId { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
