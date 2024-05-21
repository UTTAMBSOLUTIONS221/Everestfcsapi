namespace DBL.Models
{
    public class CustomerAccountEmployeePolicyDetails
    {
        public long EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public List<AccountEmployeeProduct>? AccountEmployeeproductspolicy { get; set; }
        public List<AccountEmployeeStation>? AccountEmployeestationspolicy { get; set; }
        public List<AccountEmployeeWeekDaysPolicy>? AccountEmployeeweekdayspolicy { get; set; }
        public List<AccountEmployeeFrequencyPolicy>? AccountEmployeefrequencypolicy { get; set; }

    }

    public class AccountEmployeeProduct
    {
        public long EmployeeProductId { get; set; }
        public long EmployeeId { get; set; }
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

    public class AccountEmployeeStation
    {
        public long EmployeeStationId { get; set; }
        public long EmployeeId { get; set; }
        public long StationId { get; set; }
        public string? Stationname { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class AccountEmployeeWeekDaysPolicy
    {
        public long EmployeeWeekDaysId { get; set; }
        public long EmployeeId { get; set; }
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

    public class AccountEmployeeFrequencyPolicy
    {
        public long EmployeeFrequencyId { get; set; }
        public long EmployeeId { get; set; }
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
