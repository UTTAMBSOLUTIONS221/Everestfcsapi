namespace DBL.Models
{
    public class CustomerAccountCardDetails
    {
        public long CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Phonenumber { get; set; }
        public string? CustomerEmail { get; set; }
        public DateTime DateCreated { get; set; }
        public bool CustomerIsActive { get; set; }
        public decimal NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public long ConsecutiveTransTimeMin { get; set; }
        public long AgreementId { get; set; }
        public string? BillingBasis { get; set; }
        public long HasDriverCode { get; set; }
        public long GroupingId { get; set; }
        public long AccountNumber { get; set; }
        public string? Credittypename { get; set; }
        public long Credittypevalue { get; set; }
        public string? Agreementtypename { get; set; }
        public long LimitTypeId { get; set; }
        public string? LimitTypename { get; set; }
        public string? Descriptions { get; set; }
        public string? Currency { get; set; }
        public decimal PostpaidLimitInPeriod { get; set; }
        public decimal CustomerPostPaidLimit { get; set; }
        public decimal AgreementActualBalance { get; set; }
        public decimal CustomerBalance { get; set; }
        public decimal CustomerAccountBalance { get; set; }
    }
}
