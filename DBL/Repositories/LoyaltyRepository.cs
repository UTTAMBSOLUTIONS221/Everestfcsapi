using Dapper;
using DBL.Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using DBL.Entities;

namespace DBL.Repositories
{
    public class LoyaltyRepository:BaseRepository, ILoyaltyRepository
    {
        public LoyaltyRepository(string connectionString) : base(connectionString)
        {
        }

        #region Loyalty Formula
        public LoyaltyFormulaandFormulaRules GetSystemLoyaltyFormulaandFormulaRulesData(long TenantId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@LoyaltyFormulaDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemLoyaltyFormulaData", parameters, commandType: CommandType.StoredProcedure);
                string loyaltyFormulaDetailsJson = parameters.Get<string>("@LoyaltyFormulaDetails");
                if (loyaltyFormulaDetailsJson != null)
                {
                    return JsonConvert.DeserializeObject<LoyaltyFormulaandFormulaRules>(loyaltyFormulaDetailsJson);
                }
                return new LoyaltyFormulaandFormulaRules();
            }
        }
        public Genericmodel Registerformulaandrules(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterLoyaltyFormulaData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemFormulaData GetSystemLoyaltyFormulaDataById(long FormulaId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FormulaId", FormulaId);
                return connection.Query<SystemFormulaData>("Usp_GetSystemLoyaltyFormulaDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registerformulaeditdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registerformulaeditdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemFormulaRuleData GetSystemLoyaltyFormularuleDataById(long FormulaRuleId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@FormulaRuleId", FormulaRuleId);
                return connection.Query<SystemFormulaRuleData>("Usp_GetSystemLoyaltyFormulaRuleDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterformulaRuleeditdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterformulaRuleeditdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion


        #region Loyalty Schemes
        public LoyaltySchemeandSchemeRules GetSystemLoyaltySchemeandSchemeRulesData(long TenantId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@LoyaltySchemeDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemLoyaltySchemeData", parameters, commandType: CommandType.StoredProcedure);
                string loyaltySchemeDetailsJson = parameters.Get<string>("@LoyaltySchemeDetails");
                if (loyaltySchemeDetailsJson != null)
                {
                    return JsonConvert.DeserializeObject<LoyaltySchemeandSchemeRules>(loyaltySchemeDetailsJson);
                }
                return new LoyaltySchemeandSchemeRules();
            }
        }
        public Genericmodel Registerschemeandrules(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterschemeandruleData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemLoyaltyScheme GetSystemLoyaltyschemeDataById(long SchemeId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LSchemeId", SchemeId);
                return connection.Query<SystemLoyaltyScheme>("Usp_GetSystemLoyaltySchemeDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Registerschemeeditdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registerschemeeditdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemSchemeRuleResultData GetSystemLoyaltyschemeRuleDataById(long LSchemeRuleId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                SystemSchemeRuleResultData loyaltyData = new SystemSchemeRuleResultData();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LSchemeRuleId", LSchemeRuleId);
                var result= connection.Query<SystemSchemeRuleResultData>("Usp_GetSystemLoyaltyschemeRuleDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (result != null)
                {
                    // Parse the comma-separated string fields into lists
                    result.DayOfWeek = ParseStringToList(result.DaysOfWeek);
                    result.Station = ParseStringToListLong(result.Stations);
                    result.Loyaltygroup = ParseStringToListLong(result.Loyaltygroups);
                    result.Paymentmode = ParseStringToListLong(result.Paymentmodes);
                    result.Product = ParseStringToListLong(result.Products);

                    // Assign the parsed result to the loyaltyData object
                    loyaltyData = result;
                }
                return loyaltyData;
            }
        }
        public Genericmodel Registerschemeruleeditdata(string JsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", JsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Registerschemeruleeditdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Other Methods
        // Helper method to parse comma-separated string to List<string>
        private List<string> ParseStringToList(string commaSeparatedString)
        {
            if (!string.IsNullOrEmpty(commaSeparatedString))
            {
                return commaSeparatedString.Split(',').ToList();
            }
            return new List<string>();
        }

        // Helper method to parse comma-separated string to List<long>
        private List<long> ParseStringToListLong(string commaSeparatedString)
        {
            if (!string.IsNullOrEmpty(commaSeparatedString))
            {
                return commaSeparatedString.Split(',').Select(long.Parse).ToList();
            }
            return new List<long>();
        }

        #endregion
    }
}
