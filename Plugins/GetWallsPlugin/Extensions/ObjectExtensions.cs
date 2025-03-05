namespace GetWallsPlugin.Extensions;

public static class ObjectExtensions
{
    public static bool IsNull(this object? obj) => obj is null;
}