namespace WebPlex.Applications.CompactStore.Models {
    using System.ComponentModel.DataAnnotations;
    using WebPlex.Applications.CompactStore.Properties;

    public class CartItemModel : DbModelBase {
        [Display(Name = "Members_CartItem_Title", ResourceType = typeof (Resources))]
        public string Title { get; set; }

        [Display(Name = "Members_CartItem_Count", ResourceType = typeof (Resources))]
        public int Count { get; set; }

        [Display(Name = "Members_CartItem_UnitPrice", ResourceType = typeof (Resources))]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        [Display(Name = "Members_CartItem_TotalPrice", ResourceType = typeof (Resources))]
        [DataType(DataType.Currency)]
        public double TotalPrice {
            get { return Count*UnitPrice; }
        }
    }
}
