using Dapper;
using DBL.Models;
using System.Data.SqlClient;
using System.Data;
using DBL.Entities;
using Newtonsoft.Json;

namespace DBL.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }

        #region Product Station Data
        public IEnumerable<SystemProductModelData> GetSystemProductvariationData(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                return connection.Query<SystemProductModelData>("Usp_GetSystemProductVariationData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<SystemProductModelData> GetSystemStationProductData(long TenantId,long StationId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@StationId", StationId);
                return connection.Query<SystemProductModelData>("Usp_GetSystemStationProductData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel RegisterSystemProduct(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemProductData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SystemProductVariation GetSystemProductDetailDataById(long ProductVariationId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProductvariationId", ProductVariationId);
                return connection.Query<SystemProductVariation>("Usp_GetSystemProductDetailDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); 
            }
        }
        public Genericmodel UpdateSystemProduct(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_UpdateSystemProductData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        #endregion

        #region Main Store Listing
        public IEnumerable<DryStockMainStoreModelData> Getsystemproductmainstoredata(long TenantId, long StationId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@StationId", StationId);
                return connection.Query<DryStockMainStoreModelData>("Usp_Getsystemproductmainstoredata", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Savetransfertoaccessoriesdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Savetransfertoaccessoriesdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
    }
}
