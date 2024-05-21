using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface ISettingsRepository
    {
        #region System Permissions
        IEnumerable<Systempermissions> Getsystempermissiondata();
        Genericmodel Registersystempermissiondata(string jsonObjectdata);
        Systempermissions Getsystempermissiondatabyid(long Permissionid);
        #endregion

        #region Tenant Settings
        IEnumerable<SystemTenantAccountData> Getsystemtenantaccountdata();
        SystemTenantAccount Getsystemtenantaccountbytenantid(long TenantId);
        Genericmodel Registertenantaccountdata(string JsonObjectdata);
        #endregion

        #region System Suppliers
        IEnumerable<SupplierDetailData> Getsystemsupplierslistdata(long TenantId);
        Genericmodel Registersystemsuppliersdata(string JsonObjectdata);
        SystemSupplier Getsystemsupplierdetailbyid(long SupplierId);
        #endregion

        #region Loyalty Settings
        IEnumerable<LoyaltySettingsModelData> Getsystemloyaltysettingsdata();
        SystemLoyaltySetings GetSystemLoyaltySettingsById(long LoyaltysettId);
        SystemLoyaltySetings GetSystemLoyaltySettings(long TenantId);
        Genericmodel RegisterLoyaltySettings(string JsonObjectdata);
        #endregion

        #region Communication Templates
        IEnumerable<Communicationtemplatedata> Getsystemcommunicationtemplatedata();
        CommunicationTemplateModel Getsystemcommunicationtemplatedatabymodule(string Moduledata);
        CommunicationTemplateModel Getsystemcommunicationtemplatedatabyname(bool Isemail, string Templatename);
        Genericmodel Registersystemcommunicationtemplatedata(string jsonObjectdata);
        Communicationtemplate Getsystemcommunicationtemplatedatabyid(long Templateid);
        #endregion
    }
}
