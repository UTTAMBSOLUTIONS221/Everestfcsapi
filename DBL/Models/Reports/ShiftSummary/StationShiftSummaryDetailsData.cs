namespace DBL.Models.Reports.ShiftSummary
{
    public class StationShiftSummaryDetailsData
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<FinancialDetailSummary>? FinancialDetails { get; set; }
        public List<ShiftPumpSaleSummary>? ShiftPumpSaleSummary { get; set; }
        public List<ShiftTankSaleSummary>? ShiftTankSaleSummary { get; set; }
        public List<AttendantShiftSummary>? AttendantShiftSummary { get; set; }
        public decimal ExpectedCash { get; set; }
    }
}
