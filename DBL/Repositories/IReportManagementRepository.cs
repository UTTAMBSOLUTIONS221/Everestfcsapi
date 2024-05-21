using DBL.Models.Reports;
using DBL.Models.Reports.ShiftSummary;

namespace DBL.Repositories
{
    public interface IReportManagementRepository
    {
        SalesTransactionsDetailsData GetSalesTransactionsReportData(string jsonObjectdata);
        CustomerPostpaidStatementDataReportData GetCustomerPostpaidStatementReportData(string jsonObjectdata);
        CustomerPaymentDataReport GetCustomerPaymentReportData(string jsonObjectdata);
        CustomerPrepaidStatementReportData GetCustomerPrepaidStatementReportData(string jsonObjectdata);
        CustomerTopupDataReport GetCustomerTopupReportData(string jsonObjectdata);
        CustomerPostpaidStatementDataReportData GetCustomerPointStatementReportData(string jsonObjectdata);
        CustomerCumulativeDataReport GetCustomerCumulativeReportData(string jsonObjectdata);
        CustomerPointAwardReport GetCustomerPointAwardReportData(string jsonObjectdata);
        CustomerPointRedeemReport GetCustomerPointRedeemReportData(string jsonObjectdata);

        #region Station Shift Summary
        ShiftPumpReadingReport Generateshiftpumpreadingreportdata(string jsonObjectdata);
        ShiftTankReadingDetails Generateshifttankreadingreportdata(string jsonObjectdata);
        ShiftLpgLubeReadingDetails Generateshiftlubelpgreadingreportdata(string jsonObjectdata);
        ShiftExpensesDetails Generateshiftexpensesreadingreportdata(string jsonObjectdata);
        ShiftCreditSalesDetails Generateshiftcreditsalereadingreportdata(string jsonObjectdata);
        ShiftCashDropsDetails Generateshiftcashdropreadingreportdata(string jsonObjectdata);
        ShiftpurchasesReadingDetails Generateshiftpurchasereadingreportdata(string jsonObjectdata);
        StationShiftDetailsData Generatestationshiftreadingreportdata(string jsonObjectdata);
        StationShiftSummaryDetailsData Generatestationshiftsummaryreadingreportdata(string jsonObjectdata);
        ShiftCustomerStatementData Generatestationshiftcustomerstatementreportdata(string jsonObjectdata);
        #endregion
    }
}
