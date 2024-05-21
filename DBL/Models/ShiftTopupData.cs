namespace DBL.Models
{
    public class ShiftTopupData
    {
        public int RecordsTotal { get; set; }
        public IEnumerable<ShiftTopup>? DataTableData { get; set; }
    }
}
