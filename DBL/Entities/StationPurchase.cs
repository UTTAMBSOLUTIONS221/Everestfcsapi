namespace DBL.Entities
{
    public class StationPurchase
    {
        public long PurchaseId { get; set; }
        public long StationId { get; set; }
        public string? InvoiceNumber { get; set; }
        public long SupplierId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string? TruckNumber { get; set; }
        public string? DriverName { get; set; }
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
        public List<StationPurchaseItem>? StationPurchaseItem { get; set; }
    }

    public class StationPurchaseItem
    {
        public long PurchaseItemId { get; set; }
        public long PurchaseId { get; set; }
        public long ProductVariationId { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseDiscount { get; set; }
        public decimal PurchaseTotal { get; set; }
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
    }

}
