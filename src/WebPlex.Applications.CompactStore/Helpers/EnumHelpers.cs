namespace WebPlex.Applications.CompactStore.Helpers {
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Properties;

    public static class EnumHelpers {
        public static IDictionary<string, TEnum> GetNamesValues<TEnum>() where TEnum : struct {
            return (from fields in typeof (TEnum).GetFields(BindingFlags.Static | BindingFlags.Public)
                    let displayAttribute = (DisplayAttribute) fields.GetCustomAttributes(typeof (DisplayAttribute), false).Single()
                    orderby displayAttribute.Order
                    select new {
                        Name = displayAttribute.GetName(),
                        Value = (TEnum) fields.GetValue(null)
                    }).ToDictionary(nv => nv.Name, nv => nv.Value);
        }

        public static string ToLocalizedName<TEnum>(this TEnum value) where TEnum : struct {
            return (from fields in typeof (TEnum).GetFields(BindingFlags.Static | BindingFlags.Public)
                    where fields.Name == value.ToString()
                    let displayAttribute = (DisplayAttribute) fields.GetCustomAttributes(typeof (DisplayAttribute), false).Single()
                    select displayAttribute.GetName()).Single();
        }

        public static MultiSelectList ToSelectList(this bool value) {
            var nameValues = new Dictionary<string, bool> {
                {Resources.Common_No, false},
                {Resources.Common_Yes, true}
            };

            return ToSelectList(value, nameValues);
        }

        public static MultiSelectList ToSelectList<TEnum>(this TEnum value) where TEnum : struct {
            var nameValues = GetNamesValues<TEnum>();

            return ToSelectList(value, nameValues);
        }

        private static MultiSelectList ToSelectList<TValue>(TValue value, IDictionary<string, TValue> nameValues) {
            var items = nameValues.Select(nv => new SelectListItem {
                Text = nv.Key,
                Value = nv.Value.ToString(),
                Selected = Equals(nv.Value, value)
            });

            return new MultiSelectList(items);
        }
    }
}
