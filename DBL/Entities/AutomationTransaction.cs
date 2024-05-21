namespace DBL.Entities
{
    public class AutomationTransaction
    {
        public string? EfdId { get; set; }
        public string? RegId { get; set; }
        public long FdcNum { get; set; }
        public string? FdcName { get; set; }
        public long RdgSaveNum { get; set; }
        public long FdcSaveNum { get; set; }
        public DateTime RdgDate { get; set; }
        public string? RdgTime { get; set; }
        public DateTime FdcDate { get; set; }
        public string? FdcTime { get; set; }
        public long RdgIndex { get; set; }
        public long RdgId { get; set; }
        public long Fp { get; set; }
        public long PumpAddr { get; set; }
        public long Noz { get; set; }
        public decimal Price { get; set; }
        public decimal Vol { get; set; }
        public decimal Amo { get; set; }
        public decimal VolTotal { get; set; }
        public long RoundType { get; set; }
        public long RdgProd { get; set; }
        public long FdcProd { get; set; }
        public string? FdcProdName { get; set; }
        public string? FdcTank { get; set; }
    }
}
