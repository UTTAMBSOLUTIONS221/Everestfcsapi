namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftCustomerStatementData
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? CustomerName { get; set; }
        public string? AttendantName { get; set; }
        public List<ShiftCustomerStatement>? ShiftCustomerStatement { get; set; }
    }
    public class ShiftCustomerStatement
    {
        public DateTime Datecreated { get; set; }
        public string? Customername { get; set; }
        public string? DebitCredit { get; set; }
        public string? Equipment { get; set; }
        public string? Attendant { get; set; }
        public string? Productname { get; set; }
        public decimal ProductUnits { get; set; }
        public decimal ProductPrice { get; set; }
        public string? Paymentmode { get; set; }
        public string? PaymentReference { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal Amount { get; set; }
        public decimal RunningBalance { get; set; }
    }
}
