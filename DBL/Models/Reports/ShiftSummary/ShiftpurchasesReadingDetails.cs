namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftpurchasesReadingDetails
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<PurchaseData>? Purchases { get; set; }
    }

    public class PurchaseData
    {
        public string? ShiftCode { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public string? WetDryPurchase { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? SupplierName { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal TransportAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? TruckNumber { get; set; }
        public string? DriverName { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public List<PurchaseItemData>? PurchaseItems { get; set; }
    }

    public class PurchaseItemData
    {
        public string? ProductVariationname { get; set; }
        public string? TankName { get; set; }
        public decimal DipsBeforeOffloading { get; set; }
        public decimal DipsAfterOffloading { get; set; }
        public decimal ExpectedQuantity { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal Gainloss { get; set; }
        public decimal PercentGainloss { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseTax { get; set; }
        public decimal PurchaseDiscount { get; set; }
        public decimal PurchaseGTotal { get; set; }
        public decimal PurchaseNTotal { get; set; }
        public decimal PurchaseTaxAmount { get; set; }
        public string? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
