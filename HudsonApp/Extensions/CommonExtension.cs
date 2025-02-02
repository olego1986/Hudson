using System.ComponentModel;

namespace HudsonApp.Extensions;

public static class CommonExtension
{
    public static string GetEnumDescription(this Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());

        if (fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}