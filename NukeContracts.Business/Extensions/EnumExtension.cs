using NukeContracts.Business.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace NukeContracts.Business.Extensions
{
    public static class EnumExtension
    {
        public static string DisplayName(this Region value)
        {
            var attribute = (DisplayAttribute)Attribute.GetCustomAttribute(typeof(Region), typeof(DisplayAttribute));
            return attribute?.Name ?? value.ToString();
        }

        //too verbose to call imho
        //public static string DisplayName<T>(string value)
        //{
        //    Type type = typeof(T);
        //    var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();
        //    if (name == null) return string.Empty;
          
        //    var field = type.GetField(name);
        //    var customAttribute = field.GetCustomAttributes(typeof(DisplayAttribute), false);
        //    return customAttribute.Length > 0 ? ((DisplayAttribute)customAttribute[0]).Description : name;
        //}
    }
}
