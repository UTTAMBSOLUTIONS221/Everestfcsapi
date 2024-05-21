namespace DBL.Models.Reports
{
    public class CustomerPointAwardReport
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
        public List<CustomerPointRewardData>? CustomerPointRewardData { get; set; }
    }
    public class CustomerPointRewardData
    {
        public string? Product { get; set; }
        public decimal SaleValue { get; set; }
        public decimal AwardValue { get; set; }
        public string? Station { get; set; }
        public string? Attendant { get; set; }
        public string? AccountCreditType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Account { get; set; }
        public string? Customer { get; set; }
        public string? AccountNumber { get; set; }
        public string? IDNumber { get; set; }
        public decimal Units { get; set; }
        public decimal Price { get; set; }
    }
}
