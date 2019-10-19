namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum SortDirection {
        [Display(ResourceType = typeof (Resources), Name = "Members_SortDirection_Ascending", Order = 1)]
        Ascending = 0,

        [Display(ResourceType = typeof (Resources), Name = "Members_SortDirection_Descending", Order = 2)]
        Descending = 1
    }
}
