namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class OrderLineModel : DbModelBase {
        [Display(Name = "Members_OrderLine_Order", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual OrderModel Order { get; set; }

        [Display(Name = "Members_OrderLine_Product", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual ProductModel Product { get; set; }

        [Display(Name = "Members_OrderLine_Count", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [DataType("Number")]
        public virtual int Count { get; set; }
    }
}
