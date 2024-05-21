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
    public class SystemSuppliersController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public SystemSuppliersController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }

        [HttpGet("Getsystemsupplierslistdata/{TenantId}")]
        public async Task<IEnumerable<SupplierDetailData>> Getsystemsupplierslistdata(long TenantId)
        {
            return await bl.Getsystemsupplierslistdata(TenantId);
        }
        [HttpPost("Registersystemsuppliersdata")]
        public async Task<Genericmodel> Registersystemsuppliersdata(SystemSupplier obj)
        {
            return await bl.Registersystemsuppliersdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("Getsystemsupplierdetailbyid/{SupplierId}")]
        public async Task<SystemSupplier> Getsystemsupplierdetailbyid(long SupplierId)
        {
            return await bl.Getsystemsupplierdetailbyid(SupplierId);
        }
    }
}
