using DBL;
using Everestfcsapi.Helpers;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly BL bl;
        private readonly IJobService _jobService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        public JobController(IConfiguration config,IJobService jobService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _jobService = jobService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }
       
        [HttpGet("AutomationSalesdata")]
        public async Task<IActionResult> AutomationSalesdata()
        {
            var data = await bl.Getautomatedsystemstationsdata();
            string ftpServerUrl = "ftp://win6111.site4now.net/";
            string ftpUsername = "uttambadmin";
            string ftpPassword = "Password123!";
            foreach (var item in data)
            {
                RecurringJob.AddOrUpdate<FtpReader>("ReadXmlFiles", reader => reader.ProcessXmlFromFtpAsync(ftpServerUrl, ftpUsername, ftpPassword, item.Stationcode.ToLower()), Cron.MinuteInterval(1));
            }
            return Ok();
        }
    }
}
