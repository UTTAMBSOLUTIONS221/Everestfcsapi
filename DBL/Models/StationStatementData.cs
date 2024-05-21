namespace DBL.Models
{
    public class StationStatementData
    {
        public string? StationName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Stationshiftstatements>? Stationshiftstatements { get; set; }
    }
    public class Stationshiftstatements
    {
        public string? ShiftCode { get; set; }
        public string? ShiftCategory { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public string? ShiftStatus { get; set; }
        public string? ShiftStatusGain { get; set; }
        public string? PercentShiftStatusGain { get; set; }
        public string? Attendant { get; set; }
        public decimal TotalOpeningRead { get; set; }
        public decimal TotalClosingRead { get; set; }
        public decimal TotalSales { get; set; }
    }
}
