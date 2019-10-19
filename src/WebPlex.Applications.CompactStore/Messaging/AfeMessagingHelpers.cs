namespace WebPlex.Applications.CompactStore.Messaging {
    using System;
    using System.Linq;
    using System.Net;
    using WebPlex.Applications.CompactStore.Configuration;
    using WebPlex.Applications.CompactStore.Logging;

    public static class AfeMessagingHelpers {
        private const string AFE_FULLYQUALIFIED_GATEWAY_URL = "{0}?Username={1}&Password={2}&Number={3}&Mobile={4}&SMS={5}";

        public static void SendMessage(string cellPhone, string text, params object[] args) {
            var url = GetAfeGatewayUrl(AppConfiguration.Current, cellPhone, text, args);

            try {
                using (var client = new WebClient())
                    client.DownloadString(url);
            } catch (Exception exception) {
                LogHelpers.Write(string.Format("Failed to send message: {0}", exception.Message));
                LogHelpers.Write(exception);
            }
        }

        private static string GetAfeGatewayUrl(AppConfiguration configuration, string cellPhone, string text, params object[] args) {
            if (args != null && args.Any())
                text = string.Format(text, args);

            return string.Format(AFE_FULLYQUALIFIED_GATEWAY_URL,
                                 configuration.AfeGatewayUri,
                                 configuration.AfeUserName,
                                 configuration.AfePassword,
                                 configuration.AfeNumber,
                                 cellPhone,
                                 text);
        }
    }
}
