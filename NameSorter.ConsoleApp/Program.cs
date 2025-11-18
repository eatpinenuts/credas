// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using NameSorter.Core.Services;

/// <summary>
/// The main entry point class for the application.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        // Require an input file path
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: name-sorter <file-path>");
            return;
        }

        var inputPath = args[0];
        const string outputPath = "sorted-names-list.txt";

        // Dependency Injection container setup.
        // Using DI in a console app keeps architecture consistent and testable.
        var services = new ServiceCollection();

        services.AddSingleton<INameParser, PersonNameParser>();
        services.AddSingleton<INameSorter, PersonNameSorter>();
        services.AddSingleton<IFileService, FileService>();

        var provider = services.BuildServiceProvider();

        var parser = provider.GetRequiredService<INameParser>();
        var sorter = provider.GetRequiredService<INameSorter>();
        var fileService = provider.GetRequiredService<IFileService>();

        // Read and parse names from file
        var lines = fileService.ReadLines(inputPath);
        var people = lines.Select(parser.Parse).ToList();

        // Sort using the dedicated sorter service
        var sorted = sorter.Sort(people).ToList();

        // Output to screen
        foreach (var p in sorted)
        {
            Console.WriteLine(p);
        }

        // Write sorted results to the required output file
        fileService.WriteLines(outputPath, sorted.Select(n => n.ToString()));
    }
}
