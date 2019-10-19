namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class ResetPasswordModel : ModelBase {
        [Display(Name = "Members_ResetPassword_CellPhoneOrEmail", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public string CellPhoneOrEmail { get; set; }
    }
}
