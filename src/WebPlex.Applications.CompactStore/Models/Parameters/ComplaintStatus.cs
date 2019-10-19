namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum ComplaintStatus : byte {
        [Display(Name = @"Members_ComplaintStatus_Pending", ResourceType = typeof (Resources), Order = 1)]
        Pending = 0,

        [Display(Name = @"Members_ComplaintStatus_Replied", ResourceType = typeof (Resources), Order = 2)]
        Replied = 1,

        [Display(Name = @"Members_ComplaintStatus_Rejected", ResourceType = typeof (Resources), Order = 3)]
        Rejected = 2
    }
}
