using System;
using System.Diagnostics.Contracts;

namespace RevitDev.Common.Extensions;

public static class ObjectExtensions
{
    [Pure]
    public static T CastTo<T>(this object? source) where T : class
    {
        source = source.ReturnOrThrowIfNull();

        if (source is not T casted)
        {
            throw new InvalidCastException($"Could not result in type {typeof(T).Name}");
        }

        return casted;
    }

    [Pure]
    public static object ReturnOrThrowIfNull(this object? argument, string? paramName = null)
    {
        if (argument == null)
        {
            throw new ArgumentNullException(paramName);
        }

        return argument;
    }

    [Pure]
    public static T ReturnOrThrowIfNull<T>(this T? argument, string? paramName = null) where T : class
    {
        if (argument == null)
        {
            throw new ArgumentNullException(paramName);
        }

        return argument;
    }

    [Pure]
    public static object ReturnOrThrowIfNull(this object? argument, string? paramName, string message)
    {
        if (argument is null)
        {
            throw new ArgumentNullException(paramName, message);
        }

        return argument;
    }

    [Pure]
    public static T ReturnOrThrowIfNull<T>(this T? argument, string? paramName, string message) where T : class
    {
        if (argument is null)
        {
            throw new ArgumentNullException(paramName, message);
        }

        return argument;
    }
}