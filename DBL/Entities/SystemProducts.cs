using DBL.Models;

namespace DBL.Entities
{
    public class SystemProducts
    {
        public long ProductvariationId { get; set; }
        public long ProductId { get; set; }
        public long TenantId { get; set; }
        public long CategoryId { get; set; }
        public long UomId { get; set; }
        public string? Productname { get; set; }
        public string? Productdescription { get; set; }
        public string? Productvariationname { get; set; }
        public long TaxId { get; set; }
        public string? Barcode { get; set; }
        public string? TaxclassificationCode { get; set; }
        public decimal Levyamount { get; set; }
        public decimal Productprice { get; set; }
        public decimal ProductVat { get; set; }
        public string? Levyreference { get; set; }
        public string? Referencenumber { get; set; }
        public string? Imageurl { get; set; }
        public long CreatedbyId { get; set; }
        public long ModifiedId { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public List<ProductPricestationa>? ProductPriceStations { get; set; }
    }
    public class ProductPricestationa
    {
        public long StationId { get; set; }
    }
}
