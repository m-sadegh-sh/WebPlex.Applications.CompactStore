namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class ChangePasswordModel : ChangePasswordModelBase {
        [Display(Name = "Members_ChangePassword_CurrentPassword", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}
