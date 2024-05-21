namespace DBL.Models
{
    public class ShiftSummaryDetailData
    {
        public List<ManualPumpSummary>? ManualPumpSummary { get; set; }
        public List<ManualTankSummary>? ManualTankSummary { get; set; }
    }

    public class ManualPumpSummary
    {
        public string? Nozzle { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal OpeningReading { get; set; }
        public decimal ClosingReading { get; set; }
        public decimal GrossSale { get; set; }
        public decimal PricePerLiter { get; set; }
        public decimal EquiCashGross { get; set; }
        public decimal Transfers { get; set; }
        public decimal PumpTestRTT { get; set; }
        public decimal GeneratorFuel { get; set; }
        public decimal TotalTransferRttandGen { get; set; }
        public decimal EquiCashTransferRttandGen { get; set; }
        public decimal NetSale { get; set; }
        public decimal EquiCashNetSale { get; set; }
    }
    public class ManualTankSummary
    {
        public string? Tank { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal Purchases { get; set; }
        public decimal TotalStock { get; set; }
        public decimal SalebyPump { get; set; }
        public decimal ExpectedClosingStock { get; set; }
        public decimal ActualClosingStock { get; set; }
        public decimal SaleByTank { get; set; }
        public decimal Gain { get; set; }
        public decimal PercentageGain { get; set; }
    }
}
