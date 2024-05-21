namespace DBL.Models
{
    public class ProductVatPriceData
    {
        public long ProductvariationId { get; set; }
        public string? Productvariationname { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal VatValue { get; set; }
    }
}
