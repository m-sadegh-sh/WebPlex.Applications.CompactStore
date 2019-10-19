namespace WebPlex.Applications.CompactStore.Security {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.SessionState;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Extensions;
    using WebPlex.Applications.CompactStore.Helpers;
    using WebPlex.Applications.CompactStore.Models;

    public sealed class CustomerContext : Singleton<CustomerContext> {
        private const string CUSTOMER_SESSION_KEY = "$currentCustomer$";

        private readonly HttpSessionState _currentSession;
        private readonly ICustomerRepository _customerRepository;
        private CustomerModel _cachedCustomer;

        public CustomerContext() {
            if (HttpContext.Current != null) {
                _currentSession = HttpContext.Current.Session;
                _customerRepository = DependencyResolver.Current.GetService<ICustomerRepository>();
            }
        }

        public bool IsAuthenticated {
            get { return Customer != null && !Customer.IsLockedOut(); }
        }

        public CustomerModel Customer {
            get {
                if (_cachedCustomer == null && CurrentCustomerId != null)
                    _cachedCustomer = _customerRepository.GetById((int) CurrentCustomerId);

                return _cachedCustomer;
            }

            set {
                CurrentCustomerId = value == null ? null : (int?) value.Id;
                _cachedCustomer = value;
            }
        }

        private int? CurrentCustomerId {
            get {
                if (_currentSession == null)
                    return null;

                return (int?) _currentSession[CUSTOMER_SESSION_KEY];
            }
            set {
                if (_currentSession == null)
                    return;

                _currentSession[CUSTOMER_SESSION_KEY] = value;
            }
        }
    }
}
