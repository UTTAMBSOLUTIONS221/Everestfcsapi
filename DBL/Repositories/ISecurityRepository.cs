using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface ISecurityRepository
    {
        UsermodelResponce VerifySystemStaff(string Username);

        #region Verify Staffs
        SystemStaffData VerifySystemStaff(long StationId, string? Username);
        Systemstaffresponse VerifySystemStaffEmail(string Username);
        List<UserStations> GetSystemStaffStation(long Userid);
        #endregion

        #region System Staff Roles
        IEnumerable<SystemUserRoles> GetSystemRoles(long TenantId, int Offset, int Count);
        Genericmodel RegisterSystemStaffRole(string JsonEntity);
        SystemUserRoles GetSystemRoleDetailData(long RoleId);
        IEnumerable<SystemPermissions> GetSystemUserPermissions(long StaffId, bool Isportal);
        #endregion

        #region System Staffs
        IEnumerable<SystemStaffsData> GetSystemStaffsData(long TenantId,int Offset, int Count);
        Genericmodel RegisterSystemStaff(string JsonEntity);
        Genericmodel Registersystemstaffdata(string JsonObjectdata);
        SystemStaffs GetSystemStaffById(long StaffId);
        SystemStaffsDataModel Resendsystemstaffpassword(long StaffId);
        Genericmodel Resetuserpasswordpost(string JsonObjectdata);
        UsermodelResponce GetSystemStaffAlldata(long UserId);
        #endregion

        #region Log Email Messages
        Genericmodel LogEmailMessage(string JsonEntity);
        #endregion
    }
}
