namespace DBL.Entities
{
    public class CustomerAccountEquipments
    {
        public long EquipmentId { get; set; }
        public long AccountId { get; set; }
        public string? EquipmentReg { get; set; }
        public long VehicleMakeId { get; set; }
        public long VehicleModelId { get; set; }
        public long ProductVariationId { get; set; }
        public decimal TankCapacity { get; set; }
        public decimal OdometerReading { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
