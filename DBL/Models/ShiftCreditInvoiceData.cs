namespace DBL.Models
{
    public class ShiftCreditInvoiceData
    {
        public int RecordsTotal { get; set; }
        public IEnumerable<ShiftCreditInvoice>? DataTableData { get; set; }
    }
}
