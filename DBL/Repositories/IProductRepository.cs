using DBL.Entities;
using DBL.Models;

namespace DBL.Repositories
{
    public interface IProductRepository
    {
        #region Station Products Data
        IEnumerable<SystemProductModelData> GetSystemProductvariationData(long TenantId);
        IEnumerable<SystemProductModelData> GetSystemStationProductData(long TenantId,long StationId);
        Genericmodel RegisterSystemProduct(string JsonObjectdata);
        SystemProductVariation GetSystemProductDetailDataById(long ProductVariationId);
        Genericmodel UpdateSystemProduct(string JsonObjectdata);
        #endregion

        #region Main Store Listing
        IEnumerable<DryStockMainStoreModelData> Getsystemproductmainstoredata(long TenantId, long StationId);
        Genericmodel Savetransfertoaccessoriesdata(string JsonObjectdata);
        #endregion
    }
}
