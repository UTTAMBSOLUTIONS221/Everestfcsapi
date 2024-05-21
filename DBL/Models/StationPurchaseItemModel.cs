namespace DBL.Models
{
    public class StationPurchaseItemModel
    {
        public DateTime InvoiceDate { get; set; }
        public string? StationName { get; set; }
        public string? InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string? TruckNumber { get; set; }
        public string? DriverName { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseDiscount { get; set; }
        public decimal PurchaseTotal { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
