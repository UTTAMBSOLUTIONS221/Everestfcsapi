namespace DBL.Entities
{
    public class SystemProductVariation
    {
        public long ProductvariationId { get; set; }
        public string? Productvariationname { get; set; }
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public long UomId { get; set; }
        public long TaxId { get; set; }
        public string? Barcode { get; set; }
        public string? TaxclassificationCode { get; set; }
        public decimal Levyamount { get; set; }
        public string? Levyreference { get; set; }
        public string? Referencenumber { get; set; }
        public string? Imageurl { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

}
