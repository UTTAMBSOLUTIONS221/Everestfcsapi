namespace DBL.Models
{
    public class AccountProductPolicy
    {
        public long AccountId { get; set; }
        public long AccountProductId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? LimitPeriod { get; set; }
        public decimal LimitValue { get; set; }
    }

    public class AccountStationPolicy
    {
        public long AccountId { get; set; }
        public long AccountStationId { get; set; }
        public long StationId { get; set; }
        public string? Sname { get; set; }
    }

    public class AccountTransactionPolicy
    {
        public long AccountId { get; set; }
        public long AccountFrequencyId { get; set; }
        public int Frequency { get; set; }
        public string? FrequencyPeriod { get; set; }
    }

    public class AccountWeekdayPolicy
    {
        public long AccountId { get; set; }
        public long AccountWeekDaysId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? WeekDays { get; set; }
    }

    public class Employeeproductpolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeProductId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? LimitPeriod { get; set; }
        public decimal LimitValue { get; set; }
    }

    public class Employeestationpolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeStationId { get; set; }
        public long StationId { get; set; }
        public string? Sname { get; set; }
    }

    public class Employeetransactionpolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeFrequencyId { get; set; }
        public int Frequency { get; set; }
        public string? FrequencyPeriod { get; set; }
    }

    public class Employeeweekdaypolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeWeekDaysId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? WeekDays { get; set; }
    }

    public class Equipmentproductpolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentProductId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? LimitPeriod { get; set; }
        public decimal LimitValue { get; set; }
    }

    public class Equipmentstationpolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentStationId { get; set; }
        public long StationId { get; set; }
        public string? Sname { get; set; }
    }

    public class Equipmenttransactionpolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentFrequencyId { get; set; }
        public int Frequency { get; set; }
        public string? FrequencyPeriod { get; set; }
    }

    public class Equipmentweekdaypolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentWeekDaysId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? WeekDays { get; set; }
    }

}
