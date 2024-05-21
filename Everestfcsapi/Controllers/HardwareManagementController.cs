using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DBL.Entities;
using System.Text.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HardwareManagementController : ControllerBase
    {
        private readonly BL bl;
        public HardwareManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
        }

        #region System POS

        [HttpGet("GetSystemGadgetsData/{Offset}/{Count}")]
        public async Task<IEnumerable<SystemGadgetsData>> GetSystemGadgetsData(int Offset, int Count)
        {
            return await bl.GetSystemGadgetsData(Offset, Count);
        }
        [HttpPost("RegisterSystemGadgets")]
        public async Task<Genericmodel> RegisterSystemGadgets(Systemgadgets obj)
        {
            return await bl.RegisterSystemGadgets(JsonSerializer.Serialize(obj));
        }
        [HttpGet("GetSystemGadgetsDataById/{GadgetId}")]
        public async Task<Systemgadgets> GetSystemGadgetsDataById(long GadgetId)
        {
            return await bl.GetSystemGadgetsDataById(GadgetId);
        }
        #endregion
    }
}
