namespace DBL.Models.Reports
{
    public class CustomerCumulativeDataReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? AgreementName { get; set; }
        public string? PaymentModeName { get; set; }
        public List<CustomerPointCumulativeData>? CustomerPointCumulativeData { get; set; }
    }
    public class CustomerPointCumulativeData
    {
        public string? StationName { get; set; }
        public string? CustomerName { get; set; }
        public string? CardNumber { get; set; }
        public string? Contact { get; set; }
        public decimal CumSalesAmt { get; set; }
        public decimal CumSalesVol { get; set; }
        public decimal CumPoints { get; set; }
    }
}
