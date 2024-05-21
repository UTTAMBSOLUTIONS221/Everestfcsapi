namespace DBL.Models
{
    public class LoyaltyFormulaandFormulaRules
    {
        public List<Formula>? Formula { get; set; }
    }
    public class Formula
    {
        public long FormulaId { get; set; }
        public string? FormulaName { get; set; }
        public string? ValueType { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public List<FormulaRules>? SystemFormulaRules { get; set; }
    }
    public class FormulaRules
    {
        public long FormulaRuleId { get; set; }
        public long FormulaId { get; set; }
        public double Range1 { get; set; }
        public double Range2 { get; set; }
        public bool IsRangetoInfinity { get; set; }
        public string? Formula { get; set; }
        public bool IsApproved { get; set; }
        public string? ApprovalLevel { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
