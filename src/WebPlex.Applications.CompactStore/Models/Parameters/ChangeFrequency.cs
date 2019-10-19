namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum ChangeFrequency {
        [Display(ResourceType = typeof (Resources), Name = "Members_ChangeFrequency_Never", Order = 1)]
        Never = 0,

        [Display(ResourceType = typeof (Resources), Name = "Members_ChangeFrequency_Hourly", Order = 2)]
        Hourly = 1,

        [Display(ResourceType = typeof (Resources), Name = "Members_ChangeFrequency_Daily", Order = 3)]
        Daily = 2,

        [Display(ResourceType = typeof (Resources), Name = "Members_ChangeFrequency_Weekly", Order = 4)]
        Weekly = 3,

        [Display(ResourceType = typeof (Resources), Name = "Members_ChangeFrequency_Monthly", Order = 5)]
        Monthly = 4,

        [Display(ResourceType = typeof (Resources), Name = "Members_ChangeFrequency_Yearly", Order = 6)]
        Yearly = 5,

        [Display(ResourceType = typeof (Resources), Name = "Members_ChangeFrequency_Always", Order = 7)]
        Always = 6
    }
}
