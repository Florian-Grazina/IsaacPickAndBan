using System.ComponentModel;
using System.Reflection;

namespace IsaacPickAndBan.Models
{
    public enum Extension
    {
        [Description("Base")]
        b2,
        [Description("Four Souls+")]
        fsp2,
        [Description("Gold Box")]
        g2,
        [Description("Requiem")]
        r,
        [Description("Warp Zone")]
        rwz,
        [Description("Tapeworm")]
        tw,
        [Description("Anniversary")]
        anni,
        [Description("Summer")]
        soi,
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
                return attribute?.Description ?? value.ToString();
            }
            return value.ToString();
        }
    }
}
