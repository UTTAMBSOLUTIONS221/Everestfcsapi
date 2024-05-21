using Dapper;
using DBL.Models;
using System.Data.SqlClient;
using System.Data;
using DBL.Models.Reports;
using Newtonsoft.Json;
using DBL.Models.Reports.ShiftSummary;
using Newtonsoft.Json.Linq;

namespace DBL.Repositories
{
    public class ReportManagementRepository:BaseRepository, IReportManagementRepository
    {
        public ReportManagementRepository(string connectionString) : base(connectionString)
        {
        }

        #region Sales Transactions Data
        public SalesTransactionsDetailsData GetSalesTransactionsReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@FinanceTransactionDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportSalesTransactionsData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("FinanceTransactionDetailsJson");
                return JsonConvert.DeserializeObject<SalesTransactionsDetailsData>(JsonData);
            }
        }
        #endregion

        #region Postpaid Customer Statement Data
        public CustomerPostpaidStatementDataReportData GetCustomerPostpaidStatementReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@PostPaidCustomerStatementDataDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportPostPaidCustomerStatementData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("PostPaidCustomerStatementDataDetailsJson");
                return JsonConvert.DeserializeObject<CustomerPostpaidStatementDataReportData>(JsonData);
            }
        }
        #endregion

        #region Customer Payment Data
        public CustomerPaymentDataReport GetCustomerPaymentReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@CustomerPaymentDataDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportCustomerPaymentData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("CustomerPaymentDataDetailsJson");
                return JsonConvert.DeserializeObject<CustomerPaymentDataReport>(JsonData);
            }
        }
        #endregion

        #region Prepaid Customer Statement Data
        public CustomerPrepaidStatementReportData GetCustomerPrepaidStatementReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@CustomerPrepaidStatementDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportPrepaidCustomerStatementData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("CustomerPrepaidStatementDetailsJson");
                return JsonConvert.DeserializeObject<CustomerPrepaidStatementReportData>(JsonData);
            }
        }
        #endregion

        #region Customer Topup Data
        public CustomerTopupDataReport GetCustomerTopupReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@CustomerTopUpDataDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportCustomerTopupData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("CustomerTopUpDataDetailsJson");
                return JsonConvert.DeserializeObject<CustomerTopupDataReport>(JsonData);
            }
        }
        #endregion

        #region  Customer Cumulative Data
        public CustomerCumulativeDataReport GetCustomerCumulativeReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@CustomerPointCumulativeDataJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportCumulativepointsData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("CustomerPointCumulativeDataJson");
                return JsonConvert.DeserializeObject<CustomerCumulativeDataReport>(JsonData);
            }
        }
        #endregion

        #region Point Statement Report Data
        public CustomerPostpaidStatementDataReportData GetCustomerPointStatementReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@PointAwardStatementDataDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportAwardStatementData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("PointAwardStatementDataDetailsJson");
                if (JsonData != null)
                {
                    return JsonConvert.DeserializeObject<CustomerPostpaidStatementDataReportData>(JsonData);
                }
                else
                {
                    return new CustomerPostpaidStatementDataReportData();
                }
            }
        }
        #endregion

        #region Point Award Data
        public CustomerPointAwardReport GetCustomerPointAwardReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@PointAwardDataDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportCustomerAwardsData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("PointAwardDataDetailsJson");
                if (JsonData != null)
                {
                    return JsonConvert.DeserializeObject<CustomerPointAwardReport>(JsonData);
                }
                else
                {
                    return  new CustomerPointAwardReport();
                }   
            }
        }
        #endregion

        #region Point Redeem Data
        public CustomerPointRedeemReport GetCustomerPointRedeemReportData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@PointRedeemDataDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportCustomerRedeemData", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("PointRedeemDataDetailsJson");
                return JsonConvert.DeserializeObject<CustomerPointRedeemReport>(JsonData);
            }
        }
        #endregion

        #region Station Shift Summary
        #region Shift Pump Reading
        public ShiftPumpReadingReport Generateshiftpumpreadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftPumpReadingDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftPumpReading", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftPumpReadingDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["ShiftPumpReading"] != null
                    ? JsonConvert.DeserializeObject<ShiftPumpReadingReport>(JsonData)
                    : new ShiftPumpReadingReport();
            }
        }
        #endregion

        #region Shift Tank Reading
        public ShiftTankReadingDetails Generateshifttankreadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftTankReadingDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftTankReading", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftTankReadingDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["ShiftTankReading"] != null
                    ? JsonConvert.DeserializeObject<ShiftTankReadingDetails>(JsonData)
                    : new ShiftTankReadingDetails();
            }
        }
        #endregion

        #region Shift Lub Lpg Reading
        public ShiftLpgLubeReadingDetails Generateshiftlubelpgreadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftLpgLubeReadingDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftLpgLubesReading", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftLpgLubeReadingDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["LpgLubeReadings"] != null
                    ? JsonConvert.DeserializeObject<ShiftLpgLubeReadingDetails>(JsonData)
                    : new ShiftLpgLubeReadingDetails();
            }
        }
        #endregion

        #region Shift Expenses Reading
        public ShiftExpensesDetails Generateshiftexpensesreadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftExpensesDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftExpenses", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftExpensesDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["ShiftExpenses"] != null
                    ? JsonConvert.DeserializeObject<ShiftExpensesDetails>(JsonData)
                    : new ShiftExpensesDetails();
            }
        }
        #endregion

        #region Shift Credit Sales Reading
        public ShiftCreditSalesDetails Generateshiftcreditsalereadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftCreditSalesDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftCreditSalesReading", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftCreditSalesDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["ShiftCreditsales"] != null
                    ? JsonConvert.DeserializeObject<ShiftCreditSalesDetails>(JsonData)
                    : new ShiftCreditSalesDetails();
            }
        }
        #endregion

        #region Shift Cash Drop Reading
        public ShiftCashDropsDetails Generateshiftcashdropreadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftCashDropsDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftCashDrops", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftCashDropsDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["ShiftCashDrop"] != null
                    ? JsonConvert.DeserializeObject<ShiftCashDropsDetails>(JsonData)
                    : new ShiftCashDropsDetails();
            }
        }
        #endregion

        #region Shift Purchases Reading
        public ShiftpurchasesReadingDetails Generateshiftpurchasereadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftpurchasesDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftpurchasesReading", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftpurchasesDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["Purchases"] != null
                    ? JsonConvert.DeserializeObject<ShiftpurchasesReadingDetails>(JsonData)
                    : new ShiftpurchasesReadingDetails();
            }
        }
        #endregion

        #region Shift Sales Reading
        public StationShiftDetailsData Generatestationshiftreadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@StationShiftDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportStationShiftSales", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@StationShiftDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["StationShiftDetails"] != null
                    ? JsonConvert.DeserializeObject<StationShiftDetailsData>(JsonData)
                    : new StationShiftDetailsData();
            }
        }
        #endregion

        #region Shift Sales Summary Reading
        public StationShiftSummaryDetailsData Generatestationshiftsummaryreadingreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftSummaryReadingDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftSummaryReading", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftSummaryReadingDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["FinancialDetails"] != null
                    ? JsonConvert.DeserializeObject<StationShiftSummaryDetailsData>(JsonData)
                    : new StationShiftSummaryDetailsData();
            }
        }
        #endregion
        #region Shift Customer Statement Reading
        public ShiftCustomerStatementData Generatestationshiftcustomerstatementreportdata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@ShiftCustomerStatementDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_ReportShiftCustomerStatementReading", parameters, commandType: CommandType.StoredProcedure);
                string JsonData = parameters.Get<string>("@ShiftCustomerStatementDetailsJson");
                JObject responseJson = JObject.Parse(JsonData);
                return responseJson["ShiftCustomerStatement"] != null
                    ? JsonConvert.DeserializeObject<ShiftCustomerStatementData>(JsonData)
                    : new ShiftCustomerStatementData();
            }
        }
        #endregion
        #endregion
    }
}
