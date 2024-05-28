namespace DBL.Entities
{
    public class ActivateDeactivateActions
    {
        public long TenantId { get; set; }
        public string? Tablename { get; set; }
        public string? Columname { get; set; }
        public int Status { get; set; }
        public string? Columnidname { get; set; }
        public long Entryid { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
