namespace DBL.Entities
{
    public class LoyaltyFormulaandRules
    {
        public long FormulaId { get; set; }
        public long TenantId { get; set; }
        public string? FormulaName { get; set; }
        public string? ValueType { get; set; }
        public List<FormulaRule>? Formularules { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }

    public class FormulaRule
    {
        public long FormulaId { get; set; }
        public long FormulaRuleId { get; set; }
        public decimal Range1 { get; set; }
        public decimal Range2 { get; set; }
        public bool IsRangetoInfinity { get; set; }
        public string? Formula { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }

    }
}
