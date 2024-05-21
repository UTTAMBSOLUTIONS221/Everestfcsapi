namespace DBL.Entities
{
    public class Discount
    {
        public long DiscountType { get; set; }
        public decimal PriceOrigin { get; set; }
        public decimal PriceNew { get; set; }
        public decimal PriceDiscount { get; set; }
        public decimal VolOrigin { get; set; }
        public decimal AmoOrigin { get; set; }
        public decimal AmoNew { get; set; }
        public decimal AmoDiscount { get; set; }
    }
}
