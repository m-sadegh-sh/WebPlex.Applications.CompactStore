namespace WebPlex.Applications.CompactStore.Logging {
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    public static class ExceptionSerializationHelpers {
        public static string ToFriendlyString(DbEntityValidationException exception) {
            var builder = new StringBuilder();

            builder.AppendLine(exception.Message);
            builder.AppendLine();

            foreach (var validationResult in exception.EntityValidationErrors) {
                var validationErrors = validationResult.ValidationErrors;
                if (validationErrors.Any()) {
                    var propertyName = validationErrors.First().PropertyName;
                    var errorMessages = string.Join(", ", validationErrors.Select(ve => ve.ErrorMessage));

                    builder.AppendFormat("{0}: {1}", propertyName, errorMessages);
                    builder.AppendLine();
                }
            }

            return builder.ToString();
        }
    }
}
