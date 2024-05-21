using DBL.Enums;
using DBL.Models;

namespace DBL.Repositories
{
    public interface IGeneralRepository
    {
        IEnumerable<ListModel> GetListModel(ListModelType listType);
        IEnumerable<ListModel> GetListModelbycode(ListModelType listType, long code);
        IEnumerable<ListModel> GetListModelByIdAndSearchParam(ListModelType listType, long code,string SearchParam);
        IEnumerable<ListModel> GetListModelByIdandTenantId(ListModelType listType, long TenantId, long code);
        Genericmodel DeactivateorDeleteTableColumnData(string jsonObjectdata);
        Genericmodel RemoveTableColumnData(string jsonObjectdata);
        Genericmodel DefaultThisTableColumnData(string jsonObjectdata);
    }
}
