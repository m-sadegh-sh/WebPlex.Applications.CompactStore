namespace WebPlex.Applications.CompactStore.Configuration {
    using System;
    using System.Configuration;

    public static class ConvertHelpers {
        public static string GetAppSetting(string key, string defaultValue = null) {
            var rawValue = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrEmpty(rawValue))
                return rawValue;

            return defaultValue;
        }

        public static int GetAppSetting(string key, int defaultValue, int minValue = int.MinValue, int maxValue = int.MaxValue) {
            var rawValue = ConfigurationManager.AppSettings[key];

            int value;
            if (int.TryParse(rawValue, out value)) {
                value = Math.Max(value, minValue);
                value = Math.Min(value, maxValue);

                return value;
            }

            return defaultValue;
        }

        public static float GetAppSetting(string key, float defaultValue, float minValue = float.MinValue, float maxValue = float.MaxValue) {
            var rawValue = ConfigurationManager.AppSettings[key];

            float value;
            if (float.TryParse(rawValue, out value)) {
                value = Math.Max(value, minValue);
                value = Math.Min(value, maxValue);

                return value;
            }

            return defaultValue;
        }

        public static TimeSpan GetAppSetting(string key, TimeSpan defaultValue, TimeSpan minValue = default(TimeSpan), TimeSpan maxValue = default(TimeSpan)) {
            var rawValue = ConfigurationManager.AppSettings[key];

            TimeSpan value;
            if (TimeSpan.TryParse(rawValue, out value)) {
                if (minValue != default(TimeSpan) && value < minValue)
                    return minValue;

                if (maxValue != default(TimeSpan) && value > maxValue)
                    return maxValue;

                return value;
            }

            return defaultValue;
        }

        public static Uri GetAppSetting(string key, Uri defaultValue) {
            var rawValue = ConfigurationManager.AppSettings[key];

            Uri value;
            if (Uri.TryCreate(rawValue, UriKind.RelativeOrAbsolute, out value))
                return value;

            return defaultValue;
        }
    }
}
