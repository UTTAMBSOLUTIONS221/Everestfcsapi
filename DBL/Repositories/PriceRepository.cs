using Dapper;
using DBL.Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using DBL.Entities;

namespace DBL.Repositories
{
    public class PriceRepository:BaseRepository, IPriceRepository
    {
        public PriceRepository(string connectionString) : base(connectionString)
        {
        }

        #region PriceList
        public SystemPriceListData GetSystemPriceListData(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@CustomerPriceDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemPriceListsData", parameters, commandType: CommandType.StoredProcedure);
                string loyaltyFormulaDetailsJson = parameters.Get<string>("@CustomerPriceDetails");
                if (loyaltyFormulaDetailsJson != null)
                {
                    return JsonConvert.DeserializeObject<SystemPriceListData>(loyaltyFormulaDetailsJson);
                }
                return new SystemPriceListData();
            }
        }
        public Genericmodel Registerpricelistdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemPriceListData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public PriceListInfoData Getsystempricelistdatabyid(long PricelistId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PriceListId", PricelistId);
                return connection.Query<PriceListInfoData>("Usp_GetSystemPriceListDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Editsystempricelistdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Editsystempricelistdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Addpricelistpricenewdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Addpricelistpricenewdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public PriceListData GetSystemCustomerAgreementPriceListData(long PricelistId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PriceListId", PricelistId);
                parameters.Add("@PriceListDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemCustomerAgreementPriceListDetailData", parameters, commandType: CommandType.StoredProcedure);
                string priceListDetailsJson = parameters.Get<string>("@PriceListDetails");
                return JsonConvert.DeserializeObject<PriceListData>(priceListDetailsJson);
            }
        }
        #endregion

       
        #region Discount Data
        public SystemDiscountListData GetSystemDiscountListData(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@CustomerDiscountDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemDiscountListsData", parameters, commandType: CommandType.StoredProcedure);
                string loyaltyFormulaDetailsJson = parameters.Get<string>("@CustomerDiscountDetails");
                if (loyaltyFormulaDetailsJson != null)
                {
                    return JsonConvert.DeserializeObject<SystemDiscountListData>(loyaltyFormulaDetailsJson);
                }
                return new SystemDiscountListData();
            }
        }
        public Genericmodel Registerdiscountlistdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemDiscountListData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DiscountListModelData Getsystemdiscountlistdatabyid(long DiscountlistId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DiscountlistId", DiscountlistId);
                return connection.Query<DiscountListModelData>("Usp_Getsystemdiscountlistdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Editsystemdiscountlistdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Editsystemdiscountlistdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Adddicountlistvaluenewdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Adddicountlistvaluenewdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DiscountListData GetSystemCustomerAgreementDiscountListData(long DiscountListId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DiscountListId", DiscountListId);
                parameters.Add("@DiscountListDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemCustomerAgreementDiscountListData", parameters, commandType: CommandType.StoredProcedure);
                string discountListDetailsJson = parameters.Get<string>("@DiscountListDetails");
                return JsonConvert.DeserializeObject<DiscountListData>(discountListDetailsJson);
            }
        }
        #endregion
    }
}
