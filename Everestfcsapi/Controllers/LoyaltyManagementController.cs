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
    public class LoyaltyManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public LoyaltyManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        #region Formulas
        [HttpGet("GetSystemLoyaltyFormulaandFormulaRulesData/{TenantId}")]
        public async Task<LoyaltyFormulaandFormulaRules> GetSystemLoyaltyFormulaandFormulaRulesData(long TenantId)
        {
            return await bl.GetSystemLoyaltyFormulaandFormulaRulesData(TenantId);
        }
        [HttpPost("Registerformulaandrules")]
        public async Task<Genericmodel> Registerformulaandrules(LoyaltyFormulaandRules obj)
        {
            return await bl.Registerformulaandrules(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemLoyaltyFormulaDataById/{FormulaId}")]
        public async Task<SystemFormulaData> GetSystemLoyaltyFormulaDataById(long FormulaId)
        {
            return await bl.GetSystemLoyaltyFormulaDataById(FormulaId);
        }
        [HttpPost("Registerformulaeditdata")]
        public async Task<Genericmodel> Registerformulaeditdata(SystemFormulaData obj)
        {
            return await bl.Registerformulaeditdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemLoyaltyFormularuleDataById/{FormulaRuleId}")]
        public async Task<SystemFormulaRuleData> GetSystemLoyaltyFormularuleDataById(long FormulaRuleId)
        {
            return await bl.GetSystemLoyaltyFormularuleDataById(FormulaRuleId);
        }
        [HttpPost("RegisterformulaRuleeditdata")]
        public async Task<Genericmodel> Registerformularuleeditdata(SystemFormulaRuleData obj)
        {
            return await bl.RegisterformulaRuleeditdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemLoyaltySchemeandSchemeRulesData/{TenantId}")]
        public async Task<LoyaltySchemeandSchemeRules> GetSystemLoyaltySchemeandSchemeRulesData(long TenantId)
        {
            return await bl.GetSystemLoyaltySchemeandSchemeRulesData(TenantId);
        }
        [HttpPost("Registerschemeandrules")]
        public async Task<Genericmodel> Registerschemeandrules(LoyaltySchemesandRules obj)
        {
            return await bl.Registerschemeandrules(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemLoyaltyschemeDataById/{SchemeId}")]
        public async Task<SystemLoyaltyScheme> GetSystemLoyaltyschemeDataById(long SchemeId)
        {
            return await bl.GetSystemLoyaltyschemeDataById(SchemeId);
        }
        [HttpPost("Registerschemeeditdata")]
        public async Task<Genericmodel> Registerschemeeditdata(SystemLoyaltyScheme obj)
        {
            return await bl.Registerschemeeditdata(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemLoyaltyschemeRuleDataById/{LSchemeRuleId}")]
        public async Task<SystemSchemeRuleResultData> GetSystemLoyaltyschemeRuleDataById(long LSchemeRuleId)
        {
            return await bl.GetSystemLoyaltyschemeRuleDataById(LSchemeRuleId);
        }
        [HttpPost("Registerschemeruleeditdata")]
        public async Task<Genericmodel> Registerschemeruleeditdata(SchemeRule obj)
        {
            return await bl.Registerschemeruleeditdata(JsonSerializer.Serialize(obj));
        }
        #endregion

    }
}
