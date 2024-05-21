namespace DBL.Entities
{
    public class CustomerPrepaidAgreement
    {
        public long AgreementId { get; set; }
        public long CustomerId { get; set; }
        public long GroupingId { get; set; }
        public long AgreementTypeId { get; set; }
        public long PriceListId { get; set; }
        public long DiscountListId { get; set; }
        public string? Descriptions { get; set; }
        public string? AgreementDoc { get; set; }
        public string? Notes { get; set; }
        public bool HasGroup { get; set; }
        public bool HasOverdraft { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedbyId { get; set; }
        public string? Createdby { get; set; }
        public long ModifiedId { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
