using DBL.Entities;
using DBL.Models;
using DBL;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffManagemetController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public StaffManagemetController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        #region System Staff Roles
        [HttpGet("GetSystemRoles/{TenantId}/{offset}/{count}")]
        public async Task<IEnumerable<SystemUserRoles>> GetSystemRoles(long TenantId,int offset, int Count)
        {
            return await bl.GetSystemRoles(TenantId,offset, Count);
        }
        [HttpPost("RegisterSystemStaffRole")]
        public async Task<Genericmodel> RegisterSystemStaffRole(SystemUserRoles obj)
        {
            return await bl.RegisterSystemStaffRole(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("GetSystemRoleDetailData/{RoleId}")]
        public async Task<SystemUserRoles> GetSystemRoleDetailData(long RoleId)
        {
            return await bl.GetSystemRoleDetailData(RoleId);
        }
        [HttpGet("GetSystemUserPermissions/{StaffId}/{Isportal}")]
        public async Task<IEnumerable<SystemPermissions>> GetSystemUserPermissions(long StaffId,bool Isportal)
        {
            return await bl.GetSystemUserPermissions(StaffId, Isportal);
        }
        #endregion

        #region System Staffs
        [HttpGet("GetSystemStaffsData/{TenantId}/{Offset}/{Count}")]
        public async Task<IEnumerable<SystemStaffsData>> GetSystemStaffsData(long TenantId, int Offset,int Count)
        {
            return await bl.GetSystemStaffsData(TenantId,Offset, Count);
        }
        [HttpPost("RegisterSystemStaff")]
        public async Task<Genericmodel> RegisterSystemStaff(SystemStaffs obj)
        {
            return await bl.RegisterSystemStaff(obj);
        }
        [HttpGet("GetSystemStaffById/{StaffId}")]
        public async Task<SystemStaffs> GetSystemStaffById(long StaffId)
        {
            return await bl.GetSystemStaffById(StaffId);
        }
        [HttpGet("Resendsystemstaffpassword/{StaffId}")]
        public async Task<Genericmodel> Resendsystemstaffpassword(long StaffId)
        {
            return await bl.Resendsystemstaffpassword(StaffId);
        }

        [HttpPost("Forgotuserpasswordpost")]
        [AllowAnonymous]
        public async Task<UsermodelResponce> Forgotuserpasswordpost(StaffForgotPassword obj)
        {
            return await bl.Forgotuserpasswordpost(obj);
        }
        [HttpPost("Resetuserpasswordpost")]
        [AllowAnonymous]
        public async Task<Genericmodel> Resetuserpasswordpost(Staffresetpassword obj)
        {
            return await bl.Resetuserpasswordpost(obj);
        }
        #endregion

    }
}
