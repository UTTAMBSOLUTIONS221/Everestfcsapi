namespace DBL.Entities
{
    public class StationTankModel
    {
        public long TankId { get; set; }
        public long StationId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Length { get; set; }
        public double Diameter { get; set; }
        public double Volume { get; set; }
        public int NumberOfCalibrations { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
