namespace DBL.Entities
{
    public class AutomatedStationData
    {
        public long AutomatedStationId { get; set; }
        public long TenantId { get; set; }
        public long StationId { get; set; }
        public string? Stationcode { get; set; }
        public bool Isautomated { get; set; }
        public long Automatedby { get; set; }
        public DateTime DateAutomated { get; set; }
    }
}
