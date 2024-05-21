namespace DBL.Models
{
    public class LoyaltySchemeandSchemeRules
    {
        public List<LoyaltyScheme>? LoyaltyScheme { get; set; }
    }
    public class LoyaltyScheme
    {
        public long LSchemeId { get; set; }
        public string? LSchemeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public List<SystemSchemeRule>? SystemSchemeRules { get; set; }
    }
    public class SystemSchemeRule
    {
        public long LSchemeRuleId { get; set; }
        public long LSchemeId { get; set; }
        public long FormulaId { get; set; }
        public string? FormulaName { get; set; }
        public long LRewardId { get; set; }
        public string? RewardName { get; set; }
        public string? CalculateProdOrPaymode { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalLevel { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string? DaysofWeek { get; set; }
        public string? Station { get; set; }
        public string? LoyaltyGrouping { get; set; }
        public string? Paymentmode { get; set; }
        public string? Product { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
    }
}
