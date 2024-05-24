using DBL;
using DBL.Entities;
using DBL.Models;
using Everestfcsapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Everestfcsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerManagementController : ControllerBase
    {
        private readonly BL bl;
        IConfiguration _config;
        public CustomerManagementController(IConfiguration config)
        {
            bl = new BL(Util.ShareConnectionString(config));
            _config = config;
        }

        #region Authenticate Customer Data
        [AllowAnonymous]
        [Route("AuthenticateCustomer"), HttpPost]
        public async Task<ActionResult> AuthenticateCustomerAsync([FromBody] Usercred userdata)
        {
            var _customerData = await bl.ValidateSystemCustomer(userdata.username, userdata.password);
            if (_customerData.RespStatus == 1)
                return Unauthorized(new CustomermodelResponce
                {
                    RespStatus = 401,
                    RespMessage = _customerData.RespMessage,
                    Token = "",
                    CustomerModel = new CustomermodeldataResponce()
                });
            if (_customerData.RespStatus == 2)
                return StatusCode(StatusCodes.Status500InternalServerError, _customerData.RespMessage);
            var claims = new[] {
                     new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                     new Claim("CustomerId", _customerData.CustomerModel.CustomerId.ToString()),
                 };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new CustomermodelResponce
            {
                RespStatus = 200,
                RespMessage = "Ok",
                Token = tokenString,
                CustomerModel = _customerData.CustomerModel
            });
        }
        #endregion

        #region System Customer Data
        [HttpGet("GetSystemCustomerData/{TenantId}/{Offset}/{Count}")]
        public async Task<IEnumerable<SystemCustomerModel>> GetSystemCustomerData(long TenantId,int Offset, int Count)
        {
            return await bl.GetSystemCustomerData(TenantId,Offset, Count);
        }
        [HttpGet("GetSystemCustomerData/{TenantId}/{SearchParam}/{Offset}/{Count}")]
        public async Task<IEnumerable<SystemCustomerModel>> GetSystemCustomerData(long TenantId,string SearchParam, int Offset, int Count)
        {
            return await bl.GetSystemCustomerData(TenantId,SearchParam, Offset, Count);
        }

        [HttpPost("RegisterCustomerData")]
        public async Task<Genericmodel> RegisterCustomerData(SystemCustomer obj)
        {
            return await bl.RegisterCustomerData(obj);
        }
        [HttpGet("GetSystemCustomerData/{CustomerId}")]
        public async Task<SystemCustomer> GetSystemCustomerData(long CustomerId)
        {
            return await bl.GetSystemCustomerData(CustomerId);
        }

        [HttpGet("GetSystemCustomerDetailData/{CustomerId}")]
        public async Task<SystemCustomerDetails> GetSystemCustomerDetailData(long CustomerId)
        {
            return await bl.GetSystemCustomerDetailData(CustomerId);
        }
        [HttpPost("GetSystemCustomerAccountCardDetailData")]
        public async Task<CustomerCardDetailsData> GetSystemCustomerAccountCardDetailData(PostcardDetails obj)
        {
            return await bl.GetSystemCustomerAccountCardDetailData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Agreements
        [HttpPost("RegisterCustomerPrepaidAgreementData")]
        public async Task<Genericmodel> RegisterCustomerPrepaidAgreementData(CustomerPrepaidAgreement obj)
        {
            return await bl.RegisterCustomerPrepaidAgreementData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomerprepaidagreementdatabyid/{CustomerAgreementId}")]
        public async Task<CustomerPrepaidAgreement> Getcustomerprepaidagreementdatabyid(long CustomerAgreementId)
        {
            return await bl.Getcustomerprepaidagreementdatabyid(CustomerAgreementId);
        }
        [HttpPost("RegisterCustomerPostpaidRecurrentAgreementData")]
        public async Task<Genericmodel> RegisterCustomerPostpaidRecurrentAgreementData(PostpaidRecurentAgreement obj)
        {
            return await bl.RegisterCustomerPostpaidRecurrentAgreementData(JsonConvert.SerializeObject(obj));
        }

        [HttpPost("RegisterCustomerPostpaidOneoffAgreementData")]
        public async Task<Genericmodel> RegisterCustomerPostpaidOneoffAgreementData(PostpaidOneOffAgreement obj)
        {
            return await bl.RegisterCustomerPostpaidOneoffAgreementData(JsonConvert.SerializeObject(obj));
        }

        [HttpPost("RegisterCustomerPostpaidCreditAgreementData")]
        public async Task<Genericmodel> RegisterCustomerPostpaidCreditAgreementData(CustomerCreditAgreement obj)
        {
            return await bl.RegisterCustomerPostpaidCreditAgreementData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomerpostpaidcreditagreementdatabyid/{CustomerAgreementId}")]
        public async Task<CustomerCreditAgreement> Getcustomerpostpaidcreditagreementdatabyid(long CustomerAgreementId)
        {
            return await bl.Getcustomerpostpaidcreditagreementdatabyid(CustomerAgreementId);
        }

        #endregion

        #region customer Agreement Topups
        [HttpGet("GetSystemCustomerAgreementtopuptransferData/{Agreementaccountid}")]
        public async Task<IEnumerable<CustomerAccountTopups>> GetSystemCustomerAgreementtopuptransferData(long Agreementaccountid)
        {
            return await bl.GetSystemCustomerAgreementtopuptransferData(Agreementaccountid);
        }
        #endregion

        #region Customer Agreements Payment
        [HttpPost("RegisterCustomerAgreementPaymentData")]
        public async Task<Genericmodel> RegisterCustomerAgreementPaymentData(CustomerAgreementPayment obj)
        {
            return await bl.RegisterCustomerAgreementPaymentData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("GetSystemCustomerAgreementPaymentListData/{Agreementid}")]
        public async Task<IEnumerable<CustomerAgreementPayments>> GetSystemCustomerAgreementPaymentListData(long Agreementid)
        {
            return await bl.GetSystemCustomerAgreementPaymentListData(Agreementid);
        }
        #endregion

        #region Reverse Sales And Topups Payment
        [HttpPost("PostReverseTopupTransactionData")]
        public async Task<Genericmodel> PostReverseTopupTransactionData(ReverseSaleRequestData obj)
        {
            return await bl.PostReverseTopupTransactionData(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("PostReversePaymentTransactionData")]
        public async Task<Genericmodel> PostReversePaymentTransactionData(ReverseSaleRequestData obj)
        {
            return await bl.PostReversePaymentTransactionData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Agreements Account
        [HttpPost("RegisterCustomerAgreementAccountData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountData(CustomerAgreementAccountData obj)
        {
            return await bl.RegisterCustomerAgreementAccountData(obj);
        }

        [HttpPost("RegisterCustomerAgreementAccountTopupData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountTopupData(CustomerAccountTopup obj)
        {
            return await bl.RegisterCustomerAgreementAccountTopupData(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("RegisterCustomerAgreementAccountTransferData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountTransferData(CustomerAccountTransfer obj)
        {
            return await bl.RegisterCustomerAgreementAccountTransferData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("GetSystemCustomerAccountDetailData/{AccountId}")]
        public async Task<SystemAccountDetailData> GetSystemCustomerAccountDetailData(long AccountId)
        {
            return await bl.GetSystemCustomerAccountDetailData(AccountId);
        }
        [HttpPost("GetSystemCustomerAndAccountDetailData")]
        public async Task<SystemCustomerAndAccountDetailData> GetSystemCustomerAndAccountDetailData(Systemcustomercarddata obj)
        {
            return await bl.GetSystemCustomerAndAccountDetailData(obj);
        }

        #region Replace Customer Account Mask
        [HttpPost("Replacecustomeraccountcarddata")]
        public async Task<Genericmodel> Replacecustomeraccountcarddata(AccountCardReplaceDetails obj)
        {
            return await bl.Replacecustomeraccountcarddata(obj);
        }
        #endregion


        #region Customer Account Policy
        [HttpGet("GetSystemCustomerAccountPolicyDetailData/{AccountId}")]
        public async Task<CustomerAccountDetails> GetSystemCustomerAccountPolicyDetailData(long AccountId)
        {
            return await bl.GetSystemCustomerAccountPolicyDetailData(AccountId);
        }

        [HttpPost("RegisterCustomerAgreementAccountProductPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountProductPolicyData(AccountProductpolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountProductPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("GetcustomeraccountproductpolicyData/{AccountProductId}")]
        public async Task<AccountProductpolicy> GetcustomeraccountproductpolicyData(long AccountProductId)
        {
            return await bl.GetcustomeraccountproductpolicyData(AccountProductId);
        }
        [HttpPost("RegisterCustomerAgreementAccountStationPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountStationPolicyData(AccountStationspolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountStationPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountstationpolicydata/{AccountStationId}")]
        public async Task<AccountStationspolicy> Getcustomeraccountstationpolicydata(long AccountStationId)
        {
            return await bl.Getcustomeraccountstationpolicydata(AccountStationId);
        }
        [HttpPost("RegisterCustomerAgreementAccountWeekdayPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountWeekdayPolicyData(AccountWeekDayspolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountWeekdayPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountweekdaypolicydata/{AccountWeekDaysId}")]
        public async Task<AccountWeekDayspolicy> Getcustomeraccountweekdaypolicydata(long AccountWeekDaysId)
        {
            return await bl.Getcustomeraccountweekdaypolicydata(AccountWeekDaysId);
        }
        [HttpPost("RegisterCustomerAgreementAccountFrequencyPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountFrequencyPolicyData(AccountTransactionFrequencypolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountFrequencyPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountfrequencypolicydata/{AccountFrequencyId}")]
        public async Task<AccountTransactionFrequencypolicy> Getcustomeraccountfrequencypolicydata(long AccountFrequencyId)
        {
            return await bl.Getcustomeraccountfrequencypolicydata(AccountFrequencyId);
        }
        #endregion


        #region Customer Account Employee And Policy
        [HttpPost("RegisterCustomerAccountEmployeeData")]
        public async Task<Genericmodel> RegisterCustomerAccountEmployeeData(CustomerAccountEmployees obj)
        {
            return await bl.RegisterCustomerAccountEmployeeData(obj);
        }
        [HttpGet("GetCustomerAccountEmployeeById/{EmployeeId}")]
        public async Task<CustomerAccountEmployees> GetCustomerAccountEmployeeById(long EmployeeId)
        {
            return await bl.GetCustomerAccountEmployeeById(EmployeeId);
        }
        [HttpGet("GetSystemCustomerAccountEmployeePolicyDetailData/{EmployeeId}")]
        public async Task<CustomerAccountEmployeePolicyDetails> GetSystemCustomerAccountEmployeePolicyDetailData(long EmployeeId)
        {
            return await bl.GetSystemCustomerAccountEmployeePolicyDetailData(EmployeeId);
        }

        [HttpPost("RegisterCustomerAgreementAccountEmployeeProductPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeProductPolicyData(AccountEmployeeProductpolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEmployeeProductPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountemployeeproductpolicydata/{EmployeeProductId}")]
        public async Task<AccountEmployeeProductpolicy> Getcustomeraccountemployeeproductpolicydata(long EmployeeProductId)
        {
            return await bl.Getcustomeraccountemployeeproductpolicydata(EmployeeProductId);
        }
        [HttpPost("RegisterCustomerAgreementAccountEmployeeStationPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeStationPolicyData(AccountEmployeeStationspolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEmployeeStationPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData(AccountEmployeeWeekDayspolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEmployeeWeekdayPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountemployeeweekdaypolicydata/{EmployeeweekdayId}")]
        public async Task<AccountEmployeeWeekDayspolicy> Getcustomeraccountemployeeweekdaypolicydata(long EmployeeweekdayId)
        {
            return await bl.Getcustomeraccountemployeeweekdaypolicydata(EmployeeweekdayId);
        }
        [HttpPost("RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData(AccountEmployeeTransactionFrequencypolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEmployeeFrequencyPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountemployeefrequencypolicydata/{EmployeefrequencyId}")]
        public async Task<AccountEmployeeTransactionFrequencypolicy> Getcustomeraccountemployeefrequencypolicydata(long EmployeefrequencyId)
        {
            return await bl.Getcustomeraccountemployeefrequencypolicydata(EmployeefrequencyId);
        }
        #endregion

        #endregion

        #region Delete,Deactivate Actions
        [HttpPost("DeactivateorDeleteTableColumnData")]
        public async Task<Genericmodel> DeactivateorDeleteTableColumnData(ActivateDeactivateActions obj)
        {
            return await bl.DeactivateorDeleteTableColumnData(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("RemoveTableColumnData")]
        public async Task<Genericmodel> RemoveTableColumnData(ActivateDeactivateActions obj)
        {
            return await bl.RemoveTableColumnData(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("DefaultThisTableColumnData")]
        public async Task<Genericmodel> DefaultThisTableColumnData(ActivateDeactivateActions obj)
        {
            return await bl.DefaultThisTableColumnData(JsonConvert.SerializeObject(obj));
        }
        #endregion

        #region Customer Account Equipments
        [HttpPost("RegisterCustomerAccountEquipmentData")]
        public async Task<Genericmodel> RegisterCustomerAccountEquipmentData(CustomerAccountEquipments obj)
        {
            return await bl.RegisterCustomerAccountEquipmentData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("GetSystemCustomerAccountEquipmentData/{EquipmentId}")]
        public async Task<CustomerAccountEquipments> GetSystemCustomerAccountEquipmentData(long EquipmentId)
        {
            return await bl.GetSystemCustomerAccountEquipmentData(EquipmentId);
        }
        [HttpGet("GetSystemCustomerAccountEquipmentPolicyDetailData/{EquipmentId}")]
        public async Task<CustomerAccountEquipmentPolicyDetails> GetSystemCustomerAccountEquipmentPolicyDetailData(long EquipmentId)
        {
            return await bl.GetSystemCustomerAccountEquipmentPolicyDetailData(EquipmentId);
        }

        [HttpPost("RegisterCustomerAgreementAccountEquipmentProductPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentProductPolicyData(AccountEquipmentProductpolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEquipmentProductPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountequipmentproductpolicydata/{EquipmentProductId}")]
        public async Task<AccountEquipmentProductpolicy> Getcustomeraccountequipmentproductpolicydata(long EquipmentProductId)
        {
            return await bl.Getcustomeraccountequipmentproductpolicydata(EquipmentProductId);
        }

        [HttpPost("RegisterCustomerAgreementAccountEquipmentStationPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentStationPolicyData(AccountEquipmentStationspolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEquipmentStationPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpPost("RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData(AccountEquipmentWeekDayspolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEquipmentWeekdayPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountequipmentweekdaypolicydata/{EquipmentWeekDaysId}")]
        public async Task<AccountEquipmentWeekDayspolicy> Getcustomeraccountequipmentweekdaypolicydata(long EquipmentWeekDaysId)
        {
            return await bl.Getcustomeraccountequipmentweekdaypolicydata(EquipmentWeekDaysId);
        }
        [HttpPost("RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData")]
        public async Task<Genericmodel> RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData(AccountEquipmentTransactionFrequencypolicy obj)
        {
            return await bl.RegisterCustomerAgreementAccountEquipmentFrequencyPolicyData(JsonConvert.SerializeObject(obj));
        }
        [HttpGet("Getcustomeraccountequipmentfrequencypolicydata/{EquipmentFrequencyId}")]
        public async Task<AccountEquipmentTransactionFrequencypolicy> Getcustomeraccountequipmentfrequencypolicydata(long EquipmentFrequencyId)
        {
            return await bl.Getcustomeraccountequipmentfrequencypolicydata(EquipmentFrequencyId);
        }
        #endregion

        #region Authorize Customer And Employee
        [Route("Authorizecustomerordriver"), HttpPost]
        public async Task<ActionResult> AuthorizeCustomerorDriver([FromBody] CustomerDriverRequest CustomerDriverData)
        {
            var Resp = await bl.ValidateSystemCustomerorDriver(CustomerDriverData);
            if (Resp.RespStatus == 1)
                return Unauthorized(new CustomerDriverResponse
                {
                    RespStatus = 401,
                    RespMessage = Resp.RespMessage
                });
            if (Resp.RespStatus == 2)
                return StatusCode(StatusCodes.Status500InternalServerError, Resp.RespMessage);
            return Ok(new CustomerDriverResponse
            {
                RespStatus = 200,
                RespMessage = "OK",
                RequestResponseId = Convert.ToInt64(Resp.Data1),
            });
        }
        #endregion

    }
}
