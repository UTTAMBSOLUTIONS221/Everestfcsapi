namespace DBL.Models.Reports
{
    public class CustomerPointStatementReport
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
        public List<CustomerPointStatementReportData>? PointsStatementData { get; set; }
    }
    public class CustomerPointStatementReportData
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Customer { get; set; }
        public string? Customeridnumber { get; set; }
        public string? Mask { get; set; }
        public string? Equipment { get; set; }
        public string? StationName { get; set; }
        public string? StaffName { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
