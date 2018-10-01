using NukeContracts.Business.Enumerations;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NukeContracts.Business.Extensions
{
    public static class EnumExtension
    {
        public static string DisplayName(this Region value)
        {
            var member = typeof(Region).GetMember($"{value}").FirstOrDefault();
            var attribute = member?.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
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
