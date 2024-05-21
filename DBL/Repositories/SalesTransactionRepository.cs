using Dapper;
using DBL.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace DBL.Repositories
{
    public class SalesTransactionRepository : BaseRepository, ISalesTransactionRepository
    {
        public SalesTransactionRepository(string connectionString) : base(connectionString)
        {
        }

        #region Post Sale Tranaction
        public SingleFinanceTransactions PostSaleTransaction(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@FinanceTransactionDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_RegisterSaleTransactionData", parameters, commandType: CommandType.StoredProcedure);
                string FinanceTransactionDetailsJson = parameters.Get<string>("FinanceTransactionDetailsJson");
                if (FinanceTransactionDetailsJson!=null)
                {
                    return JsonConvert.DeserializeObject<SingleFinanceTransactions>(FinanceTransactionDetailsJson);
                }
                else
                {

                }
                return new SingleFinanceTransactions { RespStatus = 0, RespMessage="Sale Posted"};
            }
        }
        public Genericmodel PostReverseSaleTransactionData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_PostReverseSaleTransactionData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<FinanceTransactions> Getallofflinesalesdata(long TenantId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                return connection.Query<FinanceTransactions>("Usp_Getallofflinesalesdata", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public SingleFinanceTransactions Getsingleofflinesalesdata(long FinanceTransactionId, long AccountId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FinanceTransactionId", FinanceTransactionId);
                parameters.Add("@AccountId", AccountId);
                parameters.Add("@FinanceTransactionDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetTransactionRecieptDetailData", parameters, commandType: CommandType.StoredProcedure);
                string FinanceTransactionDetailsJson = parameters.Get<string>("@FinanceTransactionDetailsJson");
                return JsonConvert.DeserializeObject<SingleFinanceTransactions>(FinanceTransactionDetailsJson);
            }
        }
        #endregion

        #region Automation Sales Data
        public Genericmodel ProcessAutomationsalesData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_ProcessAutomationsalesData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
    }
}
