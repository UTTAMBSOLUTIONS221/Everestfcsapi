namespace DBL.Models.Reports
{
    public class CustomerPaymentDataReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? AgreementName { get; set; }
        public string? PaymentModeName { get; set; }
        public List<CustomerPaymentData>? CustomerPaymentData { get; set; }
    }

    public class CustomerPaymentData
    {

        public DateTime TransactionDate { get; set; }
        public DateTime PostingDate { get; set; }
        public string? Customer { get; set; }
        public string? Description { get; set; }
        public string? Reference { get; set; }
        public string? TopupReference { get; set; }
        public string? Mask { get; set; }
        public long Account { get; set; }
        public string? TopupMode { get; set; }
        public double Amount { get; set; }
        public string? Attendant { get; set; }
    }

}
