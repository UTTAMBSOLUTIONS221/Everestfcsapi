using Dapper;
using DBL.Entities;
using DBL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DBL.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }
        #region Verify System Customer
        public CustomermodelResponce VerifySystemCustomer(string Username)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                CustomermodelResponce resp = new CustomermodelResponce();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", Username);
                parameters.Add("@@CustomerDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_Everestfcsverifysystemcustomer", parameters, commandType: CommandType.StoredProcedure);
                string customerDetailsJson = parameters.Get<string>("@CustomerDetails");
                JObject responseJson = JObject.Parse(customerDetailsJson);
                if (Convert.ToInt32(responseJson["RespStatus"]) == 0)
                {
                    string customerModelJson = responseJson["Customermodel"].ToString();
                    CustomermodeldataResponce customerResponse = JsonConvert.DeserializeObject<CustomermodeldataResponce>(customerModelJson);
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.CustomerModel = customerResponse;
                    return resp;
                }
                else
                {
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.CustomerModel = new CustomermodeldataResponce();
                    return resp;
                }
            }
        }
        #endregion

        #region System Customers
        public IEnumerable<SystemCustomerModel> GetSystemCustomerData(long TenantId, int Offset, int Count)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@Offset", Offset);
                parameters.Add("@Count", Count);
                return connection.Query<SystemCustomerModel>("Usp_GetSystemCustomerData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<SystemCustomerModel> GetSystemCustomerData(long TenantId, string SearchParam, int Offset, int Count)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenantId", TenantId);
                parameters.Add("@SearchParam", SearchParam);
                parameters.Add("@Offset", Offset);
                parameters.Add("@Count", Count);
                return connection.Query<SystemCustomerModel>("Usp_GetSystemCustomerDataSearch", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public Genericmodel RegisterCustomerData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterSystemCustomerData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemCustomer GetSystemCompanyCustomerData(long CustomerId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", CustomerId);
                return connection.Query<SystemCustomer>("Usp_GetSystemCompanyCustomerDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemCustomerAgreements GetSystemCustomerData(long CustomerId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", CustomerId);
                return connection.Query<SystemCustomerAgreements>("Usp_GetSystemCustomerData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CustomerCardDetailsData GetSystemCustomerAccountCardDetailData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                CustomerCardDetailsData resp = new CustomerCardDetailsData();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                parameters.Add("@CustomerAccountDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemCustomerAccountCardDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerDetailsJson = parameters.Get<string>("@CustomerAccountDetailsJson");
                JObject responseJson = JObject.Parse(customerDetailsJson);
                if (Convert.ToInt32(responseJson["RespStatus"]) == 0)
                {
                    string accountCardModelJson = responseJson["CustomerAccountCardDetail"].ToString();
                    CustomerAccountCardDetail accountCardResponse = JsonConvert.DeserializeObject<CustomerAccountCardDetail>(accountCardModelJson);
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.CustomerAccountCardDetail = accountCardResponse;
                    return resp;
                }
                else
                {
                    resp.RespStatus = Convert.ToInt32(responseJson["RespStatus"]);
                    resp.RespMessage = responseJson["RespMessage"].ToString();
                    resp.CustomerAccountCardDetail = new CustomerAccountCardDetail();
                    return resp;
                }



            }
        }
        public SystemCustomerModel Resendcustomerpassword(long CustomerId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", CustomerId);
                parameters.Add("@Staffdetaildata", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemStaffUserDetailData", parameters, commandType: CommandType.StoredProcedure);
                string roledetailDetailsJson = parameters.Get<string>("@Staffdetaildata");
                return JsonConvert.DeserializeObject<SystemCustomerModel>(roledetailDetailsJson);
            }
        }
        #endregion

        #region Customer Agreements

        public Genericmodel RegisterCustomerPrepaidAgreementData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerPrepaidAgreementData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CustomerPrepaidAgreement Getcustomerprepaidagreementdatabyid(long CustomerAgreementId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerAgreementId", CustomerAgreementId);
                return connection.Query<CustomerPrepaidAgreement>("Usp_Getcustomerprepaidagreementdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel RegisterCustomerPostpaidRecurrentAgreementData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerPostpaidRecurrentAgreementData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerPostpaidOneoffAgreementData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerPostpaidOneOffAgreementData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel RegisterCustomerPostpaidCreditAgreementData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerPostpaidCreditAgreementData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CustomerCreditAgreement Getcustomerpostpaidcreditagreementdatabyid(long CustomerAgreementId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerAgreementId", CustomerAgreementId);
                return connection.Query<CustomerCreditAgreement>("Usp_Getcustomerpostpaidcreditagreementdatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemCustomerDetails GetSystemCustomerDetailData(long CustomerId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", CustomerId);
                parameters.Add("@CustomerDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemCustomerDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerDetailsJson = parameters.Get<string>("@CustomerDetails");
                return JsonConvert.DeserializeObject<SystemCustomerDetails>(customerDetailsJson);
            }
        }
        public IEnumerable<SystemCustomerAgreementsData> GetSystemCustomerAgreementData(long CustomerId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", CustomerId);
                return connection.Query<SystemCustomerAgreementsData>("Usp_GetSystemCustomeAgreementData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        #endregion

        #region Customer Agreement Topups
        public IEnumerable<CustomerAccountTopups> GetSystemCustomerAgreementtopuptransferData(long Agreementaccountid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Agreementaccountid", Agreementaccountid);
                return connection.Query<CustomerAccountTopups>("Usp_GetSystemCustomerAgreementtopuptransferData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion

        #region Customer Agreements Payments
        public Genericmodel RegisterCustomerAgreementPaymentData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementPaymentData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<CustomerAgreementPayments> GetSystemCustomerAgreementPaymentListData(long Agreementid)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AgreementId", Agreementid);
                return connection.Query<CustomerAgreementPayments>("Usp_GetSystemCustomerAgreementPaymentListData", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion

        #region Reverse Topup and Payment
        public Genericmodel PostReverseTopupTransactionData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_PostReverseTopupTransactionData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel PostReversePaymentTransactionData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_PostReversePaymentTransactionData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Customer Agreements Accounts
        public Genericmodel RegisterCustomerAgreementAccountData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Genericmodel RegisterCustomerAgreementAccountTopupData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountTopupData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountTransferData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountTransferData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SystemAccountDetailData GetSystemCustomerAccountDetailData(long AccountId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AccountId", AccountId);
                parameters.Add("@CustomerAccountDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetCustomerAccountDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerAccountDetailsJson = parameters.Get<string>("@CustomerAccountDetailsJson");
                if (customerAccountDetailsJson != null)
                {
                    return JsonConvert.DeserializeObject<SystemAccountDetailData>(customerAccountDetailsJson);
                }
                else
                {
                    return new SystemAccountDetailData();
                }
            }
        }

        public SystemAccountDetailData GetSystemCustomerAccountDetailData(string  CardNumber)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CardNumber", CardNumber);
                parameters.Add("@CustomerAccountDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetCustomerAccountCardDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerAccountDetailsJson = parameters.Get<string>("@CustomerAccountDetailsJson");
                return JsonConvert.DeserializeObject<SystemAccountDetailData>(customerAccountDetailsJson);
            }
        }
        public SystemCustomerAndAccountDetailData GetSystemCustomerAndAccountDetailData(Systemcustomercarddata entity)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SearchParameter", entity.SearchParameter);
                parameters.Add("@StationId", entity.StationId);
                parameters.Add("@CustomerAccountDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetCustomerAccountCardDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerAccountDetailsJson = parameters.Get<string>("@CustomerAccountDetailsJson");
                return JsonConvert.DeserializeObject<SystemCustomerAndAccountDetailData>(customerAccountDetailsJson);
            }
        }
        public CustomerAccountDetails GetSystemCustomerAccountPolicyDetailData(long AccountId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AccountId", AccountId);
                parameters.Add("@CustomerAccountPolicyDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemCustomerAccountPolicyDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerAccountDetailsJson = parameters.Get<string>("@CustomerAccountPolicyDetailsJson");
                return JsonConvert.DeserializeObject<CustomerAccountDetails>(customerAccountDetailsJson);
            }
        }

        public Genericmodel RegisterCustomerAgreementAccountProductPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountProductPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountProductpolicy GetcustomeraccountproductpolicyData(long AccountProductId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AccountProductId", AccountProductId);
                return connection.Query<AccountProductpolicy>("Usp_GetcustomeraccountproductpolicyDatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountStationPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountStationPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountStationspolicy Getcustomeraccountstationpolicydata(long AccountStationId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AccountStationId", AccountStationId);
                return connection.Query<AccountStationspolicy>("Usp_Getcustomeraccountstationpolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountWeekdayPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountWeekdayPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountWeekDayspolicy Getcustomeraccountweekdaypolicydata(long AccountWeekDaysId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AccountWeekDaysId", AccountWeekDaysId);
                return connection.Query<AccountWeekDayspolicy>("Usp_Getcustomeraccountweekdaypolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountFrequencyPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountFrequencyPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountTransactionFrequencypolicy Getcustomeraccountfrequencypolicydata(long AccountFrequencyId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AccountFrequencyId", AccountFrequencyId);
                return connection.Query<AccountTransactionFrequencypolicy>("Usp_Getcustomeraccountfrequencypolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel Replacecustomeraccountcarddata(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_Replacecustomeraccountcarddata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Customer Account Employee
        public Genericmodel RegisterCustomerAccountEmployeeData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAccountEmployeeData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CustomerAccountEmployees GetCustomerAccountEmployeeById(long EmployeeId)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AccountEmployeeId", EmployeeId);
                return connection.Query<CustomerAccountEmployees>("Usp_GetCustomerAccountEmployeepolicydataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CustomerAccountEmployeePolicyDetails GetSystemCustomerAccountEmployeePolicyDetailData(long EmployeeId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", EmployeeId);
                parameters.Add("@CustomerAccountEmployeePolicyDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemCustomerAccountEmployeePolicyDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerAccountDetailsJson = parameters.Get<string>("@CustomerAccountEmployeePolicyDetailsJson");
                return JsonConvert.DeserializeObject<CustomerAccountEmployeePolicyDetails>(customerAccountDetailsJson);
            }
        }

        public Genericmodel RegisterCustomerAgreementAccountEmployeeProductPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEmployeeProductPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountEmployeeProductpolicy Getcustomeraccountemployeeproductpolicydata(long EmployeeProductId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeProductId", EmployeeProductId);
                return connection.Query<AccountEmployeeProductpolicy>("Usp_Getcustomeraccountemployeeproductpolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountEmployeeStationPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEmployeeStationPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountEmployeeWeekDayspolicy Getcustomeraccountemployeeweekdaypolicydata(long EmployeeweekdayId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeweekdayId", EmployeeweekdayId);
                return connection.Query<AccountEmployeeWeekDayspolicy>("Usp_Getcustomeraccountemployeeweekdaypolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountEmployeeTransactionFrequencypolicy Getcustomeraccountemployeefrequencypolicydata(long EmployeefrequencyId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeefrequencyId", EmployeefrequencyId);
                return connection.Query<AccountEmployeeTransactionFrequencypolicy>("Usp_Getcustomeraccountemployeefrequencypolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Customer Account Equipments
        public Genericmodel RegisterCustomerAccountEquipmentData(string jsonObjectdata)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@JsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAccountEquipmentData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public CustomerAccountEquipments GetSystemCustomerAccountEquipmentData(long EquipmentId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EquipmentId", EquipmentId);
                return connection.Query<CustomerAccountEquipments>("Usp_GetSystemCustomerAccountEquipmentDataById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public CustomerAccountEquipmentPolicyDetails GetSystemCustomerAccountEquipmentPolicyDetailData(long EquipmentId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EquipmentId", EquipmentId);
                parameters.Add("@CustomerAccountEquipmentPolicyDetailsJson", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);
                var queryResult = connection.Query("Usp_GetSystemCustomerAccountEquipmentPolicyDetailData", parameters, commandType: CommandType.StoredProcedure);
                string customerAccountDetailsJson = parameters.Get<string>("@CustomerAccountEquipmentPolicyDetailsJson");
                return JsonConvert.DeserializeObject<CustomerAccountEquipmentPolicyDetails>(customerAccountDetailsJson);
            }
        }

        public Genericmodel RegisterCustomerAgreementAccountEquipmentProductPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEquipmentProductPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountEquipmentProductpolicy Getcustomeraccountequipmentproductpolicydata(long EquipmentProductId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EquipmentProductId", EquipmentProductId);
                return connection.Query<AccountEquipmentProductpolicy>("Usp_Getcustomeraccountequipmentproductpolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountEquipmentStationPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEquipmentStationPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountEquipmentWeekDayspolicy Getcustomeraccountequipmentweekdaypolicydata(long EquipmentWeekDaysId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EquipmentWeekDaysId", EquipmentWeekDaysId);
                return connection.Query<AccountEquipmentWeekDayspolicy>("Usp_Getcustomeraccountequipmentweekdaypolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Genericmodel RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData(string jsonObjectdata)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@jsonObjectdata", jsonObjectdata);
                return connection.Query<Genericmodel>("Usp_RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public AccountEquipmentTransactionFrequencypolicy Getcustomeraccountequipmentfrequencypolicydata(long EquipmentFrequencyId)
        {

            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EquipmentFrequencyId", EquipmentFrequencyId);
                return connection.Query<AccountEquipmentTransactionFrequencypolicy>("Usp_Getcustomeraccountequipmentfrequencypolicydatabyid", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Validate Customer
        public Genericmodel ValidateSystemCustomer(long RequestId, string EncryptedPin)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RequestId", RequestId);
                parameters.Add("@EncryptedPin", EncryptedPin);
                return connection.Query<Genericmodel>("Usp_ValidateSystemCustomer", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Validate Customer Employee
        public Genericmodel ValidateSystemCustomeremployee(long RequestId, string EncryptedPin)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RequestId", RequestId);
                parameters.Add("@EncryptedPin", EncryptedPin);
                return connection.Query<Genericmodel>("Usp_ValidateSystemCustomeremployee", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
    }
}
