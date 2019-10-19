namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum CheckOutType : byte {
        [Display(Name = "Members_CheckOutType_PayOnDemand", ResourceType = typeof (Resources), Order = 1)]
        PayOnDemand = 0,

        [Display(Name = "Members_CheckOutType_OnlinePayment", ResourceType = typeof (Resources), Order = 2)]
        OnlinePayment = 1
    }
}
