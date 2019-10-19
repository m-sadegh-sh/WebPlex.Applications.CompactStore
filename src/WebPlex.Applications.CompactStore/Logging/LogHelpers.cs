namespace WebPlex.Applications.CompactStore.Logging {
    using System;
    using System.IO;
    using System.Web.Hosting;

    public static class LogHelpers {
        private const string LOG_FILE_NAME = "Store.Logs.{0}.log";

        public static void Write(string message) {
            DoWrite(message);
        }

        public static void Write(Exception exception) {
            do {
                DoWrite(string.Format("{0}\t{1}\t{2}", exception.Message, exception.StackTrace, exception.Source));
            } while ((exception = exception.InnerException) != null);
        }

        private static void DoWrite(string message) {
            File.AppendAllText(GetLogFilePath(), string.Format("{0}\t{1}", DateTime.UtcNow, message));
        }

        private static string GetLogFilePath() {
            var fileName = string.Format(LOG_FILE_NAME, DateTime.UtcNow.ToString("yyyy-MM-dd-HH"));
            var virtualPath = string.Format("~/Logs/{0}", fileName);
            var fullPath = HostingEnvironment.MapPath(virtualPath);

            var directoryPath = Path.GetDirectoryName(fullPath);

            if (string.IsNullOrEmpty(directoryPath))
                throw new InvalidOperationException(string.Format(@"Couldn't convert virtual path ""{0}"" to full path.", virtualPath));

            var logFileDirectory = new DirectoryInfo(directoryPath);

            if (!logFileDirectory.Exists)
                logFileDirectory.Create();

            return fullPath;
        }
    }
}
