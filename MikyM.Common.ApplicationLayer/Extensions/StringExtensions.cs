﻿namespace MikyM.Common.ApplicationLayer.Extensions;

/// <summary>
/// String extensions
/// </summary>
[PublicAPI]
public static class StringExtensions
{
    /// <summary>
    /// Contains extension.
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="toCheck">Sequence to look for</param>
    /// <param name="comparison"><see cref="StringComparison"/> settings</param>
    /// <returns></returns>
    public static bool Contains(this string? source, string toCheck, StringComparison comparison)
        => source?.IndexOf(toCheck, comparison) >= 0;
}
