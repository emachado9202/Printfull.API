using System.Runtime.CompilerServices;
using Printful.API.Repository;

namespace Printful.API
{
    public class RepositoryBroker
    {
        private static RepositoryBroker singleton = null;
        private static object padlock = new object();

        private RepositoryBroker()
        {
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            lock (padlock)
            {
                if (singleton == null)
                {
                    singleton = new RepositoryBroker();
                    singleton.Product = new ProductImplRepo();
                    singleton.Order = new OrderImplRepo();
                    singleton.File = new FileImplRepo();
                    singleton.ShippingRate = new ShippingRateImplRepo();
                    singleton.E_commerce = new E_commerceImplRepo();
                    singleton.CountryState = new CountryStateImplRepo();
                    singleton.TaxRate = new TaxRateImplRepo();
                    singleton.StoreRepo = new StoreImplRepo();
                    singleton.MockupRepo = new MockupImplRepo();
                }
            }
        }

        public static RepositoryBroker Instance
        {
            get
            {
                if (singleton == null)
                    CreateInstance();

                return singleton;
            }
        }

        public ProductRepo Product { get; private set; }
        public OrderRepo Order { get; private set; }
        public FileRepo File { get; private set; }
        public ShippingRateRepo ShippingRate { get; private set; }
        public E_commerceRepo E_commerce { get; private set; }
        public CountryStateRepo CountryState { get; private set; }
        public TaxRateRepo TaxRate { get; private set; }
        public StoreRepo StoreRepo { get; private set; }
        public MockupRepo MockupRepo { get; private set; }
    }
}