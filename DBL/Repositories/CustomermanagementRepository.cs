using System.Data.SqlClient;
using System.Data;
using Dapper;
using DBL.Models;

namespace DBL.Repositories
{
    public class CustomermanagementRepository:BaseRepository,ICustomermanagementRepository
    {
        public CustomermanagementRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Systemtenantcustomers> Getsystemtenantcustomersdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Systemtenantcustomers>("Usp_Getsystemtenantcustomersdata", null, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel Registersystemccustomerdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registersystemccustomerdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
