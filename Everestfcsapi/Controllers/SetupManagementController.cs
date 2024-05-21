using DBL;
using DBL.Entities;
using DBL.Models;
using Everestfcsapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SetupManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public SetupManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        #region System Gadget SetUp
        [HttpPost("SystemGadgetsAppSetUp/{Serialnumber}")]
        public async Task<SystemGadgetResponseModel> SystemGadgetsAppSetUp(string Serialnumber)
        {
            return await bl.SystemGadgetsAppSetUp(Serialnumber);
        }
        #endregion



        #region System Tenant Card

        [HttpGet("GetSystemTenantCardData/{TenantId}/{Offset}/{Count}")]
        public async Task<IEnumerable<SystemTenantsCardData>> GetSystemTenantCardData(long TenantId,int Offset, int Count)
        {
            return await bl.GetSystemTenantCardData(TenantId,Offset, Count);
        }
        [HttpPost("RegisterSystemTenantCards")]
        public async Task<Genericmodel> RegisterSystemTenantCards(SystemTenantCard obj)
        {
            return await bl.RegisterSystemTenantCards(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemTenantCardDataById/{CardId}")]
        public async Task<SystemTenantCard> GetSystemTenantCardDataById(long CardId)
        {
            return await bl.GetSystemTenantCardDataById(CardId);
        }
        //[HttpGet("GetSystemTenantCardById/{Tenantcardid}")]
        //public async Task<Genericmodel> GetSystemTenantCardById(long Tenantcardid)
        //{
        //    return await bl.GetSystemTenantCardById(Tenantcardid);
        //}
        [HttpGet("GetSystemTenantCardById/{Tenantcardid}")]
        public async Task<Genericmodel> GetSystemTenantCardById(long Tenantcardid)
        {
            return await bl.Resendcustomercardpin(Tenantcardid);
        }
        [AllowAnonymous]
        [Route("Authenticatecard"), HttpPost]
        public async Task<Genericmodel> Authenticatecard([FromBody] Cardcred carddata)
        {
            return await bl.Authenticatecustomercard(carddata.CardCode,carddata.CardPin);
        }
        #endregion

        #region Get Station Related Data
        [HttpPost("GetSystemStationRelatedData")]
        public async Task<SystemStationRelatedData> GetSystemStationRelatedData(SystemStationRequest model)
        {
            return await bl.GetSystemStationRelatedData(model.TenantstationCode);
        }
        #endregion

        #region System Station Data
        [HttpPost("Registersystemstationdata")]
        public async Task<Genericmodel> Registersystemstationdata(Genericmodel obj)
        {
            return await bl.Registersystemstationdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemStationallDetailDataById/{StationId}")]
        public async Task<Systemstationdetailmodel> GetSystemStationallDetailDataById(long StationId)
        {
            return await bl.GetSystemStationallDetailDataById(StationId);
        }
        #endregion

        #region System Station Staff Data
        [HttpPost("Registersystemstaffdata")]
        public async Task<Genericmodel> Registersystemstaffdata(Genericmodel obj)
        {
            return await bl.Registersystemstaffdata(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Station Tanks
        [HttpGet("GetSystemStationTankDetailDataById/{TankId}")]
        public async Task<StationTankModel> GetSystemStationTankDetailDataById(long TankId)
        {
            return await bl.GetSystemStationTankDetailDataById(TankId);
        }
        [HttpPost("RegisterSystemStationTank")]
        public async Task<Genericmodel> RegisterSystemStationTank(StationTankModel obj)
        {
            return await bl.RegisterSystemStationTank(JsonSerializer.Serialize(obj));
        }
        #endregion

        #region Station Pumps
        [HttpGet("GetSystemStationPumpDetailDataById/{PumpId}")]
        public async Task<Stationpumps> GetSystemStationpumpDetailDataById(long PumpId)
        {
            return await bl.GetSystemStationpumpDetailDataById(PumpId);
        }
        [HttpPost("RegisterSystemStationPump")]
        public async Task<Genericmodel> RegisterSystemStationPump(Stationpumps obj)
        {
            return await bl.RegisterSystemStationPump(JsonSerializer.Serialize(obj));
        }
        #endregion


        [HttpPost("Resendstaffpassword")]
        public async Task<Genericmodel> Resendstaffpassword(Emailsendingdata model)
        {
            return await bl.Resendstaffpassword(model);
        }
    }
}
