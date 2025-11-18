// © 2025 Billy Flatman. All rights reserved.

namespace NameSorter.Core.Services;

using NameSorter.Core.Models;

/// <summary>
/// Defines the logic for sorting a collection of PersonName instances.
/// </summary>
public interface INameSorter
{
    /// <summary>
    /// Sorts a collection of names.
    /// </summary>
    /// <param name="names">The names to sort.</param>
    /// <returns>An <see cref="IEnumerable{PersonName}"/> ordered by last name then given names.</returns>
    IEnumerable<PersonName> Sort(IEnumerable<PersonName> names);
}
