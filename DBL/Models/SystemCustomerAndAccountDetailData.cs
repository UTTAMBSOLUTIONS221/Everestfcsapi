using DBL.Entities;

namespace DBL.Models
{
    public class EmployeeProductPolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeProductId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? LimitPeriod { get; set; }
        public long LimitValue { get; set; }
    }

    public class EmployeeStationPolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeStationId { get; set; }
        public long StationId { get; set; }
        public string? Sname { get; set; }
    }

    public class EmployeeTransactionPolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeFrequencyId { get; set; }
        public int Frequency { get; set; }
        public string? FrequencyPeriod { get; set; }
    }

    public class EmployeeWeekDayPolicy
    {
        public long EmployeeId { get; set; }
        public long EmployeeWeekDaysId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? WeekDays { get; set; }
    }

    public class SystemCustomerAccountEmployee
    {
        public long EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Emailaddress { get; set; }
        public string? Codeharshkey { get; set; }
        public string? Employeecode { get; set; }
        public string? Changecode { get; set; }
        public List<EmployeeProductPolicy>? Employeeproductpolicies { get; set; }
        public List<EmployeeStationPolicy>? Employeestationpolicies { get; set; }
        public List<EmployeeTransactionPolicy>? Employeetransactionpolicies { get; set; }
        public List<EmployeeWeekDayPolicy>? Employeeweekdaypolicies { get; set; }
    }

    public class EquipmentProductPolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentProductId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? LimitPeriod { get; set; }
        public decimal LimitValue { get; set; }
    }

    public class EquipmentStationPolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentStationId { get; set; }
        public long StationId { get; set; }
        public string? Sname { get; set; }
    }

    public class EquipmentTransactionPolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentFrequencyId { get; set; }
        public int Frequency { get; set; }
        public string? FrequencyPeriod { get; set; }
    }

    public class EquipmentWeekDayPolicy
    {
        public long EquipmentId { get; set; }
        public long EquipmentWeekDaysId { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? WeekDays { get; set; }
    }

    public class StationProduct
    {
        public long ProductvariationId { get; set; }
        public string? Productvariationname { get; set; }
        public string? Categoryname { get; set; }
        public string? Uomname { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Discountvalue { get; set; }
        public string? Stationname { get; set; }
        public string? Productdefaultimage { get; set; }
    }

    public class SystemCustomerAccount
    {
        public long AccountId { get; set; }
        public long AgreementId { get; set; }
        public string? AgreementDescription { get; set; }
        public long AccountNumber { get; set; }
        public long CardId { get; set; }
        public string? CardUID { get; set; }
        public string? AccountMask { get; set; }
        public long GroupingId { get; set; }
        public string? LoyaltyGrouping { get; set; }
        public long ParentId { get; set; }
        public long CredittypeId { get; set; }
        public string? Credittypename { get; set; }
        public int Credittypevalue { get; set; }
        public long LimitTypeId { get; set; }
        public string? LimitTypename { get; set; }
        public int Limitkey { get; set; }
        public decimal ConsumptionLimit { get; set; }
        public string? ConsumptionPeriod { get; set; }
        public long EquipmentId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public long EquipmentModelId { get; set; }
        public string? EquipmentRegNo { get; set; }
        public decimal TankCapacity { get; set; }
        public decimal Odometer { get; set; }
        public string? EquipmentMake { get; set; }
        public string? EquipmentModel { get; set; }
        public decimal CustomerBalance { get; set; }
        public decimal AccountBalance { get; set; }
        public List<SystemCustomerAccountEmployee>? CustomerAccountemployees { get; set; }
        public List<EquipmentProductPolicy>? Equipmentproductpolicies { get; set; }
        public List<EquipmentStationPolicy>? Equipmentstationpolicies { get; set; }
        public List<EquipmentTransactionPolicy>? Equipmenttransactionpolicies { get; set; }
        public List<EquipmentWeekDayPolicy>? Equipmentweekdaypolicies { get; set; }
        public List<StationProduct>? StationProducts { get; set; }
    }

    public class SystemCustomerAndAccountDetailData
    {
        public long CustomerId { get; set; }
        public string? Customername { get; set; }
        public string? Currency { get; set; }
        public string? SelectedCustomerorDriver { get; set; }
        public string? Emailaddress { get; set; }
        public string? Phonenumber { get; set; }
        public string? HarshKey { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public string? IDNumber { get; set; }
        public string? Designation { get; set; }
        public string? CompanyAddress { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? CompanyIncorporationDate { get; set; }
        public string? CompanyRegistrationNo { get; set; }
        public string? StationName { get; set; }
        public string? Countryname { get; set; }
        public string? CompanyPIN { get; set; }
        public string? CompanyVAT { get; set; }
        public DateTime? Contractstartdate { get; set; }
        public DateTime? Contractenddate { get; set; }
        public int NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public int ConsecutiveTransTimeMin { get; set; }
        public List<SystemCustomerAccount>? CustomerAccounts { get; set; }
    }
}
