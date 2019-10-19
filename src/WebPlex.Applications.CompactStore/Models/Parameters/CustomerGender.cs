namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public enum CustomerGender : byte {
        [Display(Name = "Members_CustomerGender_Male", ResourceType = typeof (Resources), Order = 1)]
        Male = 0,

        [Display(Name = "Members_CustomerGender_Female", ResourceType = typeof (Resources), Order = 2)]
        Female = 1
    }
}
