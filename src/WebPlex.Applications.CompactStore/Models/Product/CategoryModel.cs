namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class CategoryModel : DbModelBase {
        [Display(Name = "Members_Category_DisplayOrder", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual int DisplayOrder { get; set; }

        [Display(Name = "Members_Category_Title", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [StringLength(512, ErrorMessageResourceName = "Validation_InvalidLength", ErrorMessageResourceType = typeof (Resources))]
        public virtual string Title { get; set; }

        [Display(Name = "Members_Category_Slug", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [StringLength(256, ErrorMessageResourceName = "Validation_InvalidLength", ErrorMessageResourceType = typeof (Resources))]
        public virtual string Slug { get; set; }

        [Display(Name = "Members_Category_MetaKeywords", ResourceType = typeof (Resources))]
        public virtual string MetaKeywords { get; set; }

        [Display(Name = "Members_Category_MetaDescription", ResourceType = typeof (Resources))]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "Members_Category_CssClass", ResourceType = typeof (Resources))]
        [StringLength(64, ErrorMessageResourceName = "Validation_InvalidLength", ErrorMessageResourceType = typeof (Resources))]
        public virtual string CssClass { get; set; }

        [Display(Name = "Members_Category_Parent", ResourceType = typeof (Resources))]
        public virtual CategoryModel Parent { get; set; }
    }
}
