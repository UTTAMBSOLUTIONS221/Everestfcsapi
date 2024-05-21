namespace DBL.Entities
{
    public class StationDailyDip
    {
        public long StationDipId { get; set; }
        public long StationId { get; set; }
        public long TankId { get; set; }
        public decimal CurrentDipReading { get; set; }
        public decimal CurrentMeterReading { get; set; }
        public decimal PreviousDipReading { get; set; }
        public decimal PreviousMeterReading { get; set; }
        public decimal TankVariance { get; set; }
        public decimal MeterVariance { get; set; }
        public decimal TankSale { get; set; }
        public decimal MeterSale { get; set; }
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
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
