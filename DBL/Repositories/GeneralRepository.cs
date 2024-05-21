using Dapper;
using DBL.Enums;
using DBL.Models;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace DBL.Repositories
{
    public class GeneralRepository : BaseRepository, IGeneralRepository
    {
        public GeneralRepository(string connectionString) : base(connectionString)
        {
        }
        public IEnumerable<ListModel> GetListModel(ListModelType listType)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Type", (int)listType);
                return connection.Query<ListModel>("Usp_GetListModel", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<ListModel> GetListModelbycode(ListModelType listType, long code)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Type", (int)listType);
                parameters.Add("@Code", code);
                return connection.Query<ListModel>("Usp_GetListModelbycode", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        } 
        public IEnumerable<ListModel> GetListModelByIdAndSearchParam(ListModelType listType, long code, string SearchParam)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Type", (int)listType);
                parameters.Add("@Code", code);
                parameters.Add("@SearchParam", SearchParam);
                return connection.Query<ListModel>("Usp_GetListModelbycodeandsearchparam", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<ListModel> GetListModelByIdandTenantId(ListModelType listType,long TenantId, long code)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@Type", (int)listType);
                parameters.Add("@Code", code);
                return connection.Query<ListModel>("Usp_GetListModelbycodeandtenant", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Genericmodel DeactivateorDeleteTableColumnData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_DeactivateorDeleteTableColumnData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RemoveTableColumnData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RemoveTableColumnData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel DefaultThisTableColumnData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_DefaultThisTableColumnData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
