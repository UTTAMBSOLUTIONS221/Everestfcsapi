namespace DBL.Entities
{
    public class AccountEquipmentStationspolicy
    {
        public long EquipmentStationId { get; set; }

        public long EquipmentId { get; set; }

        public List<long>? StationId { get; set; }

        public string? EquipmentNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
