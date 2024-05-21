namespace DBL.Entities
{
    public class SystemSchemeRuleResultData
    {
        public long LSchemeRuleId { get; set; }
        public long LSchemeId { get; set; }
        public long FormulaId { get; set; }
        public long LRewardId { get; set; }
        public string? CalculateProdOrPaymode { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalLevel { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? DaysOfWeek { get; set; }
        public List<string>? DayOfWeek { get; set; }
        public string? Stations { get; set; }
        public List<long>? Station { get; set; }
        public string? Loyaltygroups { get; set; }
        public List<long>? Loyaltygroup { get; set; }
        public string? Paymentmodes { get; set; }
        public List<long>? Paymentmode { get; set; }
        public string? Products { get; set; }
        public List<long>? Product { get; set; }
    }
}
