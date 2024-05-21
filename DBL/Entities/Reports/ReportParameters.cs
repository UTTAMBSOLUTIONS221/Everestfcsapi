namespace DBL.Entities.Reports
{
    public class ReportParameters
    {
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public long TenantId { get; set; }
        public long Customer { get; set; }
        public long Agreement { get; set; }
        public long Group { get; set; }
        public long Station { get; set; }
        public long Shift { get; set; }
        public long Paymode { get; set; }
        public long Account { get; set; }
        public long Attendant { get; set; }
        public long Product { get; set; }
    }
}
