namespace DBL.Entities
{
    public class SaleTicketLines
    {
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal ProductVariationPrice { get; set; }
        public decimal ProductvariationUnits { get; set; }
        public decimal TotalMoneySold { get; set; }
        public decimal ProductVariationDiscount { get; set; }
        public long CreatedbyId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
