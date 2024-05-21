namespace DBL.Models;

public class CustomerCardDetailsData
{
    public int RespStatus { get; set; }
    public string? RespMessage { get; set; }

    public CustomerAccountCardDetail? CustomerAccountCardDetail { get; set; }
}


public class CustomerAccountCardDetail
{
    public long CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? Phonenumber { get; set; }
    public string? CustomerEmail { get; set; }
    public DateTime DateCreated { get; set; }
    public bool CustomerIsActive { get; set; }
    public decimal NoOfTransactionPerDay { get; set; }
    public decimal AmountPerDay { get; set; }
    public long ConsecutiveTransTimeMin { get; set; }
    public long AgreementId { get; set; }
    public long AccountId { get; set; }
    public long CardId { get; set; }
    public string? CardUID { get; set; }
    public string? CardCode { get; set; }
    public string? CardSNO { get; set; }
    public string? BillingBasis { get; set; }
    public long HasDriverCode { get; set; }
    public long GroupingId { get; set; }
    public long AccountNumber { get; set; }
    public string? Credittypename { get; set; }
    public long Credittypevalue { get; set; }
    public string? Agreementtypename { get; set; }
    public long LimitTypeId { get; set; }
    public string? LimitTypename { get; set; }
    public string? Descriptions { get; set; }
    public string? Currency { get; set; }
    public decimal PostpaidLimitInPeriod { get; set; }
    public decimal CustomerPostPaidLimit { get; set; }
    public decimal AgreementActualBalance { get; set; }
    public decimal CustomerBalance { get; set; }
    public decimal CustomerAccountBalance { get; set; }
    public List<PaymentModeItem>? PaymentModes { get; set; }
    public List<AccountProductsItem>? AccountProducts { get; set; }
    public List<AccountStationsItem>? AccountStations { get; set; }
    public List<AccountWeekDay>? AccountWeekDay { get; set; }
    public List<AccountTransactionFrequency>? AccountTransactionFrequency { get; set; }
    public List<CustomerAccountEquipmentItem>? CustomerAccountEquipment { get; set; }
    public List<AccountEmployeesItem>? AccountEmployees { get; set; }
    public List<CustomerAccountProductsItem>? CustomerAccountProducts { get; set; }
    public List<CustomerAccountRewards>? CustomerAccountRewards { get; set; }
}
public class PaymentModeItem
{
    public long Value { get; set; }
    public string? Text { get; set; }
    public long GroupId { get; set; }
    public string? Groupname { get; set; }
}
public class AccountEmployeesItem
{
    public long EmployeeId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Emailaddress { get; set; }
    public string? Employeecode { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public List<EmployeeProductsItem>? EmployeeProducts { get; set; }
    public List<EmployeeStationsItem>? EmployeeStations { get; set; }
    public List<EmployeeWeekDaysItem>? EmployeeWeekDays { get; set; }
    public List<EmployeeTransactionFrequencyItem>? EmployeeTransactionFrequency { get; set; }
}
public class CustomerAccountEquipmentItem
{
    public long EquipmentId { get; set; }
    public string? Productvariationname { get; set; }
    public string? EquipmentMake { get; set; }
    public string? EquipmentModel { get; set; }
    public string? EquipmentRegNo { get; set; }
    public decimal TankCapacity { get; set; }
    public decimal Odometer { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public List<EquipmentProductsItem>? EquipmentProducts { get; set; }
    public List<EquipmentStationsItem>? EquipmentStations { get; set; }
    public List<EquipmentWeekDaysItem>? EquipmentWeekDays { get; set; }
    public List<EquipmentTransactionFrequencyItem>? EquipmentTransactionFrequency { get; set; }
}
public class AccountProductsItem
{
    public long AccountProductId { get; set; }
    public long AccountId { get; set; }
    public long ProductVariationId { get; set; }
    public decimal LimitValue { get; set; }
    public string? LimitPeriod { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

public class AccountStationsItem
{
    public long AccountStationId { get; set; }
    public long AccountId { get; set; }
    public long StationId { get; set; }
    public string? StationName { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

public class AccountWeekDay
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

public class AccountTransactionFrequency
{
    public long AccountFrequencyId { get; set; }
    public long AccountId { get; set; }
    public long Frequency { get; set; }
    public string? FrequencyPeriod { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

public class EquipmentProductsItem
{
    public long EquipmentProductId { get; set; }
    public long EquipmentId { get; set; }
    public long ProductVariationId { get; set; }
    public long LimitValue { get; set; }
    public string? LimitPeriod { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

public class EquipmentStationsItem
{
    public long EquipmentStationId { get; set; }
    public long EquipmentId { get; set; }
    public long StationId { get; set; }
    public string? StationName { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

public class EquipmentWeekDaysItem
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
public class EquipmentTransactionFrequencyItem
{
    public long EquipmentFrequencyId { get; set; }
    public long EquipmentId { get; set; }
    public int Frequency { get; set; }
    public string? FrequencyPeriod { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
public class EmployeeProductsItem
{
    public long EmployeeProductId { get; set; }
    public long EmployeeId { get; set; }
    public long ProductVariationId { get; set; }
    public decimal LimitValue { get; set; }
    public string? LimitPeriod { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

public class EmployeeStationsItem
{
    public long EmployeeStationId { get; set; }
    public long EmployeeId { get; set; }
    public long StationId { get; set; }
    public string? StationName { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

public class EmployeeWeekDaysItem
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
public class EmployeeTransactionFrequencyItem
{
    public long EmployeeFrequencyId { get; set; }
    public long EmployeeId { get; set; }
    public int Frequency { get; set; }
    public string? FrequencyPeriod { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
public class CustomerAccountProductsItem
{
    public long ProductvariationId { get; set; }
    public string? Productvariationname { get; set; }
    public string? Categoryname { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal Discountvalue { get; set; }
    public string? Discounttype { get; set; }
}

public class CustomerAccountRewards
{
    public long LRewardId { get; set; }
    public string? RewardName { get; set; }
    public decimal RewardValue { get; set; }
    public decimal RewardRedeemValue { get; set; }
}