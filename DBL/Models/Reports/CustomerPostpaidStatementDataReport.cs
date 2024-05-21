namespace DBL.Models.Reports
{
    public class CustomerPostpaidStatementDataReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? AgreementName { get; set; }
        public string? PaymentModeName { get; set; }
        public List<CustomerPostPaidCustomerStatementData>? PostPaidCustomerStatementData { get; set; }
    }
    public class CustomerPostPaidCustomerStatementData
    {
        public long? CustomerAgreementId { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime Datecreated { get; set; }
        public string? TransactionCode { get; set; }
        public string? Description { get; set; }
        public string? Station { get; set; }
        public string? Mask { get; set; }
        public string? Equipment { get; set; }
        public decimal Units { get; set; }
        public decimal Price { get; set; }
        public string? Product { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalUsed { get; set; }
        public decimal Balance { get; set; }
        public long Sort { get; set; }
    }
}
