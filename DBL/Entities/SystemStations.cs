namespace DBL.Entities
{
    public class SystemStations
    {
        public long StationId { get; set; }
        public long Tenantid { get; set; }
        public string? Sname { get; set; }
        public string? Semail { get; set; }
        public long Phoneid { get; set; }
        public string? Phone { get; set; }
        public string? Addresses { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        //public List<StationShiftsData>? StationShifts { get; set; }
    }

    public class StationShiftsData
    {
        public long ShiftId { get; set; }
        public long StationId { get; set; }
        public string? Shiftname { get; set; }
        public string? Starttime { get; set; }
        public string? Endtime { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
