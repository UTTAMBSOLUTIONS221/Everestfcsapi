namespace DBL.Models.Reports
{
    
    public class CustomerPrepaidStatementReportData
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? AgreementName { get; set; }
        public string? AccountName { get; set; }
        public string? PaymentModeName { get; set; }
        public List<CustomerPrepaidStatementData>? CustomerPrepaidStatementData { get; set; }
    }
    public class CustomerPrepaidStatementData
    {
        public long CustomerAgreementId { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime PostingDate { get; set; }
        public string? TransactionCode { get; set; }
        public string? Memo { get; set; }
        public string? Mask { get; set; }
        public string? Station { get; set; }
        public string? Equipment { get; set; }
        public decimal QTY { get; set; }
        public decimal Price { get; set; }
        public string? Product { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}
