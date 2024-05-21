namespace DBL.Models
{
    public class ProductPriceData
    {
        public long ProductvariationId { get; set; }
        public string? Productvariationname { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal VatValue { get; set; }
    }
}
