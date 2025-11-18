// <copyright file="PersonNameParser.cs">
// © 2025 Billy Flatman. All rights reserved.
// </copyright>

namespace NameSorter.Core.Services;

using NameSorter.Core.Models;

/// <summary>
/// Converts a single line of text into a PersonName object.
/// Handles validation of name format and structure.
/// </summary>
public class PersonNameParser : INameParser
{
    /// <inheritdoc/>
    public PersonName Parse(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            throw new ArgumentException("Name line cannot be empty.");
        }

        // Split on spaces, removing duplicate empty entries.
        var parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Enforce valid name structure: 1–3 given names + 1 surname.
        if (parts.Length < 2 || parts.Length > 4)
        {
            throw new ArgumentException("A name must have 1–3 given names and a surname.");
        }

        // Last part is always the surname.
        var lastName = parts.Last();

        // Remaining parts are given names.
        var givenNames = parts.Take(parts.Length - 1);

        return new PersonName(givenNames, lastName);
    }
}
