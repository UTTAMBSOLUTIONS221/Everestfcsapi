namespace DBL.Models.Reports.ShiftSummary
{
    public class StationShiftDetailsData
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<StationShiftDetails>? StationShiftDetails { get; set; }
    }
    public class StationShiftDetails
    {
        public string? StationName { get; set; }
        public string? ShiftCode { get; set; }
        public string? ShiftCategory { get; set; }
        public string? CashOrAccount { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public string? ShiftStatus { get; set; }
        public bool IsPosted { get; set; }
        public bool IsDeleted { get; set; }
        public decimal ShiftBalance { get; set; }
        public string? ShiftReference { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
