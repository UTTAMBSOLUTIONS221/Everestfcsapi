namespace DBL.Models.Reports
{
    public class SalesTransactionsDetailsData
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? AgreementName { get; set; }
        public string? GroupName { get; set; }
        public string? StationName { get; set; }
        public string? PaymentModeName { get; set; }
        public string? AccountName { get; set; }
        public string? AttendantName { get; set; }
        public string? ProductName { get; set; }
        public List<SalesTransactionDetails>? SalesDetails { get; set; }
    }
    public class SalesTransactionDetails
    {
        public DateTime TransactionDate { get; set; }
        public DateTime PostingDate { get; set; }
        public string? TransactionCode { get; set; }
        public string? AutomationRefence { get; set; }
        public int ParentId { get; set; }
        public int OrderKey { get; set; }
        public string? Station { get; set; }
        public string? Attendant { get; set; }
        public string? Customer { get; set; }
        public string? GroupName { get; set; }
        public long AccountNumber { get; set; }
        public string? Mask { get; set; }
        public string? Equipment { get; set; }
        public string? PayMode { get; set; }
        public string? Products { get; set; }
        public decimal Units { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal SaleAmount { get; set; }
        public decimal SumUnits { get; set; }
        public decimal SumDiscount { get; set; }
        public decimal SumSalesAmount { get; set; }
    }
}
