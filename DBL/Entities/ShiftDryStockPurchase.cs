namespace DBL.Entities
{
    public class ShiftDryStockPurchase
    {
        public long PurchaseId { get; set; }
        public long ShiftId { get; set; }
        public string? WetDryPurchase { get; set; }
        public string? InvoiceNumber { get; set; }
        public long SupplierId { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal TransportAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? TruckNumber { get; set; }
        public string? DriverName { get; set; }
        public long PurchaseItemId { get; set; }
        public long ProductVariationId { get; set; }
        public long TankId { get; set; }
        public decimal DipsBeforeOffloading { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal DipsAfterOffloading { get; set; }
        public decimal ExpectedQuantity { get; set; }
        public decimal Gainloss { get; set; }
        public decimal PercentGainloss { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseTax { get; set; }
        public decimal PurchaseDiscount { get; set; }
        public decimal PurchaseGTotal { get; set; }
        public decimal PurchaseNTotal { get; set; }
        public decimal PurchaseTaxAmount { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
