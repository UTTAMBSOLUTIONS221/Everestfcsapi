namespace DBL.Entities
{
    public class SystemCustomerAgreements
    {
        public long CustomerId { get; set; }
        public long LoyaltyGroupingId { get; set; }
        public long PricelistId { get; set; }
        public long DiscountlistId { get; set; }
        public string? AgreementDoc { get; set; }
        public string? Agreementnote { get; set; }
        public bool AllowOverdraft { get; set; }
        public decimal AllowOverdraftAmount { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
