using DBL.Models;

namespace DBL.Repositories
{
    public interface ISalesTransactionRepository
    {
        SingleFinanceTransactions PostSaleTransaction(string jsonObjectdata);
        Genericmodel PostReverseSaleTransactionData(string jsonObjectdata);
        IEnumerable<FinanceTransactions> Getallofflinesalesdata(long TenantId);
        SingleFinanceTransactions Getsingleofflinesalesdata(long FinanceTransactionId, long AccountId);
        Genericmodel ProcessAutomationsalesData(string jsonObjectdata);
    }
}
