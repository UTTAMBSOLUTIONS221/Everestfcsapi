namespace DBL.Entities
{
    public class LnkDiscountProductModel
    {
        public long LnkDiscountProductId { get; set; }
        public long DiscountlistId { get; set; }
        public long ProductvariationId { get; set; }
        public List<DiscountListpricesnew>? DiscountListpricestations { get; set; }
        public decimal Discountvalue { get; set; }
        public string? Daysapplicable { get; set; }
        public string? Starttime { get; set; }
        public string? Endtime { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
    public class DiscountListpricesnew
    {
        public long StationId { get; set; }
    }
}
