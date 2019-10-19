namespace WebPlex.Applications.CompactStore.Extensions {
    using WebPlex.Applications.CompactStore.Models;

    public static class EnumExtensions {
        public static bool IsCheckOutRequired(this OrderStatus status) {
            return status == OrderStatus.Submitted || status == OrderStatus.PayOnDemand;
        }

        public static bool IsCancellable(this OrderStatus status) {
            return status == OrderStatus.Submitted || status == OrderStatus.PayOnDemand;
        }
    }
}
