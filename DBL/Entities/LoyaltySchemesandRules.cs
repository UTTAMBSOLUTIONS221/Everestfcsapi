namespace DBL.Entities
{
    public class LoyaltySchemesandRules
    {
        public long LSchemeId { get; set; }
        public long TenantId { get; set; }
        public string? LSchemeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public List<SchemeRule>? Schemerules { get; set; }
    }
    public class SchemeRule
    {
        public long LSchemeRuleId { get; set; }
        public long SchemeId { get; set; }
        public long FormulaId { get; set; }
        public long LRewardId { get; set; }
        public List<string>? DaysApplicable { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public List<long>? ProductId { get; set; }
        public List<long>? StationId { get; set; }
        public List<long>? LoyaltygroupId { get; set; }
        public List<long>? PaymentmodeId { get; set; }
        public string? CalculateProdOrPaymode { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalLevel { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
