namespace DBL.Models.Reports
{
    public class CustomerTopupDataReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? AgreementName { get; set; }
        public string? PaymentModeName { get; set; }
        public List<CustomerTopupData>? CustomerTopupData { get; set; }
    }

    public class CustomerTopupData
    {
        public DateTime TopUpDate { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Customer { get; set; }
        public string? Description { get; set; }
        public string? TransactionCode { get; set; }
        public string? TopupReference { get; set; }
        public string? Mask { get; set; }
        public string? Identifier { get; set; }
        public long AccountNumber { get; set; }
        public string? TopupMode { get; set; }
        public double Amount { get; set; }
        public string? Station { get; set; }
        public string? Attendant { get; set; }
    }
}
