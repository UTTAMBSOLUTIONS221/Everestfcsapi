using Dapper;
using DBL.Entities;
using DBL.Models;
using System.Data.SqlClient;
using System.Data;
using static Dapper.SqlMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DBL.Repositories
{
    public class SecurityRepository:BaseRepository, ISecurityRepository
    {
        public SecurityRepository(string connectionString) : base(connectionString)
        {
        }
        #region Verify System Staff
        public UsermodelResponce VerifySystemStaff(string Username)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                UsermodelResponce resp = new UsermodelResponce();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", Username);
                parameters.Add("@StaffDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Everestfcsverifysystemuser", parameters, commandType: CommandType.StoredProcedure);
                string staffDetailsJson = parameters.Get<string>("@StaffDetails");
                JObject responseJson = JObject.Parse(staffDetailsJson);
                if (Convert.ToInt32(responseJson["RespStatus"]) == 0)
                {
                    string userModelJson = responseJson["Usermodel"].ToString();
                    UsermodeldataResponce userResponse = JsonConvert.DeserializeObject<UsermodeldataResponce>(userModelJson);
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Usermodel = userResponse;
                    return resp;
                }
                else
                {
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Usermodel = new UsermodeldataResponce();
                    return resp;
                }
            }
        }
        public Systemstaffresponse VerifySystemStaffEmail(string Username)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", Username);
                parameters.Add("@StaffDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Fuelproverifysystemuseremail", parameters, commandType: CommandType.StoredProcedure);
                string staffDetailsJson = parameters.Get<string>("@StaffDetails");
                var json = string.Format("{0}", staffDetailsJson);
                return JsonConvert.DeserializeObject<Systemstaffresponse>(json);
            }
        }

        public List<UserStations> GetSystemStaffStation(long Userid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Userid", Userid);
                return connection.Query<UserStations>("Usp_GetSystemStaffStation", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion

        #region System Setup
        public Genericmodel Getsystemtenatdata(string TetantCode)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TempTitle", TetantCode);
                return connection.Query<Genericmodel>("Usp_GetListModel", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Verify System Staff 
        public SystemStaffData VerifySystemStaff(long StationId,string? Username)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationId", StationId);
                parameters.Add("@Username", Username);
                parameters.Add("@StaffDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_VerifySystemStaff", parameters, commandType: CommandType.StoredProcedure);
                string staffDetailsJson = parameters.Get<string>("@StaffDetails");
                var json = string.Format("{0}", staffDetailsJson);
                return JsonConvert.DeserializeObject<SystemStaffData>(json);
            }
        }
        #endregion

        #region System Staff Role Management
        public IEnumerable<SystemUserRoles> GetSystemRoles(long TenantId,int Offset, int Count)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@Offset", Offset);
                parameters.Add("@Count", Count);
                return connection.Query<SystemUserRoles>("Usp_GetSystemRolesData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel RegisterSystemStaffRole(string JsonEntity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@JsonObjectdata", JsonEntity);
                return connection.Query<Genericmodel>("Usp_RegisterSystemStaffRole", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemUserRoles GetSystemRoleDetailData(long RoleId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RoleId", RoleId);
                parameters.Add("@Roledetaildata", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemRoleDetailData", parameters, commandType: CommandType.StoredProcedure);
                string roledetailDetailsJson = parameters.Get<string>("@Roledetaildata");
                return JsonConvert.DeserializeObject<SystemUserRoles>(roledetailDetailsJson);
            }
        }
        public IEnumerable<SystemPermissions> GetSystemUserPermissions(long StaffId,bool Isportal)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StaffId", StaffId);
                parameters.Add("@Isportal", Isportal);
                return connection.Query<SystemPermissions>("Usp_GetSystemUserPermissions", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion

        #region System Staff 
        public IEnumerable<SystemStaffsData> GetSystemStaffsData(long TenantId, int Offset, int Count)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@Offset", Offset);
                parameters.Add("@Count", Count);
                return connection.Query<SystemStaffsData>("Usp_GetSystemStaffData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel RegisterSystemStaff(string JsonEntity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonEntity);
                return connection.Query<Genericmodel>("Usp_RegisterSystemStaffData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemstaffdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemStaffData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SystemStaffs GetSystemStaffById(long StaffId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", StaffId);
                parameters.Add("@Staffdetaildata", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemUserDetailData", parameters, commandType: CommandType.StoredProcedure);
                string roledetailDetailsJson = parameters.Get<string>("@Staffdetaildata");
                return JsonConvert.DeserializeObject<SystemStaffs>(roledetailDetailsJson);
            }
        }
        public SystemStaffsDataModel Resendsystemstaffpassword(long StaffId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", StaffId);
                parameters.Add("@Staffdetaildata", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemStaffUserDetailData", parameters, commandType: CommandType.StoredProcedure);
                string roledetailDetailsJson = parameters.Get<string>("@Staffdetaildata");
                return JsonConvert.DeserializeObject<SystemStaffsDataModel>(roledetailDetailsJson);
            }
        }
        public Genericmodel Resetuserpasswordpost(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_ResetuserpasswordpostData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public UsermodelResponce GetSystemStaffAlldata(long UserId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                UsermodelResponce resp = new UsermodelResponce();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", UserId);
                parameters.Add("@StaffDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Fuelproverifysystemuser", parameters, commandType: CommandType.StoredProcedure);
                string staffDetailsJson = parameters.Get<string>("@StaffDetails");
                JObject responseJson = JObject.Parse(staffDetailsJson);
                if (Convert.ToInt32(responseJson["RespStatus"]) == 0)
                {
                    string userModelJson = responseJson["Usermodel"].ToString();
                    UsermodeldataResponce userResponse = JsonConvert.DeserializeObject<UsermodeldataResponce>(userModelJson);
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Usermodel = userResponse;
                    return resp;
                }
                else
                {
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.Usermodel = new UsermodeldataResponce();
                    return resp;
                }
            }
        }
        #endregion
    }
}
