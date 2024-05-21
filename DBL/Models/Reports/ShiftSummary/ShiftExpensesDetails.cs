namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftExpensesDetails
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<ShiftExpensesData>? ShiftExpenses { get; set; }
    }
    public class ShiftExpensesData
    {
        public long ShiftVoucherId { get; set; }
        public long ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public string? VoucherType { get; set; }
        public string? CreditDebit { get; set; }
        public long VoucherModeId { get; set; }
        public string? VoucherMode { get; set; }
        public string? VoucherName { get; set; }
        public decimal VoucherAmount { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
