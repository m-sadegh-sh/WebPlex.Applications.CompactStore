namespace WebPlex.Applications.CompactStore.Models {
    using System;
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class ProductModel : DbModelBase {
        [Display(Name = "Members_Product_Category", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual CategoryModel Category { get; set; }

        [Display(Name = "Members_Product_Title", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [StringLength(512, ErrorMessageResourceName = "Validation_InvalidLength", ErrorMessageResourceType = typeof (Resources))]
        public virtual string Title { get; set; }

        [Display(Name = "Members_Product_Slug", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [StringLength(256, ErrorMessageResourceName = "Validation_InvalidLength", ErrorMessageResourceType = typeof (Resources))]
        public virtual string Slug { get; set; }

        [Display(Name = "Members_Product_Summary", ResourceType = typeof (Resources))]
        public virtual string Summary { get; set; }

        [Display(Name = "Members_Product_Description", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual string Description { get; set; }

        [Display(Name = "Members_Product_MetaKeywords", ResourceType = typeof (Resources))]
        public virtual string MetaKeywords { get; set; }

        [Display(Name = "Members_Product_MetaDescription", ResourceType = typeof (Resources))]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "Members_Product_Features", ResourceType = typeof (Resources))]
        public virtual string Features { get; set; }

        [Display(Name = "Members_Product_UnitPrice", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [DataType(DataType.Currency)]
        public virtual double UnitPrice { get; set; }

        [Display(Name = "Members_Product_ReleaseDateUtc", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual DateTime ReleaseDateUtc { get; set; }

        [Display(Name = "Members_Product_LastModifiedDateUtc", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual DateTime LastModifiedDateUtc { get; set; }

        [Display(Name = "Members_Product_ViewsCount", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual int ViewsCount { get; set; }

        [Display(Name = "Members_Product_AddedToCartCount", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual int AddedToCartCount { get; set; }
    }
}
