using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DBL.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Everestfcsapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PriceManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public PriceManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }


        #region Management Prices
        [HttpGet("GetSystemPriceListData/{TenantId}")]
        public async Task<SystemPriceListData> GetSystemPriceListData(long TenantId)
        {
            return await bl.GetSystemPriceListData(TenantId);
        }
        [HttpPost("Registerpricelistdata")]
        public async Task<Genericmodel> Registerpricelistdata(StationPriceLists obj)
        {
            return await bl.Registerpricelistdata(JsonConvert.SerializeObject(obj));
        }

        [HttpGet("Getsystempricelistdatabyid/{PricelistId}")]
        public async Task<PriceListInfoData> Getsystempricelistdatabyid(long PricelistId)
        {
            return await bl.Getsystempricelistdatabyid(PricelistId);
        }
        [HttpPost("Editsystempricelistdata")]
        public async Task<Genericmodel> Editsystempricelistdata(PriceListInfoData obj)
        {
            return await bl.Editsystempricelistdata(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("Addpricelistpricenewdata")]
        public async Task<Genericmodel> Addpricelistpricenewdata(PriceListPriceDataModel obj)
        {
            return await bl.Addpricelistpricenewdata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("GetSystemCustomerAgreementPriceListData/{PricelistId}")]
        public async Task<PriceListData> GetSystemCustomerAgreementPriceListData(long PricelistId)
        {
            return await bl.GetSystemCustomerAgreementPriceListData(PricelistId);
        }
        #endregion

        #region Management Discounts
        [HttpGet("GetSystemDiscountListData/{TenantId}")]
        public async Task<SystemDiscountListData> GetSystemDiscountListData(long TenantId)
        {
            return await bl.GetSystemDiscountListData(TenantId);
        }
        [HttpPost("Registerdiscountlistdata")]
        public async Task<Genericmodel> Registerdiscountlistdata(StationDiscountLists obj)
        {
            return await bl.Registerdiscountlistdata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemdiscountlistdatabyid/{DiscountlistId}")]
        public async Task<DiscountListModelData> Getsystemdiscountlistdatabyid(long DiscountlistId)
        {
            return await bl.Getsystemdiscountlistdatabyid(DiscountlistId);
        }
        [HttpPost("Editsystemdiscountlistdata")]
        public async Task<Genericmodel> Editsystemdiscountlistdata(DiscountListModelData obj)
        {
            return await bl.Editsystemdiscountlistdata(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("Adddicountlistvaluenewdata")]
        public async Task<Genericmodel> Adddicountlistvaluenewdata(LnkDiscountProductModel obj)
        {
            return await bl.Adddicountlistvaluenewdata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("GetSystemCustomerAgreementDiscountListData/{DiscountListId}")]
        public async Task<DiscountListData> GetSystemCustomerAgreementDiscountListData(long DiscountListId)
        {
            return await bl.GetSystemCustomerAgreementDiscountListData(DiscountListId);
        }
        #endregion
    }
}
