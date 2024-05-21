namespace DBL.Models
{
    public class StationShiftDetailData
    {
        public List<StationShift>? StationShifts { get; set; }
    }

    public class StationShiftData
    {
        public long ShiftDataId { get; set; }
        public long ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public string? ShiftCategory { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public long PumpId { get; set; }
        public decimal OpeningMeter { get; set; }
        public decimal ClosingMeter { get; set; }
        public decimal MovedMeter { get; set; }
        public string? Pumpname { get; set; }
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

    public class StationShift
    {
        public long ShiftId { get; set; }
        public long StationId { get; set; }
        public string? ShiftCode { get; set; }
        public string? ShiftCategory { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public int TotalCustomerinvoices { get; set; }
        public int ShiftStatus { get; set; }
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
        public List<StationShiftData>? StationShiftData { get; set; }
    }

}
