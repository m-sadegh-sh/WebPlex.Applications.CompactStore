namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public abstract class DbModelBase : ModelBase {
        [Display(Name = "Members_DbBase_Id", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        public virtual int Id { get; set; }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (!(obj is DbModelBase))
                return false;

            return Id == ((DbModelBase) obj).Id;
        }
    }
}
