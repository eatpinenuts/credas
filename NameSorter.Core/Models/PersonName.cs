// <copyright file="PersonName.cs">
// © 2025 Billy Flatman. All rights reserved.
// </copyright>

namespace NameSorter.Core.Models;

/// <summary>
/// Represents a person's name broken into given names and a surname.
/// This allows structured sorting rather than raw string comparison.
/// </summary>
public class PersonName(IEnumerable<string> givenNames, string lastName)
{
    /// <summary>
    /// Gets one to three given names, stored in order.
    /// </summary>
    public IReadOnlyList<string> GivenNames { get; } = givenNames.ToList();

    /// <summary>
    /// Gets the family/last name, used as the primary sort key.
    /// </summary>
    public string LastName { get; } = lastName;

    /// <summary>
    /// Converts the structured name back into a standard display format.
    /// </summary>
    /// <returns>
    /// String.
    /// </returns>
    public override string ToString()
        => string.Join(" ", this.GivenNames.Append(this.LastName));
}
