using DBL.Entities;

namespace DBL.Models
{
    public class SystemAccountDetailData
    {
        public long CustomerId { get; set; }
        public long AccountId { get; set; }
        public string? Customername { get; set; }
        public string? Emailaddress { get; set; }
        public long AccountNumber { get; set; }
        public string? CardSNO { get; set; }
        public string? CardUID { get; set; }
        public double ConsumptionLimit { get; set; }
        public long GroupingId { get; set; }
        public string? LoyaltyGroupingName { get; set; }
        public string? Agreementtypename { get; set; }
        public string? LimitTypename { get; set; }
        public long CredittypeId { get; set; }
        public string? Credittypename { get; set; }
        public string? Currency { get; set; }
        public string? ConsumptionPeriod { get; set; }
        public double CustomerBalance { get; set; }
        public double AgreementBalance { get; set; }
        public double AccountBalance { get; set; }
        public List<CustomerAccountTopups>? CustomerAccounttopups { get; set; }
        public List<AccountProductPolicy>? Accountproductpolicies { get; set; }
        public List<AccountStationPolicy>? Accountstationpolicies { get; set; }
        public List<AccountTransactionPolicy>? Accounttransactionpolicies { get; set; }
        public List<AccountWeekdayPolicy>? Accountweekdaypolicies { get; set; }
        public List<CustomerAccountEmployee>? CustomerAccountemployees { get; set; }
        public List<CustomerAccountEquipment>? CustomerAccountequipments { get; set; }

    }
    public class CustomerAccountTopups
    {
        public long AccountTopupId { get; set; }
        public long FinanceTransactionId { get; set; }
        public string? TransactionCode { get; set; }
        public string? Saledescription { get; set; }
        public string? SaleRefence { get; set; }
        public long AccountId { get; set; }
        public long StationId { get; set; }
        public string? StationName { get; set; }
        public long ModeofPayment { get; set; }
        public string? Paymentmode { get; set; }
        public string? Topupreference { get; set; }
        public decimal Amount { get; set; }
        public bool Isreversed { get; set; }
        public long Createdby { get; set; }
        public string? Fullname { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class CustomerAccountEmployee
    {
        public long EmployeeId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Emailaddress { get; set; }
        public string? Codeharshkey { get; set; }
        public string? Employeecode { get; set; }
        public bool Changecode { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }

    public class CustomerAccountEquipment
    {
        public long EquipmentId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public long EquipmentModelId { get; set; }
        public string? EquipmentRegNo { get; set; }
        public double TankCapacity { get; set; }
        public double Odometer { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
