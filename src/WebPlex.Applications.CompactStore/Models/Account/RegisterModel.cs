namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Properties;

    public class RegisterModel : ModelBase {
        [Display(Name = "Members_Register_CellPhone", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [Phone(ErrorMessageResourceName = "Validation_InvalidPhone", ErrorMessageResourceType = typeof (Resources), ErrorMessage = null)]
        [Remote("Account-ValidateCustomerCellPhone-Freeness", HttpMethod = "Post", ErrorMessage = "", ErrorMessageResourceName = "Validation_Duplicate", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.PhoneNumber)]
        public string CellPhone { get; set; }

        [Display(Name = "Members_Register_Password", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Members_Register_PasswordConfirmation", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceName = "Validation_UnMatched", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "Members_Register_FirstName", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public string FirstName { get; set; }

        [Display(Name = "Members_Register_LastName", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public string LastName { get; set; }

        [Display(Name = "Members_Register_Email", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [EmailAddress(ErrorMessageResourceName = "Validation_InvalidEmail", ErrorMessageResourceType = typeof (Resources), ErrorMessage = null)]
        [Remote("Account-ValidateCustomerEmail-Freeness", HttpMethod = "Post", ErrorMessage = "", ErrorMessageResourceName = "Validation_Duplicate", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Members_Customer_Gender", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual CustomerGender Gender { get; set; }
    }
}
