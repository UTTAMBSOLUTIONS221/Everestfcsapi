namespace DBL.Models
{
    public class CustomerAccountEquipmentPolicyDetails
    {
        public long EquipmentId { get; set; }
        public string? EquipmentNumber { get; set; }
        public List<AccountEquipmentProduct>? AccountEquipmentproductspolicy { get; set; }
        public List<AccountEquipmentStation>? AccountEquipmentstationspolicy { get; set; }
        public List<AccountEquipmentWeekDaysPolicy>? AccountEquipmentweekdayspolicy { get; set; }
        public List<AccountEquipmentFrequencyPolicy>? AccountEquipmentfrequencypolicy { get; set; }

    }

    public class AccountEquipmentProduct
    {
        public long EquipmentProductId { get; set; }
        public long EquipmentId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public decimal LimitValue { get; set; }
        public string? LimitPeriod { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class AccountEquipmentStation
    {
        public long EquipmentStationId { get; set; }
        public long EquipmentId { get; set; }
        public long StationId { get; set; }
        public string? Stationname { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class AccountEquipmentWeekDaysPolicy
    {
        public long EquipmentWeekDaysId { get; set; }
        public long EquipmentId { get; set; }
        public string? WeekDays { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class AccountEquipmentFrequencyPolicy
    {
        public long EquipmentFrequencyId { get; set; }
        public long EquipmentId { get; set; }
        public long Frequency { get; set; }
        public string? FrequencyPeriod { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
