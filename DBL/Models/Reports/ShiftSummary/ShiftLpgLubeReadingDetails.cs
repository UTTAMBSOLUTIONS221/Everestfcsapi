namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftLpgLubeReadingDetails
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<ShiftLpgLubeReadingData>? ShiftLpgLubeReading { get; set; }
        public List<LpgLubeSummaryData>? LpgLubeReadings { get; set; }
    }

    public class ShiftLpgLubeReadingData
    {
        public long ShiftLubeLpgId { get; set; }
        public long ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public long StockTypeId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal OpeningUnits { get; set; }
        public decimal AddedUnits { get; set; }
        public decimal ClosingUnits { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal UnitsTotal { get; set; }
        public decimal TotalVat { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class LpgLubeSummaryData
    {
        public string? Product { get; set; }
        public string? Category { get; set; }
        public decimal DryTotalAmount { get; set; }
    }
}
