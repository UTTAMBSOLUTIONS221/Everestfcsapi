using DBL.Entities;
using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommunicationtemplateController : ControllerBase
    {        
        private readonly BL bl;
        IConfiguration _config;
        public CommunicationtemplateController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        [HttpGet("Getsystemcommunicationtemplatedata")]
        public async Task<IEnumerable<Communicationtemplatedata>> Getsystemcommunicationtemplatedata()
        {
            return await bl.Getsystemcommunicationtemplatedata();
        }
        [HttpGet("Getsystemcommunicationtemplatedatabymodule/{Moduledata}")]
        public async Task<CommunicationTemplateModel> Getsystemcommunicationtemplatedatabymodule(string Moduledata)
        {
            return await bl.Getsystemcommunicationtemplatedatabymodule(Moduledata);
        }
        [HttpPost("Registersystemcommunicationtemplatedata")]
        public async Task<Genericmodel> Registersystemcommunicationtemplatedata(Communicationtemplate obj)
        {
            return await bl.Registersystemcommunicationtemplatedata(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getsystemcommunicationtemplatedatabyid/{TemplateId}")]
        public async Task<Communicationtemplate> Getsystemcommunicationtemplatedatabyid(long TemplateId)
        {
            return await bl.Getsystemcommunicationtemplatedatabyid(TemplateId);
        }
    }
}
