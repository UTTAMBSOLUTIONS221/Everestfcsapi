namespace DBL.Models
{
    public class ShiftPaymentData
    {
        public int RecordsTotal { get; set; }
        public IEnumerable<ShiftPayment>? DataTableData { get; set; }
    }
}
