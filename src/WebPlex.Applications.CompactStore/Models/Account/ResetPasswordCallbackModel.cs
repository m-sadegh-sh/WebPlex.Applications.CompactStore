namespace WebPlex.Applications.CompactStore.Models {
    public class ResetPasswordCallbackModel : ChangePasswordModelBase {
        public virtual string ResetPasswordToken { get; set; }
    }
}