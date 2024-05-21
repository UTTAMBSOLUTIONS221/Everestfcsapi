namespace DBL.Entities
{
    public class SalePaymentList
    {
        public long PaymentModeId { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalUsed { get; set; }
        public string? MpesaCode { get; set; }
        public string? MpesaMSISDN { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
