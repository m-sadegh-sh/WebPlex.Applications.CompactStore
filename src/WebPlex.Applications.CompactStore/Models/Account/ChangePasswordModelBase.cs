namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class ChangePasswordModelBase : ModelBase {
        [Display(Name = "Members_ChangePasswordBase_NewPassword", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Members_ChangePasswordBase_NewPasswordConfirmation", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [Compare("NewPassword", ErrorMessageResourceName = "Validation_UnMatched", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Password)]
        public string NewPasswordConfirmation { get; set; }
    }
}