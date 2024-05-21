namespace DBL.Entities
{
    public class ShiftLubesandLpg
    {
        public long ShiftLubeLpgId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public long ProductVariationId { get; set; }
        public decimal ProductUnits { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductTotal { get; set; }
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
