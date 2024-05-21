namespace DBL.Entities
{
    public class StationPriceLists
    {
        public long PriceListId { get; set; }
        public long TenantId { get; set; }
        public string? PriceListname { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public List<PriceListprices>? PriceListprices { get; set; }
        public long ProductvariationId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductVat { get; set; }
    }
    public class PriceListprices
    {
        public long PriceListPricesId { get; set; }
        public long StationId { get; set; }
        public long ProductvariationId { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
