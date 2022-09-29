namespace CMCS.Shared.Extensions.EnumExtensions;

public static class EnumExtensions
{
    public static T ToEnum<T>(this string str) where T : Enum
    {
        return (T)Enum.Parse(typeof(T), str);
    }
}