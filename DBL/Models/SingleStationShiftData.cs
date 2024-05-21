namespace DBL.Models
{
    public class SingleStationShiftData
    {
        public bool HasPrevious { get; set; }
        public long ShiftId { get; set; }
        public long StationId { get; set; }
        public string? LocationData { get; set; }
        public string? ShiftCode { get; set; }
        public string? ShiftCategory { get; set; }
        public string? CashOrAccount { get; set; }
        public DateTime ShiftDateTime { get; set; }
        public int ShiftStatus { get; set; }
        public bool IsPosted { get; set; }
        public bool IsDeleted { get; set; }
        public decimal ShiftTotalAmount { get; set; }
        public decimal ShiftBankedAmount { get; set; }
        public decimal ShiftBalance { get; set; }
        public decimal ExpectedTankAmount { get; set; }
        public decimal ExpectedPumpAmount { get; set; }
        public decimal GainLoss { get; set; }
        public decimal PercentGainLoss { get; set; }
        public string? ShiftBankReference { get; set; }
        public string? ShiftReference { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public List<ShiftPumpReading>? ShiftPumpReading { get; set; }
        public List<ShiftTankReading>? ShiftTankReading { get; set; }
        public List<ShiftLubeReading>? ShiftLubeReading { get; set; }
        public List<ShiftLpgReading>? ShiftLpgReading { get; set; }
        public List<ShiftSparePart>? ShiftSparePartsData { get; set; }
        public List<ShiftCarWashsData>? ShiftCarWashsData { get; set; }
        public ShiftWetStockPurchaseData? WetstockPurchases { get; set; }
        public ShiftDryStockPurchaseData? DrystockPurchases { get; set; }
        public List<ShiftCreditInvoice>? ShiftCreditInvoice { get; set; }
        public List<ShiftExpenses>? ShiftExpenses { get; set; }
        public List<ShiftMpesaCollection>? ShiftMpesaCollection { get; set; }
        public List<ShiftFuelCardCollection>? ShiftFuelCardCollection { get; set; }
        public List<ShiftMerchantCollection>? ShiftMerchantCollection { get; set; }
        public List<ShiftTopup>? ShiftTopup { get; set; }
        public List<ShiftPayment>? ShiftPayment { get; set; }
        public List<ShiftPumpSaleSummary>? ShiftPumpSaleSummary { get; set; }
        public List<ShiftTankSaleSummary>? ShiftTankSaleSummary { get; set; }
        public List<FinancialDetailSummary>? FinancialDetails { get; set; }
        public List<AttendantShiftSummary>? AttendantShiftSummary { get; set; }
    }
    public class ShiftPumpReading
    {
        public long ShiftPumpReadingId { get; set; }
        public long ShiftId { get; set; }
        public string? Shiftcode { get; set; }
        public long NozzleId { get; set; }
        public long Nozzlename { get; set; }
        public long PumpId { get; set; }
        public string? Pumpname { get; set; }
        public string? Warehouse { get; set; }
        public long AttendantId { get; set; }
        public long ProductVariationId { get; set; }
        public string? Productvariationname { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal OpeningShilling { get; set; }
        public decimal OpeningElectronic { get; set; }
        public decimal OpeningManual { get; set; }
        public decimal ClosingShilling { get; set; }
        public decimal ClosingElectronic { get; set; }
        public decimal ClosingManual { get; set; }
        public decimal TestingRtt { get; set; }
        public decimal ElectronicSold { get; set; }
        public decimal TotalShilling { get; set; }
        public decimal ElectronicAmount { get; set; }
        public decimal ShillingDifference { get; set; }
        public decimal ManualSold { get; set; }
        public decimal ManualAmount { get; set; }
        public decimal LitersDifference { get; set; }
        public decimal PumpRttAmount { get; set; }
        public decimal TotalPumpAmount { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftTankReading
    {
        public long ShiftTankReadingId { get; set; }
        public long ShiftId { get; set; }
        public long TankId { get; set; }
        public string? TankName { get; set; }
        public long AttendantId { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal QuantitySold { get; set; }
        public decimal AmountSold { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftLubeReading
    {
        public long ShiftLubeLpgId { get; set; }
        public long ShiftId { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public long StockTypeId { get; set; }
        public long AttendantId { get; set; }
        public string? CategoryName { get; set; }
        public decimal OpeningUnits { get; set; }
        public decimal ClosingUnits { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal UnitsTotal { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftLpgReading
    {
        public long ShiftLubeLpgId { get; set; }
        public long ShiftId { get; set; }
        public long ProductVariationId { get; set; }
        public long StockTypeId { get; set; }
        public long AttendantId { get; set; }
        public decimal OpeningUnits { get; set; }
        public decimal ClosingUnits { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal UnitsTotal { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftSparePart
    {
        public long ShiftLubeLpgId { get; set; }
        public long ShiftId { get; set; }
        public long ProductVariationId { get; set; }
        public long StockTypeId { get; set; }
        public long AttendantId { get; set; }
        public decimal OpeningUnits { get; set; }
        public decimal ClosingUnits { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal UnitsTotal { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
    public class ShiftCarWashsData
    {
        public long ShiftLubeLpgId { get; set; }
        public long ShiftId { get; set; }
        public long ProductVariationId { get; set; }
        public long StockTypeId { get; set; }
        public long AttendantId { get; set; }
        public decimal OpeningUnits { get; set; }
        public decimal ClosingUnits { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal UnitsTotal { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
    public class ShiftCreditInvoice
    {
        public long ShiftCreditInvoiceId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public long CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public long EquipmentId { get; set; }
        public string? EquipmentNo { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal ProductUnits { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal VatTotal { get; set; }
        public string? OrderNumber { get; set; }
        public string? RecieptNumber { get; set; }
        public string? Reference { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }


    public class ShiftWetStockPurchaseData
    {
        public int RecordsTotal { get; set; }
        public long PurchaseId { get; set; }
        public long ShiftId { get; set; }
        public string? WetDryPurchase { get; set; }
        public string? InvoiceNumber { get; set; }
        public long SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal TransportAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? TruckNumber { get; set; }
        public string? DriverName { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public List<ShiftWetStockPurchases>? ShiftWetStockPurchases { get; set; }
    }

    public class ShiftWetStockPurchases
    {
        public long PurchaseItemId { get; set; }
        public long PurchaseId { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public long TankId { get; set; }
        public string? TankName { get; set; }
        public decimal DipsBeforeOffloading { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal DipsAfterOffloading { get; set; }
        public decimal ExpectedQuantity { get; set; }
        public decimal Gainloss { get; set; }
        public decimal PercentGainloss { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseTax { get; set; }
        public decimal PurchaseDiscount { get; set; }
        public decimal PurchaseGTotal { get; set; }
        public decimal PurchaseNTotal { get; set; }
        public decimal PurchaseTaxAmount { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
    public class ShiftDryStockPurchaseData
    {
        public long PurchaseId { get; set; }
        public long ShiftId { get; set; }
        public string? WetDryPurchase { get; set; }
        public string? InvoiceNumber { get; set; }
        public long SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal TransportAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? TruckNumber { get; set; }
        public string? DriverName { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public List<ShiftDryStockPurchases>? ShiftDryStockPurchases { get; set; }
    }

    public class ShiftDryStockPurchases
    {
        public long PurchaseItemId { get; set; }
        public long PurchaseId { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public long TankId { get; set; }
        public string? TankName { get; set; }
        public decimal DipsBeforeOffloading { get; set; }
        public decimal PurchaseQuantity { get; set; }
        public decimal DipsAfterOffloading { get; set; }
        public decimal ExpectedQuantity { get; set; }
        public decimal Gainloss { get; set; }
        public decimal PercentGainloss { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseTax { get; set; }
        public decimal PurchaseDiscount { get; set; }
        public decimal PurchaseGTotal { get; set; }
        public decimal PurchaseNTotal { get; set; }
        public decimal PurchaseTaxAmount { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }

    public class ShiftExpenses
    {
        public long ShiftVoucherId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public string? VoucherType { get; set; }
        public string? CreditDebit { get; set; }
        public long VoucherModeId { get; set; }
        public string? VoucherModeName { get; set; }
        public string? VoucherName { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal VoucherAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string? RecieptNumber { get; set; }
        public string? CardNumber { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftMpesaCollection
    {
        public long ShiftVoucherId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public string? VoucherType { get; set; }
        public string? CreditDebit { get; set; }
        public long VoucherModeId { get; set; }
        public string? VoucherModeName { get; set; }
        public string? VoucherName { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal VoucherAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string? RecieptNumber { get; set; }
        public string? CardNumber { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftFuelCardCollection
    {
        public long ShiftVoucherId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public string? VoucherType { get; set; }
        public string? CreditDebit { get; set; }
        public long VoucherModeId { get; set; }
        public string? VoucherModeName { get; set; }
        public string? VoucherName { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal VoucherAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string? RecieptNumber { get; set; }
        public string? CardNumber { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftMerchantCollection
    {
        public long ShiftVoucherId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public string? VoucherType { get; set; }
        public string? CreditDebit { get; set; }
        public long VoucherModeId { get; set; }
        public string? VoucherModeName { get; set; }
        public string? VoucherName { get; set; }
        public long ProductVariationId { get; set; }
        public string? ProductVariationName { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal VoucherAmount { get; set; }
        public decimal VatAmount { get; set; }
        public string? RecieptNumber { get; set; }
        public string? CardNumber { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
    public class ShiftTopup
    {
        public long ShiftTopupId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public decimal TopupAmount { get; set; }
        public string? TopupReference { get; set; }
        public bool IsReversed { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public class ShiftPayment
    {
        public long ShiftPaymentId { get; set; }
        public long ShiftId { get; set; }
        public long AttendantId { get; set; }
        public string? AttendantName { get; set; }
        public long CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public long PaymentModeId { get; set; }
        public string? PaymentMode { get; set; }
        public decimal PaymentAmount { get; set; }
        public string? PaymentReference { get; set; }
        public bool IsReversed { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
    public class ShiftPumpSaleSummary
    {
        public long ShiftId { get; set; }
        public string? AttendantName { get; set; }
        public string? Product { get; set; }
        public string? TankName { get; set; }
        public string? PumpName { get; set; }
        public decimal PumpLitres { get; set; }
        public decimal TotalShillings { get; set; }
        public decimal ElectronicAmount { get; set; }
        public decimal ManualAmount { get; set; }
    }
    public class ShiftTankSaleSummary
    {
        public long ShiftId { get; set; }
        public string? AttendantName { get; set; }
        public string? Product { get; set; }
        public string? TankName { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal QuantitySold { get; set; }
        public decimal AmountSold { get; set; }
    }
    public class FinancialDetailSummary
    {
        public string? AttendantName { get; set; }
        public string? Categoryname { get; set; }
        public string? Descriptions { get; set; }
        public decimal Amount { get; set; }
    }
    public class AttendantShiftSummary
    {
        public string? Attendantname { get; set; }
        public decimal Amount { get; set; }
    }
}
