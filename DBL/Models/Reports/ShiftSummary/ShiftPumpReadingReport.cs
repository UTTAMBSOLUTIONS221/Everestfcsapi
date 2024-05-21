namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftPumpReadingReport
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<ShiftPumpReadingData>? ShiftPumpReading { get; set; }
        public List<ShiftPumpSummary>? PumpSummary { get; set; }
    }
    public class ShiftPumpReadingData
    {
        public long ShiftPumpReadingId { get; set; }
        public long ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public long PumpId { get; set; }
        public string? Pumpname { get; set; }
        public string? Pumpmodel { get; set; }
        public long NozzleId { get; set; }
        public string? Nozzle { get; set; }
        public string? WareHouse { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal OpeningShilling { get; set; }
        public decimal ClosingShilling { get; set; }
        public decimal TotalShilling { get; set; }
        public decimal ShillingDifference { get; set; }
        public decimal OpeningElectronic { get; set; }
        public decimal ClosingElectronic { get; set; }
        public decimal ElectronicSold { get; set; }
        public decimal ElectronicAmount { get; set; }
        public decimal OpeningManual { get; set; }
        public decimal ClosingManual { get; set; }
        public decimal ManualSold { get; set; }
        public decimal ManualAmount { get; set; }
        public decimal LitersDifference { get; set; }
        public decimal TestingRtt { get; set; }
        public decimal PumpRttAmount { get; set; }
        public decimal TotalPumpAmount { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }
    public class ShiftPumpSummary
    {
        public string? Pumpname { get; set; }
        public decimal OpeningElectronicAmount { get; set; }
        public decimal CloseElectronicAmount { get; set; }
        public decimal TotalPumpAmount { get; set; }
    }
}
