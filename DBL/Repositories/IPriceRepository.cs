using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface IPriceRepository
    {
        SystemPriceListData GetSystemPriceListData(long TenantId);
       
        Genericmodel Registerpricelistdata(string jsonObjectdata);
        PriceListInfoData Getsystempricelistdatabyid(long PricelistId);
        Genericmodel Editsystempricelistdata(string jsonObjectdata);
        Genericmodel Addpricelistpricenewdata(string jsonObjectdata);
        PriceListData GetSystemCustomerAgreementPriceListData(long PricelistId);


        SystemDiscountListData GetSystemDiscountListData(long TenantId);
        Genericmodel Registerdiscountlistdata(string jsonObjectdata);
        DiscountListModelData Getsystemdiscountlistdatabyid(long DiscountlistId);
        Genericmodel Editsystemdiscountlistdata(string jsonObjectdata);
        Genericmodel Adddicountlistvaluenewdata(string jsonObjectdata);
        DiscountListData GetSystemCustomerAgreementDiscountListData(long DiscountListId);
    }
}
