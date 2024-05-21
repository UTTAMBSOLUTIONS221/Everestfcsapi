namespace DBL.Models
{
    public class PriceListData
    {
        public long PriceListId { get; set; }
        public string? PriceListname { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public List<PriceListPriceData>? Pricelistprices { get; set; }
    }

    public class PriceListPriceData
    {
        public long PriceListPricesId { get; set; }
        public long PriceListId { get; set; }
        public long StationId { get; set; }
        public string? Station { get; set; }
        public long ProductvariationId { get; set; }
        public string? Productvariationname { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
