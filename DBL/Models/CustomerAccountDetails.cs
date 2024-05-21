using DBL.Entities;

namespace DBL.Models
{
    public class CustomerAccountDetails
    {
        public long AccountId { get; set; }
        public long AccountNumber { get; set; }
        public string? MaskNumber { get; set; }
        public List<AccountProduct>? Accountproductspolicy { get; set; }
        public List<AccountStation>? Accountstationspolicy { get; set; }
        public List<AccountWeekDaysPolicy>? Accountweekdayspolicy { get; set; }
        public List<AccountFrequencyPolicy>? Accountfrequencypolicy { get; set; }

    }

    public class AccountProduct
    {
        public long AccountProductId { get; set; }
        public long AccountId { get; set; }
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

    public class AccountStation
    {
        public long AccountStationId { get; set; }
        public long AccountId { get; set; }
        public long StationId { get; set; }
        public string? Stationname { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class AccountWeekDaysPolicy
    {
        public long AccountWeekDaysId { get; set; }
        public long AccountId { get; set; }
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

    public class AccountFrequencyPolicy
    {
        public int AccountFrequencyId { get; set; }
        public int AccountId { get; set; }
        public int Frequency { get; set; }
        public string FrequencyPeriod { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public object CreatedBy { get; set; }
        public object ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
