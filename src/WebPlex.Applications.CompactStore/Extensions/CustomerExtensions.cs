namespace WebPlex.Applications.CompactStore.Extensions {
    using System;
    using WebPlex.Applications.CompactStore.Configuration;
    using WebPlex.Applications.CompactStore.Models;

    public static class CustomerExtensions {
        public static string GetDisplayName(this CustomerModel customer) {
            if (customer == null)
                return null;

            if (string.IsNullOrEmpty(customer.FirstName) && string.IsNullOrEmpty(customer.LastName))
                return customer.Email;

            if (string.IsNullOrEmpty(customer.LastName))
                return customer.FirstName;

            if (string.IsNullOrEmpty(customer.FirstName))
                return customer.LastName;

            return string.Format("{0} {1}", customer.FirstName, customer.LastName);
        }

        public static bool IsLockedOut(this CustomerModel customer) {
            if (customer == null)
                return false;

            if (customer.LockedOutDateUtc == null)
                return false;

            return ((DateTime) customer.LockedOutDateUtc).Add(AppConfiguration.Current.CustomerLockDuration) >= DateTime.Now;
        }

        public static bool IsDuplicate(this CustomerModel customer, int? id, bool freeness) {
            if (freeness)
                return customer != null;

            if (customer == null && id == null)
                return true;

            if (customer == null)
                return false;

            if (id == null)
                return false;

            return customer.Id != id;
        }
    }
}
