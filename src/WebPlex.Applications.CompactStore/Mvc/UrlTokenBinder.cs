namespace WebPlex.Applications.CompactStore.Mvc {
    using System;
    using System.Web.Mvc;

    public sealed class UrlTokenBinder : DefaultModelBinder {
        private static readonly Type _urlTokenType = typeof (UrlToken<>);

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            if (HasGenericTypeBase(bindingContext.ModelType, _urlTokenType)) {
                var urlTokenUnderlyingType = bindingContext.ModelType.GenericTypeArguments[0];

                var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (valueProviderResult != null) {
                    var genericType = _urlTokenType.MakeGenericType(urlTokenUnderlyingType);
                    var model = Activator.CreateInstance(genericType);
                    ((dynamic) model).SetValue(valueProviderResult.AttemptedValue);

                    return model;
                }
            }

            return base.BindModel(controllerContext, bindingContext);
        }

        private static bool HasGenericTypeBase(Type type, Type genericType) {
            while (type != null && type != typeof (object)) {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                    return true;

                type = type.BaseType;
            }

            return false;
        }
    }
}
