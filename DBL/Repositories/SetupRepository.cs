using Dapper;
using DBL.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using DBL.Entities;

namespace DBL.Repositories
{
    public class SetupRepository:BaseRepository,ISetupRepository
    {
        public SetupRepository(string connectionString) : base(connectionString)
        {
        }
        #region System Setup
        public SystemGadgetResponseModel SystemGadgetsAppSetUp(string SerialNumber)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Serialnumber", SerialNumber);
                parameters.Add("@GadgetDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_VerifySystemGadget", parameters, commandType: CommandType.StoredProcedure);
                string gadgetDetailsJson = parameters.Get<string>("@GadgetDetails");
                var json = string.Format("{0}", gadgetDetailsJson);
                return JsonConvert.DeserializeObject<SystemGadgetResponseModel>(json);
            }
        }
        #endregion

        #region System Hardware Data

        #region System POS
        public IEnumerable<SystemGadgetsData> GetSystemGadgetsData(int Offset, int Count)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Offset", Offset);
                parameters.Add("@Count", Count);
                return connection.Query<SystemGadgetsData>("Usp_GetSystemGadgetsData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Genericmodel RegisterSystemGadgets(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemGadgetsData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Systemgadgets GetSystemGadgetsDataById(long GadgetId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@GadgetId", GadgetId);
                return connection.Query<Systemgadgets>("Usp_GetSystemGadgetsDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region System Tenant Cards
        public IEnumerable<SystemTenantsCardData> GetSystemTenantCardData(long TenantId, int Offset, int Count)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@Offset", Offset);
                parameters.Add("@Count", Count);
                return connection.Query<SystemTenantsCardData>("Usp_GetSystemTenantCardData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Genericmodel RegisterSystemTenantCards(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemTenantCardsData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemTenantCard GetSystemTenantCardDataById(long CardId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardId", CardId);
                return connection.Query<SystemTenantCard>("Usp_GetSystemTenantCardDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel GetSystemTenantCardById(long Tenantcardid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Tenantcardid", Tenantcardid);
                return connection.Query<Genericmodel>("Usp_GetSystemTenantCardById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Getcustomercardbycardcode(string CardCode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardCode", CardCode);
                return connection.Query<Genericmodel>("Usp_Getcustomercardbycardcode", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
        #endregion

        #region System Stations Related Data, Staffs, Products etc
        public SystemStationRelatedData GetSystemStationRelatedData(long StationId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StationId", StationId);
                parameters.Add("@SystemStationDataDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemStationRelatedData", parameters, commandType: CommandType.StoredProcedure);
                string systemStationDataDetailsJson = parameters.Get<string>("@SystemStationDataDetails");
                var json = string.Format("{0}", systemStationDataDetailsJson);
                return JsonConvert.DeserializeObject<SystemStationRelatedData>(json);
            }
        }

        #endregion

        
    }
}
