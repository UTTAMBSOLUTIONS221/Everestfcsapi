namespace DBL.Entities
{
    public class DryStockMovement
    {
        public long DryStockMoveId { get; set; }
        public long TenantId { get; set; }
        public long DryStockStoreId { get; set; }
        public long ProductVariationId { get; set; }
        public decimal Quantity { get; set; }
        public string? Movement { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
