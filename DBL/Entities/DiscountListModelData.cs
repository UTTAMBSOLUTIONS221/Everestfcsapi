namespace DBL.Entities
{
    public class DiscountListModelData
    {
        public long DiscountListId { get; set; }
        public string? DiscountListname { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
