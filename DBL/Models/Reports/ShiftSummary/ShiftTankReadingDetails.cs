namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftTankReadingDetails
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<ShiftTankReadingData>? ShiftTankReading { get; set; }
        public List<TankSummary>? TankSummary { get; set; }
    }
    public class ShiftTankReadingData
    {
        public long ShiftTankReadingId { get; set; }
        public long ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public long TankId { get; set; }
        public string? TankName { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal TankPurchase { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal QuantitySold { get; set; }
        public decimal PumpLitres { get; set; }
        public decimal Differences { get; set; }
        public decimal DifferenceValue { get; set; }
        public decimal AmountSold { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class TankSummary
    {
        public string? TankName { get; set; }
        public decimal TotalTankAmount { get; set; }
    }
}
