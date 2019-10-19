namespace WebPlex.Applications.CompactStore.Models {
    using System;
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class OrderModel : DbModelBase {
        [Display(Name = "Members_Order_AccessToken", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual string AccessToken { get; set; }

        [Display(Name = "Members_Order_Customer", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual CustomerModel Customer { get; set; }

        [Display(Name = "Members_Order_SubmitDateUtc", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual DateTime SubmitDateUtc { get; set; }

        [Display(Name = "Members_Order_TotalPrice", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Currency)]
        public virtual double TotalPrice { get; set; }

        [Display(Name = "Members_Order_Status", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual OrderStatus Status { get; set; }

        [Display(Name = "Members_Order_IpAddress", ResourceType = typeof (Resources))]
        [DataType("IpAddress")]
        public virtual string IpAddress { get; set; }
    }
}
