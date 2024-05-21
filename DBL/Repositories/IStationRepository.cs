using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface IStationRepository
    {
        IEnumerable<SystemStationData> GetSystemstationsData(long Tenantid,long StationId, int Offset, int Count);
        Genericmodel RegisterSystemStation(string JsonObjectdata);
        Genericmodel Automatesystemstationdata(string JsonObjectdata);
        Genericmodel Registersystemstationdata(string JsonObjectdata);
        SystemStations GetSystemStationDetailDataById(long StationId);
        Systemstationdetailmodel GetSystemStationallDetailDataById(long StationId);
        StationTankModel GetSystemStationTankDetailDataById(long TankId);
        Genericmodel RegisterSystemStationTank(string JsonObjectdata);
        Stationpumps GetSystemStationpumpDetailDataById(long PumpId);
        Genericmodel RegisterSystemStationPump(string JsonObjectdata);
        IEnumerable<AutomatedStationData> Getautomatedsystemstationsdata();


        Genericmodel Registersystemstationtankdipsdata(string JsonObjectdata);
        StationDailyDip GetsystemstationtankdetailbyId(long TankId);


        Genericmodel Registersystemstationpurchasesdata(string JsonObjectdata);
        StationPurchase Getsystemstationpurchasesdetailbyid(long PurchaseId);

        SingleStationShiftData Getsystemstationsingleshiftdata(long StationId, long ShiftId);
        Genericmodel Registersystemstationshiftdata(string JsonObjectdata);
        Genericmodel Registersystemstationshiftpumpdata(string JsonObjectdata);
        Genericmodel Registersystemstationshifttankdata(string JsonObjectdata);
        Genericmodel Registersystemstationshiftlubedata(string JsonObjectdata);
        Genericmodel Registersystemstationshiftlpgdata(string JsonObjectdata);
        Genericmodel Registersystemstationshiftsparepartdata(string JsonObjectdata);
        Genericmodel Registersystemstationshiftcarwashdata(string JsonObjectdata);

        #region Shift Credit Invoice
        ShiftCreditInvoiceData Getsystemstationshiftcreditinvoicedata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftcreditinvoicedata(string JsonObjectdata);
        #endregion

        #region Shift Wetstock Purchase
        ShiftWetStockPurchaseData Getsystemstationshiftwetstockpurchasedata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftwetstockpurchasedata(string JsonObjectdata);
        #endregion

        #region Shift Drystock Purchase
        ShiftDryStockPurchaseData Getsystemstationshiftdrystockpurchasedata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftdrystockpurchasedata(string JsonObjectdata);
        #endregion

        #region Shift Expenses
        ShiftExpenseData Getsystemstationshiftexpensedata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftexpensedata(string JsonObjectdata);
        #endregion
        #region Shift Mpesa Collections
        ShiftMpesaCollectionData Getsystemstationshiftmpesadata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftmpesadata(string JsonObjectdata);
        #endregion

        #region Shift Fuel Card Collection
        ShiftFuelCardCollectionData Getsystemstationshiftfuelcarddata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftfuelcarddata(string JsonObjectdata);
        #endregion

        #region Shift Merchant Collection
        ShiftMerchantCollectionData Getsystemstationshiftmerchantdata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftmerchantdata(string JsonObjectdata);
        #endregion

        #region Shift Topup
        ShiftTopupData Getsystemstationshifttopupdata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshifttopupdata(string JsonObjectdata);
        #endregion

        #region Shift Payments
        ShiftPaymentData Getsystemstationshiftpaymentdata(long ShiftId, int start, int length, string? searchParam);
        Genericmodel Registersystemstationshiftpaymentdata(string JsonObjectdata);
        #endregion
        Genericmodel Closesystemstationshiftdata(string JsonObjectdata);
        Genericmodel Supervisorclosesystemstationshiftdata(string JsonObjectdata);
        decimal Getsystemstationtankshiftpurchasedata(long ShiftId, long TankId);
        decimal Getsystemstationdryproductshiftpurchasedata(long ShiftId, long ProductId);
        decimal Getsystemstationproductpricedata(long StationId, long ProductId);
        ShiftDetailDataModel Getsystemstationshiftdetaildata(long ShiftId);
        IEnumerable<SystemStationShift> Getsystemstationshiftlistdata(long StationId);
        StationShiftDetailData Getsystemstationshiftdetaildata();
        Genericmodel Registersystemstationshiftvoucherdata(string JsonObjectdata);
        ShiftVoucher Getsystemstationvoucherbyid(long ShiftVoucherId);
        ProductPriceData GetsystemdryproductpricebyId(long ProductVariationId, long StationId, long CustomerId);
        ProductVatPriceData GetsystemproductpricevatbyId(long SupplierId, long ProductId);
        Genericmodel Registersystemstationlubedata(string JsonObjectdata);
        ShiftLubesandLpg Getsystemstationlubeandlpgbyid(long ShiftLubeLpgId);
        Genericmodel Registersystemstationcreditinvoicedata(string JsonObjectdata);
        //ShiftCreditInvoice Getsystemcreditinvoicesalebyid(long ShiftCreditInvoiceId);

    }
}
