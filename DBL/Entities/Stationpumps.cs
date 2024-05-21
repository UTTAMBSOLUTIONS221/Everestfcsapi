namespace DBL.Entities
{
    public class Stationpumps
    {
        public long Pumpid { get; set; }
        public long Stationid { get; set; }
        public long Tankid { get; set; }
        public string? Pumpname { get; set; }
        public string? Pumpmodel { get; set; }
        public int Pumpnozzle { get; set; }
        public bool IsDoubleSided { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public List<StationPumpNozzles>? StationPumpNozzles { get; set; }
    }
    public class StationPumpNozzles
    {
        public long Nozzleid { get; set; }
        public long Tankid { get; set; }
        public string? TankName { get; set; }
        public long Pumpid { get; set; }
        public string? Side { get; set; }
        public string? Nozzle { get; set; }
    }
}
