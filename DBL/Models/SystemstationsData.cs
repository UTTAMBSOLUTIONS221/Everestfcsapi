namespace DBL.Models
{
    public class SystemstationsData
    {
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public List<TenantStations>? Stations { get;set; }
    }

    public class TenantStations
    {
        public long StationId { get; set; }
        public string? StationName { get; set; }
    }
}
