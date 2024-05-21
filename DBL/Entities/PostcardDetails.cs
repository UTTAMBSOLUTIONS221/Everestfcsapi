namespace DBL.Entities
{
    public class PostcardDetails
    {
        public string? CardNo { get; set; }
        public long StationId { get; set; }
        public long TenantId { get; set; }
        public long PaymantModeId { get; set; }
        public string? PaymantModeName { get; set; }
        public List<long>? ProductVariationIds { get; set; }
    }
}
