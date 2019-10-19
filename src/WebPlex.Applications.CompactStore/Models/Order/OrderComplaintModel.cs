namespace WebPlex.Applications.CompactStore.Models {
    using System;
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class OrderComplaintModel : DbModelBase {
        [Display(Name = "Members_OrderComplaint_Order", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual OrderModel Order { get; set; }

        [Display(Name = "Members_OrderComplaint_SubmitDateUtc", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual DateTime SubmitDateUtc { get; set; }

        [Display(Name = "Members_OrderComplaint_Message", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual string Message { get; set; }

        [Display(Name = "Members_OrderComplaint_Priority", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual ComplaintPriority Priority { get; set; }

        [Display(Name = "Members_OrderComplaint_Status", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual ComplaintStatus Status { get; set; }

        [Display(Name = "Members_OrderComplaint_CheckDateUtc", ResourceType = typeof (Resources))]
        public virtual DateTime? CheckDateUtc { get; set; }

        [Display(Name = "Members_OrderComplaint_Reply", ResourceType = typeof (Resources))]
        public virtual string Reply { get; set; }
    }
}
