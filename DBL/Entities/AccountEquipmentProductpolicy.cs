namespace DBL.Entities
{
    public class AccountEquipmentProductpolicy
    {
        public long EquipmentProductId { get; set; }

        public long EquipmentId { get; set; }

        public long ProductVariationId { get; set; }

        public decimal LimitValue { get; set; }

        public string? LimitPeriod { get; set; }
        public string? EquipmentNumber { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }

        public long ModifiedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
