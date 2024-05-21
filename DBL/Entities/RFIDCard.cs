namespace DBL.Entities
{
    public class RFIDCard
    {
        public long Used { get; set; }
        public long CardType { get; set; }
        public string? Num { get; set; }
        public string? Num10 { get; set; }
        public string? CustName { get; set; }
        public long CustIdType { get; set; }
        public long CustId { get; set; }
        public string? CustContact { get; set; }
        public long PayMethod { get; set; }
        public long DiscountType { get; set; }
        public decimal Discount { get; set; }
        public string? ProductEnabled { get; set; }
    }
}
