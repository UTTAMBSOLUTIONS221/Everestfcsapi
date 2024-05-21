using DBL;
using DBL.Entities.Reports;
using DBL.Models;
using DBL.Models.Reports;
using DBL.Models.Reports.ShiftSummary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public ReportManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        #region Sales Transactions Data
        [HttpPost("GetSalesTransactionsReportData")]
        public async Task<SalesTransactionsDetailsData> GetSalesTransactionsReportData(ReportParameters obj)
        {
            return await bl.GetSalesTransactionsReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Postpaid Statement Data
        [HttpPost("GetCustomerPostpaidStatementReportData")]
        public async Task<CustomerPostpaidStatementDataReportData> GetCustomerPostpaidStatementReportData(ReportParameters obj)
        {
            return await bl.GetCustomerPostpaidStatementReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Payement Data
        [HttpPost("GetCustomerPaymentReportData")]
        public async Task<CustomerPaymentDataReport> GetCustomerPaymentReportData(ReportParameters obj)
        {
            return await bl.GetCustomerPaymentReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Prepaid Statement Data
        [HttpPost("GetCustomerPrepaidStatementReportData")]
        public async Task<CustomerPrepaidStatementReportData> GetCustomerPrepaidStatementReportData(ReportParameters obj)
        {
            return await bl.GetCustomerPrepaidStatementReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Topup Data
        [HttpPost("GetCustomerTopupReportData")]
        public async Task<CustomerTopupDataReport> GetCustomerTopupReportData(ReportParameters obj)
        {
            return await bl.GetCustomerTopupReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Cumulative Report Data
        [HttpPost("GetCustomerCumulativeReportData")]
        public async Task<CustomerCumulativeDataReport> GetCustomerCumulativeReportData(ReportParameters obj)
        {
            return await bl.GetCustomerCumulativeReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Points Statement Data
        [HttpPost("GetCustomerPointStatementReportData")]
        public async Task<CustomerPostpaidStatementDataReportData> GetCustomerPointStatementReportData(ReportParameters obj)
        {
            return await bl.GetCustomerPointStatementReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Points Award Data
        [HttpPost("GetCustomerPointAwardReportData")]
        public async Task<CustomerPointAwardReport> GetCustomerPointAwardReportData(ReportParameters obj)
        {
            return await bl.GetCustomerPointAwardReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Points Redeem Data
        [HttpPost("GetCustomerPointRedeemReportData")]
        public async Task<CustomerPointRedeemReport> GetCustomerPointRedeemReportData(ReportParameters obj)
        {
            return await bl.GetCustomerPointRedeemReportData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Shift Summary
        #region Shift Pump Reading
        [HttpPost("Generateshiftpumpreadingreportdata")]
        public async Task<ShiftPumpReadingReport> Generateshiftpumpreadingreportdata(ReportParameters obj)
        {
            return await bl.Generateshiftpumpreadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Shift Tank Reading
        [HttpPost("Generateshifttankreadingreportdata")]
        public async Task<ShiftTankReadingDetails> Generateshifttankreadingreportdata(ReportParameters obj)
        {
            return await bl.Generateshifttankreadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Shift Lube Lpg Reading
        [HttpPost("Generateshiftlubelpgreadingreportdata")]
        public async Task<ShiftLpgLubeReadingDetails> Generateshiftlubelpgreadingreportdata(ReportParameters obj)
        {
            return await bl.Generateshiftlubelpgreadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Shift Expenses Reading
        [HttpPost("Generateshiftexpensesreadingreportdata")]
        public async Task<ShiftExpensesDetails> Generateshiftexpensesreadingreportdata(ReportParameters obj)
        {
            return await bl.Generateshiftexpensesreadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Shift Credit Sales Reading
        [HttpPost("Generateshiftcreditsalereadingreportdata")]
        public async Task<ShiftCreditSalesDetails> Generateshiftcreditsalereadingreportdata(ReportParameters obj)
        {
            return await bl.Generateshiftcreditsalereadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Shift Cash Drops Reading
        [HttpPost("Generateshiftcashdropreadingreportdata")]
        public async Task<ShiftCashDropsDetails> Generateshiftcashdropreadingreportdata(ReportParameters obj)
        {
            return await bl.Generateshiftcashdropreadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Shift Purchases Reading
        [HttpPost("Generateshiftpurchasereadingreportdata")]
        public async Task<ShiftpurchasesReadingDetails> Generateshiftpurchasereadingreportdata(ReportParameters obj)
        {
            return await bl.Generateshiftpurchasereadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Station Shift Reading
        [HttpPost("Generatestationshiftreadingreportdata")]
        public async Task<StationShiftDetailsData> Generatestationshiftreadingreportdata(ReportParameters obj)
        {
            return await bl.Generatestationshiftreadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Station Shift Summary Reading
        [HttpPost("Generatestationshiftsummaryreadingreportdata")]
        public async Task<StationShiftSummaryDetailsData> Generatestationshiftsummaryreadingreportdata(ReportParameters obj)
        {
            return await bl.Generatestationshiftsummaryreadingreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion
        #region Station Customer Statement Reading
        [HttpPost("Generatestationshiftcustomerstatementreportdata")]
        [AllowAnonymous]
        public async Task<ShiftCustomerStatementData> Generatestationshiftcustomerstatementreportdata(ReportParameters obj)
        {
            return await bl.Generatestationshiftcustomerstatementreportdata(JsonConvert.SerializeObject(obj));
        }
        #endregion
        #endregion
    }
}
