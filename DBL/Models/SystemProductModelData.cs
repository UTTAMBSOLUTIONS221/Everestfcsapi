namespace DBL.Models
{
    public class SystemProductModelData
    {
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public string? CategoryName { get; set; }
        public string? UomName { get; set; }
        public string? Barcode { get; set; }
        public string? TaxClassificationCode { get; set; }
        public decimal LevyAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public string? LevyReference { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
