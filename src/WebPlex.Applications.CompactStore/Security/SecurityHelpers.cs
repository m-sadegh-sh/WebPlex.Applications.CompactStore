namespace WebPlex.Applications.CompactStore.Security {
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using WebPlex.Applications.CompactStore.Helpers;
    using WebPlex.Applications.CompactStore.Models;

    public static class SecurityHelpers {
        public static string GenerateToken(int size = 12) {
            var salt = GenerateSalt(size * 2);
            var slug = StringHelpers.Slugify(salt);
            return slug.Replace("-", "").Substring(0, size);
        }

        public static string GenerateSalt(int size = 12) {
            var random = new RNGCryptoServiceProvider();
            var salt = new byte[size];
            random.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt) {
            var combinedPassword = string.Concat(password, salt);
            var sha256 = new SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(combinedPassword);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string enteredPassword, string storedHash, string storedSalt) {
            var hash = HashPassword(enteredPassword, storedSalt);

            return storedHash == hash;
        }

        internal static void UpdateCustomerPassword(CustomerModel customer, string newPassword, bool updateResetPasswordToken) {
            customer.SecuredSalt = GenerateSalt();
            customer.SecuredPassword = HashPassword(newPassword, customer.SecuredSalt);

            if (updateResetPasswordToken) {
                customer.ResetPasswordToken = null;
                customer.ResetPasswordRequestedDateUtc = null;
            }
        }
    }
}
