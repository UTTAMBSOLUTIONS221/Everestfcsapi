namespace DBL.Entities
{
    public class SystemFormulaRuleData
    {
        public long FormulaRuleId { get; set; }
        public long FormulaId { get; set; }
        public decimal Range1 { get; set; }
        public decimal Range2 { get; set; }
        public bool IsRangetoInfinity { get; set; }
        public string? Formula { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalLevel { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
