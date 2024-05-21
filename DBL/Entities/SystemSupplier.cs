namespace DBL.Entities
{
    public class SystemSupplier
    {
        public long SupplierId { get; set; }
        public long TenantId { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierEmail { get; set; }
        public long PhoneId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public List<SystemSuplierPrice>? SystemSuplierPrice { get; set; }
    }
    public class SystemSuplierPrice
    {
        public long SupplierPriceId { get; set; }
        public long SupplierId { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public string? Categoryname { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductVat { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
