using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface ISetupRepository
    {
        SystemGadgetResponseModel SystemGadgetsAppSetUp(string SerialNumber);
        SystemStationRelatedData GetSystemStationRelatedData(long StationId);
        IEnumerable<SystemGadgetsData> GetSystemGadgetsData(int Offset, int Count);
        Genericmodel RegisterSystemGadgets(string JsonObjectdata);
        Systemgadgets GetSystemGadgetsDataById(long GadgetId);
        IEnumerable<SystemTenantsCardData> GetSystemTenantCardData(long TenantId, int Offset, int Count);
        Genericmodel RegisterSystemTenantCards(string JsonObjectdata);
        SystemTenantCard GetSystemTenantCardDataById(long CardId);
        Genericmodel GetSystemTenantCardById(long Tenantcardid);
        Genericmodel Getcustomercardbycardcode(string CardCode);
    }
}
