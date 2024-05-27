using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface ICustomerRepository
    {
        #region Verify System Customer
        CustomermodelResponce VerifySystemCustomer(string Username);
        #endregion

        #region System Customers
        IEnumerable<SystemCustomerModel> GetSystemCustomerData(long TenantId,int Offset, int Count);
        IEnumerable<SystemCustomerModel> GetSystemCustomerData(long TenantId, string SearchParam, int Offset, int Count);
        Genericmodel RegisterCustomerData(string jsonObjectdata);
        SystemCustomer GetSystemCompanyCustomerData(long CustomerId);
        SystemCustomerDetails GetSystemCustomerDetailData(long CustomerId);
        IEnumerable<SystemCustomerAgreementsData> GetSystemCustomerAgreementData(long CustomerId);
        CustomerCardDetailsData GetSystemCustomerAccountCardDetailData(string jsonObjectdata);
        SystemCustomerModel Resendcustomerpassword(long CustomerId);
        #endregion

        #region Customer Agreement
        Genericmodel RegisterCustomerPrepaidAgreementData(string jsonObjectdata);
        CustomerPrepaidAgreement Getcustomerprepaidagreementdatabyid(long CustomerAgreementId);
        Genericmodel RegisterCustomerPostpaidRecurrentAgreementData(string jsonObjectdata);
        Genericmodel RegisterCustomerPostpaidOneoffAgreementData(string jsonObjectdata);
        Genericmodel RegisterCustomerPostpaidCreditAgreementData(string jsonObjectdata);
        CustomerCreditAgreement Getcustomerpostpaidcreditagreementdatabyid(long CustomerAgreementId);

        #endregion

        #region Customer Agreement Payements
        Genericmodel RegisterCustomerAgreementPaymentData(string jsonObjectdata);
        IEnumerable<CustomerAgreementPayments> GetSystemCustomerAgreementPaymentListData(long Agreementid);
        #endregion

        #region Customer Agreement Topups
        IEnumerable<CustomerAccountTopups> GetSystemCustomerAgreementtopuptransferData(long Agreementaccountid);
        #endregion

        #region Reverse Topup and Payment
        Genericmodel PostReverseTopupTransactionData(string jsonObjectdata);
        Genericmodel PostReversePaymentTransactionData(string jsonObjectdata);
        #endregion

        #region Customer Agreement Accounts
        Genericmodel RegisterCustomerAgreementAccountData(string jsonObjectdata);
        Genericmodel RegisterCustomerAgreementAccountTopupData(string jsonObjectdata);
        Genericmodel RegisterCustomerAgreementAccountTransferData(string jsonObjectdata);
        SystemAccountDetailData GetSystemCustomerAccountDetailData(long AccountId);
        SystemAccountDetailData GetSystemCustomerAccountDetailData(string CardNumber);
        SystemCustomerAndAccountDetailData GetSystemCustomerAndAccountDetailData(Systemcustomercarddata entity);
        CustomerAccountDetails GetSystemCustomerAccountPolicyDetailData(long AccountId);
        Genericmodel RegisterCustomerAgreementAccountProductPolicyData(string jsonObjectdata);
        AccountProductpolicy GetcustomeraccountproductpolicyData(long AccountProductId);
        Genericmodel RegisterCustomerAgreementAccountStationPolicyData(string jsonObjectdata);
        AccountStationspolicy Getcustomeraccountstationpolicydata(long AccountStationId);
        Genericmodel RegisterCustomerAgreementAccountWeekdayPolicyData(string jsonObjectdata);
        AccountWeekDayspolicy Getcustomeraccountweekdaypolicydata(long AccountWeekDaysId);
        Genericmodel RegisterCustomerAgreementAccountFrequencyPolicyData(string jsonObjectdata);
        AccountTransactionFrequencypolicy Getcustomeraccountfrequencypolicydata(long AccountFrequencyId);
        Genericmodel Replacecustomeraccountcarddata(string jsonObjectdata);

        #endregion

        #region Customer Account Employee
        Genericmodel RegisterCustomerAccountEmployeeData(string jsonObjectdata);
        CustomerAccountEmployees GetCustomerAccountEmployeeById(long EmployeeId);
        CustomerAccountEmployeePolicyDetails GetSystemCustomerAccountEmployeePolicyDetailData(long EmployeeId);
        Genericmodel RegisterCustomerAgreementAccountEmployeeProductPolicyData(string jsonObjectdata);
        AccountEmployeeProductpolicy Getcustomeraccountemployeeproductpolicydata(long EmployeeProductId);
        Genericmodel RegisterCustomerAgreementAccountEmployeeStationPolicyData(string jsonObjectdata);
        Genericmodel RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData(string jsonObjectdata);
        AccountEmployeeWeekDayspolicy Getcustomeraccountemployeeweekdaypolicydata(long EmployeeweekdayId);
        Genericmodel RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData(string jsonObjectdata);
        AccountEmployeeTransactionFrequencypolicy Getcustomeraccountemployeefrequencypolicydata(long EmployeefrequencyId);
        #endregion

        #region Customer Account Equipments
        Genericmodel RegisterCustomerAccountEquipmentData(string jsonObjectdata);
        CustomerAccountEquipments GetSystemCustomerAccountEquipmentData(long EquipmentId);
        CustomerAccountEquipmentPolicyDetails GetSystemCustomerAccountEquipmentPolicyDetailData(long EquipmentId);
        Genericmodel RegisterCustomerAgreementAccountEquipmentProductPolicyData(string jsonObjectdata);
        AccountEquipmentProductpolicy Getcustomeraccountequipmentproductpolicydata(long EquipmentProductId);
        Genericmodel RegisterCustomerAgreementAccountEquipmentStationPolicyData(string jsonObjectdata);
        Genericmodel RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData(string jsonObjectdata);
        AccountEquipmentWeekDayspolicy Getcustomeraccountequipmentweekdaypolicydata(long EquipmentWeekDaysId);
        Genericmodel RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData(string jsonObjectdata);
        AccountEquipmentTransactionFrequencypolicy Getcustomeraccountequipmentfrequencypolicydata(long EquipmentFrequencyId);
        #endregion

        #region Validate customer
        Genericmodel ValidateSystemCustomer(long RequestId, string EncryptedPin);
        #endregion

        #region Validate customer employee
        Genericmodel ValidateSystemCustomeremployee(long RequestId, string EncryptedPin);
        #endregion
    }
}
