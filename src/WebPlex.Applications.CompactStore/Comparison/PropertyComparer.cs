namespace WebPlex.Applications.CompactStore.Comparison {
    using System.Collections.Generic;
    using System.Reflection;

    public sealed class PropertyComparer<T> : IComparer<string> {
        private readonly IDictionary<string, int> _weights;

        public PropertyComparer() {
            _weights = new Dictionary<string, int>();

            var properties = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var weight = 1;

            foreach (var property in properties)
                _weights.Add(property.Name, weight++);
        }

        public int Compare(string @this, string other) {
            return GetPropertyWeight(@this) - GetPropertyWeight(other);
        }

        private int GetPropertyWeight(string propertyName) {
            if (_weights.ContainsKey(propertyName))
                return _weights[propertyName];

            return -1;
        }
    }
}
