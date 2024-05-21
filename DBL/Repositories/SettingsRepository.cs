using Dapper;
using DBL.Models;
using System.Data.SqlClient;
using System.Data;
using DBL.Entities;
using Newtonsoft.Json;

namespace DBL.Repositories
{
    public class SettingsRepository:BaseRepository,ISettingsRepository
    {
        public SettingsRepository(string connectionString) : base(connectionString)
        {
        }

        #region System Permissions
        public IEnumerable<Systempermissions> Getsystempermissiondata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<Systempermissions>("Usp_Getsystempermissiondata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystempermissiondata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystempermissiondata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systempermissions Getsystempermissiondatabyid(long Permissionid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Permissionid", Permissionid);
                return connection.Query<Systempermissions>("Usp_Getsystempermissiondatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Tenant Settings
        public IEnumerable<SystemTenantAccountData> Getsystemtenantaccountdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<SystemTenantAccountData>("Usp_Getsystemtenantaccountdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public SystemTenantAccount Getsystemtenantaccountbytenantid(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                return connection.Query<SystemTenantAccount>("Usp_Getsystemtenantaccountbyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel Registertenantaccountdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registertenantaccountdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region System Suppliers
        public IEnumerable<SupplierDetailData> Getsystemsupplierslistdata(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                return connection.Query<SupplierDetailData>("Usp_Getsystemsupplierslistdata", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemsuppliersdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemsuppliersdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemSupplier Getsystemsupplierdetailbyid(long SupplierId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SupplierId", SupplierId);
                parameters.Add("@SystemSupplierData", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Getsystemsupplierdetailbyid", parameters, commandType: CommandType.StoredProcedure);
                string suppliersDetailsJson = parameters.Get<string>("@SystemSupplierData");
                var json = string.Format("{0}", suppliersDetailsJson);
                return JsonConvert.DeserializeObject<SystemSupplier>(json);
            }
        }
        #endregion

        #region Loyalty Settings
        public IEnumerable<LoyaltySettingsModelData> Getsystemloyaltysettingsdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<LoyaltySettingsModelData>("Usp_Getallsystemloyaltysettingsdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public SystemLoyaltySetings GetSystemLoyaltySettingsById(long LoyaltysettId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LoyaltysettId", LoyaltysettId);
                return connection.Query<SystemLoyaltySetings>("Usp_Getsystemloyaltysettingsdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemLoyaltySetings GetSystemLoyaltySettings(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                return connection.Query<SystemLoyaltySetings>("Usp_GetSystemLoyaltySettingsData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterLoyaltySettings(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterLoyaltySetting", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Communication Templates
        public IEnumerable<Communicationtemplatedata> Getsystemcommunicationtemplatedata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                return connection.Query<Communicationtemplatedata>("Usp_Getsystemcommunicationtemplatedata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public CommunicationTemplateModel Getsystemcommunicationtemplatedatabymodule(string Moduledata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Moduledata", Moduledata);
                return connection.Query<CommunicationTemplateModel>("Usp_Getsystemcommunicationtemplatedatabymodule", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CommunicationTemplateModel Getsystemcommunicationtemplatedatabyname(bool Isemail, string Templatename)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Isemail", Isemail);
                parameters.Add("@Templatename", Templatename);
                return connection.Query<CommunicationTemplateModel>("Usp_Getsystemcommunicationtemplatedatabyname", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registersystemcommunicationtemplatedata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemcommunicationtemplatedata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Communicationtemplate Getsystemcommunicationtemplatedatabyid(long Templateid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Templateid", Templateid);
                return connection.Query<Communicationtemplate>("Usp_Getsystemcommunicationtemplatedatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
    }
}
