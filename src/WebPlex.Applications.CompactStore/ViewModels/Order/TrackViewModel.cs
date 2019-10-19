namespace WebPlex.Applications.CompactStore.ViewModels {
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Properties;

    public sealed class TrackViewModel {
        [Display(Name = "Members_TrackViewModel_AccessToken", ResourceType = typeof (Resources))]
        [Required(ErrorMessageResourceName = "Validation_Required", ErrorMessageResourceType = typeof (Resources))]
        [Remote("Order-ValidateAccessToken", HttpMethod = "Post", ErrorMessage = "", ErrorMessageResourceName = "Validation_NotFound", ErrorMessageResourceType = typeof (Resources))]
        public string AccessToken { get; set; }

        public OrderModel Order { get; set; }

        public OrderComplaintModel SubmittedComplaint { get; set; }

        public bool OrderPresented {
            get { return Order != null && SubmittedComplaint != null; }
        }

        public bool ComplaintIsNew {
            get { return OrderPresented && SubmittedComplaint.Id == default(int); }
        }

        public bool ComplaintIsUpdated {
            get { return OrderPresented && SubmittedComplaint.Id != default(int); }
        }

        public bool CanSubmitComplaint {
            get { return OrderPresented && SubmittedComplaint.Status == ComplaintStatus.Pending; }
        }
    }
}
