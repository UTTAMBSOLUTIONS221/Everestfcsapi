namespace DBL.Models
{
    public class SystemStationRelatedData
    {
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public int StationId { get; set; }
        public List<SystemStaffsData>? Staffs { get; set; }    
        public List<SystemProductModelData>? Prodcts { get; set; }    
    }
}
