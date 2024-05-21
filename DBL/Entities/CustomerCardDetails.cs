namespace DBL.Entities
{
    public class CustomerCardDetails
    {
        public string? cardNo { get; set; }
        public long stationId { get; set; }
        public List<long>? productVariationIds { get; set; }
    }
}
