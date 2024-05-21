using DBL;
using DBL.Entities;
using DBL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StationManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public StationManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }
        #region Station Management
        [HttpGet("GetSystemstationsData/{TenantId}/{StationId}/{Offset}/{Count}")]
        public async Task<IEnumerable<SystemStationData>> GetSystemstationsData(long TenantId, long StationId, int Offset, int Count)
        {
            return await bl.GetSystemstationsData(TenantId, StationId, Offset, Count);
        }
        [HttpPost("RegisterSystemStation")]
        public async Task<Genericmodel> RegisterSystemStation(SystemStations obj)
        {
            return await bl.RegisterSystemStation(JsonSerializer.Serialize(obj));
        }
        [HttpPost("Automatesystemstationdata")]
        public async Task<Genericmodel> Automatesystemstationdata(AutomatedStationData obj)
        {
            return await bl.Automatesystemstationdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemStationDetailDataById/{StationId}")]
        public async Task<SystemStations> GetSystemStationDetailDataById(long StationId)
        {
            return await bl.GetSystemStationDetailDataById(StationId);
        }

        #endregion

        #region Station Tank Dips
        [HttpPost("Registersystemstationtankdipsdata")]
        public async Task<Genericmodel> Registersystemstationtankdipsdata(StationDailyDip obj)
        {
            return await bl.Registersystemstationtankdipsdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetsystemstationtankdetailbyId/{TankId}")]
        public async Task<StationDailyDip> GetsystemstationtankdetailbyId(long TankId)
        {
            return await bl.GetsystemstationtankdetailbyId(TankId);
        }
        #endregion

        #region Station Purchases Data
        [HttpPost("Registersystemstationpurchasesdata")]
        public async Task<Genericmodel> Registersystemstationpurchasesdata(StationPurchase obj)
        {
            return await bl.Registersystemstationpurchasesdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("Getsystemstationpurchasesdetailbyid/{PurchaseId}")]
        public async Task<StationPurchase> Getsystemstationpurchasesdetailbyid(long PurchaseId)
        {
            return await bl.Getsystemstationpurchasesdetailbyid(PurchaseId);
        }

        #endregion

        #region System Shifts Management
        [HttpGet("Getsystemstationsingleshiftdata/{StationId}/{ShiftId}")]
        public async Task<SingleStationShiftData> Getsystemstationsingleshiftdata(long StationId, long ShiftId)
        {
            return await bl.Getsystemstationsingleshiftdata(StationId, ShiftId);
        }
        [HttpPost("Registersystemstationshiftdata")]
        public async Task<Genericmodel> Registersystemstationshiftdata(SingleStationShiftData obj)
        {
            return await bl.Registersystemstationshiftdata(JsonSerializer.Serialize(obj));
        }
        [HttpPost("Registersystemstationshiftpumpdata")]
        public async Task<Genericmodel> Registersystemstationshiftpumpdata(SingleStationShiftData obj)
        {
            return await bl.Registersystemstationshiftpumpdata(JsonSerializer.Serialize(obj));
        }

        [HttpPost("Registersystemstationshifttankdata")]
        public async Task<Genericmodel> Registersystemstationshifttankdata(SingleStationShiftData obj)
        {
            return await bl.Registersystemstationshifttankdata(JsonSerializer.Serialize(obj));
        }

        [HttpPost("Registersystemstationshiftlubedata")]
        public async Task<Genericmodel> Registersystemstationshiftlubedata(SingleStationShiftData obj)
        {
            return await bl.Registersystemstationshiftlubedata(JsonSerializer.Serialize(obj));
        }

        [HttpPost("Registersystemstationshiftlpgdata")]
        public async Task<Genericmodel> Registersystemstationshiftlpgdata(SingleStationShiftData obj)
        {
            return await bl.Registersystemstationshiftlpgdata(JsonSerializer.Serialize(obj));
        }

        [HttpPost("Registersystemstationshiftsparepartdata")]
        public async Task<Genericmodel> Registersystemstationshiftsparepartdata(SingleStationShiftData obj)
        {
            return await bl.Registersystemstationshiftsparepartdata(JsonSerializer.Serialize(obj));
        }

        [HttpPost("Registersystemstationshiftcarwashdata")]
        public async Task<Genericmodel> Registersystemstationshiftcarwashdata(SingleStationShiftData obj)
        {
            return await bl.Registersystemstationshiftcarwashdata(JsonSerializer.Serialize(obj));
        }
        #region Shift Credit Invoice
        [HttpGet("Getsystemstationshiftcreditinvoicedata")]
        public async Task<ShiftCreditInvoiceData> Getsystemstationshiftcreditinvoicedata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftcreditinvoicedata(ShiftId, start, length, searchParam);
        }

        [HttpPost("Registersystemstationshiftcreditinvoicedata")]
        public async Task<Genericmodel> Registersystemstationshiftcreditinvoicedata(ShiftCreditInvoice obj)
        {
            return await bl.Registersystemstationshiftcreditinvoicedata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Shift wetstock purchase
        [HttpGet("Getsystemstationshiftwetstockpurchasedata")]
        public async Task<ShiftWetStockPurchaseData> Getsystemstationshiftwetstockpurchasedata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftwetstockpurchasedata(ShiftId, start, length, searchParam);
        }
        [HttpPost("Registersystemstationshiftwetstockpurchasedata")]
        public async Task<Genericmodel> Registersystemstationshiftwetstockpurchasedata(ShiftWetStockPurchase obj)
        {
            return await bl.Registersystemstationshiftwetstockpurchasedata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Shift drystock purchase
        [HttpGet("Getsystemstationshiftdrystockpurchasedata")]
        public async Task<ShiftDryStockPurchaseData> Getsystemstationshiftdrystockpurchasedata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftdrystockpurchasedata(ShiftId, start, length, searchParam);
        }
        [HttpPost("Registersystemstationshiftdrystockpurchasedata")]
        public async Task<Genericmodel> Registersystemstationshiftdrystockpurchasedata(ShiftDryStockPurchase obj)
        {
            return await bl.Registersystemstationshiftdrystockpurchasedata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Station Shift Expenses
        [HttpGet("Getsystemstationshiftexpensedata")]
        public async Task<ShiftExpenseData> Getsystemstationshiftexpensedata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftexpensedata(ShiftId, start, length, searchParam);
        }
        [HttpPost("Registersystemstationshiftexpensedata")]
        public async Task<Genericmodel> Registersystemstationshiftexpensedata(ShiftExpenses obj)
        {
            return await bl.Registersystemstationshiftexpensedata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Shift Mpesa Collection
        [HttpGet("Getsystemstationshiftmpesadata")]
        public async Task<ShiftMpesaCollectionData> Getsystemstationshiftmpesadata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftmpesadata(ShiftId, start, length, searchParam);
        }
        [HttpPost("Registersystemstationshiftmpesadata")]
        public async Task<Genericmodel> Registersystemstationshiftmpesadata(ShiftMpesaCollection obj)
        {
            return await bl.Registersystemstationshiftmpesadata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Fuel Card Collections
        [HttpGet("Getsystemstationshiftfuelcarddata")]
        public async Task<ShiftFuelCardCollectionData> Getsystemstationshiftfuelcarddata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftfuelcarddata(ShiftId, start, length, searchParam);
        }
        [HttpPost("Registersystemstationshiftfuelcarddata")]
        public async Task<Genericmodel> Registersystemstationshiftfuelcarddata(ShiftFuelCardCollection obj)
        {
            return await bl.Registersystemstationshiftfuelcarddata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Shift Merchant Collection
        [HttpGet("Getsystemstationshiftmerchantdata")]
        public async Task<ShiftMerchantCollectionData> Getsystemstationshiftmerchantdata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftmerchantdata(ShiftId, start, length, searchParam);
        }
        [HttpPost("Registersystemstationshiftmerchantdata")]
        public async Task<Genericmodel> Registersystemstationshiftmerchantdata(ShiftMerchantCollection obj)
        {
            return await bl.Registersystemstationshiftmerchantdata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Shift Topup
        [HttpGet("Getsystemstationshifttopupdata")]
        public async Task<ShiftTopupData> Getsystemstationshifttopupdata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshifttopupdata(ShiftId, start, length, searchParam);
        }
        [HttpPost("Registersystemstationshifttopupdata")]
        public async Task<Genericmodel> Registersystemstationshifttopupdata(ShiftTopup obj)
        {
            return await bl.Registersystemstationshifttopupdata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Shift Payment 
        [HttpGet("Getsystemstationshiftpaymentdata")]
        public async Task<ShiftPaymentData> Getsystemstationshiftpaymentdata(long ShiftId, int start, int length, string? searchParam)
        {
            return await bl.Getsystemstationshiftpaymentdata(ShiftId, start, length, searchParam);
        }

        [HttpPost("Registersystemstationshiftpaymentdata")]
        public async Task<Genericmodel> Registersystemstationshiftpaymentdata(ShiftPayment obj)
        {
            return await bl.Registersystemstationshiftpaymentdata(JsonSerializer.Serialize(obj));
        }

        #endregion

        [HttpPost("Closesystemstationshiftdata")]
        public async Task<Genericmodel> Closesystemstationshiftdata(SingleStationShiftData obj)
        {
            return await bl.Closesystemstationshiftdata(JsonSerializer.Serialize(obj));
        }

        [HttpPost("Supervisorclosesystemstationshiftdata")]
        public async Task<Genericmodel> Supervisorclosesystemstationshiftdata(SingleStationShiftData obj)
        {
            return await bl.Supervisorclosesystemstationshiftdata(JsonSerializer.Serialize(obj));
        }

        [HttpGet("Getsystemstationtankshiftpurchasedata/{ShiftId}/{TankId}")]
        public async Task<decimal> Getsystemstationtankshiftpurchasedata(long ShiftId, long TankId)
        {
            return await bl.Getsystemstationtankshiftpurchasedata(ShiftId, TankId);
        }
        [HttpGet("Getsystemstationdryproductshiftpurchasedata/{ShiftId}/{ProductId}")]
        public async Task<decimal> Getsystemstationdryproductshiftpurchasedata(long ShiftId, long ProductId)
        {
            return await bl.Getsystemstationdryproductshiftpurchasedata(ShiftId, ProductId);
        }
        [HttpGet("Getsystemstationproductpricedata/{StationId}/{ProductId}")]
        public async Task<decimal> Getsystemstationproductpricedata(long StationId, long ProductId)
        {
            return await bl.Getsystemstationproductpricedata(StationId, ProductId);
        }
        [HttpGet("Getsystemstationshiftlistdata/{StationId}")]
        public async Task<IEnumerable<SystemStationShift>> Getsystemstationshiftlistdata(long StationId)
        {
            return await bl.Getsystemstationshiftlistdata(StationId);
        }
        [HttpGet("Getsystemstationshiftdetaildata")]
        public async Task<StationShiftDetailData> Getsystemstationshiftdetaildata()
        {
            return await bl.Getsystemstationshiftdetaildata();
        }
        [HttpGet("Getsystemstationshiftdetaildata/{ShiftId}")]
        public async Task<ShiftDetailDataModel> Getsystemstationshiftdetaildata(long ShiftId)
        {
            return await bl.Getsystemstationshiftdetaildata(ShiftId);
        }

        [HttpPost("Registersystemstationshiftvoucherdata")]
        public async Task<Genericmodel> Registersystemstationshiftvoucherdata(ShiftVoucher obj)
        {
            return await bl.Registersystemstationshiftvoucherdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("Getsystemstationvoucherbyid/{ShiftVoucherId}")]
        public async Task<ShiftVoucher> Getsystemstationvoucherbyid(long ShiftVoucherId)
        {
            return await bl.Getsystemstationvoucherbyid(ShiftVoucherId);
        }
        [HttpGet("GetsystemdryproductpricebyId/{ProductVariationId}/{StationId}/{CustomerId}")]
        public async Task<ProductPriceData> GetsystemdryproductpricebyId(long ProductVariationId,long StationId,long CustomerId)
        {
            return await bl.GetsystemdryproductpricebyId(ProductVariationId, StationId, CustomerId);
        }
        [HttpGet("GetsystemproductpricevatbyId/{SupplierId}/{ProductId}")]
        public async Task<ProductVatPriceData> GetsystemproductpricevatbyId(long SupplierId, long ProductId)
        {
            return await bl.GetsystemproductpricevatbyId(SupplierId, ProductId);
        }
        [HttpPost("Registersystemstationlubedata")]
        public async Task<Genericmodel> Registersystemstationlubedata(ShiftLubesandLpg obj)
        {
            return await bl.Registersystemstationlubedata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("Getsystemstationlubeandlpgbyid/{ShiftLubeLpgId}")]
        public async Task<ShiftLubesandLpg> Getsystemstationlubeandlpgbyid(long ShiftLubeLpgId)
        {
            return await bl.Getsystemstationlubeandlpgbyid(ShiftLubeLpgId);
        }

        //[HttpPost("Registersystemstationcreditinvoicedata")]
        //public async Task<Genericmodel> Registersystemstationcreditinvoicedata(ShiftCreditInvoice obj)
        //{
        //    return await bl.Registersystemstationcreditinvoicedata(JsonSerializer.Serialize(obj));
        //}
        //[HttpGet("Getsystemcreditinvoicesalebyid/{ShiftCreditInvoiceId}")]
        //public async Task<ShiftCreditInvoice> Getsystemcreditinvoicesalebyid(long ShiftCreditInvoiceId)
        //{
        //    return await bl.Getsystemcreditinvoicesalebyid(ShiftCreditInvoiceId);
        //}
        #endregion
    }
}
