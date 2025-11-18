// <copyright file="FileService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NameSorter.Core.Services;

/// <summary>
/// Handles raw file read/write operations.
/// Keeping IO separate avoids coupling business logic to filesystem code.
/// </summary>
public class FileService : IFileService
{
    /// <inheritdoc/>
    public IEnumerable<string> ReadLines(string path)
        => File.ReadAllLines(path);

    /// <inheritdoc/>
    public void WriteLines(string path, IEnumerable<string> lines)
        => File.WriteAllLines(path, lines);
}
