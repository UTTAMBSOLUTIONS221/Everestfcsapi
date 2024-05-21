using DBL.Repositories;

namespace DBL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private ISalesTransactionRepository salesTransactionRepository;
        private ISecurityRepository securityRepository;
        private IDashboardRepository dashboardRepository;
        private IGeneralRepository generalRepository;
        private ICustomerRepository customerRepository;
        private IProductRepository productRepository;
        private ISettingsRepository settingsRepository;
        private ISetupRepository setupRepository;
        private IStationRepository stationRepository;
        private ILoyaltyRepository loyaltyRepository;
        private IPriceRepository priceRepository;
        private IReportManagementRepository reportManagementRepository;
        public UnitOfWork(string connectionString) => connString = connectionString;
        public ISalesTransactionRepository SalesTransactionRepository
        {
            get { return salesTransactionRepository ?? (salesTransactionRepository = new SalesTransactionRepository(connString)); }
        }
        public ISecurityRepository SecurityRepository
        {
            get { return securityRepository ?? (securityRepository = new SecurityRepository(connString)); }
        }
        public IDashboardRepository DashboardRepository
        {
            get { return dashboardRepository ?? (dashboardRepository = new DashboardRepository(connString)); }
        }
        public IGeneralRepository GeneralRepository
        {
            get { return generalRepository ?? (generalRepository = new GeneralRepository(connString)); }
        }
        public ICustomerRepository CustomerRepository
        {
            get { return customerRepository ?? (customerRepository = new CustomerRepository(connString)); }
        }
        public IProductRepository ProductRepository
        {
            get { return productRepository ?? (productRepository = new ProductRepository(connString)); }
        }
        public ISettingsRepository SettingsRepository
        {
            get { return settingsRepository ?? (settingsRepository = new SettingsRepository(connString)); }
        }
        public ISetupRepository SetupRepository
        {
            get { return setupRepository ?? (setupRepository = new SetupRepository(connString)); }
        }
        public IStationRepository StationRepository
        {
            get { return stationRepository ?? (stationRepository = new StationRepository(connString)); }
        }
        public ILoyaltyRepository LoyaltyRepository
        {
            get { return loyaltyRepository ?? (loyaltyRepository = new LoyaltyRepository(connString)); }
        }
        public IPriceRepository PriceRepository
        {
            get { return priceRepository ?? (priceRepository = new PriceRepository(connString)); }
        }
        public IReportManagementRepository ReportManagementRepository
        {
            get { return reportManagementRepository ?? (reportManagementRepository = new ReportManagementRepository(connString)); }
        }
        public void Reset()
        {
            salesTransactionRepository = null;
            securityRepository = null;
            dashboardRepository = null;
            generalRepository = null;
            customerRepository = null;
            productRepository = null;
            settingsRepository = null;
            setupRepository = null;
            stationRepository = null;
            loyaltyRepository = null;
            priceRepository = null;
            reportManagementRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
