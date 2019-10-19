namespace WebPlex.Applications.CompactStore.Configuration {
    using System;
    using WebPlex.Applications.CompactStore.Helpers;

    public class AppConfiguration : Singleton<AppConfiguration> {
        private const string STORE_DEFAULT_PAGE_SIZE_KEY = "store:DefaultPageSize";
        private const string STORE_VIEWS_COUNT_FACTOR_KEY = "store:ViewsCountFactor";
        private const string STORE_ADDED_TO_CART_COUNT_FACTOR_KEY = "store:AddedToCartCountFactor";
        private const string STORE_SENDER_EMAIL_ADDRESS_KEY = "store:SenderEmailAddress";
        private const string STORE_RECEIVER_EMAIL_ADDRESS_KEY = "store:ReceiverEmailAddress";
        private const string STORE_AFE_GATEWAY_URI_KEY = "store:AfeGatewayUri";
        private const string STORE_AFE_USER_NAME_KEY = "store:AfeUserName";
        private const string STORE_AFE_PASSWORD_KEY = "store:AfePassword";
        private const string STORE_AFE_NUMBER_KEY = "store:AfeNumber";
        private const string STORE_MAXIMUM_INVALID_CREDENTIALS_ATTEMPTS_KEY = "store:MaximumInvalidCredentialsAttempts";
        private const string STORE_CUSTOMER_LOCK_DURATION_KEY = "store:CustomerLockDuration";
        private const string STORE_CUSTOMER_RESET_PASSWORD_TOKEN_VALIDITY_DURATION_KEY = "store:CustomerResetPasswordTokenValidityDuration";

        public AppConfiguration() {
            DefaultPageSize = ConvertHelpers.GetAppSetting(STORE_DEFAULT_PAGE_SIZE_KEY, 9, 3, 30);
            ViewsCountFactor = ConvertHelpers.GetAppSetting(STORE_VIEWS_COUNT_FACTOR_KEY, 1, 0, 1);
            AddedToCartCountFactor = ConvertHelpers.GetAppSetting(STORE_ADDED_TO_CART_COUNT_FACTOR_KEY, 1, 0, 1);
            SenderEmailAddress = ConvertHelpers.GetAppSetting(STORE_SENDER_EMAIL_ADDRESS_KEY, "");
            ReceiverEmailAddress = ConvertHelpers.GetAppSetting(STORE_RECEIVER_EMAIL_ADDRESS_KEY, "");
            AfeGatewayUri = ConvertHelpers.GetAppSetting(STORE_AFE_GATEWAY_URI_KEY, new Uri("http://www.afe.ir/Url/SendSMS.aspx"));
            AfeUserName = ConvertHelpers.GetAppSetting(STORE_AFE_USER_NAME_KEY, "");
            AfePassword = ConvertHelpers.GetAppSetting(STORE_AFE_PASSWORD_KEY, "");
            AfeNumber = ConvertHelpers.GetAppSetting(STORE_AFE_NUMBER_KEY, "");
            MaximumInvalidCredentialsAttempts = ConvertHelpers.GetAppSetting(STORE_MAXIMUM_INVALID_CREDENTIALS_ATTEMPTS_KEY, 3, 0);
            CustomerLockDuration = ConvertHelpers.GetAppSetting(STORE_CUSTOMER_LOCK_DURATION_KEY, TimeSpan.FromMinutes(30));
            CustomerResetPasswordTokenValidityDuration = ConvertHelpers.GetAppSetting(STORE_CUSTOMER_RESET_PASSWORD_TOKEN_VALIDITY_DURATION_KEY, TimeSpan.FromDays(2));
        }

        public int DefaultPageSize { get; private set; }
        public float ViewsCountFactor { get; private set; }
        public float AddedToCartCountFactor { get; private set; }
        public string SenderEmailAddress { get; private set; }
        public string ReceiverEmailAddress { get; private set; }
        public Uri AfeGatewayUri { get; private set; }
        public string AfeUserName { get; private set; }
        public string AfePassword { get; private set; }
        public string AfeNumber { get; private set; }
        public int MaximumInvalidCredentialsAttempts { get; private set; }
        public TimeSpan CustomerLockDuration { get; private set; }
        public TimeSpan CustomerResetPasswordTokenValidityDuration { get; private set; }
    }
}
