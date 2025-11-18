// <copyright file="PersonNameSorter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NameSorter.Core.Services;

using NameSorter.Core.Models;

/// <summary>
/// Sorts names by surname first, then by full given-name sequence.
/// </summary>
public class PersonNameSorter : INameSorter
{
    /// <inheritdoc/>
    public IEnumerable<PersonName> Sort(IEnumerable<PersonName> names)
    {
        // Primary sort: Last name
        // Secondary sort: concatenated given names
        return names
            .OrderBy(n => n.LastName)
            .ThenBy(n => string.Join(" ", n.GivenNames))
            .ToList();
    }
}
