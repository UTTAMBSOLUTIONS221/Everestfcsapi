namespace DBL.Entities
{
    public class PostpaidRecurentAgreement
    {
        public long PostpaidRecurentAgreementId { get; set; }
        public long CustomerId { get; set; }
        public long AgreementId { get; set; }
        public long GroupingId { get; set; }
        public long AgreementTypeId { get; set; }
        public long PriceListId { get; set; }
        public long DiscountListId { get; set; }
        public string? BillingCycleType { get; set; }
        public long ConsumptionLimitType { get; set; }
        public decimal ConsumptionLimitValue { get; set; }
        public string? Descriptions { get; set; }
        public string? Reference { get; set; }
        public string? BillingBasis { get; set; }
        public DateTime StartDate { get; set; }
        public bool HasGroup { get; set; }
        public bool HasOverdraft { get; set; }
        public int GracePeriod { get; set; }
        public int BillingDay { get; set; }
        public int BillingCycle { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
