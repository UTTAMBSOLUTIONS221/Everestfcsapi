using DBL.Repositories;

namespace DBL.UOW
{
    public interface IUnitOfWork
    {
        ISalesTransactionRepository SalesTransactionRepository { get; }
        IDashboardRepository DashboardRepository { get; }
        IGeneralRepository GeneralRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }
        ISettingsRepository SettingsRepository { get; }
        ISetupRepository SetupRepository { get; }
        IStationRepository StationRepository { get; }
        ILoyaltyRepository LoyaltyRepository { get; }
        IPriceRepository PriceRepository { get; }
    }
}
