namespace DBL.Models
{
    public class ShiftMerchantCollectionData
    {
        public int RecordsTotal { get; set; }
        public IEnumerable<ShiftMerchantCollection>? DataTableData { get; set; }
    }
}
