// © 2025 Billy Flatman. All rights reserved.

namespace NameSorter.Core.Services;

/// <summary>
/// Handles raw file read/write operations.
/// Keeping IO separate avoids coupling business logic to filesystem code.
/// </summary>
public class FileService : IFileService
{
    /// <summary>
    /// Asynchronously reads a file line-by-line using streaming I/O.
    /// </summary>
    /// <param name="path">The full path of the file to read.</param>
    /// <returns>
    /// An <see cref="IAsyncEnumerable{T}"/> that yields each line of the file
    /// without loading the entire file into memory.
    /// </returns>
    public async IAsyncEnumerable<string> ReadLinesAsync(string path)
    {
        using var reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync().ConfigureAwait(false);
            if (line != null)
            {
                yield return line;
            }
        }
    }

    /// <summary>
    /// Asynchronously writes a sequence of lines to a file using streamed writes.
    /// Lines are written as they are received, preventing large memory usage.
    /// </summary>
    /// <param name="path">The full path of the output file to write.</param>
    /// <param name="lines">
    /// The asynchronous sequence of lines to write to the file.
    /// </param>
    /// <returns>A task that completes once all lines have been written.</returns>
    public async Task WriteLinesAsync(string path, IAsyncEnumerable<string> lines)
    {
        await using var writer = new StreamWriter(path);

        await foreach (var line in lines.ConfigureAwait(false))
        {
            await writer.WriteLineAsync(line).ConfigureAwait(false);
        }
    }
}
