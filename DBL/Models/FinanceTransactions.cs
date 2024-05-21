namespace DBL.Models
{
    public class FinanceTransactions
    {
        public long FinanceTransactionId { get; set; }
        public string? TransactionCode { get; set; }
        public string? AutomationRefence { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Stationname { get; set; }
        public string? Attendantname { get; set; }
        public string? CardSNO { get; set; }
        public string? EquipmentRegNo { get; set; }
        public string? ProductVariationName { get; set; }
        public string? PaymentMode { get; set; }
        public long AccountId { get; set; }
        public decimal Units { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool IsOnlineSale { get; set; }
        public bool Isreversed { get; set; }
        public bool IsDeletd { get; set; }
        public long TotalUsed { get; set; }
        public decimal TotalPaid { get; set; }
    }
}
