namespace DBL.Entities
{
    public class SystemStationShift
    {
        public long ShiftId { get; set; }
        public long StationId { get; set; }
        public string? ShiftCode { get; set; }
        public string? StationName { get; set; }
        public string? ShiftCategory { get; set; }
        public string? CashOrAccount { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public int ShiftStatus { get; set; }
        public decimal ShiftTotalAmount { get; set; }
        public decimal ShiftBankedAmount { get; set; }
        public decimal ShiftBalance { get; set; }
        public decimal ExpectedTankAmount { get; set; }
        public decimal ExpectedPumpAmount { get; set; }
        public decimal GainLoss { get; set; }
        public decimal PercentGainLoss { get; set; }
        public string? ShiftBankReference { get; set; }
        public string? ShiftReference { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public List<StationshiftsData>? StationshiftsData { get; set; }
    }
    public class StationshiftsData
    {
        public long ShiftDataId { get; set; }
        public long ShiftId { get; set; }
        public long NozzleId { get; set; }
        public long AttendantId { get; set; }
        public long PumpId { get; set; }
        public long ProductvariationId { get; set; }
        public decimal OpeningRead { get; set; }
        public decimal ClosingRead { get; set; }
        public decimal SaleQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TestingQuantity { get; set; }
        public decimal GeneratorQuantity { get; set; }
        public decimal GainOrLoss { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
