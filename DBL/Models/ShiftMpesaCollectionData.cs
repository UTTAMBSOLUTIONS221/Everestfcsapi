namespace DBL.Models
{
    public class ShiftMpesaCollectionData
    {
        public int RecordsTotal { get; set; }
        public IEnumerable<ShiftMpesaCollection>? DataTableData { get; set; }
    }
}
