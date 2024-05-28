namespace DBL.Models
{
    public class LoyaltySettingsModelData
    {
        public long LoyaltysettId { get; set; }
        public long Tenantid { get; set; }
        public string? Tenantname { get; set; }
        public string? Fromreward { get; set; }
        public string? Toreward { get; set; }
        public string? NumberFormat { get; set; }
        public long RoundofDecimals { get; set; }
        public string? CeilorFloor { get; set; }
        public string? PointsAwardLimitType { get; set; }
        public int NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public bool IsApprovalOn { get; set; }
        public string? CollisionRule { get; set; }
        public long SalesRangeStartDay { get; set; }
        public string? DelayedorInstant { get; set; }
        public int AzureCronJobCycleMinutes { get; set; }
        public int ConsecutiveTransTimeMin { get; set; }
        public decimal MinRedeemPoints { get; set; }
        public string? VoucherUse { get; set; }
        public long DaysToDeactivateNoTransAcc { get; set; }
        public bool ApplyLoyaltySettings { get; set; }
        public string? PeriodApplicable { get; set; }
        public long FromRewardId { get; set; }
        public long ToRewardId { get; set; }
        public decimal ConversionValue { get; set; }
        public bool AutoRedeem { get; set; }
        public string? RedeemPeriod { get; set; }
        public int RedeemDay { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
