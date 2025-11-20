// © 2025 Billy Flatman. All rights reserved.

namespace NameSorter.Core.Services;

/// <summary>
/// Abstracts file IO for easier mocking in tests and cleaner architecture.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Asynchronously reads a file line-by-line using streaming I/O.
    /// </summary>
    /// <param name="path">The full path of the file to read.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{T}"/> that yields each line of the file
    /// without loading the entire file into memory.
    /// </returns>
    IAsyncEnumerable<string> ReadLinesAsync(string path);

    /// <summary>
    /// Asynchronously writes a sequence of lines to a file using streaming I/O.
    /// </summary>
    /// <param name="path">The full path of the output file to write.</param>
    /// <param name="lines">
    /// The asynchronous sequence of lines to write to the file.
    /// </param>
    /// <returns>A task that completes when all lines have been written.</returns>
    Task WriteLinesAsync(string path, IAsyncEnumerable<string> lines);
}
