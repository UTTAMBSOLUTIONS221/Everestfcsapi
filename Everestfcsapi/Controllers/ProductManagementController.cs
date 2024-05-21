using DBL;
using DBL.Entities;
using DBL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public ProductManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        #region Product Data
        [HttpGet("GetSystemProductvariationData/{TenantId}")]
        public async Task<IEnumerable<SystemProductModelData>> GetSystemProductvariationData(long TenantId)
        {
            return await bl.GetSystemProductvariationData(TenantId);
        }
        [HttpGet("GetSystemProductDetailDataById/{ProductVariationId}")]
        public async Task<SystemProductVariation> GetSystemProductDetailDataById(long ProductVariationId)
        {
            return await bl.GetSystemProductDetailDataById(ProductVariationId);
        }

        [HttpGet("GetSystemStationProductData")]
        public async Task<IEnumerable<SystemProductModelData>> GetSystemStationProductData(long TenantId,long StationId)
        {
            return await bl.GetSystemStationProductData(TenantId,StationId);
        }
        [HttpPost("RegisterSystemProduct")]
        public async Task<Genericmodel> RegisterSystemProduct(SystemProducts obj)
        {
            return await bl.RegisterSystemProduct(JsonSerializer.Serialize(obj));
        }
        [HttpPost("UpdateSystemProduct")]
        public async Task<Genericmodel> UpdateSystemProduct(SystemProductVariation obj)
        {
            return await bl.UpdateSystemProduct(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Main Store
        [HttpGet("Getsystemproductmainstoredata")]
        public async Task<IEnumerable<DryStockMainStoreModelData>> Getsystemproductmainstoredata(long TenantId, long StationId)
        {
            return await bl.Getsystemproductmainstoredata(TenantId, StationId);
        }
        [HttpPost("Savetransfertoaccessoriesdata")]
        public async Task<Genericmodel> Savetransfertoaccessoriesdata(DryStockMovement obj)
        {
            return await bl.Savetransfertoaccessoriesdata(JsonSerializer.Serialize(obj));
        }
        #endregion
    }
}
