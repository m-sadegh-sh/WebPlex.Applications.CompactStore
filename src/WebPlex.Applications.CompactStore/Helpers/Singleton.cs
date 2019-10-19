namespace WebPlex.Applications.CompactStore.Helpers {
    public abstract class Singleton<T> where T : class, new() {
        private static T _instance;

        public static T Current {
            get {
                if (_instance == null)
                    _instance = CreateInstance();

                return _instance;
            }
        }

        private static T CreateInstance() {
            return new T();
        }
    }
}
