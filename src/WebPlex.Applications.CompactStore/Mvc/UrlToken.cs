namespace WebPlex.Applications.CompactStore.Mvc {
    using Dnum;
    using WebPlex.Applications.CompactStore.Helpers;

    public sealed class UrlToken<T> where T : struct {
        private T _value;

        public UrlToken() {}

        public UrlToken(object rawValue) {
            SetValue((string) rawValue);
        }

        public void SetValue(string slug) {
            var rawValue = StringHelpers.Unslugify(slug);
            var value = Dnum<T>.Parse(rawValue, true);

            _value = value;
        }

        public static implicit operator UrlToken<T>(T value) {
            return new UrlToken<T> {
                _value = value
            };
        }

        public static implicit operator T(UrlToken<T> token) {
            return token == null ? default(T) : token._value;
        }

        public override string ToString() {
            return StringHelpers.Slugify(_value.ToString());
        }
    }
}
