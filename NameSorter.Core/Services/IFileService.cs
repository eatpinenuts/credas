// © 2025 Billy Flatman. All rights reserved.

namespace NameSorter.Core.Services;

/// <summary>
/// Abstracts file IO for easier mocking in tests and cleaner architecture.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Reads all lines from the specified file path.
    /// </summary>
    /// <param name="path">The file path to read from.</param>
    /// <returns>
    /// A sequence of lines read from the file.
    /// </returns>
    IEnumerable<string> ReadLines(string path);

    /// <summary>
    /// Writes the specified lines to the given file path, overwriting any existing file.
    /// </summary>
    /// <param name="path">The file path to write to.</param>
    /// <param name="lines">The collection of lines to write to the file.</param>
    void WriteLines(string path, IEnumerable<string> lines);
}
