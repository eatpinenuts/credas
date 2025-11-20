// © 2025 Billy Flatman. All rights reserved.

using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using NameSorter.Core.Extensions;
using NameSorter.Core.Models;
using NameSorter.Core.Services;

/// <summary>
/// The main entry point class for the application.
/// </summary>
internal class Program
{
    private static async Task Main(string[] args)
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

        try
        {
            // Read + parse (streaming)
            var people = new List<PersonName>();

            await foreach (var line in fileService.ReadLinesAsync(inputPath).ConfigureAwait(false))
            {
                var parsed = parser.Parse(line);
                people.Add(parsed);
            }

            // Sort (sync is correct here)
            var sorted = sorter.Sort(people).ToList();

            // Output to screen
            foreach (var p in sorted)
            {
                Console.WriteLine(p);
            }

            // Write sorted results to the required output file (streaming)
            await fileService.WriteLinesAsync(
                outputPath,
                sorted.Select(n => n.ToString()).ToAsyncEnumerable()).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error processing file: {ex.Message}");
            Environment.ExitCode = 1;
        }
    }
}
