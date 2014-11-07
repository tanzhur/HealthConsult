namespace HealthConsult.Common
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public static class ExtensionMethods
    {
        public static string ToDescription<T>(this T value) where T : struct 
        {
            var fieldName = Enum.GetName(typeof(T), value);
            if(fieldName == null) {
                return string.Empty;
            }
            var fieldInfo = typeof(T).GetField(fieldName, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);
            if(fieldInfo == null) {
                return string.Empty;
            }
            var descriptionAttribute = (DescriptionAttribute) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            if(descriptionAttribute == null) {
                return fieldInfo.Name;
            }
            return descriptionAttribute.Description;
        }
    }
}
