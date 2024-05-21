namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftCashDropsDetails
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<ShiftCashDropData>? ShiftCashDrop { get; set; }
    }
    public class ShiftCashDropData
    {
        public long ShiftVoucherId { get; set; }
        public long ShiftId { get; set; }
        public string? ShiftCode { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public string? VoucherType { get; set; }
        public string? CreditDebit { get; set; }
        public long VoucherModeId { get; set; }
        public string? VoucherMode { get; set; }
        public string? VoucherName { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductVariationName { get; set; }
        public long ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal VoucherAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string? RecieptNumber { get; set; }
        public string? CardNumber { get; set; }
        public string? CreatedByName { get; set; }
        public long ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
