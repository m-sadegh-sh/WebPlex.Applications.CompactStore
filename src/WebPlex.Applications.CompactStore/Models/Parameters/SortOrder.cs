namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum SortOrder {
        [Display(ResourceType = typeof (Resources), Name = "Members_SortOrder_Default", Order = 1)]
        Default = 0,

        [Display(ResourceType = typeof (Resources), Name = "Members_SortOrder_ReleaseDateUtc", Order = 2)]
        ReleaseDateUtc = 1,

        [Display(ResourceType = typeof (Resources), Name = "Members_SortOrder_UnitPrice", Order = 3)]
        UnitPrice = 2
    }
}
