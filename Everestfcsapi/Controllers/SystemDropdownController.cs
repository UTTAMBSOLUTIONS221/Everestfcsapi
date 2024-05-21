using DBL;
using DBL.Enums;
using DBL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SystemDropdownController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public SystemDropdownController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }


        [HttpGet]
        [AllowAnonymous]
        public List<ListModel> UnauthSystemdropdowns(ListModelType listType)
        {
            return bl.GetListModel(listType).Result.Select(x => new ListModel
            {
                Text = x.Text,
                Value = x.Value,
                GroupId = x.GroupId,
                GroupName = x.GroupName,
            }).ToList();
        }
        [HttpGet]
        public List<ListModel> Systemdropdowns(ListModelType listType)
        {
            return bl.GetListModel(listType).Result.Select(x => new ListModel
            {
                Text = x.Text,
                Value = x.Value,
                GroupId = x.GroupId,
                GroupName = x.GroupName,
            }).ToList();
        }

        [HttpGet]
        public List<ListModel> SystemdropdownbyId(ListModelType listType, long Id)
        {
            return bl.GetListModelById(listType, Id).Result.Select(x => new ListModel
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
        }
        [HttpGet]
        public List<ListModel> Systemdropdownbyidandsearch(ListModelType listType, long Id,string SearchParam)
        {
            return bl.GetListModelByIdAndSearchParam(listType, Id, SearchParam).Result.Select(x => new ListModel
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
        }

        [HttpGet]
        public List<ListModel> SystemdropdownbyIdandTenantId(ListModelType listType, long TenantId, long Id)
        {
            return bl.GetListModelByIdandTenantId(listType, TenantId, Id).Result.Select(x => new ListModel
            {
                Text = x.Text,
                Value = x.Value
            }).ToList();
        }

    }
}
