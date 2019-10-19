namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class LoginModel : ModelBase {
        [Display(Name = "Members_Login_CellPhoneOrEmail", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public string CellPhoneOrEmail { get; set; }

        [Display(Name = "Members_Login_Password", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
