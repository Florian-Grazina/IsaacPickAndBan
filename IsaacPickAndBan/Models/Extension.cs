using System.ComponentModel;
using System.Reflection;

namespace IsaacPickAndBan.Models
{
    public enum Extension
    {
        [Description("Base Game V2")]
        b2,
        [Description("Four Souls+ V2")]
        fsp2,
        [Description("Gold Box V2")]
        g2,
        [Description("Requiem")]
        r,
        [Description("Requiem Warp Zone")]
        rwz,
        [Description("Tapeworm")]
        tw
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
