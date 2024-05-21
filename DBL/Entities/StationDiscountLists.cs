namespace DBL.Entities
{
    public class StationDiscountLists
    {
        public long DiscountListId { get; set; }
        public long TenantId { get; set; }
        public string? DiscountListname { get; set; }
        public string? DiscountListDays { get; set; }
        public string? DiscountListStartTime { get; set; }
        public string? DiscountListEndTime { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public List<DiscountListprices>? DiscountListpricestations { get; set; }
        public long ProductvariationId { get; set; }
        public decimal ProductDiscountValue { get; set; }
    }
    public class DiscountListprices
    {
        public long StationId { get; set; }
    }
}
