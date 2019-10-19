namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum OrderStatus : byte {
        [Display(Name = "Members_OrderStatus_Submitted", ResourceType = typeof (Resources), Order = 1)]
        Submitted = 0,

        [Display(Name = "Members_OrderStatus_PayOnDemand", ResourceType = typeof (Resources), Order = 2)]
        PayOnDemand = 1,

        [Display(Name = "Members_OrderStatus_Cancelled", ResourceType = typeof (Resources), Order = 3)]
        Cancelled = 2,

        [Display(Name = "Members_OrderStatus_Paid", ResourceType = typeof (Resources), Order = 4)]
        Paid = 4,

        [Display(Name = "Members_OrderStatus_Completed", ResourceType = typeof (Resources), Order = 5)]
        Completed = 8,

        [Display(Name = "Members_OrderStatus_Rejected", ResourceType = typeof (Resources), Order = 6)]
        Rejected = 16
    }
}
