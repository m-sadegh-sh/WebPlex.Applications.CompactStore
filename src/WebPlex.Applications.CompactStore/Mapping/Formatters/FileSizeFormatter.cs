namespace WebPlex.Applications.CompactStore.Mapping.Formatters {
    using WebPlex.Applications.CompactStore.Properties;

    public sealed class FileSizeFormatter {
        private const long KILOBYTE = 1024;
        private const long MEGABYTE = 1024*KILOBYTE;
        private const long GIGABYTE = 1024*MEGABYTE;
        private const long TERABYTE = 1024*GIGABYTE;

        public static string FormatValue(long value) {
            if (value > TERABYTE)
                return (value/TERABYTE).ToString(Resources.PrettySize_Terabyte);

            if (value > GIGABYTE)
                return (value/GIGABYTE).ToString(Resources.PrettySize_Gigabyte);

            if (value > MEGABYTE)
                return (value/MEGABYTE).ToString(Resources.PrettySize_Megabyte);

            if (value > KILOBYTE)
                return (value/KILOBYTE).ToString(Resources.PrettySize_Kilobyte);

            return value.ToString(Resources.PrettySize_Bytes);
        }
    }
}
