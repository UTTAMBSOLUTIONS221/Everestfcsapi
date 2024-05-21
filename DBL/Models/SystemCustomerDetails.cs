namespace DBL.Models
{
    public class SystemCustomerDetails
    {
        public long CustomerId { get; set; }
        public string? Designation { get; set; }
        public string? Customername { get; set; }
        public long CountryId { get; set; }
        public long StationId { get; set; }
        public string? Currency { get; set; }
        public string? Emailaddress { get; set; }
        public string? Phonenumber { get; set; }
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public string? IDNumber { get; set; }
        public string? CompanyAddress { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime CompanyIncorporationDate { get; set; }
        public string? CompanyRegistrationNo { get; set; }
        public string? CompanyPIN { get; set; }
        public string? CompanyVAT { get; set; }
        public DateTime Contractstartdate { get; set; }
        public DateTime Contractenddate { get; set; }
        public string? Stationname { get; set; }
        public string? Countryname { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime CustomerDatecreated { get; set; }
        public DateTime CustomerDateModified { get; set; }
        public int NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public int ConsecutiveTransTimeMin { get; set; }
        public List<SystemCustomerAgreementsData>? CustomerAgreements { get; set; }
    }

    public class SystemCustomerAgreementsData
    {
        public long AgreementId { get; set; }
        public long AgreementAccountId { get; set; }
        public long CustomerId { get; set; }
        public long GroupingId { get; set; }
        public long AgreemettypeId { get; set; }
        public string? Agreementtypename { get; set; }
        public long PriceListId { get; set; }
        public string? PriceListname { get; set; }
        public long DiscountListId { get; set; }
        public string? DiscountListname { get; set; }
        public string? BillingBasis { get; set; }
        public string? BillingCycleType { get; set; }
        public int BillingCycle { get; set; }
        public int RecurrentGracePeriod { get; set; }
        public DateTime NextBillingDate { get; set; }
        public string? Descriptions { get; set; }
        public string? Notes { get; set; }
        public bool Hasgroup { get; set; }
        public bool HasOverdraft { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public decimal CustomerBalance { get; set; }
        public decimal CustomerAccountBalance { get; set; }
        public decimal CustomerAgreementBalance { get; set; }
        public decimal CreditAgreementLimit { get; set; }
        public decimal CreditAgreementBalance { get; set; }
        public decimal CreditAgreementActualDebt { get; set; }
        public decimal ConsumptiontoDate { get; set; }
        public decimal RecurrentAgreementLimit { get; set; }
        public decimal RecurrentAgreementBalance { get; set; }
        public int Paymentterms { get; set; }
        public List<CustomerAccount>? CustomerAccounts { get; set; }
    }

    public class CustomerAccount
    {
        public long AccountId { get; set; }
        public long AgreementId { get; set; }
        public long AccountNumber { get; set; }
        public long CardId { get; set; }
        public string? CardSNO { get; set; }
        public long GroupingId { get; set; }
        public long ParentId { get; set; }
        public long CredittypeId { get; set; }
        public string? Credittypename { get; set; }
        public long Credittypevalue { get; set; }
        public long LimitTypeId { get; set; }
        public string? LimitTypename { get; set; }
        public long Limitkey { get; set; }
        public decimal AccountLimit { get; set; }
        public decimal PrepaidAccountBalance { get; set; }
        public decimal CreditAccountBalance { get; set; }
        public decimal CreditConsumptionBalance { get; set; }
        public decimal CreditAccountLimitBalance { get; set; }
        public decimal RecurrentAccountBalance { get; set; }
        public string? ConsumptionPeriod { get; set; }
        public long EquipmentAssigned { get; set; }
        public long UsersAssigned { get; set; }
        public bool Isadminactive { get; set; }
        public bool Iscustomeractive { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}