namespace DBL.Models
{
    public class SystemStaffData
    {
        public long RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public long StaffId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Pin { get; set; }
        public string? PinHarsh { get; set; }
        public long RoleId { get; set; }
        public long LimitTypeId { get; set; }
        public decimal TopupLimit { get; set; }
        public int LoginStatus { get; set; }
        public long GeneralSettId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyLogo { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyReference { get; set; }
        public string? CompanyPIN { get; set; }
        public long CurrencyId { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencySymbol { get; set; }
        public bool IndividualMultipleAccounts { get; set; }
        public string? CCEmail { get; set; }
        public bool IsCCEmail { get; set; }
        public bool EmailCustomerAutomatically { get; set; }
        public string? TimeZone { get; set; }
        public string? TimeZoneOffSet { get; set; }
        public bool StaffAutoLogOff { get; set; }
        public bool ApplyTax { get; set; }
        public int noOfDecimalPlaces { get; set; }
        public bool IsEmailEnabled { get; set; }
        public bool IsSmsEnabled { get; set; }
        public bool IsTemplateTrancated { get; set; }
        public long LoyaltysettId { get; set; }
        public string? NumberFormat { get; set; }
        public int RoundofDecimals { get; set; }
        public int PointsAwardLimitType { get; set; }
        public int NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public bool IsApprovalOn { get; set; }
        public string? CollisionRule { get; set; }
        public string? SalesRangeStartDay { get; set; }
        public string? DelayedorInstant { get; set; }
        public int AzureCronJobCycleMinutes { get; set; }
        public int ConsecutiveTransTimeMin { get; set; }
        public int MinRedeemPoints { get; set; }
        public string? VoucherUse { get; set; }
        public int DaysToDeactivateNoTransAcc { get; set; }
        public bool ApplyLoyaltySettings { get; set; }
        public string? PeriodApplicable { get; set; }
        public List<StaffPermissions>? Permission { get; set; }
    }
}
