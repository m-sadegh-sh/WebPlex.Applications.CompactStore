namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum ComplaintPriority : byte {
        [Display(Name = "Members_ComplaintPriority_Low", ResourceType = typeof (Resources), Order = 1)]
        Low = 0,

        [Display(Name = "Members_ComplaintPriority_Normal", ResourceType = typeof (Resources), Order = 2)]
        Normal = 1,

        [Display(Name = "Members_ComplaintPriority_High", ResourceType = typeof (Resources), Order = 3)]
        High = 2
    }
}
