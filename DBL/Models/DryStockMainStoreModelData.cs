namespace DBL.Models
{
    public class DryStockMainStoreModelData
    {
        public long DryStockStoreId { get; set; }
        public long PurchaseId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public decimal Quantity { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
