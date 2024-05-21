namespace DBL.Entities
{
    public class SystemLoyaltySetings
    {
        public long LoyaltysettId { get; set; }
        public long TenantId { get; set; }
        public string? NumberFormat { get; set; }
        public int RoundofDecimals { get; set; }
        public string? CeilorFloor { get; set; }
        public string? PointsAwardLimitType { get; set; }
        public int NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public bool IsApprovalOn { get; set; }
        public string? CollisionRule { get; set; }
        public int SalesRangeStartDay { get; set; }
        public string? DelayedorInstant { get; set; }
        public int AzureCronJobCycleMinutes { get; set; }
        public int ConsecutiveTransTimeMin { get; set; }
        public int MinRedeemPoints { get; set; }
        public string? VoucherUse { get; set; }
        public int DaysToDeactivateNoTransAcc { get; set; }
        public bool ApplyLoyaltySettings { get; set; }
        public string? PeriodApplicable { get; set; }
        public long FromRewardId { get; set; }
        public long ToRewardId { get; set; }
        public double ConversionValue { get; set; }
        public bool AutoRedeem { get; set; }
        public string? RedeemPeriod { get; set; }
        public int RedeemDay { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
