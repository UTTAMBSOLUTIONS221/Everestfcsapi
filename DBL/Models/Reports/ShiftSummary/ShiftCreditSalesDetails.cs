namespace DBL.Models.Reports.ShiftSummary
{
    public class ShiftCreditSalesDetails
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StationName { get; set; }
        public string? AttendantName { get; set; }
        public string? ShiftCode { get; set; }
        public List<ShiftCreditsaleData>? ShiftCreditsales { get; set; }

    }

    public class ShiftCreditsaleData
    {
        public string? ShiftCode { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public string? AttendantName { get; set; }
        public long CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public long EquipmentId { get; set; }
        public string? EquipmentNo { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal ProductUnits { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal VatTotal { get; set; }
        public string? RecieptNumber { get; set; }
        public string? OrderNumber { get; set; }
        public string? Reference { get; set; }
        public long Createdby { get; set; }
        public string? CreatedByName { get; set; }
        public long Modifiedby { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
