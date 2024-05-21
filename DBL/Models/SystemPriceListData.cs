namespace DBL.Models
{
    public class SystemPriceListData
    {
        public IEnumerable<SystemPriceData>? CustomerPriceData { get; set; }
    }
    public class SystemPriceData
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
        public IEnumerable<PricelistPricesData>? PricelistData { get; set; }
    }
    public class PricelistPricesData
    {
        public long PriceListPricesId { get; set; }
        public long StationId { get; set; }
        public long ProductvariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? Station { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
