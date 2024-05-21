namespace DBL.Entities
{
    public class PriceListPriceDataModel
    {
        public long PriceListPricesId { get; set; }
        public long PriceListId { get; set; }
        public long StationId { get; set; }
        public List<long>? StationdataId { get; set; }
        public long ProductvariationId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductVat { get; set; }
    }
}
