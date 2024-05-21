namespace DBL.Models
{
    public class ShiftDetailDataModel
    {
        public int ShiftDataId { get; set; }
        public int ShiftId { get; set; }
        public int NozzleId { get; set; }
        public int AttendantId { get; set; }
        public int PumpId { get; set; }
        public int ProductvariationId { get; set; }
        public double OpeningRead { get; set; }
        public double ClosingRead { get; set; }
        public double SaleQuantity { get; set; }
        public double ProductPrice { get; set; }
        public double TestingQuantity { get; set; }
        public double GeneratorQuantity { get; set; }
        public double GainOrLoss { get; set; }
        public double TaxRate { get; set; }
        public double TaxAmount { get; set; }
        public double TotalAmount { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public int Createdby { get; set; }
        public int Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public List<ShiftLubeandLpgModel>? ShiftLubeandLpg { get; set; }
        public List<ShiftVoucherModel>? ShiftVouchers { get; set; }
        public List<ShiftCreditInvoiceModel>? ShiftCreditInvoices { get; set; }
    }
    public class ShiftLubeandLpgModel
    {
        public int ShiftLubeLpgId { get; set; }
        public int ShiftId { get; set; }
        public int AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public int ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public string? CategoryName { get; set; }
        public double ProductUnits { get; set; }
        public double ProductPrice { get; set; }
        public double ProductTotal { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public int Createdby { get; set; }
        public string? CreatedbyName { get; set; }
        public int Modifiedby { get; set; }
        public string? ModifiedbyName { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }

    public class ShiftVoucherModel
    {
        public int ShiftVoucherId { get; set; }
        public int ShiftId { get; set; }
        public int AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public string? VoucherType { get; set; }
        public int VoucherModeId { get; set; }
        public string? PaymentMode { get; set; }
        public string? VoucherName { get; set; }
        public double CreditAmount { get; set; }
        public double DebitAmount { get; set; }
        public string? CreditDebit { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public int Createdby { get; set; }
        public string? CreatedbyName { get; set; }
        public int Modifiedby { get; set; }
        public string? ModifiedbyName { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }

    public class ShiftCreditInvoiceModel
    {
        public int ShiftCreditInvoiceId { get; set; }
        public int ShiftId { get; set; }
        public int AttendantId { get; set; }
        public string?  AttendantName { get; set; }
        public int CustomerId { get; set; }
        public string? Customername { get; set; }
        public int EquipmentId { get; set; }
        public string? EquipmentRegNo { get; set; }
        public int ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public double ProductUnits { get; set; }
        public double ProductPrice { get; set; }
        public double ProductDiscount { get; set; }
        public double ProductTotal { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public string? Extra10 { get; set; }
        public int Createdby { get; set; }
        public string? CreatedbyName { get; set; }
        public int Modifiedby { get; set; }
        public string? ModifiedbyName { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
