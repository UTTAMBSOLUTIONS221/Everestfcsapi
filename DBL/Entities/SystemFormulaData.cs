namespace DBL.Entities
{
    public class SystemFormulaData
    {
        public long FormulaId { get; set; }
        public string? FormulaName { get; set; }
        public string? ValueType { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
