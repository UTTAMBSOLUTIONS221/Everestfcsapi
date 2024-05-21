namespace DBL.Models
{
    public class Systemstationdetailmodel
    {
        public long StationId { get; set; }
        public string? Sname { get; set; }
        public long Tenantstationid { get; set; }
        public List<StationTanks>? StationTanks { get; set; }
        public List<StationPumpModel>? StationPumps { get; set; }
    }
    public class StationTanks
    {
        public long TankId { get; set; }
        public long StationId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Length { get; set; }
        public double Diameter { get; set; }
        public double Volume { get; set; }
        public long NumberOfCalibrations { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
    public class StationPumpModel
    {
        public long PumpId { get; set; }
        public long StationId { get; set; }
        public string? PumpName { get; set; }
        public string? PumpModel { get; set; }
        public long Pumpnozzle { get; set; }
        public bool IsDoubleSided { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
 }
