namespace WebPlex.Applications.CompactStore.Mapping.Formatters {
    using System;
    using WebPlex.Applications.CompactStore.Properties;

    public sealed class DateTimeFormatter {
        public static string FormatValue(DateTime utcValue) {
            var utcNow = DateTime.UtcNow;
            var subtractedValue = utcNow.Subtract(utcValue);

            if (subtractedValue.TotalSeconds < 2)
                return Resources.PrettyTime_Now;

            if (subtractedValue.TotalSeconds < 60)
                return string.Format(Resources.PrettyTime_NSecAgo, subtractedValue.Seconds);

            if (subtractedValue.TotalMinutes < 2)
                return Resources.PrettyTime_AMinAgo;

            if (subtractedValue.TotalMinutes < 60)
                return string.Format(Resources.PrettyTime_NMinAgo, subtractedValue.Minutes);

            if (subtractedValue.TotalHours < 24)
                return string.Format(Resources.PrettyTime_NHourAgo, subtractedValue.Hours);

            if (Math.Abs(subtractedValue.TotalDays - 1) < double.Epsilon)
                return Resources.PrettyTime_Yesterday;

            if (subtractedValue.TotalDays < 7)
                return string.Format(Resources.PrettyTime_NDaysAgo, subtractedValue.Days);

            if (subtractedValue.TotalDays < 14)
                return Resources.PrettyTime_LastWeek;

            if (subtractedValue.TotalDays < 21)
                return Resources.PrettyTime_TwoWeekAgo;

            if (subtractedValue.TotalDays < 28)
                return Resources.PrettyTime_ThreeWeekAgo;

            if (subtractedValue.TotalDays < 60)
                return Resources.PrettyTime_LastMonth;

            if (subtractedValue.TotalDays < 365)
                return string.Format(Resources.PrettyTime_NMonthAgo, Math.Round(subtractedValue.TotalDays/30));

            if (subtractedValue.TotalDays < 730)
                return Resources.PrettyTime_LastYear;

            return string.Format(Resources.PrettyTime_NYearAgo, Math.Round(subtractedValue.TotalDays/365));
        }
    }
}
