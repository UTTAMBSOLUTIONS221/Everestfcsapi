using Dapper;
using DBL.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace DBL.Repositories
{
    public class SecuritymanagementRepository : BaseRepository, ISecuritymanagementRepository
    {
        public SecuritymanagementRepository(string connectionString) : base(connectionString)
        {
        }
        #region Verify System Staff
        public Genericmodel VerifySystemStaff(string Username)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", Username);
                return connection.Query<Genericmodel>("Usp_Fuelproverifysystemuser", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public long Verifystaffrefreshtoken(long Userid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Userid", Userid);
                return connection.Query<long>("Usp_Verifystaffrefreshtoken", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel Updatestaffrefreshtoken(long Userid, string RefreshToken)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Userid", Userid);
                parameters.Add("@RefreshToken", RefreshToken);
                return connection.Query<Genericmodel>("Usp_Updatestaffrefreshtoken", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registerstaffrefresftoken(long Userid, string TokenId, string RefreshToken)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Userid", Userid);
                parameters.Add("@TokenId", TokenId);
                parameters.Add("@RefreshToken", RefreshToken);
                return connection.Query<Genericmodel>("Usp_Registerstaffrefresftoken", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
    }
}
