using DBL.Entities;
using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Everestfcsapi.Models;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SettingsManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public SettingsManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        #region System Permissions
        [HttpGet("Getsystempermissiondata")]
        public async Task<IEnumerable<Systempermissions>> Getsystempermissiondata()
        {
            return await bl.Getsystempermissiondata();
        }

        [HttpPost("Registersystempermissiondata")]
        public async Task<Genericmodel> Registersystempermissiondata(Systempermissions obj)
        {
            return await bl.Registersystempermissiondata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystempermissiondatabyid/{Permissionid}")]
        public async Task<Systempermissions> Getsystempermissiondatabyid(long Permissionid)
        {
            return await bl.Getsystempermissiondatabyid(Permissionid);
        }
        #endregion


        #region Tenant Account Settings
        [HttpGet("Getsystemtenantaccountdata")]
        public async Task<IEnumerable<SystemTenantAccountData>> Getsystemtenantaccountdata()
        {
            return await bl.Getsystemtenantaccountdata();
        }
        [HttpGet("Getsystemtenantaccountbytenantid/{TenantId}")]
        public async Task<SystemTenantAccount> Getsystemtenantaccountbytenantid(long TenantId)
        {
            return await bl.Getsystemtenantaccountbytenantid(TenantId);
        }
        [HttpPost("Registertenantaccountdata")]
        public async Task<Genericmodel> Registertenantaccountdata(SystemTenantAccount obj)
        {
            return await bl.Registertenantaccountdata(obj);
        }

        [HttpPost("Unauthregistertenantaccountdata")]
        [AllowAnonymous]
        public async Task<Genericmodel> Unauthregistertenantaccountdata(SystemTenantAccount obj)
        {
            return await bl.Registertenantaccountdata(obj);
        }
        #endregion

        #region Loyalty Settings
        [HttpGet("Getsystemloyaltysettingsdata")]
        public async Task<IEnumerable<LoyaltySettingsModelData>> Getsystemloyaltysettingsdata()
        {
            return await bl.Getsystemloyaltysettingsdata();
        }
        [HttpGet("GetSystemLoyaltySettingsById/{LoyaltysettId}")]
        public async Task<SystemLoyaltySetings> GetSystemLoyaltySettingsById(long LoyaltysettId)
        {
            return await bl.GetSystemLoyaltySettingsById(LoyaltysettId);
        }
        [HttpGet("GetSystemLoyaltySettings/{TenantId}")]
        public async Task<SystemLoyaltySetings> GetSystemLoyaltySettings(long TenantId)
        {
            return await bl.GetSystemLoyaltySettings(TenantId);
        }
        [HttpPost("RegisterLoyaltySetings")]
        public async Task<Genericmodel> RegisterLoyaltySetings(SystemLoyaltySetings obj)
        {
            return await bl.RegisterLoyaltySettings(JsonConvert.SerializeObject(obj));
        }
        #endregion
    }
}
