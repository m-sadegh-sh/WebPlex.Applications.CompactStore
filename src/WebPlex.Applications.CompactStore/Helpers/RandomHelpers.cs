namespace WebPlex.Applications.CompactStore.Helpers {
    using System;
    using System.Linq;
    using Dnum;

    public static class RandomHelpers {
        private static readonly Random _random = new Random();

        public static DateTime GetRandom(DateTime minValue, DateTime maxValue) {
            var subtractedValue = maxValue - minValue;
            var randomSeconds = GetRandom(0, (int) subtractedValue.TotalSeconds);

            return maxValue.AddSeconds(randomSeconds);
        }

        public static int GetRandom(int minValue, int maxValue) {
            return _random.Next(minValue, maxValue);
        }

        public static T GetRandom<T>(T[] values) {
            return values[_random.Next(0, values.Length)];
        }

        public static TEnum GetRandom<TEnum>() where TEnum : struct {
            var values = Dnum<TEnum>.GetValues().ToArray();

            return Dnum<TEnum>.ToConstant(values[_random.Next(0, values.Length)]);
        }
    }
}
