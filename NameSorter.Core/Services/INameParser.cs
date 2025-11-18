// <copyright file="INameParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NameSorter.Core.Services;

using NameSorter.Core.Models;

/// <summary>
/// Parses raw text lines into structured PersonName instances.
/// Separated as an interface for testability and extendibility.
/// </summary>
public interface INameParser
{
    /// <summary>
    /// Parses a raw name string into a structured <see cref="PersonName"/>.
    /// </summary>
    /// <param name="line">The raw name text to parse.</param>
    /// <returns>
    /// A <see cref="PersonName"/> containing the extracted given names and surname.
    /// </returns>
    PersonName Parse(string line);
}
